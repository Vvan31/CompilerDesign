
using System;
using System.Collections.Generic;

namespace Falak {

    class SemanticVisitorSecondPass : SemanticVisitor {
        public new  string fun_name;

        public int counterWhile = 0;

        public int counterDo = 0;

        public String fun_name_stmt;

        public new  SortedDictionary<string, FGST_struct> FGST_Table{  get;   set; }

        //--------------------------------------------------------------
        public new SortedDictionary<string,string> VGST{ get;  set; }

        //--------------------------------------------------------------
        
        public  SemanticVisitorSecondPass(SemanticVisitor semantic) {
            FGST_Table = semantic.FGST_Table;
            VGST = semantic.VGST;
        }
    
         public new FGST_struct structManaegr(string nombre,int ari){
            FGST_struct newFGST = new FGST_struct();

            newFGST.name = nombre;
            newFGST.isPrimitive = false;
            newFGST.arity = ari;
            newFGST.refLst = null; 
            newFGST.paramLst = null; 
            
            return newFGST; 
        }

        //-----------------------------------------------------------
        public new void Visit(Program node) {
            VisitChildren(node);
        }
        //-----------------------------------------------------------
        public new void Visit(Def_list node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public new void Visit(Def node) {
            VisitChildren(node); 
        }
        //-----------------------------------------------------------
        public new void Visit(Var_def node) {}

        //-----------------------------------------------------------
        public new void Visit(Var_list_identifier node) {
            VisitChildren(node);
        }
         //----------------------------------------------------------
        public new void Visit(Var_identifier node) {
            if(fun_name != null){
                var variableName = node.AnchorToken.Lexeme;
                if(FGST_Table[fun_name].refLst.Contains(variableName)||FGST_Table[fun_name].paramLst.Contains(variableName)){
                    throw new SemanticError(
                    "Duplicated variable: " + variableName, 
                    node.AnchorToken);
                } else{
                    FGST_Table[fun_name].refLst.Add(variableName);
                }
            }
        }
        //-----------------------------------------------------------
        public new void Visit(Fun_def node) {
            fun_name = node.AnchorToken.Lexeme;
            VisitChildren(node);
        }
        //-----------------------------------------------------------

         public new void Visit(Local_var_identifier node){
            VisitChildren(node);
         }
         //-----------------------------------------------------------
        public new void Visit(Param_list_identifier node) {
            VisitChildren(node);
        }
         //-----------------------------------------------------------
        public new void Visit(Param_identifier node) {
            var varName = node.AnchorToken.Lexeme;
            
            if(FGST_Table[fun_name].paramLst.Contains(varName)){} 
            else {
                FGST_Table[fun_name].paramLst.Add(varName);
            }
        }
         //-----------------------------------------------------------
        public new void Visit(Stm_list node) {
            VisitChildren(node);
        }
         //-----------------------------------------------------------
        public new void Visit(Stm_asign node) {
            var variableName = node.AnchorToken.Lexeme;

            if(FGST_Table[fun_name].refLst.Contains(variableName) 
            || VGST.ContainsKey(variableName)
            || FGST_Table[fun_name].paramLst.Contains(variableName) ){
                VisitChildren(node);
            } else {
                throw new SemanticError(
                "Undeclared Variable: " + variableName,
                node.AnchorToken);
            }
        }
         //-----------------------------------------------------------
        public new void Visit(Stm_funcall node) {
            var functionName = node.AnchorToken.Lexeme;
            fun_name_stmt = functionName;

            if(FGST_Table.ContainsKey(functionName)){
                VisitChildren(node);
            } else {
                throw new SemanticError(
                "Undeclared Function: " + functionName,
                node.AnchorToken);
            }
        }
         //-----------------------------------------------------------
        public new void Visit(Stm_funcall_Exprlist node) {
            var param_list = node.size();
            var variableName = node.AnchorToken.Lexeme;
            if (FGST_Table[variableName].arity != param_list){
                throw new SemanticError(
                "Bad arity: " + variableName,
                node.AnchorToken);
            }else{
                VisitChildren(node);
            }
        }
         //-----------------------------------------------------------
        public new void Visit(Stm_Inc node) {
            VisitChildren(node);
        }

         //-----------------------------------------------------------
        public new void Visit(Inc_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if (VGST.ContainsKey(variableName)
            || FGST_Table[fun_name].refLst.Contains(variableName)
            || FGST_Table[fun_name].paramLst.Contains(variableName)) {}
            else{
                throw new SemanticError(
                    "Undeclared variable: " + variableName,
                    node.AnchorToken);
            }
        }
         //-----------------------------------------------------------
        public new void Visit(Stm_dec node) {
            VisitChildren(node);
        }
         //-----------------------------------------------------------
        public new void Visit(Dec_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if (VGST.ContainsKey(variableName)
            || FGST_Table[fun_name].refLst.Contains(variableName)
            || FGST_Table[fun_name].paramLst.Contains(variableName)) {}
            else{
                throw new SemanticError(
                    "Undeclared variable: " + variableName,
                    node.AnchorToken);
            }
        }
         //-----------------------------------------------------------
        public new void Visit(If node) {}
         //-----------------------------------------------------------
        public new void Visit(Elseif_list node) {}
         //-----------------------------------------------------------
        public new void Visit(Elseif node) {}
         //-----------------------------------------------------------
        public new void Visit(Else node) {}
         //-----------------------------------------------------------
        public new void Visit(While node) {
            counterWhile += 1;
            VisitChildren(node);
            counterWhile -= 1;
        }
         //-----------------------------------------------------------
        public new void Visit(Do node) {
            counterWhile += 1;
            VisitChildren(node);
            counterWhile -= 1;
        }
         //-----------------------------------------------------------
        public new void Visit(Break node) {
            if (counterWhile <= 0){
                throw new SemanticError(
                    "Breaking Bad: ",
                    node.AnchorToken);
            }
        }
         //-----------------------------------------------------------
        public new void Visit(Return node) {}
         //-----------------------------------------------------------
        public new void Visit(Or node) {}
        public new void Visit(Xor node) {}

         //-----------------------------------------------------------
        public new void Visit(AND node) {}
         //-----------------------------------------------------------
        public new void Visit(Equals node) {}
         //-----------------------------------------------------------
        public new void Visit(Difequals node) {}
         //-----------------------------------------------------------
        public new void Visit(Greaterthan node) {}
         //-----------------------------------------------------------
        public new void Visit(GreaterthanEquals node) {}
         //-----------------------------------------------------------
        public new void Visit(Lessthan node) {}
         //-----------------------------------------------------------
        public new void Visit(LessThanEquals node) {}
         //-----------------------------------------------------------
        public new void Visit(Plus node) {}
         //-----------------------------------------------------------
        public new void Visit(Minus node) {}
         //-----------------------------------------------------------
        public new void Visit(Multiplication node) {}
         //-----------------------------------------------------------
        public new void Visit(Division node) {}
         //-----------------------------------------------------------
        public new void Visit(Percent node) {}
         //-----------------------------------------------------------
        public new void Visit(Positive node) {}
         //-----------------------------------------------------------
        public new void Visit(Negative node) {}
         //-----------------------------------------------------------
        public new void Visit(Not node) {} //-----------------------------------------------------------
        public void Visit(Expr_funcall_identifier node) {
            var functionName = node.AnchorToken.Lexeme;
            var param_list = node.children[0].size();
            //Usar param list para verificar el numero de parametros 
            if(FGST_Table.ContainsKey(functionName)){
               VisitChildren(node);
            } else {
                throw new SemanticError(
                "Undeclared Function: " + functionName,
                node.AnchorToken);            }
        } 
        //-----------------------------------------------------------
        public void Visit(Expr_var_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if(FGST_Table[fun_name].refLst.Contains(variableName) 
            ||VGST.ContainsKey(variableName)
            || FGST_Table[fun_name].paramLst.Contains(variableName)){
            } else {
                throw new SemanticError(
                "Undeclared Variable: " + variableName,
                node.AnchorToken);            
            }
        } 
        //-----------------------------------------------------------
        public new void Visit(Expr_primary_list node) {} 
        //-----------------------------------------------------------
        public new void Visit(Expr_primary_expr node) {}
        //-----------------------------------------------------------
        public new void Visit(Lit_true node) {}
        //-----------------------------------------------------------
        public new void Visit(Lit_false node) {}
        //-----------------------------------------------------------
        public new void Visit(Lit_char node) {}
        //-----------------------------------------------------------
        public new void Visit(Lit_str node) {}
        //-----------------------------------------------------------
        public new void Visit(Lit_int node) {
            var intStr = node.AnchorToken.Lexeme;
            int value;
            if (!Int32.TryParse(intStr, out value)) {
                throw new SemanticError(
                    $"Integer literal too large: {intStr}",
                    node.AnchorToken);
            }
        }
        //-----------------------------------------------------------
        void VisitChildren(Node node) {
            foreach (var n in node) {
                Visit((dynamic) n);
            }
        }
    }
}
