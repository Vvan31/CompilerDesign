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

;; Start String: E we paro
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

i32.const 69
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 119
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

i32.const 97
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 111
 call $add
 drop
;; End of String
call $prints
drop
;; IF statement 
i32.const 49
 
i32.const 48
 
i32.gt_s 
if
;;; Stmlist if
 ;; Start String: 1 > 0 

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

i32.const 49
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 62
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 48
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
drop
end
;; IF statement 
i32.const 48
 
i32.const 49
 
i32.lt_s 
if
;;; Stmlist if
 ;; Start String: 0 < 1 

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

i32.const 48
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 60
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 49
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
drop
end
i32.const 54
return
i32.const 0  

)

)
