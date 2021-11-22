
using System;
using System.Collections.Generic;

namespace Falak {

    class SemanticVisitorSecondPass : SemanticVisitor {
        public string fun_name;

        public int counterWhile = 0;

        public int counterDo = 0;

        public String fun_name_stmt;

        public SortedDictionary<string, FGST_struct> FGST_Table{  get;   set; }

        //--------------------------------------------------------------
        public  SortedDictionary<string,string> VGST{ get;  set; }

        //--------------------------------------------------------------
        
        public  SemanticVisitorSecondPass(SemanticVisitor semantic) {
            FGST_Table = semantic.FGST_Table;
            VGST = semantic.VGST;
        }
    
         public FGST_struct structManaegr(string nombre,int ari){
            FGST_struct newFGST = new FGST_struct();

            newFGST.name = nombre;
            newFGST.isPrimitive = false;
            newFGST.arity = ari;
            newFGST.refLst = null; 
            return newFGST; 
        }

        //-----------------------------------------------------------
        public Type Visit(Program node) {
            VisitChildren(node);
            return Type.VOID;
            
        }
        //-----------------------------------------------------------
        public Type Visit(Def_list node) {
            VisitChildren(node);
            return Type.VOID;
            
        }

        //-----------------------------------------------------------
        public Type Visit(Def node) {
            VisitChildren(node);
            return Type.VOID;
            
        }
        //-----------------------------------------------------------
        public Type Visit(Var_def node) {
            VisitChildren(node);
            return Type.VOID;
            
        }

