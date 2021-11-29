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


 (func $is_leap_year
(param $y i32)
(result i32) 
;; IF statement 
local.get $y
 
i32.const 4
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
;; IF statement 
local.get $y
 
i32.const 100
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
;; IF statement 
local.get $y
 
i32.const 400
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
owo lit true
return
owo lit true
return
    end
;; IF statement 
local.get $y
 
i32.const 400
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
owo lit true
return
owo lit true
return
    end
    end
;; IF statement 
local.get $y
 
i32.const 100
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
;; IF statement 
local.get $y
 
i32.const 400
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
owo lit true
return
owo lit true
return
    end
;; IF statement 
local.get $y
 
i32.const 400
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
owo lit true
return
owo lit true
return
    end
    end
    end
i32.const 0  

)

 (func $number_of_days_in_month
(param $y i32)
(param $m i32)
(result i32) 
(local $_temp i32)
(local $result i32) 
;; IF statement 
local.get $m
 
i32.const 2
 
i32.eq 
if
;; IF statement 
local.get $y

call $is_leap_year
if
i32.const 29
local.set $result ;; VARIABLE ASSIGN
i32.const 29
local.set $result ;; VARIABLE ASSIGN
    end
;; IF statement 
local.get $y

call $is_leap_year
if
i32.const 29
local.set $result ;; VARIABLE ASSIGN
i32.const 29
local.set $result ;; VARIABLE ASSIGN
    end
    end
local.get $result
return
i32.const 0  

)

 (func $next_day
(param $y i32)
(param $m i32)
(param $d i32)
(result i32) 
;; IF statement 
local.get $d
 
local.get $y
local.get $m

call $number_of_days_in_month
 
i32.eq 
if
;; IF statement 
local.get $m
 
i32.const 12
 
i32.eq 
if
local.get $y
 
i32.const 1
 
i32.add 
i32.const 1
i32.const 1
return
local.get $y
 
i32.const 1
 
i32.add 
i32.const 1
i32.const 1
return
    end
;; IF statement 
local.get $m
 
i32.const 12
 
i32.eq 
if
local.get $y
 
i32.const 1
 
i32.add 
i32.const 1
i32.const 1
return
local.get $y
 
i32.const 1
 
i32.add 
i32.const 1
i32.const 1
return
    end
    end
i32.const 0  

)

 (func $print_next_day
(param $y i32)
(param $m i32)
(param $d i32)
(result i32) 
(local $_temp i32)
(local $next i32) 
;; Start StringThe day after 
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
local.get $y
call $printi

i32.const 39
call $printc
local.get $m
call $printi

i32.const 39
call $printc
local.get $d
call $printi
;; Start String is 
 i32.const 0
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
local.get $y
local.get $m
local.get $d

call $next_day
local.set $next ;; VARIABLE ASSIGN
local.get $next
i32.const 0

call $get
call $printi

i32.const 39
call $printc
local.get $next
i32.const 1

call $get
call $printi

i32.const 39
call $printc
local.get $next
i32.const 2

call $get
call $printi
call $println
i32.const 0  

)

 (func 
 $main
   (export "main")
    (result i32)
(local $_temp i32)

i32.const 2020
i32.const 2
i32.const 28
call $print_next_day
i32.const 2021
i32.const 2
i32.const 13
call $print_next_day
i32.const 2021
i32.const 2
i32.const 28
call $print_next_day
i32.const 2021
i32.const 12
i32.const 31
call $print_next_day
i32.const 0  

)

)
