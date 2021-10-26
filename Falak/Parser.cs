/*
 * Buttercup LL(1) Grammar:
 *
 *      Program             ::=  def-list EOF
        def-list            ::=  def*
        def                 ::=  var-def | fun-def
        var-def             ::=  var id-list 
        id-list             ::=  id id-list-cont
        id-list-cont        ::=  (, id)*
 *      fun-def             ::=  id (param-list ) { var-def-list stmt-list}
        param-list          ::=  id-list? 
        var-def-list        ::=  var-def*
        stm-list            ::=  stm*
        stm                 ::=  Id ( stmt-assign |  stmt-fun-call ) | 
                                  stmt-incr | stmt-decr |  | stmt-if | 
                                  stmt-while | stmt-do-while | stmt-break |
                                  stmt-return | stmt-empty
        stmt-assign         ::= "="‹expr›";"
 */
using System;
using System.Collections.Generic;
namespace Falak {

    class Parser {

        static readonly ISet<TokenCategory> firstOfExpr =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.PLUS,
                TokenCategory.MINUS,
                TokenCategory.EXCLAMATION,
                TokenCategory.STARTPARENTHESIS,
                TokenCategory.STARTBRACES,
                TokenCategory.CHAR,
                TokenCategory.TRUE,
                TokenCategory.FALSE,
                TokenCategory.STR,
                TokenCategory.INT
            };

        static readonly ISet<TokenCategory> firstOfDeflist =
            new HashSet<TokenCategory>() {
                TokenCategory.VAR,
                TokenCategory.IDENTIFIER,
            };
        static readonly ISet<TokenCategory> firstofliteral =
            new HashSet<TokenCategory>(){
                TokenCategory.CHAR,
                TokenCategory.TRUE,
                TokenCategory.FALSE,
                TokenCategory.STR,
                TokenCategory.INT
            };

