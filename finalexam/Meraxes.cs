/*-------------------------------------------------------------------

 EBNF grammar for the Boolang language:

    〈expr〉 → 〈dup〉
    〈expr〉 → 〈sum〉
    〈expr〉 → 〈mul〉
    〈expr〉 → 〈int〉
    〈dup〉 →“*”〈expr〉
    〈sum〉 →“[”〈list〉“]”
    〈mul〉 →“{”〈list〉“}”
    〈list〉 → 〈list〉“,”〈expr〉
    〈list〉 → 〈expr〉

-------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Meraxes{

    //---------------------------------------------------------------
    class SyntaxError: Exception {}

    //---------------------------------------------------------------
    enum Token {
        DUP, SUM, MUL, INT, STAR, OPEN_CORCHETE, CLOSE_CORCHETE, OPEN_BRAKET, CLOSE_BRAKET, 
        COMA,WHITESPACE,OTHER, ILLEGAL_CHAR, EOF
    }

    //---------------------------------------------------------------
    class Scanner {
        readonly string input;
        static readonly Regex regex = new Regex(
            @"
                (?<Star>            [*]      )
              | (?<Int>             \d+     )
              | (?<Coma>            [,]      )
              | (?<OpenCorchete>    [[]     )
              | (?<CloseCorchete>   []]      )
              | (?<OpenBraket>       [{]      )
              | (?<CloseBraket>     [}]      )
              | (?<WhiteSpace>      \s       )
              | (?<Other>             .      )
            ",
            RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
            );
        static readonly IDictionary<string, Token> regexLabels =
            new Dictionary<string, Token>() {
                {"Star", Token.STAR},
                {"Int", Token.INT},
                {"Coma", Token.COMA},
                {"OpenCorchete", Token.OPEN_CORCHETE},
                {"CloseCorchete", Token.CLOSE_CORCHETE},
                {"OpenBraket", Token.OPEN_BRAKET},
                {"CloseBraket", Token.CLOSE_BRAKET},
                {"WhiteSpace", Token.WHITESPACE},
                {"Other", Token.OTHER},

            };
        public Scanner(string input) {
            this.input = input;
        }
        public IEnumerable<Token> Start() {

            foreach (Match m in regex.Matches(input)) {
                if (m.Groups["WhiteSpace"].Success) {
                    // Skip spaces.
                }else if (m.Groups["Other"].Success) {
                    yield return Token.ILLEGAL_CHAR;
                } else {
                    foreach (var name in regexLabels.Keys) {
                        if (m.Groups[name].Success) {
                            yield return regexLabels[name];
                            break;
                        }
                    }
                }
            }
            yield return Token.EOF;
        }
    }

    //---------------------------------------------------------------
    class Node: IEnumerable<Node> {
        IList<Node> children = new List<Node>();
        public Node this[int index] {
            get {
                return children[index];
            }
        }
        public Token AnchorToken { get; set; }
        public void Add(Node node) {
            children.Add(node);
        }
        public IEnumerator<Node> GetEnumerator() {
            return children.GetEnumerator();
        }
        System.Collections.IEnumerator
                System.Collections.IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
        public override string ToString() {
            
            return GetType().Name;
        }

        public string ToStringTree() {
            var sb = new StringBuilder();
            TreeTraversal(this, "", sb);
            return sb.ToString();
        }
        static void TreeTraversal(
                Node node,
                string indent,
                StringBuilder sb) {
            sb.Append(indent);
            sb.Append(node);
            sb.Append('\n');
            foreach (var child in node.children) {
                TreeTraversal(child, indent + "  ", sb);
            }
        }
    }

    //---------------------------------------------------------------
    class Program:     Node {}
    class Expr:        Node {}
    class Dup:         Node {}
    class Sum:         Node {}
    class Mul:         Node {}
    class List:        Node {}
    class Literal_int: Node {}

    //---------------------------------------------------------------

//Program
//  Sum
//    Dup
//      1
//    Dup
//      0
//    Dup
//      Dup
//        Sum
//          Dup
//            2
//          |Mul
//          |  Dup
//          |    1
//          |  3
//          |  1
//          |0

    class Parser {
        static readonly ISet<Token> firstOfExpression =
            new HashSet<Token>() {
                Token.STAR,
                Token.OPEN_CORCHETE,
                Token.OPEN_BRAKET,
                Token.INT
            };
        IEnumerator<Token> tokenStream;
        public Parser(IEnumerator<Token> tokenStream) {
            this.tokenStream = tokenStream;
            this.tokenStream.MoveNext();
        }
        public Token CurrentToken {
            get { return tokenStream.Current; }
        }
        public Token Expect(Token category) {
            if (CurrentToken == category) {
                Token current = tokenStream.Current;
                tokenStream.MoveNext();
                return current;
            } else {
                throw new SyntaxError();
            }
        }
        public Node Program() {
            var e = new Program();
            while(firstOfExpression.Contains(CurrentToken)){
                switch (CurrentToken){
                    case Token.STAR:
                        //Console.WriteLine(CurrentToken);
                        e.Add(Dup());
                        break;
                    case Token.OPEN_CORCHETE:
                        //Console.WriteLine(CurrentToken);
                        e.Add(Sum());
                        break;
                    case Token.OPEN_BRAKET:
                    //Console.WriteLine(CurrentToken);
                        e.Add(Mul());
                        break;
                    case Token.INT:
                    //Console.WriteLine(CurrentToken);
                        var literalInt = new Literal_int(){
                            AnchorToken = Expect(Token.INT)
                        };
                        e.Add(literalInt);
                        break;
                    default:
                        throw new SyntaxError();    
                }
            }
            Expect(Token.EOF);
            return e;
        }
        // public Node Exp() {
        //     var expr = new Expr();
        //     //Console.WriteLine(CurrentToken);

        //     switch (CurrentToken){
        //         case Token.STAR:
        //             //Console.WriteLine(CurrentToken);
        //             expr.Add(Dup());
        //             break;
        //         case Token.OPEN_CORCHETE:
        //             //Console.WriteLine(CurrentToken);
        //             expr.Add(Sum());
        //             break;
        //         case Token.OPEN_BRAKET:
        //         //Console.WriteLine(CurrentToken);
        //             expr.Add(Mul());
        //             break;
        //         case Token.INT:
        //         //Console.WriteLine(CurrentToken);
        //             var literalInt = new Literal_int(){
        //                 AnchorToken = Expect(Token.INT)
        //             };
        //             expr.Add(literalInt);
        //             break;
        //         default:
        //             throw new SyntaxError();    
        //     }
        //     return expr;
        // }
        public Node Dup(){
            var DupNode = new Dup(){
                AnchorToken = Expect(Token.STAR)
            };
            switch (CurrentToken){
                    case Token.STAR:
                        //Console.WriteLine(CurrentToken);
                        DupNode.Add(Dup());
                        break;
                    case Token.OPEN_CORCHETE:
                        //Console.WriteLine(CurrentToken);
                        DupNode.Add(Sum());
                        break;
                    case Token.OPEN_BRAKET:
                    //Console.WriteLine(CurrentToken);
                        DupNode.Add(Mul());
                        break;
                    case Token.INT:
                    //Console.WriteLine(CurrentToken);
                        var literalInt = new Literal_int(){
                            AnchorToken = Expect(Token.INT)
                        };
                        DupNode.Add(literalInt);
                        break;
                    default:
                        throw new SyntaxError();    
                }
            return DupNode;
        }
        public Node Sum(){
            var sum = new Sum(){
                AnchorToken = Expect(Token.OPEN_CORCHETE)
            };
            sum.Add(List());
            Expect(Token.CLOSE_CORCHETE);
            return sum;
        }
        public Node Mul(){
            var mul = new Sum(){
                AnchorToken = Expect(Token.OPEN_BRAKET)
            };
            mul.Add(List());
            Expect(Token.CLOSE_BRAKET);
            return mul;
        }
        public Node List(){
            var listNode = new List();
             switch (CurrentToken){
                    case Token.STAR:
                        //Console.WriteLine(CurrentToken);
                        listNode.Add(Dup());
                        break;
                    case Token.OPEN_CORCHETE:
                        //Console.WriteLine(CurrentToken);
                        listNode.Add(Sum());
                        break;
                    case Token.OPEN_BRAKET:
                    //Console.WriteLine(CurrentToken);
                        listNode.Add(Mul());
                        break;
                    case Token.INT:
                    //Console.WriteLine(CurrentToken);
                        var literalInt = new Literal_int(){
                            AnchorToken = Expect(Token.INT)
                        };
                        listNode.Add(literalInt);
                        break;
                    default:
                        throw new SyntaxError();    
                }
            if(firstOfExpression.Contains(CurrentToken)){
                 switch (CurrentToken){
                    case Token.STAR:
                        //Console.WriteLine(CurrentToken);
                        listNode.Add(Dup());
                        break;
                    case Token.OPEN_CORCHETE:
                        //Console.WriteLine(CurrentToken);
                        listNode.Add(Sum());
                        break;
                    case Token.OPEN_BRAKET:
                    //Console.WriteLine(CurrentToken);
                        listNode.Add(Mul());
                        break;
                    case Token.INT:
                    //Console.WriteLine(CurrentToken);
                        var literalInt = new Literal_int(){
                            AnchorToken = Expect(Token.INT)
                        };
                        listNode.Add(literalInt);
                        break;
                    default:
                        throw new SyntaxError();    
                }
                return listNode;
            }else{
                while (CurrentToken == Token.COMA)
                {
                     Expect(Token.COMA);
                      switch (CurrentToken){
                        case Token.STAR:
                            //Console.WriteLine(CurrentToken);
                            listNode.Add(Dup());
                            break;
                        case Token.OPEN_CORCHETE:
                            //Console.WriteLine(CurrentToken);
                            listNode.Add(Sum());
                            break;
                        case Token.OPEN_BRAKET:
                        //Console.WriteLine(CurrentToken);
                            listNode.Add(Mul());
                            break;
                        case Token.INT:
                        //Console.WriteLine(CurrentToken);
                            var literalInt = new Literal_int(){
                                AnchorToken = Expect(Token.INT)
                            };
                            listNode.Add(literalInt);
                            break;
                        default:
                            throw new SyntaxError();    
                    }
                }
                return listNode;
            }
        }
        
    }

    //---------------------------------------------------------------
    class WebAssemblyVisitor {
        public string Visit(Program node) {
            return
                  "(module\n"
                + "  (func\n"
                + "    (export \"start\")\n"
                + "    (result i64)\n"
                + Visit((dynamic) node[0])
                + "  )\n"
                + ")\n";
        }

        public string Visit(Dup node){
            return ( Visit((dynamic)node) + 
            "i64.const 2" + 
            "i64.mul");
        }

        public String Visit(Sum node){
            var sb = new StringBuilder();

            foreach(var n in Visit((dynamic) node)){
                sb.Append("i64.const " + n.ToString());
                sb.Append("i64.const " + n.ToString());
                sb.Append("i64.sum");
            }
            return sb.ToString();
        }

        public string Visit(Mul node){
            var sb = new StringBuilder();
            foreach(var n in Visit((dynamic) node)){
                sb.Append("i64.const " + n.ToString());
                sb.Append("i64.const " + n.ToString());
                sb.Append("i64.mul");
            }
            return sb.ToString();
        }

        public string Visit(List node){
                return "i64.const " + node.AnchorToken + "\n";
        }

        public string Visit(Literal_int node){
                return "i64.const " + node.AnchorToken + "\n";
        }

        
        string VisitChildren(Node node) {
            var sb = new StringBuilder();
            foreach (var n in node) {
                var nodito = Visit((dynamic) n);
                sb.Append(nodito);
            }
        return sb.ToString();
        }

        
    }

    //---------------------------------------------------------------
    class Driver {
        public static void Main(string[] args) {
            if (args.Length != 1) {
                Console.Error.WriteLine(
                    "Give me an operation.");
                System.Environment.Exit(1);
            }
            try {
                var p = new Parser(
                    new Scanner(args[0]).Start().GetEnumerator());
                var ast = p.Program();
                Console.Write(ast.ToStringTree());
                // File.WriteAllText(
                //     "output.wat",
                //     new WebAssemblyVisitor().Visit((dynamic) ast));
            } catch (SyntaxError e) {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}