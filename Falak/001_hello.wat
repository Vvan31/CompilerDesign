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

(local $start i32) 
i32.const 10
local.set $start ;; VARIABLE ASSIGN
;;START WHILE 
block $00000
loop $00001
i32.const 22
 
local.get $start
 
i32.le_s 
br_if  $00000
;; Start String: a

 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp

i32.const 97
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
drop
(local.get $start)
i32.const 1 
i32.add
(local.set $start)
br $00001
end
end
;; END WHILE 
i32.const 42
return
i32.const 0  

)

)
