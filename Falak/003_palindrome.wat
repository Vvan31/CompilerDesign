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


 (func $is_palindrome
(param $str i32)
(result i32) 
(local $_temp i32)
(local $start i32) 
(local $finish i32) 
i32.const 0
local.set $start ;; VARIABLE ASSIGN
local.get $str

call $size
 
i32.const 1
 
i32.sub 
local.set $finish ;; VARIABLE ASSIGN
;; Start String: start: 
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

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 116
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
local.get $start
call $printi
drop
call $println
drop
;; Start String: finish: 
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

i32.const 102
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 104
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
local.get $finish
call $printi
drop
call $println
drop
;;START WHILE 
block $00000
loop $00001
local.get $start
 
local.get $finish
 
i32.lt_s 
  
 i32.eqz
br_if  $00000
;; Start String: aa
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp

i32.const 97
 call $add
 drop

i32.const 97
 call $add
 drop
;; End of String
call $prints
drop
;; IF statement 
local.get $str
local.get $start

call $get
 
local.get $str
local.get $finish

call $get
 
i32.ne 
if
;;; Stmlist if
     i32.const 0
return
end
(local.get $start)
i32.const 1 
i32.add
(local.set $start)
(local.get $finish)
i32.const 1 
i32.sub
(local.set $finish)
br $00001
end
end
;; END WHILE 
    i32.const 1
return
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $str i32) 
(local $option i32) 
;;START WHILE 
block $00000
loop $00001
local.get $option
 

i32.const 39
 
i32.eq 
 
local.get $option
 

i32.const 39
 
i32.eq 
 
i32.or 
br_if  $00000
;; Start String: Input a string: 
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

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 103
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

call $reads
local.set $str ;; VARIABLE ASSIGN
;; Start String: The string \"
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

i32.const 84
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 103
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 34
 call $add
 drop
;; End of String
call $prints
drop
local.get $str
call $prints
drop
;; Start String: \" is 
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

i32.const 92
 call $add
 drop

i32.const 34
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
;; IF statement 
local.get $str

call $is_palindrome
 
i32.eqz 
if
;;; Stmlist if
 ;; Start String: NOT 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 78
 call $add
 drop

i32.const 79
 call $add
 drop

i32.const 84
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
end
;; Start String: a palindrome.

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

i32.const 97
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 100
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 46
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
drop
;; Start String: Check another string? 
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

i32.const 67
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 107
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

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 103
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
local.get $option

call $size
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 
i32.const 39
local.set $option ;; VARIABLE ASSIGN
;; else statement 
else
local.get $option
i32.const 0

call $get
local.set $option ;; VARIABLE ASSIGN

end
br $00001
end
end
;; END WHILE 
;;START WHILE 
block $00000
loop $00001
local.get $option
 

i32.const 39
 
i32.eq 
 
local.get $option
 

i32.const 39
 
i32.eq 
 
i32.or 
br_if  $00000
;; Start String: Input a string: 
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

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 103
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

call $reads
local.set $str ;; VARIABLE ASSIGN
;; Start String: The string \"
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

i32.const 84
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 103
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 34
 call $add
 drop
;; End of String
call $prints
drop
local.get $str
call $prints
drop
;; Start String: \" is 
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

i32.const 92
 call $add
 drop

i32.const 34
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
;; IF statement 
local.get $str

call $is_palindrome
 
i32.eqz 
if
;;; Stmlist if
 ;; Start String: NOT 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 78
 call $add
 drop

i32.const 79
 call $add
 drop

i32.const 84
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
end
;; Start String: a palindrome.

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

i32.const 97
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 100
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 46
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
drop
;; Start String: Check another string? 
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

i32.const 67
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 107
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

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 103
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
local.get $option

call $size
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 
i32.const 39
local.set $option ;; VARIABLE ASSIGN
;; else statement 
else
local.get $option
i32.const 0

call $get
local.set $option ;; VARIABLE ASSIGN

end
br $00001
end
end
;; END WHILE 
i32.const 0  

)

)
