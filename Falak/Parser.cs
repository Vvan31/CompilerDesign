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

        public node Program() {
            var varDefList = Def_list();
            Expect(TokenCategory.EOF);

            return new Program(){
                varDefList
            };
        }


        public Node Def_list() {
            //var decList = new 

            var varDefList = new DefList();

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
            var varIdentifier = new Var_identifier(){
                AnchorToken = Expect(TokenCategory.VAR)
                }; 
            varIdentifier.Add(Id_list());
           
            Expect(TokenCategory.SEMICOLON);

            return varIdentifier;
        }
        public Node Id_list(){
            var idList = new Id_list(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            };

            while(CurrentToken == TokenCategory.COMA){
                Expect(TokenCategory.COMA);

                idList.Add(Expect(TokenCategory.IDENTIFIER));
            }

            return idList;
        }
        public Node Fun_def(){
            var funDef = new Fun_def(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            };

            Expect(TokenCategory.STARTPARENTHESIS);
            if (CurrentToken == TokenCategory.IDENTIFIER){
                funDef.Add(Id_list());
            }
            Expect(TokenCategory.ENDPARENTHESIS);
            Expect(TokenCategory.STARTCURLBRACES);
            while(CurrentToken == TokenCategory.VAR){
                funDef.Add(Var_def());
            }
            while(firstOfStmtlist.Contains(CurrentToken)){
                funDef.Add(Statement());
            }
            Expect(TokenCategory.ENDCURLBRACES);
            return funDef;
        }
        public Node Statement(){    //stm-list
            var statementVar = new Stm_list();
            
            while(firstOfStmtlist.Contains(CurrentToken)){
                switch (CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    var stmIdentifier = new Stm_identifier(){
                        AnchorToken = Expect(TokenCategory.IDENTIFIER)
                    };
                    if(CurrentToken == TokenCategory.ASSIGNMENT){
                        stmt_assign();
                    }else{
                        stmt_fun_call();
                    }
                    break;
                case TokenCategory.INC:
                
                    stmt_incr();
                    break;
                case TokenCategory.DEC:
                    stmt_decr();
                    break;
                case TokenCategory.IF:
                    If();
                    break;
                case TokenCategory.WHILE:
                    While();
                    break;
                case TokenCategory.DO:
                    DoWhile();
                    break;
                case TokenCategory.BREAK:
                    Break();
                    break;
                case TokenCategory.RETURN:
                    Return();
                    break;
                case TokenCategory.SEMICOLON:
                    Expect(TokenCategory.SEMICOLON);
                    break;
                default:
                    throw new SyntaxError(firstOfStmtlist,
                                        tokenStream.Current);
                }
            }
        }
        public void stmt_assign() {
            Expect(TokenCategory.ASSIGNMENT);
            Expression();
            Expect(TokenCategory.SEMICOLON);
        }
      
        public void stmt_fun_call(){
            Expect(TokenCategory.STARTPARENTHESIS);
            ExpressionList();
            Expect(TokenCategory.ENDPARENTHESIS);
            Expect(TokenCategory.SEMICOLON);
        }
        public void ExpressionList(){
            if (firstOfExpr.Contains(CurrentToken)){
                Expression();
                while(CurrentToken == TokenCategory.COMA){
                    Expect(TokenCategory.COMA);
                    Expression();
                }
            }        
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
        public void stmt_decr(){
            var stmDec = new Stm_dec(){
                AnchorToken =  Expect(TokenCategory.DEC)
            };

            stmDec.Add(new Dec_identifier(){
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            });
            Expect(TokenCategory.SEMICOLON);
            
            return stmDec;            
        }
        public void If() {
            Expect(TokenCategory.IF);
            Expect(TokenCategory.STARTPARENTHESIS);
            Expression();
            Expect(TokenCategory.ENDPARENTHESIS);
            Expect(TokenCategory.STARTCURLBRACES);
            Statement();
            Expect(TokenCategory.ENDCURLBRACES);
            while (firstofIf.Contains(CurrentToken)) {
                switch (CurrentToken) {
                    case TokenCategory.ELSEIF:
                        Expect(TokenCategory.ELSEIF);
                        Expect(TokenCategory.STARTPARENTHESIS);
                        Expression();
                        Expect(TokenCategory.ENDPARENTHESIS);
                        Expect(TokenCategory.STARTCURLBRACES);
                        Statement();
                        Expect(TokenCategory.ENDCURLBRACES);
                        break;

                    case TokenCategory.ELSE:
                        Expect(TokenCategory.ELSE);
                        Expect(TokenCategory.STARTCURLBRACES);
                        Statement();
                        Expect(TokenCategory.ENDCURLBRACES);

                        break;
                    default:
                        throw new SyntaxError(firstofIf,
                                            tokenStream.Current);
                    }
            }
        }
        public void While (){
             Expect(TokenCategory.WHILE);
             Expect(TokenCategory.STARTPARENTHESIS);
             Expression();
             Expect(TokenCategory.ENDPARENTHESIS);
             Expect(TokenCategory.STARTCURLBRACES);
             Statement();
             Expect(TokenCategory.ENDCURLBRACES);
        }
        public void DoWhile(){
            Expect(TokenCategory.DO);
            Expect(TokenCategory.STARTCURLBRACES);
            Statement();
            Expect(TokenCategory.ENDCURLBRACES);
            Expect(TokenCategory.WHILE);
            Expect(TokenCategory.STARTPARENTHESIS);
            Expression();
            Expect(TokenCategory.ENDPARENTHESIS);
        }
        public void Break(){
            Expect(TokenCategory.BREAK);
            Expect(TokenCategory.SEMICOLON);
        }
        public void Return(){
            Expect(TokenCategory.RETURN);
            Expression();
            Expect(TokenCategory.SEMICOLON);
        }
      
        public void Expression() {
            Expression_and();
            while (firstofOr.Contains(CurrentToken)) {
                switch (CurrentToken){
                case TokenCategory.OR:
                    Expect(TokenCategory.OR);
                    Expression_and();
                    break;
                case TokenCategory.CIRCUMFLEX:
                    Expect(TokenCategory.CIRCUMFLEX);
                    Expression_and();
                    break;
                default:
                    throw new SyntaxError(firstofOr,
                                        tokenStream.Current);
                } 
               
            }
        }
        public void Expression_and(){
            Expression_comp();
            while (CurrentToken == TokenCategory.AND) {
                Expect(TokenCategory.AND);
                Expression_comp();
            }
        }

        public void Expression_comp(){
            Expression_rel();
            while (firstofEquals.Contains(CurrentToken)) {
                switch (CurrentToken){
                case TokenCategory.EQUALS:
                    Expect(TokenCategory.EQUALS);
                    Expression_rel();
                    break;
                case TokenCategory.DIFEQUAL:
                    Expect(TokenCategory.DIFEQUAL);
                    Expression_rel();
                    break;
                default:
                    throw new SyntaxError(firstofEquals,
                                        tokenStream.Current);
                }        
            }
        }

        public void Expression_rel(){
            Expression_add();
            while (firstofGreaterLess.Contains(CurrentToken)) {
                switch (CurrentToken){
                case TokenCategory.GREATERTHAN:
                    Expect(TokenCategory.GREATERTHAN);
                    Expression_add();
                    break;
                case TokenCategory.GREATERTHANEQUAL:
                    Expect(TokenCategory.GREATERTHANEQUAL);
                    Expression_add();
                    break;
                case TokenCategory.LESSTHAN:
                    Expect(TokenCategory.LESSTHAN);
                    Expression_add();
                    break;
                case TokenCategory.LESSTHANEQUAL:
                    Expect(TokenCategory.LESSTHANEQUAL);
                    Expression_add();
                    break;
                default:
                    throw new SyntaxError(firstofGreaterLess,
                                        tokenStream.Current);
                }  
            }
        }

        public void Expression_add(){
            Expression_mul();
            while (CurrentToken == TokenCategory.PLUS || CurrentToken == TokenCategory.MINUS) {
                switch (CurrentToken){
                case TokenCategory.PLUS:
                    Expect(TokenCategory.PLUS);
                    Expression_mul();
                    break;
                case TokenCategory.MINUS:
                    Expect(TokenCategory.MINUS);
                    Expression_mul();
                    break;
                default:
                    throw new SyntaxError(TokenCategory.PLUS,
                                        tokenStream.Current);
                }  
            }
        }

        public void Expression_mul(){
            Expression_unary();
            while (firstofMul.Contains(CurrentToken)) {
                switch (CurrentToken){
                case TokenCategory.MULTIPLICATION:
                    Expect(TokenCategory.MULTIPLICATION);
                    Expression_unary();
                    break;
                case TokenCategory.SLASH:
                    Expect(TokenCategory.SLASH);
                    Expression_unary();
                    break;
                case TokenCategory.PERCENT:
                    Expect(TokenCategory.PERCENT);
                    Expression_unary();
                    break;
                default:
                    throw new SyntaxError(firstofMul,
                                        tokenStream.Current);
                }  
            }
        }
        public void Expression_unary(){
            
            if (firstOfUnary.Contains(CurrentToken)) {
               switch (CurrentToken){
                case TokenCategory.PLUS:
                    Expect(TokenCategory.PLUS);
                    Expression_unary();
                    break;
                case TokenCategory.MINUS:
                    Expect(TokenCategory.MINUS);
                    Expression_unary();
                    break;
                case TokenCategory.EXCLAMATION:
                    Expect(TokenCategory.EXCLAMATION);
                    Expression_unary();
                    break;
                default:
                    throw new SyntaxError(firstOfUnary,
                                        tokenStream.Current);
                }  
            }
            else{
                Expression_primary();

            }
        }

        public void Expression_primary(){
            switch (CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    Expect(TokenCategory.IDENTIFIER);
                        if(CurrentToken == TokenCategory.STARTPARENTHESIS){
                            Expect(TokenCategory.STARTPARENTHESIS);
                            ExpressionList();

                            Expect(TokenCategory.ENDPARENTHESIS);
                        }
                    break;
                case TokenCategory.STARTBRACES:
                    Expect(TokenCategory.STARTBRACES);
                    ExpressionList();

                    Expect(TokenCategory.ENDBRACES);
                    break;
                case TokenCategory.STARTPARENTHESIS:
                    Expect(TokenCategory.STARTPARENTHESIS);
                    Expression();

                    Expect(TokenCategory.ENDPARENTHESIS);
                    break;
                case TokenCategory.INT:
                    Lit();
                    break;
                case TokenCategory.STR:
                    Lit();
                    break;
                case TokenCategory.CHAR:
                    Lit();
                    break;
                case TokenCategory.TRUE:
                    Lit();
                    break;

                    Expect(TokenCategory.ENDPARENTHESIS);
                    break;
                case TokenCategory.INT:
                    Lit();
                    break;
                case TokenCategory.STR:
                    Lit();
                    break;
                case TokenCategory.CHAR:
                    Lit();
                    break;
                case TokenCategory.TRUE:
                    Lit();
                    break;

                case TokenCategory.FALSE:
                    Lit();
                    break;                    
                default:
                    throw new SyntaxError(firstOfSimpleExpression,
                                        tokenStream.Current);
            }
        }
        public void Lit(){
            switch (CurrentToken){
                case TokenCategory.TRUE:
                    Expect(TokenCategory.TRUE);
                    break;
                case TokenCategory.FALSE:
                    Expect(TokenCategory.FALSE);
                    break;
                case TokenCategory.INT:
                    Expect(TokenCategory.INT);
                    break;
                case TokenCategory.CHAR:
                    Expect(TokenCategory.CHAR);
                    break;
                case TokenCategory.STR:
                    Expect(TokenCategory.STR);
                    break;
                default:
                    throw new SyntaxError(firstofliteral,
                                        tokenStream.Current);
            }
        }
    }
}
