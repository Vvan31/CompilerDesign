calc:  calc_lex.l calc.y
	bison --defines=calc_tokens.h -o calc.c calc.y
	flex -o calc_lex.c calc_lex.l
	
	# In Linux:
	gcc -o calc calc.c calc_lex.c -lfl

	# In macOS:
	# gcc -o calc calc.c calc_lex.c -ll

clean:
	rm calc calc.c calc_lex.c calc_tokens.h
