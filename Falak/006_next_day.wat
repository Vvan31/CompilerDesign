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

(func $is_leap_yearowo PARAM IDENTIFIER
owo Equals 
    if
owo Equals 
    if
owo Equals 
    if
owo lit true
return
    end
    end
    end
i32.const 0  
)

(func $number_of_days_in_monthowo PARAM IDENTIFIER
owo PARAM IDENTIFIER
owo LOCAL VAR IDENTIFIER
owo Equals 
    if
call $is_leap_year    if
local.set $result    end
    end
OwO EVIreturn
i32.const 0  
)

(func $next_dayowo PARAM IDENTIFIER
owo PARAM IDENTIFIER
owo PARAM IDENTIFIER
owo Equals 
    if
owo Equals 
    if
OwO EVI 
i32.const 1
 
i32.addi32.const 1
i32.const 1
return
    end
    end
i32.const 0  
)

(func $print_next_dayowo PARAM IDENTIFIER
owo PARAM IDENTIFIER
owo PARAM IDENTIFIER
owo LOCAL VAR IDENTIFIER
;; Start StringThe day after i32.const 0
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

i32.const 84
 call $add
 drop

i32.const 104
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

i32.const 97
 call $add
 drop

i32.const 121
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 102
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
;; End of String
call $prints
drop 
OwO EVIcall $printi
drop 
owo lit char
call $printc
drop 
OwO EVIcall $printi
drop 
owo lit char
call $printc
drop 
OwO EVIcall $printi
drop 
;; Start String is i32.const 0
call $new
local.set $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp
local.get $_temp

i32.const 32
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 115
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop 
local.set $nextcall $getcall $printi
drop 
owo lit char
call $printc
drop 
call $getcall $printi
drop 
owo lit char
call $printc
drop 
call $getcall $printi
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
i32.const 0
i32.const 2020
i32.const 2
i32.const 28
call $print_next_day
drop 
i32.const 2021
i32.const 2
i32.const 13
call $print_next_day
drop 
i32.const 2021
i32.const 2
i32.const 28
call $print_next_day
drop 
i32.const 2021
i32.const 12
i32.const 31
call $print_next_day
drop 
i32.const 0  
)


)
