
using System;
using System.Collections.Generic;

namespace Falak {

    class SemanticVisitor {
        public string fun_name;
        public bool segundaVuelta = false;

        public int counterWhile = 0;

        public int counterDo = 0;

        public int counterBreak = 0;

        public String fun_name_stmt;

        public struct FGST_struct {
            public string name;
            public bool isPrimitive;
            public int arity;
            public List<string> refLst;   
            
        }
        public IDictionary<string, FGST_struct> FGST_Table{ get; private set; }

        //--------------------------------------------------------------
        public  IDictionary<string,string> VGST{ get; private set; }

        //--------------------------------------------------------------
        public  SemanticVisitor() {
            VGST = new SortedDictionary<string,string>();
            FGST_Table = new SortedDictionary<string,FGST_struct>();
            FGST_Table["printc"] = structManaegrAPI("printc", 1);
            FGST_Table["prints"] = structManaegrAPI("prints", 1);
            FGST_Table["printi"] = structManaegrAPI("printi", 1);
            FGST_Table["println"] = structManaegrAPI("println", 0);
            FGST_Table["readi"] = structManaegrAPI("readi", 0);
            FGST_Table["reads"] = structManaegrAPI("reads", 0);
            FGST_Table["new"] = structManaegrAPI("new", 1);
            FGST_Table["size"] = structManaegrAPI("size", 1);
            FGST_Table["add"] = structManaegrAPI("add", 2);
            FGST_Table["get"] = structManaegrAPI("add", 2);
            FGST_Table["set"] = structManaegrAPI("set", 3); 
        }
        

      
        public FGST_struct structManaegrAPI(string nombre, int ari){
            FGST_struct newFGST = new FGST_struct();
            newFGST.name = nombre;
            newFGST.isPrimitive = true;
            newFGST.arity = ari;
            newFGST.refLst = null; 
            return newFGST;
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
            var variableName = node[0].AnchorToken.Lexeme;
            if(VGST.ContainsKey(variableName)){
                throw new SemanticError(
                    "Duplicated variable: " + variableName, 
                    node[0].AnchorToken);
            } else{
                VGST[variableName] = "var";
            }
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Fun_def node) {
            var functionName = node.AnchorToken.Lexeme;
            fun_name = functionName;

            var param_list = node.children[0].size();
           
            if(FGST_Table.ContainsKey(functionName)){
                throw new SemanticError(
                "Duplicated Function: " + functionName,
                node.AnchorToken);
            } else {
                FGST_Table[functionName] = structManaegr(functionName, param_list);
            }
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Param_list_identifier node) {
            var paramListSize = node.size();

            var function_structure = FGST_Table[fun_name];
            function_structure.arity = paramListSize;
      
            if(segundaVuelta){
                VisitChildren(node);
            }            
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Param_identifier node) {

            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_list node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_identifier node) {
            Console.WriteLine("asdfasdf: ", node.AnchorToken.Lexeme);
            var functionName = node.AnchorToken.Lexeme;
            fun_name_stmt = functionName;
            Console.WriteLine("stm_identifier: ", fun_name_stmt);

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
        public Type Visit(Stm_asign node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_funcall node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_funcall_Exprlist node) {
            Console.WriteLine("asdfasdfasdf");
            Console.WriteLine(node.size());

            Console.WriteLine("funname  ", fun_name_stmt);

            var param_list = node.size();

            Console.WriteLine("PARAMLIST: " , param_list);

            if (FGST_Table[fun_name_stmt].arity != param_list){
                throw new SemanticError(
                "Bad arity: " + fun_name_stmt,
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
            if (!(VGST.ContainsKey(variableName)) || !(FGST_Table[fun_name].refLst.Contains(variableName))) {
                throw new SemanticError(
                    "Undeclared variable: " + variableName,
                    node.AnchorToken);
            }
            return Type.VOID;
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
            if (!(VGST.ContainsKey(variableName)) || !(FGST_Table[fun_name].refLst.Contains(variableName))) {
                throw new SemanticError(
                    "Undeclared variable: " + variableName,
                    node.AnchorToken);
            }
            return Type.VOID;
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
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Do node) {
            counterDo += 1;
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Break node) {
            counterBreak += 1;
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
        public Type Visit(Expr_primary_identifier node) {
            var functionName = node.AnchorToken.Lexeme;

            //ver si la variable esta en la lista de variables dentro de la funcion o global 
            var param_list = node.children[0].size();

           
            if(FGST_Table.ContainsKey(functionName)){
                throw new SemanticError(
                "Duplicated Function: " + functionName,
                node.AnchorToken);
            } else {
                FGST_Table[functionName] = structManaegr(functionName, param_list);
            }

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
            if (Visit((dynamic) node[0]) != type ||
                Visit((dynamic) node[1]) != type) {
                throw new SemanticError(
                    $"Operator {op}   two operands of type {type}",
                    node.AnchorToken);
            }
        }
    }
}
