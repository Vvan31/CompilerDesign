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
local.get $array ;; VARIABLE ASSIGN

call $size
 
i32.const 1
 
i32.sub 
local.set $finish ;; VARIABLE ASSIGN
;;START WHILE 
block $00002;; Break flag: 2
loop $00003;; LOOP flag: 2
local.get $start ;; VARIABLE ASSIGN
 
local.get $finish ;; VARIABLE ASSIGN
 
i32.lt_s 
i32.eqz
br_if $00002
local.get $array ;; VARIABLE ASSIGN
local.get $start ;; VARIABLE ASSIGN

call $get
local.set $temp ;; VARIABLE ASSIGN
local.get $array ;; VARIABLE ASSIGN
local.get $start ;; VARIABLE ASSIGN
local.get $array ;; VARIABLE ASSIGN
local.get $finish ;; VARIABLE ASSIGN

call $get
call $set
drop
local.get $array ;; VARIABLE ASSIGN
local.get $finish ;; VARIABLE ASSIGN
local.get $temp ;; VARIABLE ASSIGN
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
local.get $num ;; VARIABLE ASSIGN
 
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
loop $00003;; LOOP flag: 2
local.get $num ;; VARIABLE ASSIGN
 
i32.const 0
 
i32.gt_s 
i32.eqz
br_if $00002
local.get $num ;; VARIABLE ASSIGN
 
i32.const 2
 
i32.rem_s 
local.set $remainder ;; VARIABLE ASSIGN
local.get $result ;; VARIABLE ASSIGN
local.get $remainder ;; VARIABLE ASSIGN
 

i32.const 48
 
i32.add 
call $add
drop
local.get $num ;; VARIABLE ASSIGN
 
i32.const 2
 
i32.div_s 
local.set $num ;; VARIABLE ASSIGN
br $00003
end
end
;; END WHILE 
local.get $result ;; VARIABLE ASSIGN
call $reverse
drop
local.get $result ;; VARIABLE ASSIGN
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
local.get $num ;; VARIABLE ASSIGN

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
block $00002
loop $00003
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 

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
local.get $num ;; VARIABLE ASSIGN

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
br $00003
end
end
;; END WHILE 
;;Do Denied
i32.const 0  

)

)
