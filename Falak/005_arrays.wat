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


 (func $print_array
(param $a i32)
(result i32) 
(local $_temp i32)
(local $first i32) 
(local $i i32) 
(local $n i32) 
    i32.const 1
local.set $first ;; VARIABLE ASSIGN

i32.const 39
call $printc
drop
i32.const 0
local.set $i ;; VARIABLE ASSIGN
local.get $a

call $size
local.set $n ;; VARIABLE ASSIGN
;;START WHILE 
block $00000
loop $00001
local.get $i
 
local.get $n
 
i32.lt_s 
br_if  $00000
;; IF statement 
local.get $first
if
;;; Stmlist if
     i32.const 0
local.set $first ;; VARIABLE ASSIGN
;; else statement 
else
;; Start String: , 
 i32.const 0
call $new

 local.set $_temp

 local.get $_temp
local.get $_temp
local.get $_temp

i32.const 44
 call $add
 drop

i32.const 32
 call $add
 drop
;; End of String
call $prints
drop

end
local.get $a
local.get $i

call $get
call $printi
drop
(local.get $i)
i32.const 1 
i32.add
(local.set $i)
br $00001
end
end
;; END WHILE 

i32.const 39
call $printc
drop
i32.const 0  

)

 (func $sum_array
(param $a i32)
(result i32) 
(local $_temp i32)
(local $sum i32) 
(local $i i32) 
(local $n i32) 
i32.const 0
local.set $sum ;; VARIABLE ASSIGN
i32.const 0
local.set $i ;; VARIABLE ASSIGN
local.get $a

call $size
local.set $n ;; VARIABLE ASSIGN
;;START WHILE 
block $00000
loop $00001
local.get $i
 
local.get $n
 
i32.lt_s 
br_if  $00000
local.get $sum
 
local.get $a
local.get $i

call $get
 
i32.add 
local.set $sum ;; VARIABLE ASSIGN
(local.get $i)
i32.const 1 
i32.add
(local.set $i)
br $00001
end
end
;; END WHILE 
local.get $sum
return
i32.const 0  

)

 (func $max_array
(param $a i32)
(result i32) 
(local $_temp i32)
(local $max i32) 
(local $i i32) 
(local $n i32) 
(local $x i32) 
local.get $a
i32.const 0

call $get
local.set $max ;; VARIABLE ASSIGN
i32.const 0
local.set $i ;; VARIABLE ASSIGN
local.get $a

call $size
local.set $n ;; VARIABLE ASSIGN
;;START WHILE 
block $00000
loop $00001
local.get $i
 
local.get $n
 
i32.lt_s 
br_if  $00000
local.get $a
local.get $i

call $get
local.set $x ;; VARIABLE ASSIGN
;; IF statement 
local.get $x
 
local.get $max
 
i32.gt_s 
if
;;; Stmlist if
 local.get $x
local.set $max ;; VARIABLE ASSIGN
end
(local.get $i)
i32.const 1 
i32.add
(local.set $i)
br $00001
end
end
;; END WHILE 
local.get $max
return
i32.const 0  

)

 (func $sort_array
(param $a i32)
(result i32) 
(local $_temp i32)
(local $i i32) 
(local $j i32) 
(local $t i32) 
(local $n i32) 
(local $swap i32) 
local.get $a

call $size
local.set $n ;; VARIABLE ASSIGN
i32.const 0
local.set $i ;; VARIABLE ASSIGN
;;START WHILE 
block $00000
loop $00001
local.get $i
 
local.get $n
 
i32.const 1
 
i32.sub 
 
i32.lt_s 
br_if  $00000
i32.const 0
local.set $j ;; VARIABLE ASSIGN
    i32.const 0
local.set $swap ;; VARIABLE ASSIGN
;;START WHILE 
block $00002
loop $00003
local.get $j
 
local.get $n
 
local.get $i
 
i32.sub 
 
i32.const 1
 
i32.sub 
 
i32.lt_s 
br_if  $00002
;; IF statement 
local.get $a
local.get $j

call $get
 
local.get $a
local.get $j
 
i32.const 1
 
i32.add 

call $get
 
i32.gt_s 
if
;;; Stmlist if
 local.get $a
local.get $j

call $get
local.set $t ;; VARIABLE ASSIGN
local.get $a
local.get $j
local.get $a
local.get $j
 
i32.const 1
 
i32.add 

call $get
call $set
drop
local.get $a
local.get $j
 
i32.const 1
 
i32.add 
local.get $t
call $set
drop
    i32.const 1
local.set $swap ;; VARIABLE ASSIGN
end
(local.get $j)
i32.const 1 
i32.add
(local.set $j)
br $00003
end
end
;; END WHILE 
;; IF statement 
local.get $swap
 
i32.eqz 
if
;;; Stmlist if
 br $00000
end
(local.get $i)
i32.const 1 
i32.add
(local.set $i)
br $00001
end
end
;; END WHILE 
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

(local $array i32) 
(local $sum i32) 
(local $max i32) 
i32.const 73
i32.const 77
i32.const 56
i32.const 10
i32.const 14
i32.const 54
i32.const 75
i32.const 62
i32.const 71
i32.const 10
i32.const 3
i32.const 71
i32.const 16
i32.const 49
i32.const 66
i32.const 91
i32.const 69
i32.const 62
i32.const 25
i32.const 65
local.set $array ;; VARIABLE ASSIGN
;; Start String: Original array: 
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
local.get $array
call $print_array
drop
call $println
drop
local.get $array

call $sum_array
local.set $sum ;; VARIABLE ASSIGN
local.get $array

call $max_array
local.set $max ;; VARIABLE ASSIGN
;; Start String: Sum of array:   
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
local.get $sum
call $printi
drop
call $println
drop
;; Start String: Max of array:   
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
local.get $max
call $printi
drop
call $println
drop
local.get $array
call $sort_array
drop
;; Start String: Sorted array:   
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
local.get $array
call $print_array
drop
call $println
drop
i32.const 0  

)

)
