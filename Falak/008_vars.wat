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
(global $a(mut i32) (i32.const 0)) 
(global $b(mut i32) (i32.const 0)) 
(global $c(mut i32) (i32.const 0)) 


 (func $x
(param $b i32)
(result i32) 
(local $_temp i32)
(local $c i32) 
i32.const 5
global.set $c 
;; Start String: Function x

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

i32.const 70
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 99
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

i32.const 120
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
drop
;; Start String: a = 
 i32.const 0
call $new

 local.set $_temp

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

i32.const 61
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
global.get $a
call $printi
drop
call $println
drop
;; Start String: b = 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 98
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 61
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
global.get $b
call $printi
drop
call $println
drop
;; Start String: c = 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 99
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 61
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
global.get $c
call $printi
drop
call $println
drop
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $x i32) 
i32.const 1
global.set $a 
i32.const 2
global.set $b 
i32.const 3
global.set $c 
i32.const 4
local.set $x ;; VARIABLE ASSIGN
local.get $x
call $x
drop
;; Start String: Function main

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

i32.const 70
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 99
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

i32.const 109
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 10
 call $add
 drop
;; End of String
call $prints
drop
;; Start String: a = 
 i32.const 0
call $new

 local.set $_temp

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

i32.const 61
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
global.get $a
call $printi
drop
call $println
drop
;; Start String: b = 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 98
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 61
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
global.get $b
call $printi
drop
call $println
drop
;; Start String: c = 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 99
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 61
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
global.get $c
call $printi
drop
call $println
drop
;; Start String: x = 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 120
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 61
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop
local.get $x
call $printi
drop
call $println
drop
i32.const 0  

)

)
