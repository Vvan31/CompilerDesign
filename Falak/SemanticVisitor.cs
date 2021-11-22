
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
        public void Visit(Program node) {
            VisitChildren(node);
            
        }
        //-----------------------------------------------------------
        public void Visit(Def_list node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(Def node) {
            VisitChildren(node);
        }
        //-----------------------------------------------------------
        public void Visit(Var_def node) {
            VisitChildren(node);
        }

        //-----------------------------------------------------------
        public void Visit(Var_list_identifier node) {
            VisitChildren(node);
        }
         //----------------------------------------------------------
        public void Visit(Var_identifier node) {
            var variableName = node.AnchorToken.Lexeme;
            if(VGST.ContainsKey(variableName)){
                throw new SemanticError(
                "Duplicated variable: " + variableName, 
                node.AnchorToken);
            } else{
                Console.WriteLine(variableName);
                VGST[variableName] = "var";
            }
        }
        //-----------------------------------------------------------
        public void Visit(Fun_def node) {
            var functionName = node.AnchorToken.Lexeme;
            fun_name = functionName;
            var param_list = 0;

            if (node.children.Count > 0){
                param_list = node.children[0].size();
            }
        
            if(FGST_Table.ContainsKey(functionName)){
                throw new SemanticError(
                "Duplicated Function: " + functionName,
                node.AnchorToken);
            } else {
                FGST_Table[functionName] = structManaegr(functionName, param_list);
            }
            VisitChildren(node);
        }
         //-----------------------------------------------------------
         public void Visit(Local_var_identifier node){}
         //-----------------------------------------------------------
        public void Visit(Param_list_identifier node) {
            var paramListSize = node.size();
            var function_structure = FGST_Table[fun_name];
            function_structure.arity = paramListSize;   
        }
         //-----------------------------------------------------------
        public void Visit(Param_identifier node) {}
         //-----------------------------------------------------------
        public void Visit(Stm_list node) {}
         //-----------------------------------------------------------
        public void Visit(Stm_asign node) {}
         //-----------------------------------------------------------
        public void Visit(Stm_funcall node) {}
         //-----------------------------------------------------------
        public void Visit(Stm_funcall_Exprlist node) {}
         //-----------------------------------------------------------
        public void Visit(Stm_Inc node) {}
         //-----------------------------------------------------------
        public void Visit(Inc_identifier node) {}
         //-----------------------------------------------------------
        public void Visit(Stm_dec node) {}
         //-----------------------------------------------------------
        public void Visit(Dec_identifier node) {}
         //-----------------------------------------------------------
        public void Visit(If node) {}
         //-----------------------------------------------------------
        public void Visit(Elseif_list node) {}
         //-----------------------------------------------------------
        public void Visit(Elseif node) {}
         //-----------------------------------------------------------
        public void Visit(Else node) {}
         //-----------------------------------------------------------
        public void Visit(While node) {}
         //-----------------------------------------------------------
        public void Visit(Do node) {}
         //-----------------------------------------------------------
        public void Visit(Break node) {}
         //-----------------------------------------------------------
        public void Visit(Return node) {}
         //-----------------------------------------------------------
        public void Visit(Or node) {}
         //-----------------------------------------------------------
        public void Visit(AND node) {}
         //-----------------------------------------------------------
        public void Visit(Equals node) {}
         //-----------------------------------------------------------
        public void Visit(Difequals node) {}
         //-----------------------------------------------------------
        public void Visit(Greaterthan node) {}
         //-----------------------------------------------------------
        public void Visit(GreaterthanEquals node) {}
         //-----------------------------------------------------------
        public void Visit(Lessthan node) {}
         //-----------------------------------------------------------
        public void Visit(LessThanEquals node) {}
         //-----------------------------------------------------------
        public void Visit(Plus node) {}
         //-----------------------------------------------------------
        public void Visit(Minus node) {}
         //-----------------------------------------------------------
        public void Visit(Multiplication node) {}
         //-----------------------------------------------------------
        public void Visit(Division node) {}
         //-----------------------------------------------------------
        public void Visit(Percent node) {}
         //-----------------------------------------------------------
        public void Visit(Positive node) {}
         //-----------------------------------------------------------
        public void Visit(Negative node) {}
         //-----------------------------------------------------------
        public void Visit(Not node) {} 
        //-----------------------------------------------------------
        public void Visit(Expr_primary_identifier node) {} 
        //-----------------------------------------------------------
        public void Visit(Expr_primary_list node) {} 
        //-----------------------------------------------------------
        public void Visit(Expr_primary_expr node) {}
        //-----------------------------------------------------------
        public void Visit(Lit_true node) {}
        //-----------------------------------------------------------
        public void Visit(Lit_false node) {}
        //-----------------------------------------------------------
        public void Visit(Lit_char node) {}
        //-----------------------------------------------------------
        public void Visit(Lit_str node) {}
        //-----------------------------------------------------------
        public void Visit(Lit_int node) {}
        //-----------------------------------------------------------
        void VisitChildren(Node node) {
            foreach (var n in node) {
                Visit((dynamic) n);
            }
        }
    }
}
