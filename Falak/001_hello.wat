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
(global $ewe(mut i32) (i32.const 0)) 
(global $owo(mut i32) (i32.const 0)) 


 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $n i32) 
(local $option i32) 
i32.const 1
local.set $n ;; VARIABLE ASSIGN
;;START WHILE 
;; Start String: owo
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 111
 call $add
 drop

i32.const 119
 call $add
 drop

i32.const 111
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
local.get $option ;; VARIABLE ASSIGN
call $printc
drop
call $println
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
;; IF statement 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 
if
;;; Stmlist if
 ;; Start String: option es y so ta bien?
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

i32.const 111
 call $add
 drop

i32.const 112
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

i32.const 101
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 111
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

i32.const 63
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
end
;;START WHILE 
;; Start String: double do
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

i32.const 100
 call $add
 drop

i32.const 111
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
local.get $option ;; VARIABLE ASSIGN
call $printc
drop
call $println
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
;; IF statement 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 
if
;;; Stmlist if
 ;; Start String: option es y so ta bien?
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

i32.const 111
 call $add
 drop

i32.const 112
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

i32.const 101
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 111
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

i32.const 63
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
end
block $00006
loop $00007
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 

i32.eqz
br_if $00006
;; Start String: double do
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

i32.const 100
 call $add
 drop

i32.const 111
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
local.get $option ;; VARIABLE ASSIGN
call $printc
drop
call $println
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
;; IF statement 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 
if
;;; Stmlist if
 ;; Start String: option es y so ta bien?
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

i32.const 111
 call $add
 drop

i32.const 112
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

i32.const 101
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 111
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

i32.const 63
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
end
br $00007
end
end
;; END WHILE 
;;nope
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
;; Start String: owo
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 111
 call $add
 drop

i32.const 119
 call $add
 drop

i32.const 111
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
local.get $option ;; VARIABLE ASSIGN
call $printc
drop
call $println
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
;; IF statement 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 
if
;;; Stmlist if
 ;; Start String: option es y so ta bien?
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

i32.const 111
 call $add
 drop

i32.const 112
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

i32.const 101
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 111
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

i32.const 63
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
end
;;START WHILE 
;; Start String: double do
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

i32.const 100
 call $add
 drop

i32.const 111
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
local.get $option ;; VARIABLE ASSIGN
call $printc
drop
call $println
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
;; IF statement 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 
if
;;; Stmlist if
 ;; Start String: option es y so ta bien?
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

i32.const 111
 call $add
 drop

i32.const 112
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

i32.const 101
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 111
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

i32.const 63
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
end
block $00008
loop $00009
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 

i32.eqz
br_if $00008
;; Start String: double do
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

i32.const 100
 call $add
 drop

i32.const 111
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
local.get $option ;; VARIABLE ASSIGN
call $printc
drop
call $println
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
;; IF statement 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 89
 
i32.eq 
 
local.get $option ;; VARIABLE ASSIGN
 

i32.const 121
 
i32.eq 
 
i32.or 
if
;;; Stmlist if
 ;; Start String: option es y so ta bien?
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

i32.const 111
 call $add
 drop

i32.const 112
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

i32.const 101
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 111
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

i32.const 63
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
end
br $00009
end
end
;; END WHILE 
;;nope
br $00003
end
end
;; END WHILE 
;;nope
i32.const 69
return
i32.const 0  

)

)
