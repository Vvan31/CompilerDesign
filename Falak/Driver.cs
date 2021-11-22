using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Falak {

    public class Driver {

        const string VERSION = "0.2";

        //-----------------------------------------------------------
       static readonly string[] ReleaseIncludes = {
            "Lexical analysis",
            "Syntactic analysis",
            "AST construction",
            "Semantic analysis"
        };

        //-----------------------------------------------------------
        void PrintReleaseIncludes() {
            Console.WriteLine("Included in this release:");
            foreach (var phase in ReleaseIncludes) {
                Console.WriteLine("   * " + phase);
            }
        }

        //-----------------------------------------------------------
        void Run(string[] args) {
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
                //Parser
                var parser = new Parser(
                    new Scanner(input).Scan().GetEnumerator());
                var program = parser.Program();
                Console.Write(program.ToStringTree());

                //Semantic visitor First pass
                var semantic = new SemanticVisitor();
                semantic.Visit((dynamic) program);

               Console.WriteLine("PRIMERA PASADA\n");
               Console.WriteLine("-----------Global var ------------");
               foreach (var entry in semantic.VGST) {
                    Console.WriteLine(entry);
                }
                Console.WriteLine("\n-----------Functions ------------------");
                foreach (var entry in semantic.FGST_Table) {
                    Console.WriteLine(entry);
                }
                //Semantic visitor secoomd pass
                var semantic2 = new SemanticVisitorSecondPass(semantic);
                semantic2.Visit((dynamic) program);
            
                Console.WriteLine("\nSEGUNDA PASADA\n");
                Console.WriteLine("-----------Functions-----------------");
                foreach (var entry in semantic2.FGST_Table) {
                    Console.WriteLine("-Funtion: " + entry.Key);
                    Console.WriteLine("---Local var: " + string.Join(", ", semantic2.FGST_Table[entry.Key].refLst));

                }
               
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
                || e is SemanticError
                || e is NullReferenceException){
                    Console.Error.WriteLine(e.Message);
                    Console.Error.WriteLine(e);
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
