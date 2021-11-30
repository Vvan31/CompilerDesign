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
(global $owo(mut i32) (i32.const 0)) 


 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $start i32) 
(local $finish i32) 
i32.const 0
local.set $start ;; VARIABLE ASSIGN
i32.const 6
local.set $finish ;; VARIABLE ASSIGN
i32.const 3
global.set $owo 
;; IF statement 
local.get $start
 
local.get $finish
 
i32.lt_s 
if
;;; Stmlist if
 ;; Start String: a
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp

i32.const 97
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
end
;;START WHILE 
block $00000
loop $00001
local.get $start
 
local.get $finish
 
i32.gt_s 
br_if  $00000
;; Start String: b
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp

i32.const 98
 call $add
 drop
;; End of String
call $prints
drop
call $println
drop
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
i32.const 0  

)

)
