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
        stm-list            ::= stm*
        stm                 ::= stmt-assign | stmt-incr | stmt-decr | stmt-fun-call
                                 | stmt-if | stmt-while | stmt-do-while | stmt-break 
                                 | stmt-return | stmt-empty
        stm-assign          ::= id = expr ;
        stmt-incr           ::= inc id ;
        stmt-decr           ::= dec id ;
        stmt-fun-call       ::= fun-call
        fun-call            ::= id ( expr-list )
        expr-list           ::= ( expr expr-list-cont)?
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
                TokenCategory.CHAR
            };

        static readonly ISet<TokenCategory> firstOfStmtlist =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.IF,
                TokenCategory.DO,
                TokenCategory.ELSE,
                TokenCategory.ELSEIF,
                TokenCategory.RETURN,
                TokenCategory.WHILE
            };

        static readonly ISet<TokenCategory> firstOfOperator =
            new HashSet<TokenCategory>() {
                TokenCategory.AND,
                TokenCategory.OR,
                TokenCategory.MULTIPLICATION,
                TokenCategory.SLASH,
                TokenCategory.PERCENT,
                TokenCategory.CIRCUMFLEX,    
                TokenCategory.LESS,
                TokenCategory.PLUS,
                TokenCategory.MUL,
                TokenCategory.DEC,
                TokenCategory.INC
            };

        static readonly ISet<TokenCategory> firstOfSimpleExpression =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.LESSTHANEQUAL,
                TokenCategory.GREATERTHANEQUAL,
                TokenCategory.LESSTHAN,
                TokenCategory.GREATERTHAN,
                TokenCategory.TRUE,
                TokenCategory.FALSE,
                TokenCategory.STARTPARENTHESIS,
                TokenCategory.STARTCURLBRACES,
                TokenCategory.EXCLAMATION
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
/// aqui no esta bien UnU 
        public void Def() {

            switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
                Assignment();
                break;

            case TokenCategory.PRINT:
                Print();
                break;

            case TokenCategory.IF:
                If();
                break;

            default:
                throw new SyntaxError(firstOfStatement,
                                      tokenStream.Current);
            }
        }

        public void Type() {
            switch (CurrentToken) {

            case TokenCategory.INT:
                Expect(TokenCategory.INT);
                break;

            case TokenCategory.BOOL:
                Expect(TokenCategory.BOOL);
                break;

            default:
                throw new SyntaxError(firstOfDeclaration,
                                      tokenStream.Current);
            }
        }

        public void Assignment() {
            Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.ASSIGN);
            Expression();
        }

        public void Print() {
            Expect(TokenCategory.PRINT);
            Expression();
        }

        public void If() {
            Expect(TokenCategory.IF);
            Expression();
            Expect(TokenCategory.THEN);
            while (firstOfStatement.Contains(CurrentToken)) {
                Statement();
            }
            Expect(TokenCategory.END);
        }

        public void Expression() {
            SimpleExpression();
            while (firstOfOperator.Contains(CurrentToken)) {
                Operator();
                SimpleExpression();
            }
        }

        public void SimpleExpression() {

            switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
                Expect(TokenCategory.IDENTIFIER);
                break;

            case TokenCategory.INT_LITERAL:
                Expect(TokenCategory.INT_LITERAL);
                break;

            case TokenCategory.TRUE:
                Expect(TokenCategory.TRUE);
                break;

            case TokenCategory.FALSE:
                Expect(TokenCategory.FALSE);
                break;

            case TokenCategory.PARENTHESIS_OPEN:
                Expect(TokenCategory.PARENTHESIS_OPEN);
                Expression();
                Expect(TokenCategory.PARENTHESIS_CLOSE);
                break;

            case TokenCategory.NEG:
                Expect(TokenCategory.NEG);
                SimpleExpression();
                break;

            default:
                throw new SyntaxError(firstOfSimpleExpression,
                                      tokenStream.Current);
            }
        }

        public void Operator() {

            switch (CurrentToken) {

            case TokenCategory.AND:
                Expect(TokenCategory.AND);
                break;

            case TokenCategory.LESS:
                Expect(TokenCategory.LESS);
                break;

            case  TokenCategory.PLUS:
                Expect(TokenCategory.PLUS);
                break;

            case TokenCategory.MUL:
                Expect(TokenCategory.MUL);
                break;

            default:
                throw new SyntaxError(firstOfOperator,
                                      tokenStream.Current);
            }
        }
    }
}
