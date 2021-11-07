
using System;
using System.Collections.Generic;

namespace Falak {

    class SemanticVisitor {

        //-----------------------------------------------------------
        static readonly IDictionary<TokenCategory, Type> typeMapper =
            new Dictionary<TokenCategory, Type>() {
                { TokenCategory.INT, Type.INT }
            };

        //-----------------------------------------------------------
        public IDictionary<string, Type> Table {
            get;
            private set;
        }

        //-----------------------------------------------------------
        public SemanticVisitor() {
            Table = new SortedDictionary<string, Type>();
        }

        //-----------------------------------------------------------
        public Type Visit(Program node) {
            Visit((dynamic) node[0]);
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
         //-----------iiiishhhhhhhh----------------------------------
        public Type Visit(Var_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if (Table.ContainsKey(variableName)) {
                return Table[variableName];
            }

            throw new SemanticError(
                $"Undeclared variable: {variableName}",
                node.AnchorToken);
            return Type.VOID;
        }
        //-----------------------------------------------------------
        public Type Visit(Fun_def node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Param_list_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if (Table.ContainsKey(variableName)) {
                return Table[variableName];
            }

            throw new SemanticError(
                $"Undeclared variable: {variableName}",
                node.AnchorToken);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Param_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if (Table.ContainsKey(variableName)) {
                return Table[variableName];
            }
            throw new SemanticError(
                $"Undeclared variable: {variableName}",
                node.AnchorToken);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_list node) {
            VisitChildren(node);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Stm_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if (Table.ContainsKey(variableName)) {
                return Table[variableName];
            }

            throw new SemanticError(
                $"Undeclared variable: {variableName}",
                node.AnchorToken);
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
            VisitChildren(node);
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

            if (Table.ContainsKey(variableName)) {
                return Table[variableName];
            }

            throw new SemanticError(
                $"Undeclared variable: {variableName}",
                node.AnchorToken);
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

            if (Table.ContainsKey(variableName)) {
                return Table[variableName];
            }

            throw new SemanticError(
                $"Undeclared variable: {variableName}",
                node.AnchorToken);
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
            VisitBinaryOperator('>', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(GreaterthanEquals node) {
            VisitBinaryOperator(">=", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Lessthan node) {
            VisitBinaryOperator('<', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(LessThanEquals node) {
            VisitBinaryOperator("<=", node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Plus node) {
            VisitBinaryOperator('+', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Minus node) {
            VisitBinaryOperator('-', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Multiplication node) {
            VisitBinaryOperator('*', node, Type.INT);
            return Type.VOID; // int? aaaa 
        }
         //-----------------------------------------------------------
        public Type Visit(Division node) {
            VisitBinaryOperator('/', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Percent node) {
            VisitBinaryOperator('%', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Positive node) {
            VisitBinaryOperator('+', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Negative node) {
            VisitBinaryOperator('-', node, Type.INT);
            return Type.VOID;
        }
         //-----------------------------------------------------------
        public Type Visit(Not node) {
            VisitBinaryOperator('!', node, Type.INT);
            return Type.VOID;
        } //-----------------------------------------------------------
        public Type Visit(Expr_primary_identifier node) {
            var variableName = node.AnchorToken.Lexeme;

            if (Table.ContainsKey(variableName)) {
                return Table[variableName];
            }

            throw new SemanticError(
                $"Undeclared variable: {variableName}",
                node.AnchorToken);
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
