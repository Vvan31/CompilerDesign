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
(local $_temp i32)
;; IF statement 
local.get $y ;; VARIABLE ASSIGN
 
i32.const 4
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 ;; IF statement 
local.get $y ;; VARIABLE ASSIGN
 
i32.const 100
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
 ;; IF statement 
local.get $y ;; VARIABLE ASSIGN
 
i32.const 400
 
i32.rem_s 
 
i32.const 0
 
i32.eq 
if
;;; Stmlist if
     i32.const 1
return
;; else statement 
else
    i32.const 0
return

end
;; else statement 
else
    i32.const 1
return

end
;; else statement 
else
    i32.const 0
return

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
local.get $m ;; VARIABLE ASSIGN
 
i32.const 2
 
i32.eq 
if
;;; Stmlist if
 ;; IF statement 
local.get $y ;; VARIABLE ASSIGN

call $is_leap_year
if
;;; Stmlist if
 i32.const 29
local.set $result ;; VARIABLE ASSIGN
;; else statement 
else
i32.const 28
local.set $result ;; VARIABLE ASSIGN

end
;; elseif statement 
else
local.get $m ;; VARIABLE ASSIGN
 
i32.const 4
 
i32.eq 
 
local.get $m ;; VARIABLE ASSIGN
 
i32.const 6
 
i32.eq 
 
i32.or 
 
local.get $m ;; VARIABLE ASSIGN
 
i32.const 9
 
i32.eq 
 
i32.or 
 
local.get $m ;; VARIABLE ASSIGN
 
i32.const 11
 
i32.eq 
 
i32.or 

if
i32.const 30
local.set $result ;; VARIABLE ASSIGN

;; else statement 
else
i32.const 31
local.set $result ;; VARIABLE ASSIGN

end
end
local.get $result ;; VARIABLE ASSIGN
return
i32.const 0  

)

 (func $next_day
(param $y i32)
(param $m i32)
(param $d i32)
(result i32) 
(local $_temp i32)
;; IF statement 
local.get $d ;; VARIABLE ASSIGN
 
local.get $y ;; VARIABLE ASSIGN
local.get $m ;; VARIABLE ASSIGN

call $number_of_days_in_month
 
i32.eq 
if
;;; Stmlist if
 ;; IF statement 
local.get $m ;; VARIABLE ASSIGN
 
i32.const 12
 
i32.eq 
if
;;; Stmlist if
 local.get $y ;; VARIABLE ASSIGN
 
i32.const 1
 
i32.add 
i32.const 1
i32.const 1
return
;; else statement 
else
local.get $y ;; VARIABLE ASSIGN
local.get $m ;; VARIABLE ASSIGN
 
i32.const 1
 
i32.add 
i32.const 1
return

end
;; else statement 
else
local.get $y ;; VARIABLE ASSIGN
local.get $m ;; VARIABLE ASSIGN
local.get $d ;; VARIABLE ASSIGN
 
i32.const 1
 
i32.add 
return

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
;; Start String: The day after 
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
drop
local.get $y ;; VARIABLE ASSIGN
call $printi
drop

i32.const 47
call $printc
drop
local.get $m ;; VARIABLE ASSIGN
call $printi
drop

i32.const 47
call $printc
drop
local.get $d ;; VARIABLE ASSIGN
call $printi
drop
;; Start String:  is 
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
drop
local.get $y ;; VARIABLE ASSIGN
local.get $m ;; VARIABLE ASSIGN
local.get $d ;; VARIABLE ASSIGN

call $next_day
local.set $next ;; VARIABLE ASSIGN
local.get $next ;; VARIABLE ASSIGN
i32.const 0

call $get
call $printi
drop

i32.const 47
call $printc
drop
local.get $next ;; VARIABLE ASSIGN
i32.const 1

call $get
call $printi
drop

i32.const 47
call $printc
drop
local.get $next ;; VARIABLE ASSIGN
i32.const 2

call $get
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
