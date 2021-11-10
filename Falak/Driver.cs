using System;
using System.IO;
using System.Text;

namespace Falak {

    public class Driver {

        const string VERSION = "0.2";

        //-----------------------------------------------------------
       static readonly string[] ReleaseIncludes = {
            "Lexical analysis",
            "Syntactic analysis",
            "AST construction"
        };

        //-----------------------------------------------------------
        void PrintAppHeader() {
            /*
            Console.WriteLine("Falak compiler, version " + VERSION);
            Console.WriteLine(
                "Copyright \u00A9 2013-2021 by A. Ortiz, ITESM CEM. ft Vivana Osorio, Oscar Zuniga and Fernando Sebastian");
            Console.WriteLine("This program is free software; you may "
                + "redistribute it under the terms of");
            Console.WriteLine("the GNU General Public License version 3 or "
                + "later.");
            Console.WriteLine("This program has absolutely no warranty.");
            */
        }

        //-----------------------------------------------------------
        void PrintReleaseIncludes() {
            Console.WriteLine("Included in this release:");
            foreach (var phase in ReleaseIncludes) {
                Console.WriteLine("   * " + phase);
            }
        }

        //-----------------------------------------------------------
        void Run(string[] args) {

            PrintAppHeader();
            Console.WriteLine();
            PrintReleaseIncludes();
            Console.WriteLine();

            if (args.Length != 1) {
                Console.Error.WriteLine(
                    "Please specify the name of the input file.");
                Environment.Exit(1);
            }

            try {
                var inputPath = args[0];
                var input = File.ReadAllText(inputPath);
                var parser = new Parser(
                    new Scanner(input).Scan().GetEnumerator());
                var program = parser.Program();
                Console.Write(program.ToStringTree());

                var semantic = new SemanticVisitor();
                semantic.Visit((dynamic) program);

                semantic.segundaVuelta = true;
                semantic.Visit((dynamic) program);

                
                Console.WriteLine("Semantics OK.");
                Console.WriteLine();
                Console.WriteLine("Symbol Table");
                Console.WriteLine("============");
                foreach (var entry in semantic.FGST_Table) {
                    Console.WriteLine(entry);
                }

            } catch (Exception e) {
                if(e is FileNotFoundException 
                || e is SyntaxError
                || e is SemanticError){
                    Console.Error.WriteLine(e.Message);
                    Environment.Exit(1);
                }

                throw;
            }
        }

        //-----------------------------------------------------------
        public static void Main(string[] args) {
            new Driver().Run(args);
        }
    }
}
