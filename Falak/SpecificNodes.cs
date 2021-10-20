namespace Falak {

    class Program: Node {} //NO ANCHOR TOKEN
        class Var_def: Node {}
            class Var_identifier: Node {}

        class Fun_def: Node {}
            class Param_list: Node {} //NO ANCHOR TOKEN
                class Param_identifier: Node {}

//----------STMT---------------------------------
            class Stm_list: Node {} //NO ANCHOR TOKEN
                class Stm_identifier: Node {}
                    class Stm_asign: Node {}
                        class Asign_expression: Node {}
                    class Stm_funcall: Node {}
                        class Funcall_expression: Node {}
    
                class Stm_Inc: Node {}
                    class Inc_identifier: Node {}
                class Stm_dec: Node {}
                    class Dec_identifier: Node {}

                class If:Node{}
                    class Expr_if:Node{}
                    class stm_list_if:Node{}
                    class Elseif_list:Node{}
                        class Elseif:Node{}
                        class stmt_list_elseif:Node{}
                    class Else:Node{}
                        class Stm_list_else:Node{}

                class While:Node{}
                    class Expr_while:Node{}
                    class stm_list_while:Node{}
                
                class Do:Node{}
                    class stm_list_do:Node{}
                    class While_do:Node{}
                    class Expr_do:Node{}

                class Break:Node{}

                class Return:Node{}
                class Expr_return:Node{}
//--------------------Expr-------------------------------------------
    class Expr : Node{}
        class OR : Node {}
        class Expr_and : Node {}
            class AND : Node {}
            class Expr_comp :Node {}
                class Equals : Node {}
                class Difequals : Node {}
                class Expr_rel : Node {}
                    class Lessthan : Node {}
                    class LessThanEquals : Node {}
                    class Greaterthan : Node {}
                    class GreaterthanEquals : Node {}
                    class Expr_add : Node {}
                        class Plus : Node {}
                        class Minus : Node {}
                        class Expr_mul : Node {}
                            class Multiplication : Node {}
                            class Division : Node {}
                            class Percent : Node {}
                            class Expr_unary : Node {}
                                class Positive : Node {}
                                class Negative : Node {}
                                class Not : Node {}
                                class Expr_primary : Node {}
                                    class Expr_primary_identifier : Node {}
                                    class Expr_primary_expr : Node {}
                                    class Lit_bool : Node {}
                                    class Lit_int : Node {}
                                    class Lit_char : Node {}
                                    class Lit_str : Node {}
























    class Print: Node {}
    

    class IntLiteral: Node {}

    class True: Node {}

    class False: Node {}

    class Neg: Node {}

    class And: Node {}

    class Less: Node {}

    class Plus: Node {}

    class Mul: Node {}
}