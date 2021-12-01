﻿using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace Falak {

    class CodePoints {
    public IList<int> AsCodePoints(String str) {
        var result = new List<int>(str.Length);
        for (var i = 0; i < str.Length; i++) {
            result.Add(char.ConvertToUtf32(str, i));
            if (char.IsHighSurrogate(str, i)) {
                i++;
            }

        }
        return result;
        }
    }

   
    class WatVisitor {

        public string functionFlag = "global"; 
        
        public SortedDictionary<string, FGST_struct> FGST_Table{get;  set; }

        //--------------------------------------------------------------
        public  SortedDictionary<string,string> VGST{ get; set;}
        
        public WatVisitor(SortedDictionary<string, FGST_struct> FGST_Table, 
        SortedDictionary<string, string> VGST) {
            this.FGST_Table = FGST_Table;
            this.VGST = VGST;
        }

        public CodePoints codPoints =  new CodePoints();      
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
        int counterWhile = 0;
        int else_if = 0;

        int YeEstaElTemp = 0;


        

        public String GenerateLabel() {
            return String.Format("${0:00000}", labelCounter++);

        }

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
            if(YeEstaElTemp == 0){
                if(functionFlag != "global" && functionFlag != "main"){
                    sb.Append("(local $_temp i32)\n");
                }
                YeEstaElTemp = 1;
            }

                //sb.Append("(local $_temp i32)\n");
            
            if(functionFlag != "global"){
                //var issues;

                //sb.Append("(local $_temp i32)\n");

                foreach (var localVar in node){
                    sb.Append("(local $" + localVar.AnchorToken.Lexeme + " i32) \n");
                }
                
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
            return VisitChildren(node);

        }
        //-----------------------------------------------------------
        public string Visit(Expr_funcall_identifier node) {
            return(VisitChildren(node) + "\ncall $" + node.AnchorToken.Lexeme + "\n");
        }

        public string Visit(Fun_def node) {
            functionFlag = node.AnchorToken.Lexeme; 
            YeEstaElTemp = 0;
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
             return VisitChildren(node);
         }
         //-----------------------------------------------------------
        public string Visit(Param_list_identifier node) {
            var sb = new StringBuilder();
            sb.Append(VisitChildren(node) + "(result i32) \n");
            if(YeEstaElTemp == 0){
                if(functionFlag != "global" && functionFlag != "main"){
                    sb.Append("(local $_temp i32)\n");
                }
                YeEstaElTemp = 1;
            }
            return sb.ToString();
        }
         //-----------------------------------------------------------
        public string Visit(Param_identifier node) {
            var name = node.AnchorToken.Lexeme;
            return $"(param ${name} i32)\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_list node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_asign node) {
            // foreach(KeyValuePair<string, Falak.FGST_struct> fg in FGST_Table){

            //      if(fg.Key == functionFlag){
            //         var varAssign = "";
            //         varAssign += VisitChildren(node);
            //         varAssign += $"local.set ${varName} ;; VARIABLE ASSIGN\n";
            //         sb.Append(varAssign);
            //     }   

            //     else  if  (VGST.ContainsKey(varName) && fg.Key == functionFlag){
            //         sb.Append(Visit((dynamic) node[0]));
            //         sb.Append($"global.set ${varName} ;; VARIABLE ASSIGN\n");
            //     } 
                
               
            // }
            

            var sb = new StringBuilder();
            var varName = node.AnchorToken.Lexeme;
            

         
            if(FGST_Table[functionFlag].refLst.Contains(varName) || FGST_Table[functionFlag].paramLst.Contains(varName) ){ //Es una variable local
                var varAssign = "";
                varAssign += VisitChildren(node);
                varAssign += $"local.set ${varName} ;; VARIABLE ASSIGN\n";
                sb.Append(varAssign);
            }else if (VGST.ContainsKey(varName)){
                sb.Append(VisitChildren (node));
                sb.Append($"global.set ${varName} ;; VARIABLE ASSIGN\n");
            }
            
            return sb.ToString();

        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall node) {
            return VisitChildren(node) 
                   + "call $" + node.AnchorToken.Lexeme 
                   + "\ndrop\n";
        }
         //-----------------------------------------------------------
        public string Visit(Stm_funcall_Exprlist node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Stm_Inc node) {
            var varName = Visit((dynamic) node[0]);
            var scopeString = "";
            if(FGST_Table[functionFlag].refLst.Contains(varName)|| FGST_Table[functionFlag].paramLst.Contains(varName) ){ //Es una variable local
                scopeString =  "local";

            }else if (VGST.ContainsKey(varName)){
                scopeString = "global";

            }
           
            return "(" + scopeString + ".get $" + varName + ")\n"+   
                   "i32.const 1 \n" +
                   "i32.add\n"+
                   "(" + scopeString + ".set $" + varName + ")\n";          
        }
         //-----------------------------------------------------------
        public string Visit(Inc_identifier node) {
            var varName = node.AnchorToken.Lexeme;
            return varName;
        }
         //-----------------------------------------------------------
        public string Visit(Stm_dec node) {
            var varName = Visit((dynamic) node[0]);
            var scopeString = "";

            if(FGST_Table[functionFlag].refLst.Contains(varName) || FGST_Table[functionFlag].paramLst.Contains(varName) ){ //Es una variable local
                scopeString =  "local";

            }else if (VGST.ContainsKey(varName)){
                scopeString = "global";

            }
           
            return "(" + scopeString + ".get $" + varName + ")\n"+   
                   "i32.const 1 \n" +
                   "i32.sub\n"+
                   "(" + scopeString + ".set $" + varName + ")\n";          
        }
         //-----------------------------------------------------------
        public string Visit(Dec_identifier node) {
            var varName = node.AnchorToken.Lexeme;
            return varName;
        }
         //-----------------------------------------------------------
        public string Visit(If node) {
            var finalString = ";; IF statement \n" 
                + Visit((dynamic) node[0]) // Expressions 
                + "if\n"
                + ";;; Stmlist if\n "
                + Visit((dynamic) node[1]) //stm list 
                + Visit((dynamic) node[2])//elseif list
                + "end\n";
            while(else_if>0){
                finalString += "end\n";
                else_if --;
            }
            return finalString;
        }
         //-----------------------------------------------------------
        public string Visit(Elseif_list node) {
            return VisitChildren(node);
        }
         //-----------------------------------------------------------
        public string Visit(Elseif node) {
            else_if ++;
             return ";; elseif statement \n" 
             +"else\n"
             + Visit((dynamic)node[0]) + "\n"
             + "if\n"
             + Visit((dynamic)node[1]) + "\n";
        }
         //-----------------------------------------------------------
        public string Visit(Else node) {
            return ";; else statement \n" 
            + "else\n"
            + VisitChildren(node) + "\n";
        }
         //-----------------------------------------------------------
        public string Visit(While node) {
            labelCounter +=2;
           counterWhile++;
            var varString="";
            var label1 = GenerateLabel();
            var label2 = GenerateLabel();

            varString = (
            ";;START WHILE \n" + 
            "block " + label1 + "\n"+
            "loop " + label2 + "\n"+
            Visit((dynamic) node[0])+  //expressiowon 
            "  \n i32.eqz\n" + 
            $"br_if  " + label1 + "\n" +
            Visit((dynamic) node[1])+ // statement 
            "br " + label2 +"\n"+
            "end\n"+
            "end\n"+
            ";; END WHILE \n"
            );
            counterWhile--;
            labelCounter -=2;
            return varString;
        }
         //------------------------------------------------------
        public string Visit(Do node) {
            labelCounter +=2;
           counterWhile++;
            var varString="";
            var label1 = GenerateLabel();
            var label2 = GenerateLabel();

            varString = (
            ";;START WHILE \n" + 
            "block " + label1 + "\n"+
            "loop " + label2 + "\n"+
            Visit((dynamic) node[0])+  //expressioon 
            "br " + label2 +"\n"+

            Visit((dynamic) node[1])+ // statement 
            "  \n i32.eqz\n" + 
            $"br_if  " + label1 + "\n" +
            "end\n"+
            "end\n"+
            ";; END WHILE \n"
            );
            counterWhile--;
            labelCounter -=2;
            return varString;
        }
         //-----------------------------------------------------------
        public string Visit(Break node) {
            var label = String.Format("${0:00000}", labelCounter + (2*(counterWhile -1)-2));
            counterWhile--;
            return "br "+ label+ "\n";
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
         //----------------------estaaaaaa-------------------------------
        public string Visit(Greaterthan node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.gt_s \n";        
                   }
         //----------------------estaaaaaa----------------------------
        public string Visit(GreaterthanEquals node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.ge_s \n";        
        }
         //-------------------estaaaaaa----------------------------------------
        public string Visit(Lessthan node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.lt_s \n";
        }
         //-----------------------------estaaaaaa------------------------------
        public string Visit(LessThanEquals node) {
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.le_s \n";        
        }
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
            Console.WriteLine("MUL");
            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.mul \n";

        }
         //-----------------------------------------------------------
        public string Visit(Division node) {

            return $"{Visit((dynamic) node[0])} \n" +  
                   $"{Visit((dynamic) node[1])} \n" +
                   "i32.div_s \n";        }
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

            var sb = new StringBuilder();
            var varName = node.AnchorToken.Lexeme;
            

         
            if(FGST_Table[functionFlag].refLst.Contains(varName) || FGST_Table[functionFlag].paramLst.Contains(varName) ){ //Es una variable local
                var varAssign = "";
                varAssign += VisitChildren(node);
                varAssign += $"local.get ${varName} ;; VARIABLE ASSIGN\n";
                sb.Append(varAssign);
            }else if (VGST.ContainsKey(varName)){
                sb.Append(VisitChildren (node));
                sb.Append($"global.get ${varName} ;; VARIABLE ASSIGN\n");
            }
            
            return sb.ToString();


            // var idName = node.AnchorToken.Lexeme;
            // var finalVarId = "";            
            
            // if(functionFlag != "global"){ 
            //     if (VGST.ContainsKey(idName)){
            //         finalVarId ="global.get $" + idName + "\n" + ";;expr_var_identifier\n";
            //     }else{
                    
            //         finalVarId =  "local.get $" + idName+  "\n";
            //     }
            // }else{ // Not in a function
            //     finalVarId = "global.get $" + idName + "\n";
            // }
            // return finalVarId;

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
             return "    i32.const 1\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_false node) {
             return "    i32.const 0\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_char node) {
            var lit = node.AnchorToken.Lexeme;

            lit = lit.Remove(lit.Length-1,1);
            lit = lit.Remove(0,1);
            
            //PRIMERO DIOS, PERO OJALA NUNCA ALLA UN UNICODE
            lit = lit.Replace("\\n","\n");
            lit = lit.Replace("\\r","\r");
            lit = lit.Replace("\\t","\t");

            var uniChar =  codPoints.AsCodePoints($"{lit}");

            return "\ni32.const " + uniChar[0] + "\n";
        }
        //-----------------------------------------------------------
        public string Visit(Lit_str node) {


            var wantedString = node.AnchorToken.Lexeme;
            wantedString = wantedString.Remove(wantedString.Length-1,1);
            wantedString = wantedString.Remove(0,1);

            wantedString = wantedString.Replace("\\n","\n");
            wantedString = wantedString.Replace("\\r","\r");
            wantedString = wantedString.Replace("\\t","\t");

            //TODO: Pasar un char Unicode en un string a una constante.
            //wantedString = wantedString.Replace("\\u","\u");


            //PUEDE O PUEDE QUE NO SE USE 
            //wantedString = wantedString.Replace("\\\\","\\");
            //wantedString = wantedString.Replace("\\'","\'");
            //wantedString = wantedString.Replace("\\"","\"");

            var finalString =  codPoints.AsCodePoints(wantedString);

            var code = ";; Start String: " + wantedString;
            code += "\n i32.const 0\ncall $new\n";
            code += "\n local.set $_temp\n";
            code += "\n local.get $_temp\n";
            
            //char[] charArr = wantedString.ToCharArray();

            foreach (var i in finalString){
                code += "local.get $_temp\n";
            }

            var specialCharFlag = 0;
            foreach (var i in finalString){ 
                code += "\ni32.const " + i  + 
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
