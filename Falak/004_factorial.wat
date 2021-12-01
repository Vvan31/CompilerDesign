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


 (func $iterative_factorial
(param $n i32)
(result i32) 
(local $_temp i32)
(local $result i32) 
(local $i i32) 
i32.const 1
local.set $result ;; VARIABLE ASSIGN
i32.const 2
local.set $i ;; VARIABLE ASSIGN
;;START WHILE 
block $00002
loop $00003
local.get $i ;; VARIABLE ASSIGN
 
local.get $n ;; VARIABLE ASSIGN
 
i32.le_s 
i32.eqz
br_if  $00002
local.get $result ;; VARIABLE ASSIGN
 
local.get $i ;; VARIABLE ASSIGN
 
i32.mul 
local.set $result ;; VARIABLE ASSIGN
(local.get $i)
i32.const 1 
i32.add
(local.set $i)
br $00003
end
end
;; END WHILE 
local.get $result ;; VARIABLE ASSIGN
return
i32.const 0  

)

 (func $recursive_factorial
(param $n i32)
(result i32) 
(local $_temp i32)
;; IF statement 
local.get $n ;; VARIABLE ASSIGN
 
i32.const 0
 
i32.le_s 
if
;;; Stmlist if
 i32.const 1
return
;; else statement 
else
local.get $n ;; VARIABLE ASSIGN
 
local.get $n ;; VARIABLE ASSIGN
 
i32.const 1
 
i32.sub 

call $recursive_factorial
 
i32.mul 
return

end
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $num i32) 
(local $option i32) 
;;START WHILE 
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
;; Start String: Iterative factorial: 
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

i32.const 73
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
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
local.get $num ;; VARIABLE ASSIGN

call $iterative_factorial
call $printi
drop
call $println
drop
;; Start String: Recursive factorial: 
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

i32.const 82
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 117
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

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
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
local.get $num ;; VARIABLE ASSIGN

call $recursive_factorial
call $printi
drop
call $println
drop
;; Start String: Compute another factorial? 
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

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 109
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

i32.const 101
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

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
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
local.get $option ;; VARIABLE ASSIGN

call $size
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 
i32.const 78
local.set $option ;; VARIABLE ASSIGN
;; else statement 
else
local.get $option ;; VARIABLE ASSIGN
i32.const 0

call $get
local.set $option ;; VARIABLE ASSIGN

end
block $00004
loop $00005
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 

i32.eqz
br_if $00004
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
;; Start String: Iterative factorial: 
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

i32.const 73
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
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
local.get $num ;; VARIABLE ASSIGN

call $iterative_factorial
call $printi
drop
call $println
drop
;; Start String: Recursive factorial: 
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

i32.const 82
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 117
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

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
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
local.get $num ;; VARIABLE ASSIGN

call $recursive_factorial
call $printi
drop
call $println
drop
;; Start String: Compute another factorial? 
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

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 109
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

i32.const 101
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

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
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
local.get $option ;; VARIABLE ASSIGN

call $size
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 
i32.const 78
local.set $option ;; VARIABLE ASSIGN
;; else statement 
else
local.get $option ;; VARIABLE ASSIGN
i32.const 0

call $get
local.set $option ;; VARIABLE ASSIGN

end
br $00005
end
end
;; END WHILE 
;;Do Denied
i32.const 0  

)

)
