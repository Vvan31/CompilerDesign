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

;; IF statement 
i32.const 1
 
i32.const 1
 
i32.eq 
if
;;; Stmlist if
 ;; Start Stringholi crayoli

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
;;; elseif list 
end
i32.const 42
return
i32.const 0  

)

)