        //-----------------------------------------------------------
        public Type Visit(Var_list_identifier node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //----------------------------------------------------------
        public Type Visit(Var_identifier node) {
            if(fun_name != null){
                var variableName = node.AnchorToken.Lexeme;
                    if(FGST_Table[fun_name].refLst.Contains(variableName)){
                        throw new SemanticError(
                        "Duplicated variable: " + variableName, 
                        node.AnchorToken);
                    } else{
                        FGST_Table[fun_name].refLst.Add(variableName);
                        }
            }
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Fun_def node) {
            fun_name = node.AnchorToken.Lexeme;
            VisitChildren(node);
            return Type.VOID;
        }
        //-----------------------------------------------------------

         public Type Visit(Local_var_identifier node){
            VisitChildren(node);
            return Type.VOID;
         }
         //-----------------------------------------------------------
        public Type Visit(Param_list_identifier node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Param_identifier node) {
             var varName = node.AnchorToken.Lexeme;
            
            if(FGST_Table[fun_name].refLst.Contains(varName)){
               return Type.VOID;
            } else {
                FGST_Table[fun_name].refLst.Add(varName);
            }
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_list node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_asign node) {
            var variableName = node.AnchorToken.Lexeme;
            foreach (var entry in VGST) {
                    Console.WriteLine(entry);
                }

            if(FGST_Table[fun_name].refLst.Contains(variableName) || 
            VGST.ContainsKey(variableName)){
                VisitChildren(node);
                return Type.VOID;
            } else {
                throw new SemanticError(
                "Undeclared Variable: " + variableName,
                node.AnchorToken);
            }

            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_funcall node) {
            var functionName = node.AnchorToken.Lexeme;
            fun_name_stmt = functionName;

            if(FGST_Table.ContainsKey(functionName)){
                VisitChildren(node);
                return Type.VOID;
            } else {
                throw new SemanticError(
                "Undeclared Function: " + functionName,
                node.AnchorToken);
            }

            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_funcall_Exprlist node) {
            var param_list = node.size();
            var variableName = node.AnchorToken.Lexeme;
            if (FGST_Table[variableName].arity != param_list){
                throw new SemanticError(
                "Bad arity: " + variableName,
                node.AnchorToken);
            }else{
                VisitChildren(node);
            }
            
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_Inc node) {
            VisitChildren(node);
            return Type.VOID;
        }

         //-----------------------------------------------------------
        public Type Visit(Inc_identifier node) {
            var variableName = node.AnchorToken.Lexeme;
    

            //ver si la variable esta en la lista de variables dentro de la funcion o global 
            if (VGST.ContainsKey(variableName)|| FGST_Table[fun_name].refLst.Contains(variableName)) {
                return Type.VOID;
            }else{
                throw new SemanticError(
                    "Undeclared variable: " + variableName,
                    node.AnchorToken);
                    return Type.VOID;
            }
            
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_dec node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Dec_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            //ver si la variable esta en la lista de variables dentro de la funcion o global 
            if (VGST.ContainsKey(variableName)|| FGST_Table[fun_name].refLst.Contains(variableName)) {
                return Type.VOID;
            }else{
                throw new SemanticError(
                    "Undeclared variable: " + variableName,
                    node.AnchorToken);
                    return Type.VOID;
            }
        }
         //-----------------------------------------------------------
        public Type Visit(If node) {
        
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Elseif_list node) {
        
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Elseif node) {
        
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Else node) {
        
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(While node) {
            counterWhile += 1;
            VisitChildren(node);
            counterWhile -= 1;
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Do node) {
            counterWhile += 1;
            VisitChildren(node);
            counterWhile -= 1;
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Break node) {
            if (counterWhile <= 0){
                throw new SemanticError(
                    "Breaking Bad: ",
                    node.AnchorToken);
            }
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Return node) {

            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Or node) {
            VisitBinaryOperator("||", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(AND node) {
            VisitBinaryOperator("&&", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Equals node) { 

            VisitBinaryOperator("==", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Difequals node) {
            VisitBinaryOperator("!=", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Greaterthan node) {
            VisitBinaryOperator(">", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(GreaterthanEquals node) {
            VisitBinaryOperator(">=", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Lessthan node) {
            VisitBinaryOperator("<", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(LessThanEquals node) {
            VisitBinaryOperator("<=", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Plus node) {
            VisitBinaryOperator("+", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Minus node) {
            VisitBinaryOperator("-", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Multiplication node) {
            VisitBinaryOperator("*", node, Type.INT);
            return Type.VOID; // int? aaaa 
        }
         //-----------------------------------------------------------
        public Type Visit(Division node) {
            VisitBinaryOperator("/", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Percent node) {
            VisitBinaryOperator("%", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Positive node) {
            VisitBinaryOperator("+", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Negative node) {
            VisitBinaryOperator("-", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Not node) {
            VisitBinaryOperator("!", node, Type.INT);
            return Type.VOID;
        } //-----------------------------------------------------------
        public Type Visit(Expr_funcall_identifier node) {
            var functionName = node.AnchorToken.Lexeme;

            //ver si la variable esta en la lista de variables dentro de la funcion o global 
            var param_list = node.children[0].size();
           
            if(FGST_Table.ContainsKey(functionName)){
               VisitChildren(node);
            } else {
                throw new SemanticError(
                "Undeclared Function: " + functionName,
                node.AnchorToken);            }

            return Type.VOID;
        } //-----------------------------------------------------------
        public Type Visit(Expr_var_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            //ver si la variable esta en la lista de variables dentro de la funcion o global 
            
           
            if(FGST_Table[fun_name].refLst.Contains(variableName) ||
                        VGST.ContainsKey(variableName)){
               return Type.VOID;
            } else {
                throw new SemanticError(
                "Undeclared Variable: " + variableName,
                node.AnchorToken);            }

            return Type.VOID;
        } //-----------------------------------------------------------
        public Type Visit(Expr_primary_list node) {
        
            return Type.VOID;
        } //-----------------------------------------------------------
        public Type Visit(Expr_primary_expr node) {
        
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Lit_true node) {
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Lit_false node) {
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Lit_char node) {
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Lit_str node) {
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Lit_int node) {

            var intStr = node.AnchorToken.Lexeme;
            int value;

            if (!Int32.TryParse(intStr, out value)) {
                throw new SemanticError(
                    $"Integer literal too large: {intStr}",
                    node.AnchorToken);
            }

            return Type.VOID;
        }
        //-----------------------------------------------------------
        void VisitChildren(Node node) {
            foreach (var n in node) {
                Visit((dynamic) n);
            }
        }

        //-----------------------------------------------------------
        void VisitBinaryOperator(string op, Node node, Type type) {
            /*
            if (Visit((dynamic) node[0]) != type ||
                Visit((dynamic) node[1]) != type) {
                throw new SemanticError(
                    $"Operator {op}   two operands of type {type}",
                    node.AnchorToken);
            }
            */
        }
    }
}
