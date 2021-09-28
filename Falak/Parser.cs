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

        static readonly ISet<TokenCategory> firstOfDeflist =
            new HashSet<TokenCategory>() {
                TokenCategory.VAR,
                TokenCategory.INT,
                TokenCategory.IDENTIFIER,
                TokenCategory.CHAR,
                TokenCategory.BOOL,
                TokenCategory.CHAR,
                TokenCategory.STR
            };

        static readonly ISet<TokenCategory> firstOfStmtlist =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.INC,
                TokenCategory.DEC,
                TokenCategory.IF,
                TokenCategory.ELSEIF,
                TokenCategory.ELSE,
                TokenCategory.WHILE,
                TokenCategory.DO,
                TokenCategory.BREAK,
                TokenCategory.RETURN,
                TokenCategory.SEMICOLON,
                TokenCategory.COMA
            };

        static readonly ISet<TokenCategory> firstOfOperator =
            new HashSet<TokenCategory>() {
                TokenCategory.OR,
                TokenCategory.CIRCUMFLEX,
                TokenCategory.AND,
                TokenCategory.MINUS,
                TokenCategory.PLUS,
                TokenCategory.EXCLAMATION,
                TokenCategory.MULTIPLICATION,
                TokenCategory.SLASH,
                TokenCategory.PERCENT
            };

        static readonly ISet<TokenCategory> firstOfSimpleExpression =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.LESSTHAN,
                TokenCategory.LESSTHANEQUAL,
                TokenCategory.EQUALS,
                TokenCategory.DIFEQUAL,
                TokenCategory.GREATERTHAN,
                TokenCategory.GREATERTHANEQUAL,
                TokenCategory.TRUE,
                TokenCategory.FALSE,
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
            while(firstOfStmtlist.Contains(CurrentToken)){
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
                    if(TokenCategory.EQUALS){
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
                    Expect(TokenCategory.SEMICOLON);/////No se si esta bien?
                    break;
                default:
                    throw new SyntaxError(firstOfStatement,
                                        tokenStream.Current);
                }
            }
        }
        public void stmt_assign() {
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.EQUALS);
            Expression();
            Expect(TokenCategory.SEMICOLON);
        }
        public void stmt_fun_call(){
            Expect(TokenCategory.STARTPARENTHESIS);
            Expression();
            while(firstOfStmtlist.Contains(CurrentToken)){
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
            while (firstOfStmtlist.Contains(CurrentToken)) {
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
                        throw new SyntaxError(firstOfStatement,
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
            while (firstOfOperator.Contains(CurrentToken)) {
                Expect(TokenCategory.OR|TokenCategory.CIRCUMFLEX);
                Expression_and();
            }
        }
        public void Expression_and(){
            Expression_comp();
            while (firstOfOperator.Contains(CurrentToken)) {
                Expect(TokenCategory.AND);
                Expression_comp();
            }
        }

        public void Expression_comp(){
            Expression_rel();
            while (firstOfOperator.Contains(CurrentToken)) {
                Expect(TokenCategory.EQUALS|TokenCategory.DIFEQUAL);
                Expression_rel();
            }
        }

        public void Expression_rel(){
            Expression_add();
            while (firstOfOperator.Contains(CurrentToken)) {
                Expect(TokenCategory.LESSTHAN|TokenCategory.LESSTHANEQUAL|
                TokenCategory.GREATERTHAN|TokenCategory.GREATERTHANEQUAL);
                Expression_add();
            }
        }

        public void Expression_add(){
            Expression_mul();
            while (firstOfOperator.Contains(CurrentToken)) {
                Expect(TokenCategory.PLUS|TokenCategory.MINUS);
                Expression_mul();
            }
        }

        public void Expression_mul(){
            Expression_unary();
            while (firstOfOperator.Contains(CurrentToken)) {
                Expect(TokenCategory.MULTIPLICATION|TokenCategory.SLASH|
                TokenCategory.PERCENT);
                Expression_unary();
            }
        }
        public void Expression_unary(){
            Expression_primary();
            while (firstOfOperator.Contains(CurrentToken)) {
                Expect(TokenCategory.PLUS|TokenCategory.MINUS|
                TokenCategory.EXCLAMATION);
                Expression_primary();
            }
        }

        public void Expression_primary(){
            switch (CurrentToken) {
                case TokenCategory.IDENTIFIER:
                    Expect(TokenCategory.IDENTIFIER);
                    Expect(TokenCategory.STARTPARENTHESIS);
                    Expression();
                    break;
                case TokenCategory.STARTBRACES:
                    Expect(TokenCategory.STARTBRACES);
                    Expression();
                    break;
                case TokenCategory.STARTPARENTHESIS:
                    Expect(TokenCategory.STARTPARENTHESIS);
                    Expression();
                    break;
                case firstOfDeflist.Contains:
                    Lit();
                    break;
                default:
                    throw new SyntaxError(firstOfStatement,
                                        tokenStream.Current);
            }
        }
        public void Lit(){
            switch (CurrentToken){
                case TokenCategory.BOOL:
                    Expect(TokenCategory.BOOL);
                    break;
                case TokenCategory.INT:
                    Expect(TokenCategory.INT);
                    break;
                case TokenCategory.CHAR:
                    Expect(TokenCategory.CHAR);
                    break;
                case TokenCategory.STARTBRACES:
                    Expect(TokenCategory.STR);
                    break;
            }
        }
        
    }
}
