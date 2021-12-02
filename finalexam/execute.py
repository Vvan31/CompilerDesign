#!/usr/bin/env python

from sys import argv
from wasmer import engine, Module, wat2wasm, Store, Instance
from wasmer_compiler_cranelift import Compiler

def create_instance(file_name):
    with open(file_name) as wat_file:
        return Instance(Module(Store(engine.JIT(Compiler)),
                               wat2wasm(wat_file.read())))

def main():
    instance = create_instance('output.wat')
    print(instance.exports.start())

main()
