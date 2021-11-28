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

(func $print_arrayowo PARAM IDENTIFIER
owo LOCAL VAR IDENTIFIER
local.set $firstowo lit char
call $printc
drop 
local.set $ilocal.set $nowo LESS THAN 
OwO EVI    if
local.set $first    end
call $getcall $printi
drop 
owo INC IDENTIFIER
owo lit char
call $printc
drop 
i32.const 0  
)

(func $sum_arrayowo PARAM IDENTIFIER
owo LOCAL VAR IDENTIFIER
local.set $sumlocal.set $ilocal.set $nowo LESS THAN 
local.set $sumowo INC IDENTIFIER
OwO EVIreturn
i32.const 0  
)

(func $max_arrayowo PARAM IDENTIFIER
owo LOCAL VAR IDENTIFIER
local.set $maxlocal.set $ilocal.set $nowo LESS THAN 
local.set $xowo Greaterthan 
    if
local.set $max    end
owo INC IDENTIFIER
OwO EVIreturn
i32.const 0  
)

(func $sort_arrayowo PARAM IDENTIFIER
owo LOCAL VAR IDENTIFIER
local.set $nlocal.set $iowo LESS THAN 
local.set $jlocal.set $swapowo LESS THAN 
owo Greaterthan 
    if
local.set $tOwO EVIOwO EVIcall $getcall $set
drop 
OwO EVIOwO EVI 
i32.const 1
 
i32.addOwO EVIcall $set
drop 
local.set $swap    end
owo INC IDENTIFIER
ewe (not owo)
    if
BREAKING BAD owo
    end
owo INC IDENTIFIER
i32.const 0  
)

(func 
 $main
   (export "main")
    (result i32)
        (local $_temp i32)
i32.const 0
owo LOCAL VAR IDENTIFIER
local.set $array;; Start StringOriginal array: i32.const 0
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

i32.const 79
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 105
 call $add
 drop

i32.const 103
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

i32.const 108
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
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

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop 
OwO EVIcall $print_array
drop 
call $println
drop 
local.set $sumlocal.set $max;; Start StringSum of array:   i32.const 0
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

i32.const 83
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
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

i32.const 97
 call $add
 drop

i32.const 114
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

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 32
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
call $println
drop 
;; Start StringMax of array:   i32.const 0
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

i32.const 77
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 120
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

i32.const 97
 call $add
 drop

i32.const 114
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

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 32
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
call $println
drop 
OwO EVIcall $sort_array
drop 
;; Start StringSorted array:   i32.const 0
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

i32.const 83
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 100
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
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

i32.const 58
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop 
OwO EVIcall $print_array
drop 
call $println
drop 
i32.const 0  
)


)
