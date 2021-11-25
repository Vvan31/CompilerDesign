#!/usr/bin/env python

# Buttercup Wat execution script.
# Copyright (C) 2021 Ariel Ortiz, ITESM CEM
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
# along with this program.  If not, see <http://www.gnu.org/licenses/>.

from sys import argv, stderr, exit
from wasmer import engine, Module, wat2wasm, Store, Instance
from wasmer_compiler_cranelift import Compiler
from bcuplib import make_import_object

def main():
    if len(argv) != 2:
        print('Please specify the name of the input Wat file.', file=stderr)
        exit(1)

    # Create a store
    store = Store(engine.JIT(Compiler))

    # Convert Wat file contents into Wasm binary code
    wat_file_name = argv[1]
    with open(wat_file_name) as wat_file:
        wat_source_code = wat_file.read()
    wasm_bytes = wat2wasm(wat_source_code)

    # Compile the Wasm module
    module = Module(store, wasm_bytes)

    # Obtain functions to be imported from the Wasm module
    import_object = make_import_object(store)

    # Instantiate the module
    instance = Instance(module, import_object)

    # Run start function and return to OS its exit code
    exit(instance.exports.start())

main()
