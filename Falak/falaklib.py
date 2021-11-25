# Falak API.
# Copyright (C) 2021 Ariel Ortiz, ITESM CEM
#
# The WebAssembly text file module should include these instructions:
#
#   (import "falak" "printi" (func $printi (param i32) (result i32)))
#   (import "falak" "printc" (func $printc (param i32) (result i32)))
#   (import "falak" "prints" (func $prints (param i32) (result i32)))
#   (import "falak" "println" (func $println (result i32)))
#   (import "falak" "readi" (func $readi (result i32)))
#   (import "falak" "reads" (func $reads (result i32)))
#   (import "falak" "new" (func $new (param i32) (result i32)))
#   (import "falak" "size" (func $size (param i32) (result i32)))
#   (import "falak" "add" (func $add (param i32 i32) (result i32)))
#   (import "falak" "get" (func $get (param i32 i32) (result i32)))
#   (import "falak" "set" (func $set (param i32 i32 i32) (result i32)))
#
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with this program. If not, see <http://www.gnu.org/licenses/>.

import sys
from re import compile
from inspect import currentframe
from wasmer import ImportObject, Function

def make_import_object(store):

    INVALID_HANDLE_ERROR = 'Invalid array handle: '
    INVALID_BOUNDS_ERROR = 'Array index out of bounds: '
    HANDLES = []
    VALID_INT_REGEX = compile(r'^\s*-?\d+\s*$')

    def check_bounds(a, i, error_message, fun_name):
        """Checks if i is within bounds of array a,
        otherwise throws an exception with a given error_message.
        """
        if not (0 <= i < len(a)):
            print(f'Runtime error in function {fun_name}. {error_message}',
                file=sys.stderr)
            sys.exit(1)

    #----------------------------------------------------------------
    # Functions to be imported from the Wasm module

    def printi(i: int) -> int:
        """Prints i to stdout as a decimal integer. Does not print a
        new line at the end. Returns 0.
        """
        print(i, end='')
        return 0

    def printc(c: int) -> int:
        """Prints a character to stdout, where c is its Unicode code
        point. Does not print a new line at the end. Returns 0.
        """
        print(chr(c), end='')
        return 0

    def prints(s: int) -> int:
        """Prints s to stdout as a string. s must be a handle to an
        array list containing zero or more Unicode code points.
        Does not print a new line at the end. Returns 0.
        """
        check_bounds(HANDLES, s, INVALID_HANDLE_ERROR + str(s),
            currentframe().f_code.co_name)
        print(''.join([chr(c) for c in HANDLES[s]]), end='')
        return 0

    def println() -> int:
        """Prints a newline character to stdout. Returns 0.
        """
        print()
        return 0

    def readi() -> int:
        """Reads from stdin a signed decimal integer and return its
        value. Does not return until a valid integer has been read.
        """
        data = ''
        while not VALID_INT_REGEX.match(data):
            data = input()
        return int(data)

    def reads() -> int:
        """
        Reads from stdin a string (until the end of line) and returns
        a handle to a newly created array list containing the Unicode
        code points of all the characters read, excluding the end of
        line.
        """ 
        data = input()
        HANDLES.append([ord(c) for c in data])
        return len(HANDLES) - 1

    def new(n: int) -> int:
        """Creates a new array list object with n elements and returns
        its handle. All the elements of the array list are set to
        zero. Throws an exception if n is less than zero.
        """
        if n < 0:
            print('Runtime error in function new. '
                f"Can't create a negative size array: {n}",
                file=sys.stderr)
            sys.exit(1)
        HANDLES.append([0] * n)
        return len(HANDLES) - 1

    def size(h: int) -> int:
        """Returns the size (number of elements) of the array list
        referenced by handle h. Throws an exception if h is not
        a valid handle.
        """
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        return len(HANDLES[h])

    def add(h: int, x: int) -> int:
        """Adds x at the end of the array list referenced by handle h.
        Returns 0. Throws an exception if h is not a valid handle.
        """
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        HANDLES[h].append(x)
        return 0

    def get(h: int, i: int) -> int:
        """Returns the value at index i from the array list referenced by
        handle h. Throws an exception if i is out of bounds or if h is
        not a valid handle.
        """
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        check_bounds(HANDLES[h], i, INVALID_BOUNDS_ERROR + str(i),
            currentframe().f_code.co_name)
        return HANDLES[h][i]

    def set(h: int, i: int, x: int) -> int:
        """Sets to x the element at index i of the array list referenced
        by handle h. Returns 0. Throws an exception if i is out of
        bounds or if h is not a valid handle.
        """
        check_bounds(HANDLES, h, INVALID_HANDLE_ERROR + str(h),
            currentframe().f_code.co_name)
        check_bounds(HANDLES[h], i, INVALID_BOUNDS_ERROR + str(i),
            currentframe().f_code.co_name)
        HANDLES[h][i] = x
        return 0

    #----------------------------------------------------------------

    import_object = ImportObject()

    import_object.register(
        "falak",
        {
            "printi":  Function(store, printi),
            "printc":  Function(store, printc),
            "prints":  Function(store, prints),
            "println": Function(store, println),
            "readi":   Function(store, readi),
            "reads":   Function(store, reads),
            "new":     Function(store, new),
            "size":    Function(store, size),
            "add":     Function(store, add),
            "get":     Function(store, get),
            "set":     Function(store, set),
        }
    )

    return import_object