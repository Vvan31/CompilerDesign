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
//TERMINAR SETS DE TOKENS Y ACTUALIZAR DEPENDENCIAS 
//CREAR SWITCHCASE EN LUGAR DE OR EXPECT
//PASAR CONTEXTO AL DEFAULT CASE PARA EL ERROR 
//CREAR REGEX PARA CHAR,STRING, INT 
//ELIMINAR TOKENS EXTRA (CHAR, BOOL) 
//VERIFICAR ORDEN DE TOKENS 
//VERIFICAR QUE SE HACE EXPECT EN EL 
    //CURRENTTOKEN PARA PASAR AL SIGUIENTE
using System;
using System.Collections.Generic;

namespace Falak {

    class Parser {

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

        public void Program() {
            Def_list();
            Expect(TokenCategory.EOF);
        }
        public void Def_list() {
            while(firstOfDeflist.Contains(CurrentToken)){
                Def();
            }
        }
        public void Def() {
            switch (CurrentToken) {
                case TokenCategory.VAR:
                    Var_def();
                    break;
                case TokenCategory.IDENTIFIER:
                    Fun_def();
                    break;
                default:
                    throw new SyntaxError(firstOfStatement,
                                        tokenStream.Current);
            }
        }
        public void Var_def(){
            Expect(TokenCategory.VAR);
            Id_list(); 
        }
        public void Id_list(){
            Expect(TokenCategory.IDENTIFIER);
            while(CurrentToken == TokenCategory.COMA){
                Expect(TokenCategory.COMA);
                Expect(TokenCategory.IDENTIFIER);
            }
        }
        public void Fun_def(){
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.STARTPARENTHESIS);
            Id_list();
            Expect(TokenCategory.STARTCURLBRACES);
            while(firstOfDeflist.Contains(CurrentToken)){
                Var_def();
            }
            while(firstOfStmtlist.Contains(CurrentToken)){
                Statement();
            }
        }
        public void Statement(){
            while(firstOfStmtlist.Contains(CurrentToken)){
                switch (CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    Expect(TokenCategory.IDENTIFIER);
                    if(CurrentToken == TokenCategory.EQUALS){
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
                    throw new SyntaxError(firstOfStatement,
                                        tokenStream.Current);
                }
            }
        }
        public void stmt_assign() {
            Expect(TokenCategory.EQUALS);
            Expression();
            Expect(TokenCategory.SEMICOLON);
        }
        public void stmt_fun_call(){
            Expect(TokenCategory.STARTPARENTHESIS);
            Expression();
            while(CurrentToken == TokenCategory.COMA){
                Expect(TokenCategory.COMA);
                Expression();
            }
        }
        public void stmt_incr(){
            Expect(TokenCategory.INC);
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.SEMICOLON);
        }
        public void stmt_decr(){
            Expect(TokenCategory.DEC);
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.SEMICOLON);
        }
        public void If() {
            Expect(TokenCategory.IF);
            Expect(TokenCategory.STARTPARENTHESIS);
            Expression();
            Expect(TokenCategory.STARTCURLBRACES);
            Statement();
            while (firstofIf.Contains(CurrentToken)) {
                switch (CurrentToken) {
                    case TokenCategory.ELSEIF:
                        Expect(TokenCategory.ELSEIF);
                        Expect(TokenCategory.STARTPARENTHESIS);
                        Expression();
                        Expect(TokenCategory.STARTCURLBRACES);
                        Statement();
                        break;

                    case TokenCategory.ELSE:
                        Expect(TokenCategory.ELSE);
                        Expect(TokenCategory.STARTCURLBRACES);
                        Statement();
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
             Expect(TokenCategory.STARTCURLBRACES);
             Statement();
        }
        public void DoWhile(){
            Expect(TokenCategory.DO);
            Expect(TokenCategory.STARTCURLBRACES);
            Statement();
            Expect(TokenCategory.WHILE);
            Expect(TokenCategory.STARTPARENTHESIS);
            Expression();
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
                Expect(TokenCategory.OR|TokenCategory.CIRCUMFLEX);
                Expression_and();
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
                case TokenCategory.DIFEQUALS:
                    Expect(TokenCategory.DIFEQUALS);
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
                    throw new SyntaxError(TokenCategory.PLUS,TokenCategory.MINUS,
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
            Expression_primary();
            while (firstOfUnary.Contains(CurrentToken)) {
               switch (CurrentToken){
                case TokenCategory.PLUS:
                    Expect(TokenCategory.PLUS);
                    Expression_primary();
                    break;
                case TokenCategory.MINUS:
                    Expect(TokenCategory.MINUS);
                    Expression_primary();
                    break;
                case TokenCategory.EXCLAMATION:
                    Expect(TokenCategory.EXCLAMATION);
                    Expression_primary();
                    break;
                default:
                    throw new SyntaxError(firstOfUnary,
                                        tokenStream.Current);
                }  
            }
        }

        public void Expression_primary(){
            switch (CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    Expect(TokenCategory.IDENTIFIER);
                        while(CurrentToken == TokenCategory.STARTPARENTHESIS){
                            Expect(TokenCategory.STARTPARENTHESIS);
                            Expression();
                        }
                    break;
                case TokenCategory.STARTBRACES:
                    Expect(TokenCategory.STARTBRACES);
                    Expression();
                    break;
                case TokenCategory.STARTPARENTHESIS:
                    Expect(TokenCategory.STARTPARENTHESIS);
                    Expression();
                    break;
                case firstofliteral.Contains(CurrentToken):
                    Lit();
                    break;
                default:
                    throw new SyntaxError(firstOfSimpleExpression,firstofliteral,
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
