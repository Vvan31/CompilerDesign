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
        int labelCounter = 0;

        public String GenerateLabel() {
            return String.Format("${0:00000}", labelCounter++);
        }

    // Rest of the class goes here
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
            return (VisitChildren(node));
            //return "(global $" + VisitChildren(node) + "(mut i32) (i32.const 0))";
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
            
            //var refl = FGST_Table[functionFlag].refLst;
          

                //sb.Append("(local $_temp i32)\n");
            if(functionFlag != "global" && functionFlag != "main"){
                sb.Append("(local $_temp i32)\n");
            }
            if(functionFlag != "global"){
                //var issues;

                //sb.Append("(local $_temp i32)\n");
                //Console.WriteLine(node.ToStringTree());

                foreach (var localVar in node){
                    //Console.WriteLine(localVar.ToStringTree());
                    //Console.WriteLine("    (local " + localVar.AnchorToken.Lexeme+" i32)\n");
                    //Console.WriteLine(VisitChildren(localVar));
                    sb.Append("(local $" + localVar.AnchorToken.Lexeme + " i32) \n");
                }
                //Console.WriteLine(sizeof(refl));
                // foreach (var localVar in FGST_Table[functionFlag].refLst){
                //     Console.W
                //     sb.Append("    (local " + localVar+" i32)\n");
                     
                // }

                
            }
            return sb.ToString();
        }

                //-----------------------------------------------------------
        public string generateGlobalBVariables(){
            var sb = new StringBuilder();
            foreach (var entry in VGST) {

                var varName = entry.Key;
                sb.Append("(global $" +  varName + "(mut i32) (i32.const 0)) \n");
            }
            return sb.ToString();
        }
         //----------------------------------------------------------
        public string Visit(Var_identifier node) {
            //Console.WriteLine("vi");
            //Console.WriteLine(node.ToStringTree());
            return VisitChildren(node);

        }
        //-----------------------------------------------------------

        public string Visit(Expr_funcall_identifier node) {
            Console.WriteLine(node);
            return(VisitChildren(node) + "\ncall $" + node.AnchorToken.Lexeme + "\n");
        }

        public string Visit(Fun_def node) {

            //Give us the name of the function.
            functionFlag = node.AnchorToken.Lexeme; 
            
            var funName = node.AnchorToken.Lexeme;
            var result = "";
            if (funName == "main"){

                funName = "\n $main\n   (export \"main\")\n" +
                          "    (result i32)\n";
                funName += "(local $_temp i32)\n";

                result = "\n (func " + funName + "\n"+
                                VisitChildren(node)+
                                "i32.const 0  \n\n)\n";
            }else{
            //POR EL AMOR A STALMAN, NO HAGAN FUNCIONES SIN PRAMETROS!!!
                funName = "$" + node.AnchorToken.Lexeme;
                result = "\n (func " + funName + "\n"+
                                VisitChildren(node)+
                                "i32.const 0  \n\n)\n";
            }
            
            //Ends whatever the function needed to be and returns to the default "Global"
            functionFlag = "global"; 
            return result;

        }
         //-----------------------------------------------------------
         public string Visit(Local_var_identifier node){
             //Console.WriteLine("lvi");
             //Console.WriteLine(node.ToStringTree());
             return VisitChildren(node);
         }
         //-----------------------------------------------------------
        public string Visit(Param_list_identifier node) {
            return(VisitChildren(node) + "(result i32) \n");
        }
         //-----------------------------------------------------------
        public string Visit(Param_identifier node) {
            var name = node.AnchorToken.Lexeme;
            return $"(param ${name} i32)\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_list node) {
            //Console.WriteLine(node.ToStringTree());
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_asign node) {
            var sb = new StringBuilder();
            var varName = node.AnchorToken.Lexeme;
            //Console.WriteLine(varName);
            //Console.WriteLine(functionFlag);
            //Console.WriteLine(node.ToStringTree());
            //Console.WriteLine(FGST_Table[functionFlag].ContainsKey(varName));
            foreach(KeyValuePair<string, Falak.FGST_struct> fg in FGST_Table){
                //Console.WriteLine(fg.Key);
                if (fg.Key ==functionFlag){
                    //Console.WriteLine(varName);
                    var varAssign = "";
                    varAssign += VisitChildren(node);
                    varAssign += $"local.set ${varName} ;; VARIABLE ASSIGN\n";
                    sb.Append(varAssign);
                } 
            }
            
            if(FGST_Table[functionFlag].refLst.Contains(varName)){ //Es una variable local
                //sb.Append(Visit((dynamic)node[0]));
                //Console.WriteLine(node.ToStringTree());
                var varAssign = "";
                varAssign += VisitChildren(node);
                varAssign += $"local.set ${varName} ;; VARIABLE ASSIGN\n";
                sb.Append(varAssign);
            }else if (VGST.ContainsKey(varName)){
                sb.Append(Visit((dynamic) node[0]));
                sb.Append($"global.set ${varName} \n");
            }
            return sb.ToString();

        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall node) {
            return VisitChildren(node) + "call $" + node.AnchorToken.Lexeme + "\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall_Exprlist node) {
            //Console.WriteLine("STM_FUNCALL_EXPRLIST");
            //Console.WriteLine(node);
            //var funCall = node.AnchorToken.Lexeme;
            //Console.WriteLine(node);
            //Console.WriteLine(funCall);
            ///Console.WriteLine(VisitChildren(node));
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_Inc node) {
             return $"i32.const 1\n" + 
                   $"{Visit((dynamic) node[0])} \n" +
                   "i32.add \n";       
        }
         //-----------------------------------------------------------
        public string Visit(Inc_identifier node) {
            var varName = node.AnchorToken.Lexeme;
            if (VGST.ContainsKey(varName)){
                return "global.get $" + varName + "\n";
            } else {
                return "local.get $" + varName + "\n";
            }
        }
         //-----------------------------------------------------------
        public string Visit(Stm_dec node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"i32.const 1 \n" +
                   "i32.sub\n";          
        }
         //-----------------------------------------------------------
        public string Visit(Dec_identifier node) {
            var varName = node.AnchorToken.Lexeme;
            if (VGST.ContainsKey(varName)){
                return "global.get $" + varName + "\n";
            } else {
                return "local.get $" + varName + "\n";
            }
        }
         //-----------------------------------------------------------
        public string Visit(If node) {
            Console.WriteLine(node.ToStringTree());
            var ifString = ";; IF statement \n" 
                + Visit((dynamic) node[0]) // Expressions 
                + "if\n"
                + ";;; Stmlist if\n "
                + Visit((dynamic) node[1]) //stm list 
                + Visit((dynamic) node[2]);//elseif list
                
                ifString += "end\n";
                return ifString;
        }
         //-----------------------------------------------------------
        public string Visit(Elseif_list node) {
            Console.WriteLine("elseif list");
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Elseif node) {
             return ";; elseif statement \n" 
             +"else\n"
             + Visit((dynamic)node[0]) + "\n"
             + "if\n"
             + Visit((dynamic)node[1]) + "\n";
            
        }
         //-----------------------------------------------------------
        public string Visit(Else node) {
           Console.WriteLine("ELSE");
            return ";; else statement \n" 
            + "else\n"
            + VisitChildren(node) + "\n";
        }
         //-----------------------------------------------------------
        public string Visit(While node) {

            var label1 = GenerateLabel();
            var label2 = GenerateLabel();

            return (
            ";;START WHILE \n" + 
            "block " + label1 + "\n"+
            "loop " + label2 + "\n"+
            Visit((dynamic) node[0])+ //The Conditional
            $"br_if  " + label1 + "\n" +
            Visit((dynamic) node[1])+
            "br " + label2 +"\n"+
            "end\n"+
            "end\n"+
            ";; END WHILE \n"
            );
        }
         //-------------FALTA ESTE------------------------------------------
        public string Visit(Do node) {
            var label1 = GenerateLabel();
            var label2 = GenerateLabel();

            return (
            ";;START WHILE \n" + 
            "block " + label1 + "\n"+
            "loop " + label2 + "\n"+
            Visit((dynamic) node[0])+ //The Conditional
            $"br_if " + label1 + "\n" +
            Visit((dynamic) node[1])+
            "br " + label2 +"\n"+
            "end\n"+
            "end\n"+
            ";; END WHILE \n"
            );
        }
         //-----------------------------------------------------------
        public string Visit(Break node) {
            labelCounter--;
            return "br "+ GenerateLabel();
        }
         //-----------------------------------------------------------
        public string Visit(Return node) {
            return VisitChildren(node) + "return\n";
        }
         //-----------------------------------------------------------
        public string Visit(Or node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.or \n";                }
         //-----------------------------------------------------------
        public string Visit(AND node) {
            //return VisitBinaryOperator("i32.and", node);
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.and \n";                }
         //-----------------------------------------------------------
        public string Visit(Equals node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.eq \n";        
        }
         //-----------------------------------------------------------
        public string Visit(Difequals node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.ne \n";        
        }
         //-----------------------------------------------------------
        public string Visit(Greaterthan node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.ge_s \n";        
                   }
         //-----------------------------------------------------------
        public string Visit(GreaterthanEquals node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.g_ts \n";        }
         //-----------------------------------------------------------
        public string Visit(Lessthan node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.lt_s \n";
        }
         //-----------------------------------------------------------
        public string Visit(LessThanEquals node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.le_s \n";        }
         //-----------------------------------------------------------
        public string Visit(Plus node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.add \n";

        }
         //-----------------------------------------------------------
        public string Visit(Minus node) {
            //return VisitBinaryOperator("i32.sub", node);
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.sub \n";
        }
         //-----------------------------------------------------------
        public string Visit(Multiplication node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.mul \n";

        }
         //-----------------------------------------------------------
        public string Visit(Division node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.div_u \n";        }
         //-----------------------------------------------------------
        public string Visit(Percent node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.rem_s \n";        }        
         //-----------------------------------------------------------
        public string Visit(Positive node) {
            return $"{Visit((dynamic) node[0])} \n";           
        }
         //-----------------------------------------------------------
        public string Visit(Negative node) {
            return "    i32.const 0\n"
                + Visit((dynamic) node[0])
                + "    i32.sub\n";
        }
         //-----------------------------------------------------------
        public string Visit(Not node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   "i32.eqz \n";        } 

        
        public string Visit(Expr_var_identifier node) {
            //Console.WriteLine(node.ToStringTree());
            var idName = node.AnchorToken.Lexeme;
            var finalVarId = "";            
            if(functionFlag != "global"){ 
                if (VGST.ContainsKey(idName)){
                    finalVarId ="global.get $" + idName + "\n";
                }else{
                    
                    finalVarId =  "local.get $" + idName+  "\n";
                }
            }else{ // Not in a function
                finalVarId = "global.get $" + idName + "\n";
            }

            return finalVarId;

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
            var lit = node.AnchorToken.Lexeme;
            
            //PRIMERO DIOS, PERO OJALA NUNCA ALLA UN UNICODE
            lit = lit.Replace("\\n","\n");
            lit = lit.Replace("\\r","\r");
            lit = lit.Replace("\\t","\t");

            char[] charArr = lit.ToCharArray();

            return "\ni32.const " + (short)charArr[0] + "\n";
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


            var code = ";; Start String: " + wantedString;
            code += "\n i32.const 0\ncall $new\n";
            code += "\n local.set $_temp\n";
            code += "\n local.get $_temp\n";

            
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
