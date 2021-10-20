
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






                    


    class Assignment: Node {}

    class Print: Node {}

    class If: Node {}

    

    class IntLiteral: Node {}

    class True: Node {}

    class False: Node {}

    class Neg: Node {}

    class And: Node {}

    class Less: Node {}

    class Plus: Node {}

    class Mul: Node {}
}