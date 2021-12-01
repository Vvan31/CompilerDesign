(module
  (import "falak" "printi" (func $printi (param i32) (result i32)))
  (import "falak" "printc" (func $printc (param i32) (result i32)))
  (import "falak" "prints" (func $prints (param i32) (result i32)))
  (import "falak" "println" (func $println (result i32)))
  (import "falak" "readi" (func $readi (result i32)))
  (import "falak" "reads" (func $reads (result i32)))
  (import "falak" "new" (func $new (param i32) (result i32) ))
  (import "falak" "size" (func $size (param i32) (result i32)))
  (import "falak" "add" (func $add (param i32 i32) (result i32)))
  (import "falak" "get" (func $get (param i32 i32) (result i32)))
  (import "falak" "set" (func $set (param i32 i32 i32) (result i32)))


 (func $reverse
(param $array i32)
(result i32) 
(local $_temp i32)
(local $start i32) 
(local $finish i32) 
(local $temp i32) 
i32.const 0
local.set $start ;; VARIABLE ASSIGN
local.get $array ;; VARIABLE Expr_var_identifier 

call $size
 
i32.const 1
 
i32.sub 
local.set $finish ;; VARIABLE ASSIGN
;;START WHILE 
block $00002;; Break flag: 2
loop $00003;; LOOP flag: 3
local.get $start ;; VARIABLE Expr_var_identifier 
 
local.get $finish ;; VARIABLE Expr_var_identifier 
 
i32.lt_s 
i32.eqz
br_if $00002
local.get $array ;; VARIABLE Expr_var_identifier 
local.get $start ;; VARIABLE Expr_var_identifier 

call $get
local.set $temp ;; VARIABLE ASSIGN
local.get $array ;; VARIABLE Expr_var_identifier 
local.get $start ;; VARIABLE Expr_var_identifier 
local.get $array ;; VARIABLE Expr_var_identifier 
local.get $finish ;; VARIABLE Expr_var_identifier 

call $get
call $set
drop
local.get $array ;; VARIABLE Expr_var_identifier 
local.get $finish ;; VARIABLE Expr_var_identifier 
local.get $temp ;; VARIABLE Expr_var_identifier 
call $set
drop
(local.get $start)
i32.const 1 
i32.add
(local.set $start)
(local.get $finish)
i32.const 1 
i32.sub
(local.set $finish)
br $00003
end
end
;; END WHILE 
i32.const 0  

)

 (func $binary
(param $num i32)
(result i32) 
(local $_temp i32)
(local $result i32) 
(local $remainder i32) 
;; IF statement 
local.get $num ;; VARIABLE Expr_var_identifier 
 
i32.const 0
 
i32.le_s 
if
;;; Stmlist if
 ;; Start String: 0
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp

i32.const 48
 call $add
 drop
;; End of String
return
end
;; Start String: 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
;; End of String
local.set $result ;; VARIABLE ASSIGN
;;START WHILE 
block $00002;; Break flag: 2
loop $00003;; LOOP flag: 3
local.get $num ;; VARIABLE Expr_var_identifier 
 
i32.const 0
 
i32.gt_s 
i32.eqz
br_if $00002
local.get $num ;; VARIABLE Expr_var_identifier 
 
i32.const 2
 
i32.rem_s 
local.set $remainder ;; VARIABLE ASSIGN
local.get $result ;; VARIABLE Expr_var_identifier 
local.get $remainder ;; VARIABLE Expr_var_identifier 
 

i32.const 48
 
i32.add 
call $add
drop
local.get $num ;; VARIABLE Expr_var_identifier 
 
i32.const 2
 
i32.div_s 
local.set $num ;; VARIABLE ASSIGN
br $00003
end
end
;; END WHILE 
local.get $result ;; VARIABLE Expr_var_identifier 
call $reverse
drop
local.get $result ;; VARIABLE Expr_var_identifier 
return
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $option i32) 
(local $num i32) 
;;START DO 
;; Start String: Input a number: 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 73
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop

call $readi
local.set $num ;; VARIABLE ASSIGN
;; Start String: Conversion to binary of that number: 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 102
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
local.get $num ;; VARIABLE Expr_var_identifier 

call $binary
call $prints
drop
call $println
drop
;; Start String: Convert another number? 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 63
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop

call $reads
local.set $option ;; VARIABLE ASSIGN
;; IF statement 
local.get $option ;; VARIABLE Expr_var_identifier 

call $size
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 
i32.const 78
local.set $option ;; VARIABLE ASSIGN
;; else statement 
else
local.get $option ;; VARIABLE Expr_var_identifier 
i32.const 0

call $get
local.set $option ;; VARIABLE ASSIGN

end
block $00002;; Break flag: 2
loop $00003;; LOOP flag: 3
local.get $option ;; VARIABLE Expr_var_identifier 
 

i32.const 89
 
i32.eq 
if (result i32)
i32.const 1
else
local.get $option ;; VARIABLE Expr_var_identifier 
 

i32.const 121
 
i32.eq 
i32.eqz
i32.eqz
end
i32.eqz
br_if $00002
;; Start String: Input a number: 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 73
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop

call $readi
local.set $num ;; VARIABLE ASSIGN
;; Start String: Conversion to binary of that number: 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 102
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
local.get $num ;; VARIABLE Expr_var_identifier 

call $binary
call $prints
drop
call $println
drop
;; Start String: Convert another number? 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 63
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop

call $reads
local.set $option ;; VARIABLE ASSIGN
;; IF statement 
local.get $option ;; VARIABLE Expr_var_identifier 

call $size
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 
i32.const 78
local.set $option ;; VARIABLE ASSIGN
;; else statement 
else
local.get $option ;; VARIABLE Expr_var_identifier 
i32.const 0

call $get
local.set $option ;; VARIABLE ASSIGN

end
br $00003
end
end
;; END DO 
;;Do Denied
i32.const 0  

)

)
