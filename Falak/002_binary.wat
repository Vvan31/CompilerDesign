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
(global $hello(mut i32) (i32.const 0)) 


 (func $reverse
(param $array i32)
(result i32) 
(local $_temp i32)
;;START WHILE 
block $00000
loop $00001
local.get $start
 
local.get $finish
 
i32.lt_s 
br_if  $00000
local.get $array
local.get $start
call $get
call $set
local.get $array
local.get $finish
local.get $temp
call $set
i32.const 1
local.get $start
 
i32.add 
local.get $finish
 
i32.const 1 
i32.sub
br $00001
end
end
;; END WHILE 
i32.const 0  

)

 (func $binary
(param $num i32)
(result i32) 
(local $_temp i32)
;; IF statement 
local.get $num
 
i32.const 0
 
i32.le_s 
if
;; Start String0
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp

i32.const 48
 call $add
 drop
;; End of String
return
;; Start String0
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp

i32.const 48
 call $add
 drop
;; End of String
return
    end
;;START WHILE 
block $00002
loop $00003
local.get $num
 
i32.const 0
 
i32.ge_s 
br_if  $00002
local.get $result
local.get $remainder
 

i32.const 39
 
i32.add 
call $add
br $00003
end
end
;; END WHILE 
;; Start StringSTRING
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

i32.const 83
 call $add
 drop

i32.const 84
 call $add
 drop

i32.const 82
 call $add
 drop

i32.const 73
 call $add
 drop

i32.const 78
 call $add
 drop

i32.const 71
 call $add
 drop
;; End of String
call $reverse
local.get $result
return
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)

(local $_temp i32)
;;START WHILE 
block $00004
loop $00005
;; Start StringInput a number: 
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

i32.const 73
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
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
;; Start StringConversion to binary of that number: 
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

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 115
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

i32.const 116
 call $add
 drop

i32.const 111
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

i32.const 110
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 121
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

i32.const 116
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
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
call $binary
call $prints
call $println
;; Start StringConvert another number? 
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
local.get $_temp

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 104
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

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 63
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
;; IF statement 
call $size
 
i32.const 0
 
i32.eq 
if
    end
br_if $00004
local.get $option
 

i32.const 39
 
i32.eq 
 
local.get $option
 

i32.const 39
 
i32.eq 
 
i32.or 
br $00005
end
end
;; END WHILE 
;;START WHILE 
block $00006
loop $00007
;; Start StringInput a number: 
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

i32.const 73
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 112
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
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
;; Start StringConversion to binary of that number: 
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

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 115
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

i32.const 116
 call $add
 drop

i32.const 111
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

i32.const 110
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 121
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

i32.const 116
 call $add
 drop

i32.const 104
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
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
call $binary
call $prints
call $println
;; Start StringConvert another number? 
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
local.get $_temp

i32.const 67
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 118
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 32
 call $add
 drop

i32.const 97
 call $add
 drop

i32.const 110
 call $add
 drop

i32.const 111
 call $add
 drop

i32.const 116
 call $add
 drop

i32.const 104
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

i32.const 110
 call $add
 drop

i32.const 117
 call $add
 drop

i32.const 109
 call $add
 drop

i32.const 98
 call $add
 drop

i32.const 101
 call $add
 drop

i32.const 114
 call $add
 drop

i32.const 63
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
;; IF statement 
call $size
 
i32.const 0
 
i32.eq 
if
    end
br_if $00006
local.get $option
 

i32.const 39
 
i32.eq 
 
local.get $option
 

i32.const 39
 
i32.eq 
 
i32.or 
br $00007
end
end
;; END WHILE 
i32.const 0  

)

)
