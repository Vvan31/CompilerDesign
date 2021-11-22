
using System;
using System.Collections.Generic;

namespace Falak {

    class SemanticVisitor {
        public string fun_name;

        public struct FGST_struct {
            public string name;
            public bool isPrimitive;
            public int arity;
            public ISet<string> refLst;   
            
        }
        public SortedDictionary<string, FGST_struct> FGST_Table{get;  set; }

        //--------------------------------------------------------------
        public  SortedDictionary<string,string> VGST{ get; set;}


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
            newFGST.refLst = new HashSet<string>(); 
            return newFGST;
        }
         public FGST_struct structManaegr(string nombre,int ari){
            FGST_struct newFGST = new FGST_struct();
            newFGST.name = nombre;
            newFGST.isPrimitive = false;
            newFGST.arity = ari;
            newFGST.refLst = new HashSet<string>(); 
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
                var variableName = node.AnchorToken.Lexeme;
                if(VGST.ContainsKey(variableName)){
                    throw new SemanticError(
                    "Duplicated variable: " + variableName, 
                    node.AnchorToken);
                } else{
                    Console.WriteLine(variableName);
                    VGST[variableName] = "var";
                    }
                return Type.VOID;
            
        }
        //-----------------------------------------------------------
        public Type Visit(Fun_def node) {

                var functionName = node.AnchorToken.Lexeme;
                fun_name = functionName;
                
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                Console.WriteLine(node.ToStringTree());

                var param_list = 0;

                if (node.children.Count > 0){
                    param_list = node.children[0].size();
                }
            
                if(FGST_Table.ContainsKey(functionName)){
                    throw new SemanticError(
                    "Duplicated Function: " + functionName,
                    node.AnchorToken);
                } else {
                    Console.WriteLine(functionName);
                    FGST_Table[functionName] = structManaegr(functionName, param_list);
                }
                VisitChildren(node);
                return Type.VOID;  
        }
         //-----------------------------------------------------------
         public Type Visit(Local_var_identifier node){
             return Type.VOID;
         }
        public Type Visit(Param_list_identifier node) {
            var paramListSize = node.size();
            var function_structure = FGST_Table[fun_name];
            function_structure.arity = paramListSize;   
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Param_identifier node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_list node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_asign node) {
            return Type.VOID;

        }
         //-----------------------------------------------------------
        public Type Visit(Stm_funcall node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_funcall_Exprlist node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_Inc node) {
            return Type.VOID;
        }

         //-----------------------------------------------------------
        public Type Visit(Inc_identifier node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_dec node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Dec_identifier node) {
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
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Do node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Break node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Return node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Or node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(AND node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Equals node) { 
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Difequals node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Greaterthan node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(GreaterthanEquals node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Lessthan node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(LessThanEquals node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Plus node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Minus node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Multiplication node) {
            return Type.VOID; 
        }
         //-----------------------------------------------------------
        public Type Visit(Division node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Percent node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Positive node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Negative node) {
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Not node) {
            return Type.VOID;
        } //-----------------------------------------------------------
        public Type Visit(Expr_primary_identifier node) {
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
