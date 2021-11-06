/* Simple expression language */
%{

#include <stdio.h>
#include <stdarg.h>
#include <stdlib.h>

int yylex(void);
void yyerror(char *s, ...);
extern int yylineno;

%}

/* Declare tokens */
%token ADD MUL POW NEG INT PAR_LEFT PAR_RIGHT EOL

/* Specify operator precedence and associativity */
%left ADD
%left MUL
%left POW
%nonassoc NEG

%%

calclist:
    /* nothing */ { } /* matches at beginning of input */
    | calclist exp EOL { printf("%d\n> ", $2); } /* EOL is end of an expression */
;

exp:
      exp ADD exp            { $$ = $1 + $3; }
    | exp MUL exp            { $$ = $1 * $3; }
    | exp POW exp            { $$ = $1 ** $3}
    | NEG exp                { $$ = -$2; }
    | PAR_LEFT exp PAR_RIGHT { $$ = $2; }
    | INT
;

%%

int main(int argc, char **argv) {
    printf("> ");
    yyparse();
    return 0;
}

void yyerror(char *s, ...) {
    va_list ap;
    va_start(ap, s);
    fprintf(stderr, "%d: error: ", yylineno);
    vfprintf(stderr, s, ap);
    fprintf(stderr, "\n");
    exit(1);
}
