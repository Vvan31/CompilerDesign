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

(local $x i32) 
(local $y i32) 
i32.const 2
local.set $x ;; VARIABLE ASSIGN
i32.const 1
local.set $y ;; VARIABLE ASSIGN
;; IF statement 
i32.const 6
 
i32.const 7
 
i32.mul 
 
i32.const 0
 
i32.xor 
if
;;; Stmlist if
 ;; Start String: Xor
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 88
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop
;; End of String
call $prints
drop
end
i32.const 0  

)

)
