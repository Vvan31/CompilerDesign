
namespace Falak {

    enum TokenCategory {
        //MULTILINECOMMENT,
        //COMMENT,
        BREAK,
        DEC,
        DO,
        ELSE,
        ELSEIF,
        FALSE,
        IF,
        INC,
        TRUE,
        VAR,
        WHILE,
        SEMICOLON,
        COMA,
        STARTPARENTHESIS,
        ENDPARENTHESIS,///END////
        STARTCURLBRACES,
        ENDCURLBRACES,////END/////
        STARTBRACES,
        ENDBRACES,////END/////
        OR,
        CIRCUMFLEX,   //XOR
        AND,
        EQUALS,
        DIFEQUAL,
        LESSTHANEQUAL,
        GREATERTHANEQUAL,
        LESSTHAN,
        GREATERTHAN,
        PLUS,
        MINUS,
        MULTIPLICATION,
        SLASH,
        PERCENT,
        EXCLAMATION, //////////////
        INT,
        CHAR,
        NEWLINE,//////n/////////
        WHITESPACE,////////
        STR,
        RETURN,
        IDENTIFIER,

        OTHER,
        EOF,
        ILLEGAL_CHAR
        
        
    }
}
