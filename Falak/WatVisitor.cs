
using System;
using System.Text;
using System.Collections.Generic;

namespace Falak {
   
    class WatVisitor {


        
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
        SortedDictionary<string, string> VGST ) {
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
                + "  (import \"falak\" \"printi\" (func $printi (param i32)))\n"
                + "  (import \"falak\" \"printc\" (func $printc (param i32)))\n"
                + "  (import \"falak\" \"prints\" (func $prints (param i32)))\n"
                + "  (import \"falak\" \"println\" (func $println (param i32)))\n"
                + "  (import \"falak\" \"readi\" (func $readi (param i32)))\n"
                + "  (import \"falak\" \"reads\" (func $reads (param i32)))\n"
                + "  (import \"falak\" \"new\" (func $new (param i32)))\n"
                + "  (import \"falak\" \"size\" (func $size (param i32)))\n"
                + "  (import \"falak\" \"add\" (func $add (param i32)))\n"
                + "  (import \"falak\" \"get\" (func $get (param i32)))\n"
                + "  (import \"falak\" \"set\" (func $set (param i32)))\n"
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
            return VisitChildren(node);
        }

        //-----------------------------------------------------------
        public string Visit(Var_list_identifier node) {
            // The code for the local variable declarations is
            // generated directly from the symbol table, not from
            // the AST nodes.
            var sb = new StringBuilder();
            foreach (var entry in VGST) {
                sb.Append($"    (local ${entry.Key} i32)\n");
            }
            return sb.ToString();
        }
         //----------------------------------------------------------
        public string Visit(Var_identifier node) {
            return VisitChildren(node);

        }
        //-----------------------------------------------------------
        public string Visit(Fun_def node) {
            Console.WriteLine("FUN DEF");
            
            var funName = node.AnchorToken.Lexeme;
            if (funName == "main"){
                funName = "\n   (export \"main\")\n";
            }else{
                funName = "$" + node.AnchorToken.Lexeme;
            }
            var result = "(func " + funName;
            result += VisitChildren(node)+ ")\n\n";
            return result;
            
        }
         //-----------------------------------------------------------
         public string Visit(Local_var_identifier node){
             return "owo\n";
         }
         //-----------------------------------------------------------
        public string Visit(Param_list_identifier node) {
            return VisitChildren(node);

        }
         //-----------------------------------------------------------
        public string Visit(Param_identifier node) {
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_list node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_asign node) {
            return VisitChildren(node);

        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall node) {
            return VisitChildren(node); 
        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall_Exprlist node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_Inc node) {
            return VisitChildren(node);

        }
         //-----------------------------------------------------------
        public string Visit(Inc_identifier node) {
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_dec node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Dec_identifier node) {
            return "owo\n";
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
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Return node) {
            return "return";
        }
         //-----------------------------------------------------------
        public string Visit(Or node) {
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(AND node) {
            //return VisitBinaryOperator("i32.and", node);
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Equals node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Difequals node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Greaterthan node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(GreaterthanEquals node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Lessthan node) {
            //return VisitBinaryOperator("i32.lt_s", node);
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(LessThanEquals node) {
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Plus node) {
           // return VisitBinaryOperator("i32.add", node);
            return "owo\n";

        }
         //-----------------------------------------------------------
        public string Visit(Minus node) {
            //return VisitBinaryOperator("i32.sub", node);
            return "owo\n";

        }
         //-----------------------------------------------------------
        public string Visit(Multiplication node) {
            //return VisitBinaryOperator("i32.mul", node);
            return "owo\n";

        }
         //-----------------------------------------------------------
        public string Visit(Division node) {
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Percent node) {
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Positive node) {
            return "owo\n";
        }
         //-----------------------------------------------------------
        public string Visit(Negative node) {
            return "    i32.const 0\n"
                + Visit((dynamic) node[0])
                + "    i32.sub\n";
        }
         //-----------------------------------------------------------
        public string Visit(Not node) {
            return "owo\n";
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
            return "owo\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_false node) {
            return "owo\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_char node) {
            return "owo\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_str node) {
            return $"    local.get ${node.AnchorToken.Lexeme}\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_int node) {
            return $"    local.get ${node.AnchorToken.Lexeme}\n";

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
