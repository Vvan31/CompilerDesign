/*
  Buttercup compiler - This class performs the syntactic analysis,
  (a.k.a. parsing).
  Copyright (C) 2013-2021 Ariel Ortiz, ITESM CEM

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

/*
 * Buttercup LL(1) Grammar:
 *
 *      Program             ::=  Declaration* Statement* EOF
 *      Declaration         ::=  Type Identifier
 *      Type                ::=  "int" | "bool"
 *      Statement           ::=  Assignment | Print | If
 *      Assignment          ::=  Identifier "=" Expression
 *      Print               ::=  "print" Expression
 *      If                  ::=  "if" Expression "then" Statement* "end"
 *      Expression          ::=  SimpleExpression (Operator SimpleExpression)*
 *      Operator›           ::=  "&" | "<" | "+" | "*"
 *      SimpleExpression    ::=  Identifier | IntLiteral | "#t" | "#f"
 *                               | "(" Expression ")" | "-" SimpleExpression
 */

using System;
using System.Collections.Generic;

namespace Buttercup {

    class Parser {

        static readonly ISet<TokenCategory> firstOfDeclaration =
            new HashSet<TokenCategory>() {
                TokenCategory.INT,
                TokenCategory.BOOL
            };

        static readonly ISet<TokenCategory> firstOfStatement =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.PRINT,
                TokenCategory.IF
            };

        static readonly ISet<TokenCategory> firstOfOperator =
            new HashSet<TokenCategory>() {
                TokenCategory.AND,
                TokenCategory.LESS,
                TokenCategory.PLUS,
                TokenCategory.MUL
            };

        static readonly ISet<TokenCategory> firstOfSimpleExpression =
            new HashSet<TokenCategory>() {
                TokenCategory.IDENTIFIER,
                TokenCategory.INT_LITERAL,
                TokenCategory.TRUE,
                TokenCategory.FALSE,
                TokenCategory.PARENTHESIS_OPEN,
                TokenCategory.NEG
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

            var declList = new DeclarationList();
            var stmtList = new StatementList();

            while (firstOfDeclaration.Contains(CurrentToken)) {
                declList.Add(Declaration());
            }

            while (firstOfStatement.Contains(CurrentToken)) {
                stmtList.Add(Statement());
            }

            Expect(TokenCategory.EOF);

            return new Program() {
                declList,
                stmtList
            };
        }

        public Node Declaration() {
            var result = new Declaration() {
                AnchorToken = Type()
            };
            result.Add(new Identifier() {
                AnchorToken = Expect(TokenCategory.IDENTIFIER)
            });
            return result;
        }

        public Node Statement() {

            switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
                return Assignment();

            case TokenCategory.PRINT:
                return Print();

            case TokenCategory.IF:
                return If();

            default:
                throw new SyntaxError(firstOfStatement,
                                      tokenStream.Current);
            }
        }

        public Token Type() {

            switch (CurrentToken) {

            case TokenCategory.INT:
                return Expect(TokenCategory.INT);

            case TokenCategory.BOOL:
                return Expect(TokenCategory.BOOL);

            default:
                throw new SyntaxError(firstOfDeclaration,
                                      tokenStream.Current);
            }
        }

        public Node Assignment() {
            var idToken = Expect(TokenCategory.IDENTIFIER);
            Expect(TokenCategory.ASSIGN);
            var expr = Expression();
            var result = new Assignment() { expr };
            result.AnchorToken = idToken;
            return result;
        }

        public Node Print() {
            var printToken = Expect(TokenCategory.PRINT);
            var expr = Expression();
            var result = new Print() { expr };
            result.AnchorToken = printToken;
            return result;
        }

        public Node If() {
            var ifToken = Expect(TokenCategory.IF);
            var expr = Expression();
            Expect(TokenCategory.THEN);
            var stmtList = new StatementList();
            while (firstOfStatement.Contains(CurrentToken)) {
                stmtList.Add(Statement());
            }
            Expect(TokenCategory.END);
            var result = new If() { expr, stmtList };
            result.AnchorToken = ifToken;
            return result;
        }

        public Node Expression() {
            var expr1 = SimpleExpression();
            while (firstOfOperator.Contains(CurrentToken)) {
                var expr2 = Operator();
                expr2.Add(expr1);
                expr2.Add(SimpleExpression());
                expr1 = expr2;
            }
            return expr1;
        }

        public Node SimpleExpression() {

            switch (CurrentToken) {

            case TokenCategory.IDENTIFIER:
                return new Identifier() {
                    AnchorToken = Expect(TokenCategory.IDENTIFIER)
                };

            case TokenCategory.INT_LITERAL:
                return new IntLiteral() {
                    AnchorToken = Expect(TokenCategory.INT_LITERAL)
                };

            case TokenCategory.TRUE:
                return new True() {
                    AnchorToken = Expect(TokenCategory.TRUE)
                };

            case TokenCategory.FALSE:
                return new False() {
                    AnchorToken = Expect(TokenCategory.FALSE)
                };

            case TokenCategory.PARENTHESIS_OPEN: {
                Expect(TokenCategory.PARENTHESIS_OPEN);
                var result = Expression();
                Expect(TokenCategory.PARENTHESIS_CLOSE);
                return result;
            }

            case TokenCategory.NEG: {
                var negToken = Expect(TokenCategory.NEG);
                var expr = SimpleExpression();
                var result = new Neg() { expr };
                result.AnchorToken = negToken;
                return result;
            }

            default:
                throw new SyntaxError(firstOfSimpleExpression,
                                      tokenStream.Current);
            }
        }

        public Node Operator() {

            switch (CurrentToken) {

            case TokenCategory.AND:
                return new And() {
                    AnchorToken = Expect(TokenCategory.AND)
                };

            case TokenCategory.LESS:
                return new Less() {
                    AnchorToken = Expect(TokenCategory.LESS)
                };

            case TokenCategory.PLUS:
                return new Plus() {
                    AnchorToken = Expect(TokenCategory.PLUS)
                };

            case TokenCategory.MUL:
                return new Mul() {
                    AnchorToken = Expect(TokenCategory.MUL)
                };

            default:
                throw new SyntaxError(firstOfOperator,
                                      tokenStream.Current);
            }
        }
    }
}
