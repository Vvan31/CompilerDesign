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


 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $n i32) 
(local $m i32) 
(local $x i32) 
;; Start String: holi crayoli

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

i32.const 104
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
;; IF statement 
i32.const 1
 
i32.const 1
 
i32.eq 
if
;;; Stmlist if
 i32.const 1
local.set $n ;; VARIABLE ASSIGN
i32.const 1
local.set $n ;; VARIABLE ASSIGN
;; Start String: holi crayoli

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

i32.const 104
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 99
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 108
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
;; elseif statement 
else
i32.const 2
 
i32.const 2
 
i32.eq 

if
i32.const 2
local.set $m ;; VARIABLE ASSIGN
i32.const 2
local.set $m ;; VARIABLE ASSIGN

;; elseif statement 
else
i32.const 3
 
i32.const 3
 
i32.eq 

if
i32.const 3
local.set $x ;; VARIABLE ASSIGN
i32.const 3
local.set $x ;; VARIABLE ASSIGN

;; else statement 
else
i32.const 5
local.set $n ;; VARIABLE ASSIGN
i32.const 5
local.set $n ;; VARIABLE ASSIGN

end
end
end
i32.const 42
return
i32.const 0  

)

)
