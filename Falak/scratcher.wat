(module
  

   ​(local $n i32)
   ​(local $r i32)
   ​(local $i i32)

   ​i32.const 5
   ​local.set $n      ;; n = 5;

   ​i32.const 1
   ​local.set $r      ;; r = 1;

   ​i32.const 1
   ​local.set $i      ;; i = 1;

   ​block $00001      ;; Target for BREAK
     ​loop $00002     ;; Target for CONTINUE

       ​local.get $r
       ​local.get $i
       ​i32.mul
       ​local.set $r  ;; r = r * i;

       ​local.get $i
       ​i32.const 1
       ​i32.add
       ​local.set $i  ;; i = i + 1;

       ​br $00002     ;; CONTINUE always

       local.get $i
       ​local.get $n
       ​i32.le_s      ;; i <= n

       ​i32.eqz
       ​br_if $00001  ;; BREAK when i <= n is false
     ​end             ;; End of loop
   ​end               ;; End of block
)