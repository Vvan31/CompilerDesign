using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Falak {

    class Scanner {

        readonly string input;

        static readonly Regex regex = new Regex(
            @"
                
                (?<MultilineComment>    <\#([\s\S]*?)\#> )
              | (?<Comment>    \#.*       )
              | (?<Break>      break\b   )
              | (?<Dec>        dec\b     )
              | (?<Do>         do\b      )
              | (?<Else>       else\b    )
              | (?<Elseif>     elseif\b  )
              | (?<False>      false\b   )
              | (?<If>         if\b      )
              | (?<Inc>        inc\b     )
              | (?<Return>     retrurn\b )
              | (?<True>       true\b    )
              | (?<Var>        var\b     )
              | (?<While>      while\b   )
              | (?<Semicolon>  [;]       )
              | (?<Startparenthesis> [(] )
              | (?<Endparenthesis>   [)] )
              | (?<Startcurlbraces>  [{] )
              | (?<Endcurlbraces>    [{] )
              | (?<Or>         [||]      )
              | (<Circumflex>  [^]       )
              | (<And>         [&&]      )
              | (<Equals>      [==]      )
              | (<DifEqual>    [!=]      )
              | (?<Lessthanequal>   [<=] )
              | (?<Greaterthanequal> [>=])
              | (?<Lessthan>   [<]       )
              | (?<Greaterthan> [>]      )
              | (?<Plus>       [+]       )
              | (?<Minus>      [-]       )
              | (?<Multiplication> [*]   )
              | (?<Slash>      [/]       )
              | (?<Percent>    [%]       )
              | (?<Exclamation> [!]      )
              | (?<Identifier> [a-zA-Z][a-zA-Z0-9_]+ )     # Must go after all keywords
              | (?<Int>        int\b     )
              | (?<Newline>    \n        )
              | (?<WhiteSpace> \s        )     # Must go after Newline.
              | (?<Char>     ""([^""\n\\]|\\([nrt\\'""]|u[0-9a-fA-F]{6}))*"" )
              | (?<Other>       .        )
            
              
            ",
            RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                | RegexOptions.Multiline
            );

        static readonly IDictionary<string, TokenCategory> tokenMap =
            new Dictionary<string, TokenCategory>() {
                //{"MultilineComment", TokenCategory.MULTILINECOMMENT},
                //{"Comment", TokenCategory.COMMENT},
                {"Break", TokenCategory.BREAK},
                {"Dec", TokenCategory.DEC},
                {"Do", TokenCategory.DO},
                {"Else", TokenCategory.ELSE},
                {"Elseif", TokenCategory.ELSEIF},
                {"False", TokenCategory.FALSE},
                {"If", TokenCategory.IF},
                {"Inc", TokenCategory.INC},
                {"Return", TokenCategory.RETURN},
                {"True", TokenCategory.TRUE},
                {"Var", TokenCategory.VAR},
                {"While", TokenCategory.WHILE},
                {"Semicolon", TokenCategory.SEMICOLON},
                {"Startparenthesis", TokenCategory.STARTPARENTHESIS},
                {"Endparenthesis", TokenCategory.ENDPARENTHESIS},
                {"Startcurlbraces", TokenCategory.STARTCURLYBRACES},
                {"Endcurlbraces", TokenCategory.ENDCURLYBRACES},
                {"Or", TokenCategory.OR},
                {"Circumflex", TokenCategory.CIRCUMFLEX},
                {"And", TokenCategory.AND},
                {"Equals", TokenCategory.EQUALS},
                {"DifEqual", TokenCategory.DIFEQUAL},
                {"Lessthan", TokenCategory.LESSTHAN},
                {"Lessthanequal", TokenCategory.LESSTHANEQUAL},
                {"Greaterthan", TokenCategory.GREATERTHAN},
                {"Greatenthanequal", TokenCategory.GREATERTHANEQUAL},
                {"Plus", TokenCategory.PLUS},
                {"Minus", TokenCategory.MINUS},
                {"Multiplication", TokenCategory.MULTIPLICATION},
                {"Slash", TokenCategory.SLASH},
                {"Percent", TokenCategory.PERCENT},
                {"Exclamation", TokenCategory.EXCLAMATION},
                {"Identifier", TokenCategory.IDENTIFIER},
                {"Int", TokenCategory.INT},
                {"Newline", TokenCategory.NEWLINE},
                {"WhiteSpace", TokenCategory.WHITESPACE},
                {"Char", TokenCategory.CHAR},
                {"Other", TokenCategory.OTHER},

            };

        public Scanner(string input) {
            this.input = input;
        }

        public IEnumerable<Token> Scan() {

            var result = new LinkedList<Token>();
            var row = 1;
            var columnStart = 0;

            foreach (Match m in regex.Matches(input)) {

                if (m.Groups["Newline"].Success) {

                    row++;
                    columnStart = m.Index + m.Length;

                } else if (m.Groups["WhiteSpace"].Success
                    || m.Groups["Comment"].Success || m.Groups["MultilineComment"].Success)  {

                    // Skip white space and comments.

                } else if (m.Groups["Other"].Success) {

                    // Found an illegal character.
                    result.AddLast(
                        new Token(m.Value,
                            TokenCategory.ILLEGAL_CHAR,
                            row,
                            m.Index - columnStart + 1));

                } else {

                    // Must be any of the other tokens.
                    result.AddLast(FindToken(m, row, columnStart));
                }
            }

            result.AddLast(
                new Token(null,
                    TokenCategory.EOF,
                    row,
                    input.Length - columnStart + 1));

            return result;
        }

        Token FindToken(Match m, int row, int columnStart) {
            foreach (var name in tokenMap.Keys) {
                if (m.Groups[name].Success) {
                    return new Token(m.Value,
                        tokenMap[name],
                        row,
                        m.Index - columnStart + 1);
                }
            }
            throw new InvalidOperationException(
                "regex and tokenMap are inconsistent: " + m.Value);
        }
    }
}
