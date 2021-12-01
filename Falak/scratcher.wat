local get $reverseArray
 (func $sum
    (param $x i32)  ;; Parameter names and types
    (param $y i32)
    (param $z i32)
    (result i32)    ;; Return type

    (local $a i32)  ;; Local variable names and types
    (local $b i32)

    local.get $x
    local.get $y
    i32.add
    local.set $a    ;; a = x + y

    local.get $z
    local.get $a
    i32.add
    local.set $b    ;; b = z + a

    local.get $b    ;; Return b
  )