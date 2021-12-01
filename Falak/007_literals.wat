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
(global $fails(mut i32) (i32.const 0)) 


 (func $assert
(param $value1 i32)
(param $value2 i32)
(param $message i32)
(result i32) 
(local $_temp i32)
;; IF statement 
local.get $value1 ;; VARIABLE ASSIGN
 
local.get $value2 ;; VARIABLE ASSIGN
 
i32.ne 
if
;;; Stmlist if
 (global.get $fails)
i32.const 1 
i32.add
(global.set $fails)
;; Start String: Assertion failure: 
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

i32.const 65
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 115
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

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 101
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
local.get $message ;; VARIABLE ASSIGN
call $prints
drop
call $println
drop
end
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $s i32) 
(local $a i32) 
(local $i i32) 
(local $n i32) 
i32.const 0
global.set $fails ;; VARIABLE ASSIGN

i32.const 10
i32.const 10
;; Start String: error in newline literal
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 119
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

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop
;; End of String
call $assert
drop

i32.const 13
i32.const 13
;; Start String: error in carriage return literal
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
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

i32.const 103
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop
;; End of String
call $assert
drop

i32.const 9
i32.const 9
;; Start String: error in tab literal
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
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

i32.const 97
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop
;; End of String
call $assert
drop

i32.const 92
i32.const 92
;; Start String: error in backslash literal
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 107
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop
;; End of String
call $assert
drop

i32.const 92
i32.const 39
;; Start String: error in single quote literal
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
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

i32.const 108
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 113
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 111
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

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop
;; End of String
call $assert
drop

i32.const 92
i32.const 34
;; Start String: error in double quote literal
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 100
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 113
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 111
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

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop
;; End of String
call $assert
drop

i32.const 92

i32.const 65
;; Start String: error in letter A literal code point
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 116
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

i32.const 32
 call $add
 drop

i32.const 65
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 100
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 116
 call $add
 drop
;; End of String
call $assert
drop

i32.const 92
i32.const 8364
;; Start String: error in euro literal code point
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 100
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 116
 call $add
 drop
;; End of String
call $assert
drop
;; Start String: \u0000A1\u0020ACste ni\u0000F1o \u0020ACst\u0000E1 bien \u0000D1o\u0000F1o!

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
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
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

i32.const 117
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 65
 call $add
 drop

i32.const 49
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 50
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 65
 call $add
 drop

i32.const 67
 call $add
 drop

i32.const 115
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

i32.const 110
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 70
 call $add
 drop

i32.const 49
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 50
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 65
 call $add
 drop

i32.const 67
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 69
 call $add
 drop

i32.const 49
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

i32.const 101
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 68
 call $add
 drop

i32.const 49
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 92
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 70
 call $add
 drop

i32.const 49
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 33
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
local.set $s ;; VARIABLE ASSIGN
i32.const 161
i32.const 8364
i32.const 115
i32.const 116
i32.const 101
i32.const 32
i32.const 110
i32.const 105
i32.const 241
i32.const 111
i32.const 32
i32.const 8364
i32.const 115
i32.const 116
i32.const 225
i32.const 32
i32.const 98
i32.const 105
i32.const 101
i32.const 110
i32.const 32
i32.const 209
i32.const 111
i32.const 241
i32.const 111
i32.const 33
i32.const 10
local.set $a ;; VARIABLE ASSIGN
i32.const 0
local.set $i ;; VARIABLE ASSIGN
local.get $s ;; VARIABLE ASSIGN

call $size
local.set $n ;; VARIABLE ASSIGN
;;START WHILE 
block $00002
loop $00003
local.get $i ;; VARIABLE ASSIGN
 
local.get $n ;; VARIABLE ASSIGN
 
i32.lt_s 
  
 i32.eqz
br_if  $00002
local.get $a ;; VARIABLE ASSIGN
local.get $i ;; VARIABLE ASSIGN

call $get
local.get $s ;; VARIABLE ASSIGN
local.get $i ;; VARIABLE ASSIGN

call $get
;; Start String: error in string literal
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

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
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

i32.const 108
 call $add
 drop

i32.const 105
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

i32.const 108
 call $add
 drop
;; End of String
call $assert
drop
(local.get $i)
i32.const 1 
i32.add
(local.set $i)
br $00003
end
end
;; END WHILE 
global.get $fails ;; VARIABLE ASSIGN
call $printi
drop
;; Start String:  assertion failure(s) found.
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

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 115
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

i32.const 102
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 40
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 41
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 102
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 100
 call $add
 drop

i32.const 46
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
local.get $a ;; VARIABLE ASSIGN
call $prints
drop
i32.const 0  

)

)
