namespace Falak {

    class Program: Node {} //NO ANCHOR TOKEN
        class Def_list : Node {}//NO ANCHOR TOKEN
        class Def : Node {}
        class Var_def: Node {}
            class Var_identifier : Node {}
            class Param_list_identifier :Node {}
            class Param_identifier : Node {}
        class Fun_def: Node {}
                
//----------STMT---------------------------------
            class Stm_list: Node {} //NO ANCHOR TOKEN
                class Stm_identifier: Node {}
                    class Stm_asign: Node {}
                    class Stm_funcall: Node {}
                        class Stm_funcall_Exprlist : Node {}//NO ANCHOR TOKEN
                class Stm_Inc: Node {}
                    class Inc_identifier: Node {}
                class Stm_dec: Node {}
                    class Dec_identifier: Node {}

                class If:Node{}
                    class Elseif_list:Node{}
                        class Elseif:Node{}
                    class Else:Node{}

                class While:Node{}
                
                class Do:Node{}

                class Break:Node{}

                class Return:Node{}
//--------------------Expr-------------------------------------------
        class Or : Node {}
            class AND : Node {}
                class Equals : Node {}
                class Difequals : Node {}
                    class Lessthan : Node {}
                    class LessThanEquals : Node {}
                    class Greaterthan : Node {}
                    class GreaterthanEquals : Node {}
                        class Plus : Node {}
                        class Minus : Node {}
                            class Multiplication : Node {}
                            class Division : Node {}
                            class Percent : Node {}
                                class Positive : Node {}
                                class Negative : Node {}
                                class Not : Node {}
                                    class Expr_primary_identifier : Node {}
                                    class Expr_primary_list : Node{}
                                    class Expr_primary_expr : Node {}
                                    class Lit_int : Node {}
                                    class Lit_char : Node {}
                                    class Lit_str : Node {}
                                    class Lit_true : Node {}
                                    class Lit_false : Node {}



}



















