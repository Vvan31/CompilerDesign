
using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace Falak {
   
    class WatVisitor {
        public string functionFlag = "global"; 
        
        public SortedDictionary<string, FGST_struct> FGST_Table{get;  set; }

        //--------------------------------------------------------------
        public  SortedDictionary<string,string> VGST{ get; set;}
        
        //-----------------------------------------------------------
        //Depreciated
        // static readonly IDictionary<Type, string> PrintInstructions =
        //     new Dictionary<Type, string>() {
        //         { Type.BOOL, "print_bool" },
        //         { Type.INT, "print_int" }
        //     };

        public WatVisitor(SortedDictionary<string, FGST_struct> FGST_Table, 
        SortedDictionary<string, string> VGST) {
            this.FGST_Table = FGST_Table;
            this.VGST = VGST;
        }
      
        //-----------------------------------------------------------
        // public string Visit(Assignment node) {
        //     return Visit((dynamic) node[0])
        //         + $"    local.set ${node.AnchorToken.Lexeme}\n";
        // }

        //-----------------------------------------------------------
        // public string Visit(Identifier node) {
        //     return $"    local.get ${node.AnchorToken.Lexeme}\n";
        // }

        //-----------------------------------------------------------
        // public string Visit(IntLiteral node) {
        //     return $"    i32.const {node.AnchorToken.Lexeme}\n";
        // }

        //-----------------------------------------------------------
        // public string Visit(True node) {
        //     return "    i32.const 1\n";
        // }

        //-----------------------------------------------------------
        // public string Visit(False node) { 
        //     return "    i32.const 0\n";
        // }
        ///=========

        public string Visit(Program node) {
            return "(module\n"
                + "  (import \"falak\" \"printi\" (func $printi (param i32) (result i32)))\n"
                + "  (import \"falak\" \"printc\" (func $printc (param i32) (result i32)))\n"
                + "  (import \"falak\" \"prints\" (func $prints (param i32) (result i32)))\n"
                + "  (import \"falak\" \"println\" (func $println (result i32)))\n"
                + "  (import \"falak\" \"readi\" (func $readi (result i32)))\n"
                + "  (import \"falak\" \"reads\" (func $reads (result i32)))\n"
                + "  (import \"falak\" \"new\" (func $new (param i32) (result i32) ))\n"
                + "  (import \"falak\" \"size\" (func $size (param i32) (result i32)))\n"
                + "  (import \"falak\" \"add\" (func $add (param i32 i32) (result i32)))\n"
                + "  (import \"falak\" \"get\" (func $get (param i32 i32) (result i32)))\n"
                + "  (import \"falak\" \"set\" (func $set (param i32 i32 i32) (result i32)))\n"
                + generateGlobalBVariables() + "\n"
                + Visit((dynamic)node[0]) + "\n"
                + ")\n";
        }
        //-----------------------------------------------------------
        public string Visit(Def_list node) {
            return VisitChildren(node);
        }

        //-----------------------------------------------------------
        public string Visit(Def node) {
            return VisitChildren(node);
        }
        //-----------------------------------------------------------
        public string Visit(Var_def node) {
            return "(global $" + VisitChildren(node) + "(mut i32) (i32.const 0))";
        }

        //-----------------------------------------------------------
        public string Visit(Var_list_identifier node) {
            // The code for the local variable declarations is
            // generated directly from the symbol table, not from
            // the AST nodes.
            var sb = new StringBuilder();
            // foreach (var entry in VGST) {
            //     sb.Append($"    (global ${entry.Key} i32)\n");
            // }
            if(functionFlag != "global"){
                foreach (var localVar in FGST_Table[functionFlag].refLst){
                    sb.Append($"    (local ${localVar} i32)\n");
                }
            }
            return sb.ToString();
        }

                //-----------------------------------------------------------
        public string generateGlobalBVariables(){
            var sb = new StringBuilder();
            foreach (var entry in VGST) {
                sb.Append($"(global ${entry.Key} (mut i32) (i32.const 0)) \n");
            }
            return sb.ToString();
        }
         //----------------------------------------------------------
        public string Visit(Var_identifier node) {
            return VisitChildren(node);

        }
        //-----------------------------------------------------------

        public string Visit(Expr_funcall_identifier node) {
            Console.WriteLine("Expr_funcall_identifier");
            Console.WriteLine(node.AnchorToken.Lexeme);
            return("call $" + node.AnchorToken.Lexeme);
        }

        public string Visit(Fun_def node) {
            Console.WriteLine("FUN DEF");
            functionFlag = node.AnchorToken.Lexeme; 
            var funName = node.AnchorToken.Lexeme;
            if (funName == "main"){
                funName = "\n $main\n   (export \"main\")\n";
                funName += "    (result i32)\n";
                funName += "        (local $_temp i32)";
                funName += "\ni32.const 0\n";
            }else{
                funName = "$" + node.AnchorToken.Lexeme;
            }
            var result = "(func " + funName;
            result += VisitChildren(node)+ "i32.const 0  \n)\n\n";
            functionFlag = "global";
            return result;
            
        }
         //-----------------------------------------------------------
         public string Visit(Local_var_identifier node){
             return "owo LOCAL VAR IDENTIFIER\n";
         }
         //-----------------------------------------------------------
        public string Visit(Param_list_identifier node) {
            return VisitChildren(node);

        }
         //-----------------------------------------------------------
        public string Visit(Param_identifier node) {
            return "owo PARAM IDENTIFIER\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_list node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_asign node) {
            var sb = new StringBuilder();
            var varName = node.AnchorToken.Lexeme;
            if(FGST_Table[functionFlag].refLst.Contains(varName)){ //Es una variable local
                Console.WriteLine("Bruh  "+ Visit((dynamic)node[0]) + "\n");
                //sb.Append(Visit((dynamic)node[0]));
                sb.Append($"local.set ${varName}");
            }else if (VGST.ContainsKey(varName)){
                sb.Append(Visit((dynamic) node[0]));
                sb.Append($"global.set ${varName}");
            }
            return sb.ToString();

        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall node) {
            return VisitChildren(node) + "call $" + node.AnchorToken.Lexeme +
                    "\ndrop \n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall_Exprlist node) {
            var funCall = node.AnchorToken.Lexeme;
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_Inc node) {
            return VisitChildren(node);

        }
         //-----------------------------------------------------------
        public string Visit(Inc_identifier node) {
            return "owo INC IDENTIFIER\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_dec node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Dec_identifier node) {
            return "owo DEC IDENTIFIER\n";
        }
         //-----------------------------------------------------------
        public string Visit(If node) {
            return Visit((dynamic) node[0])
                + "    if\n"
                + Visit((dynamic) node[1])
                + "    end\n";
        }
         //-----------------------------------------------------------
        public string Visit(Elseif_list node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Elseif node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Else node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(While node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Do node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Break node) {
            return "BREAKING BAD owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Return node) {
            Console.WriteLine("RETURN");
            Console.WriteLine(node);
            return VisitChildren(node) + "return\n";
        }
         //-----------------------------------------------------------
        public string Visit(Or node) {
            return "owoOR\n";
        }
         //-----------------------------------------------------------
        public string Visit(AND node) {
            //return VisitBinaryOperator("i32.and", node);
            return "owo AND \n";
        }
         //-----------------------------------------------------------
        public string Visit(Equals node) {
            return "owo Equals \n";
        }
         //-----------------------------------------------------------
        public string Visit(Difequals node) {
            return "owo Difequals \n";
        }
         //-----------------------------------------------------------
        public string Visit(Greaterthan node) {
            return "owo Greaterthan \n";
        }
         //-----------------------------------------------------------
        public string Visit(GreaterthanEquals node) {
            return "owo GreaterthanEquals \n";
        }
         //-----------------------------------------------------------
        public string Visit(Lessthan node) {
            //return VisitBinaryOperator("i32.lt_s", node);
            return "owo LESS THAN \n";
        }
         //-----------------------------------------------------------
        public string Visit(LessThanEquals node) {
            return "owo LESS THN EQUALS\n";
        }
         //-----------------------------------------------------------
        public string Visit(Plus node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.add";

        }
         //-----------------------------------------------------------
        public string Visit(Minus node) {
            Console.WriteLine("MINUS");
            //Console.WriteLine(node);
            Console.WriteLine(node[0]);
            //Console.WriteLine(node[1]);
            Console.WriteLine(Visit((dynamic) node[0]));


            //return VisitBinaryOperator("i32.sub", node);
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.sub";
        }
         //-----------------------------------------------------------
        public string Visit(Multiplication node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.mul";

        }
         //-----------------------------------------------------------
        public string Visit(Division node) {
            return "owo DIVISION\n";
        }
         //-----------------------------------------------------------
        public string Visit(Percent node) {
            return "owo PERCENT \n";
        }
         //-----------------------------------------------------------
        public string Visit(Positive node) {
            return "owo POSITIVE\n";
        }
         //-----------------------------------------------------------
        public string Visit(Negative node) {
            return "    i32.const 0\n"
                + Visit((dynamic) node[0])
                + "    i32.sub\n";
        }
         //-----------------------------------------------------------
        public string Visit(Not node) {
            return "ewe (not owo)\n";
        } 

        
        public string Visit(Expr_var_identifier node) {
            return "OwO EVI";
        } 
        //-----------------------------------------------------------
        public string Visit(Expr_primary_identifier node) {
            return VisitChildren(node);
        } 
        //-----------------------------------------------------------
        public string Visit(Expr_primary_list node) {
            return VisitChildren(node);
        } 
        //-----------------------------------------------------------
        public string Visit(Expr_primary_expr node) {
            return VisitChildren(node);
        }
        //-----------------------------------------------------------
        public string Visit(Lit_true node) {
            return "owo lit true\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_false node) {
            return "owo lit false\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_char node) {
            return "owo lit char\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_str node) {
            var wantedString = node.AnchorToken.Lexeme;
            wantedString = wantedString.Remove(wantedString.Length-1,1);
            wantedString = wantedString.Remove(0,1);

            wantedString = wantedString.Replace("\\n","\n");
            wantedString = wantedString.Replace("\\r","\r");
            wantedString = wantedString.Replace("\\t","\t");
            //PUEDE O PUEDE QUE NO SE USE 
            //wantedString = wantedString.Replace("\\\\","\\");
            //wantedString = wantedString.Replace("\\'","\'");
            //wantedString = wantedString.Replace("\\"","\"");


            var code = ";; Start String" + wantedString;
            code += "i32.const 0\ncall $new\n";
            code += "local.set $_temp\n";
            code += "local.get $_temp\n";

            
            char[] charArr = wantedString.ToCharArray();

            foreach (var c in charArr){
                code += "local.get $_temp\n";
            }


            var specialCharFlag = 0;
            foreach (var c in charArr){ 

                code += "\ni32.const " + (short)c  + 
                        "\n call $add"+
                        "\n drop\n";
            }

            code += ";; End of String\n";

            return code;
        }
        //-----------------------------------------------------------
        public string Visit(Lit_int node) {
            return "i32.const " + node.AnchorToken.Lexeme + "\n";
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
}
