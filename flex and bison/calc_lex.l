%{

#include "calc_tokens.h"

void yyerror(char *s, ...);

%}

%%

"+"    { return ADD; }
"-"    { return NEG; }
"*"    { return MUL; }
"**"   { return POW; }
"("    { return PAR_LEFT; }
")"    { return PAR_RIGHT; }
[0-9]+ {
        yylval = atoi(yytext);
        return INT;
}
\n     { yylineno++; return EOL; }
[ \t]  { /* ignore whitespace */ }
.      { yyerror("Mystery character %c\n", *yytext); }

%%