        static readonly ISet<TokenCategory> firstOfStmtlist =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.INC,
                TokenCategory.DEC,
                TokenCategory.IF,
                TokenCategory.WHILE,
                TokenCategory.DO,
                TokenCategory.BREAK,
                TokenCategory.RETURN,
                TokenCategory.SEMICOLON
            };
        static readonly ISet<TokenCategory> firstofIf =
            new HashSet<TokenCategory>(){
                TokenCategory.ELSEIF,
                TokenCategory.ELSE,
            };
        static readonly ISet<TokenCategory> firstofOr =
            new HashSet<TokenCategory>(){
                TokenCategory.OR,
                TokenCategory.CIRCUMFLEX,
            };
        
        static readonly ISet<TokenCategory> firstOfUnary =
            new HashSet<TokenCategory>() {
                TokenCategory.MINUS,
                TokenCategory.PLUS,
                TokenCategory.EXCLAMATION
            };
        static readonly ISet<TokenCategory> firstofEquals =
            new HashSet<TokenCategory>(){
                TokenCategory.EQUALS,
                TokenCategory.DIFEQUAL
            };
        static readonly ISet<TokenCategory> firstofGreaterLess =
            new HashSet<TokenCategory>(){
                TokenCategory.LESSTHAN,
                TokenCategory.LESSTHANEQUAL,
                TokenCategory.GREATERTHAN,
                TokenCategory.GREATERTHANEQUAL
            };
        static readonly ISet<TokenCategory> firstofMul =
            new HashSet<TokenCategory>(){
                TokenCategory.MULTIPLICATION,
                TokenCategory.SLASH,
                TokenCategory.PERCENT
            };
        static readonly ISet<TokenCategory> firstOfSimpleExpression =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.STARTPARENTHESIS,
                TokenCategory.STARTCURLBRACES
            };

        IEnumerator<Token> tokenStream;

        public Parser(IEnumerator<Token> tokenStream) {
            this.tokenStream = tokenStream;
            this.tokenStream.MoveNext();
        }

        public TokenCategory CurrentToken {
            get { return tokenStream.Current.Category; }
        }

        public Token Expect(TokenCategory category) {
            if (CurrentToken == category) {
                Token current = tokenStream.Current;
                tokenStream.MoveNext();
                return current;
            } else {
                throw new SyntaxError(category, tokenStream.Current);
            }
        }

        public Node Program() {
            var varDefList = Def_list();
            Expect(TokenCategory.EOF);

            return new Program(){
                varDefList
            };
        }


        public Node Def_list() {
            var varDefList = new Def_list();
            while(firstOfDeflist.Contains(CurrentToken)){
                varDefList.Add(Def());
            } 
            return varDefList;
        }
        public Node Def() {

            var varDef = new Def();

            switch (CurrentToken) {
                case TokenCategory.VAR:
                    varDef.Add(Var_def());
                    break;
                case TokenCategory.IDENTIFIER:
                    varDef.Add(Fun_def());
                    break;
                default:
                    throw new SyntaxError(firstOfDeflist,
                                        tokenStream.Current);
            }
            return varDef;
        }
        public Node Var_def(){
            var varIdentifier = new Var_def(){
                AnchorToken = Expect(TokenCategory.VAR)
                }; 
            varIdentifier.Add(Id_list());
           
            Expect(TokenCategory.SEMICOLON);

            return varIdentifier;
        }
        public Node Id_list(){
            var idList = new Var_list_identifier();

            var id = new Var_identifier(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            };
            idList.Add(id);
            while(CurrentToken == TokenCategory.COMA){
                Expect(TokenCategory.COMA);
                var expr2 = new Var_identifier(){
                    AnchorToken =Expect(TokenCategory.IDENTIFIER)
                };

                idList.Add(expr2);
            }
            return idList;
        }

        public Node Fun_def(){
            var funDef = new Fun_def(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            };

            Expect(TokenCategory.STARTPARENTHESIS);
            if (CurrentToken == TokenCategory.IDENTIFIER){
                funDef.Add(Param_list());
            }
            Expect(TokenCategory.ENDPARENTHESIS);
            Expect(TokenCategory.STARTCURLBRACES);
            while(CurrentToken == TokenCategory.VAR){
                //param list????
                funDef.Add(Var_def());
            }
            while(firstOfStmtlist.Contains(CurrentToken)){
                funDef.Add(Statement());
            }
            Expect(TokenCategory.ENDCURLBRACES);
            return funDef;
        }
        public Node Param_list(){
            var Param_list_Node = new Param_list_identifier();
            Param_list_Node.Add(IdParam());
            while(CurrentToken == TokenCategory.COMA){
                Expect(TokenCategory.COMA);
                Param_list_Node.Add(IdParam());
            }
            return Param_list_Node;
        }
        public Node IdParam(){
            var id_Node = new Param_identifier(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            };
            return id_Node;
        }
        public Node Statement(){    //stm-list
            var statementVar = new Stm_list();
            
            while(firstOfStmtlist.Contains(CurrentToken)){
                var stmIdentifier = new Stm_identifier();
                switch (CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    stmIdentifier = new Stm_identifier(){
                        AnchorToken = Expect(TokenCategory.IDENTIFIER)
                    };
                    if(CurrentToken == TokenCategory.ASSIGNMENT){
                        stmIdentifier.Add(stmt_assign());
                    }else{
                        stmIdentifier.Add(stmt_fun_call());
                    }
                    break;
                case TokenCategory.INC:
                    stmIdentifier.Add(stmt_incr());
                    break;
                case TokenCategory.DEC:
                    stmIdentifier.Add(stmt_decr());
                    break;
                case TokenCategory.IF:
                     stmIdentifier.Add(If());
                    break;
                case TokenCategory.WHILE:
                    stmIdentifier.Add(While());
                    break;
                case TokenCategory.DO:
                    stmIdentifier.Add(DoWhile());
                    break;
                case TokenCategory.BREAK:
                    stmIdentifier.Add(Break());
                    break;
                case TokenCategory.RETURN:
                    stmIdentifier.Add(Return());
                    break;
                case TokenCategory.SEMICOLON:
                    Expect(TokenCategory.SEMICOLON);
                    break;
                default:
                    throw new SyntaxError(firstOfStmtlist,
                                        tokenStream.Current);
                }
                statementVar.Add(stmIdentifier);
            }
            return statementVar;
        }
        public Node stmt_assign() {
            var stmAssgn = new Stm_asign (){
                AnchorToken = Expect(TokenCategory.ASSIGNMENT)
            };
            stmAssgn.Add(Expression());
            Expect(TokenCategory.SEMICOLON);
            return stmAssgn;
        }
      
        public Node stmt_fun_call(){
            var stmFunCall = new Stm_funcall (){
                AnchorToken = Expect(TokenCategory.STARTPARENTHESIS)
            };
            stmFunCall.Add(ExpressionList());
            Expect(TokenCategory.ENDPARENTHESIS);
            Expect(TokenCategory.SEMICOLON);
            return stmFunCall;
        }
        public Node ExpressionList(){
            var exprlist = new Stm_funcall_Exprlist ();
            if (firstOfExpr.Contains(CurrentToken)){
                exprlist.Add(Expression());
                while(CurrentToken == TokenCategory.COMA){
                    Expect(TokenCategory.COMA);
                    exprlist.Add(Expression());
                }
            }      
            return exprlist;  
        }


        public Node stmt_incr(){
            var stmInc = new Stm_Inc(){
                AnchorToken =  Expect(TokenCategory.INC)
            };

            stmInc.Add(new Inc_identifier(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            });
            Expect(TokenCategory.SEMICOLON);
            
            return stmInc;
        }
        public Node stmt_decr(){
            var stmDec = new Stm_dec(){
                AnchorToken =  Expect(TokenCategory.DEC)
            };

            stmDec.Add(new Dec_identifier(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            });
            Expect(TokenCategory.SEMICOLON);
            
            return stmDec;            
        }
        public Node If() {
            var ifNode = new If(){
                AnchorToken = Expect(TokenCategory.IF)
            }; /////////Expression
            Expect(TokenCategory.STARTPARENTHESIS);
            ifNode.Add(Expression());
            Expect(TokenCategory.ENDPARENTHESIS);
            Expect(TokenCategory.STARTCURLBRACES);
             ifNode.Add(Statement());
            Expect(TokenCategory.ENDCURLBRACES);

            while (firstofIf.Contains(CurrentToken)) {
                var elseiflistnode = new Elseif_list();
                ifNode.Add(elseiflistnode);

                switch (CurrentToken) {
                    case TokenCategory.ELSEIF:
                        var elseifnode = new Elseif(){
                            AnchorToken = Expect(TokenCategory.ELSEIF)
                        };
                        elseiflistnode.Add(elseifnode);
                        Expect(TokenCategory.STARTPARENTHESIS);
                        elseifnode.Add(Expression());
                        Expect(TokenCategory.ENDPARENTHESIS);
                        Expect(TokenCategory.STARTCURLBRACES);
                        elseifnode.Add(Statement());
                        Expect(TokenCategory.ENDCURLBRACES);
                        //return elseifnode;
                        break;

                    case TokenCategory.ELSE:
                        var elseNode =  new Else(){
                            AnchorToken = Expect(TokenCategory.ELSE)
                        };
                        ifNode.Add(elseNode);
                        Expect(TokenCategory.STARTCURLBRACES);
                        elseNode.Add(Statement());
                        Expect(TokenCategory.ENDCURLBRACES);
                        //return elseNode;
                        break;
                    default:
                        throw new SyntaxError(firstofIf,
                                            tokenStream.Current);
                    }
                //return elseiflistnode;
            }
            return ifNode;
        }
        public Node While (){
            var whileNode = new While(){
                AnchorToken = Expect(TokenCategory.WHILE)
            };
             Expect(TokenCategory.STARTPARENTHESIS);
             whileNode.Add(Expression());
             Expect(TokenCategory.ENDPARENTHESIS);
             Expect(TokenCategory.STARTCURLBRACES);
             whileNode.Add(Statement());
             Expect(TokenCategory.ENDCURLBRACES);
             return whileNode;
        }
        public Node DoWhile(){
            var doNode = new Do (){
                AnchorToken = Expect(TokenCategory.DO)
            };
            Expect(TokenCategory.STARTCURLBRACES);
            doNode.Add(Statement());
            Expect(TokenCategory.ENDCURLBRACES);
            Expect(TokenCategory.WHILE);
            Expect(TokenCategory.STARTPARENTHESIS);
            doNode.Add(Expression());
            Expect(TokenCategory.ENDPARENTHESIS);
            return doNode;
        }
        public Node Break(){
            var breakNode = new Break(){
                AnchorToken =  Expect(TokenCategory.BREAK)
            };
            Expect(TokenCategory.SEMICOLON);
            return breakNode;
        }
        public Node Return(){
            var returnNode = new Return(){
                AnchorToken =  Expect(TokenCategory.RETURN)
            };
            returnNode.Add(Expression());
            Expect(TokenCategory.SEMICOLON);
            return returnNode;
        }
      
        public Node Expression() {
            var expr = Expression_and();
            while (firstofOr.Contains(CurrentToken)) {
                var exprOr = new Or();
                switch (CurrentToken){
                case TokenCategory.OR:
                    exprOr = new Or(){
                        AnchorToken = Expect(TokenCategory.OR)
                    };
                    exprOr.Add(expr);
                    exprOr.Add(Expression_and());
                    expr = exprOr;
                    break;

                case TokenCategory.CIRCUMFLEX:
                    exprOr = new Or(){
                           AnchorToken = Expect(TokenCategory.CIRCUMFLEX)
                    };
                    exprOr.Add(expr);
                    exprOr.Add(Expression_and());
                    expr = exprOr;
                    break;
                    
                default:
                    throw new SyntaxError(firstofOr,
                                        tokenStream.Current);
                } 
               
            }
            return expr;
        }
        public Node Expression_and(){
            var exprComp = Expression_comp();
            while (CurrentToken == TokenCategory.AND) {
                var exp2 = new AND(){
                    AnchorToken = Expect(TokenCategory.AND)
                };
                exp2.Add(exprComp);
                exp2.Add(Expression_comp());
                exprComp = exp2;
            }
            return exprComp;
        }

        public Node Expression_comp(){
            var exprel = Expression_rel();
            while (firstofEquals.Contains(CurrentToken)) {
                Node expr2;
                switch (CurrentToken){
                case TokenCategory.EQUALS:
                        expr2 = new Equals(){
                        AnchorToken = Expect(TokenCategory.EQUALS)
                    };
                    break;
                    
                case TokenCategory.DIFEQUAL:
                        expr2 = new Difequals(){
                        AnchorToken = Expect(TokenCategory.DIFEQUAL)
                    };
                    break;
                default:
                    throw new SyntaxError(firstofEquals,
                                        tokenStream.Current);
                }
                expr2.Add(exprel);  
                expr2.Add(Expression_rel());     
                exprel = expr2;
            }
            return exprel;
        }

        public Node Expression_rel(){
            var expadd = Expression_add();
            while (firstofGreaterLess.Contains(CurrentToken)) {
                Node expr2;
                switch (CurrentToken){
                case TokenCategory.GREATERTHAN:
                        expr2 = new Greaterthan(){
                        AnchorToken = Expect(TokenCategory.GREATERTHAN)
                    };
                    break;
                   
                case TokenCategory.GREATERTHANEQUAL:
                        expr2 = new GreaterthanEquals(){
                        AnchorToken = Expect(TokenCategory.GREATERTHANEQUAL)
                    };
                    break;

                case TokenCategory.LESSTHAN:
                        expr2 = new Lessthan(){
                        AnchorToken = Expect(TokenCategory.LESSTHAN)
                    };
                    break;

                case TokenCategory.LESSTHANEQUAL:
                        expr2 = new LessThanEquals(){
                        AnchorToken = Expect(TokenCategory.LESSTHANEQUAL)
                    };
                    break;

                default:
                    throw new SyntaxError(firstofGreaterLess,
                                        tokenStream.Current);
                }
                expr2.Add(expadd);  
                expr2.Add(Expression_add());     
                expadd = expr2;  
            }
            return expadd;
        }

        public Node Expression_add(){
            var exprmul = Expression_mul();
            while (CurrentToken == TokenCategory.PLUS || 
                   CurrentToken == TokenCategory.MINUS) {
                Node expr2;
                switch (CurrentToken){
                case TokenCategory.PLUS:
                    expr2 = new Plus(){
                    AnchorToken = Expect(TokenCategory.PLUS)
                };
                break;
                case TokenCategory.MINUS:
                        expr2 = new Minus(){ 
                        AnchorToken = Expect(TokenCategory.MINUS)
                    };
                    break;
                default:
                    throw new SyntaxError(TokenCategory.PLUS,
                                        tokenStream.Current);
                }  
                expr2.Add(exprmul);  
                expr2.Add(Expression_mul());     
                exprmul = expr2;
            }
            return exprmul;
        }

        public Node Expression_mul(){
            var expunary = Expression_unary();
            while (firstofMul.Contains(CurrentToken)) {
                Node expr2;
                switch (CurrentToken){
                case TokenCategory.MULTIPLICATION:
                        expr2 = new Multiplication(){
                        AnchorToken = Expect(TokenCategory.MULTIPLICATION)
                    };
                    break;

                case TokenCategory.SLASH:
                        expr2 = new Division(){
                        AnchorToken = Expect(TokenCategory.SLASH)
                    };
                    break;
                    
                case TokenCategory.PERCENT:
                        expr2 = new Percent(){
                        AnchorToken = Expect(TokenCategory.PERCENT)
                    };
                    break;
                    
                default:
                    throw new SyntaxError(firstofMul,
                                        tokenStream.Current);
                }  
                expr2.Add(expunary);  
                expr2.Add(Expression_unary());     
                expunary = expr2;
            }
            return expunary;
        }
        ///////aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaah!
        public Node Expression_unary(){
            if (firstOfUnary.Contains(CurrentToken)) {
               Node expr2;
               switch (CurrentToken){
                case TokenCategory.PLUS:
                        expr2 = new Positive(){ 
                        AnchorToken = Expect(TokenCategory.PLUS)
                    };
                    break;
                    
                case TokenCategory.MINUS:
                        expr2 = new Negative(){
                        AnchorToken = Expect(TokenCategory.MINUS)
                    };
                    break;
                    
                case TokenCategory.EXCLAMATION:
                        expr2 = new Not(){
                        AnchorToken =  Expect(TokenCategory.EXCLAMATION)
                    };
                    break;
                    
                default:
                    throw new SyntaxError(firstOfUnary,
                                        tokenStream.Current);
                }  
                expr2.Add(Expression_unary());     
                return expr2;
            }
            else{
                return Expression_primary();

            }
        }

        public Node Expression_primary(){
            Node expr;
            switch (CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    expr = new Expr_primary_identifier(){
                        AnchorToken = Expect(TokenCategory.IDENTIFIER)
                    };
                        if(CurrentToken == TokenCategory.STARTPARENTHESIS){
                            Expect(TokenCategory.STARTPARENTHESIS);
                            expr.Add(ExpressionList());
                            Expect(TokenCategory.ENDPARENTHESIS);
                        }
                    return expr;
                    
                case TokenCategory.STARTBRACES:
                    expr = new Expr_primary_list(){
                        AnchorToken = Expect(TokenCategory.STARTBRACES)
                    };
                    expr.Add(ExpressionList());
                    Expect(TokenCategory.ENDBRACES);
                    return expr;

                case TokenCategory.STARTPARENTHESIS:
                    expr = new Expr_primary_expr(){
                        AnchorToken = Expect(TokenCategory.STARTPARENTHESIS)
                    };
                    expr.Add(Expression());
                    Expect(TokenCategory.ENDPARENTHESIS);
                    return expr;

                case TokenCategory.INT:
                case TokenCategory.STR:
                case TokenCategory.CHAR:
                case TokenCategory.TRUE:
                case TokenCategory.FALSE:
                    return Lit();
                                      
                default:
                    throw new SyntaxError(firstOfSimpleExpression,
                                        tokenStream.Current);
            }
            return expr;
        }
        public Node Lit(){
            Node litNode; 
            switch (CurrentToken){
                case TokenCategory.TRUE:
                    return litNode = new Lit_true(){
                        AnchorToken = Expect(TokenCategory.TRUE)
                    };

                case TokenCategory.FALSE:
                    return litNode = new Lit_false(){
                        AnchorToken = Expect(TokenCategory.FALSE)
                    };
                    
                case TokenCategory.INT:
                    return litNode = new Lit_int(){
                        AnchorToken = Expect(TokenCategory.INT)
                    };

                case TokenCategory.CHAR:
                    return litNode = new Lit_char(){
                        AnchorToken =  Expect(TokenCategory.CHAR)
                    };

                case TokenCategory.STR:
                    return litNode = new Lit_str(){
                        AnchorToken = Expect(TokenCategory.STR)
                    };
                default:
                    throw new SyntaxError(firstofliteral,
                                        tokenStream.Current);
            }
            return litNode;
        }
    }
}
