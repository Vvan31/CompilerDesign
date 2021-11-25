# Buttercup compiler, version 0.5

This program is free software. You may redistribute it under the terms of the GNU General Public License version 3 or later. See `license.txt` for details.

Included in this release:

* Lexical analysis
* Syntactic analysis
* AST construction
* Semantic analysis
* Wat code generation

## Requirements

Additionally to the Mono C# software, make sure your system has the following installed:

* Python 3
* The Wasmer Python package

### Python 3

You’ll need Python version 3.6 or newer. To check that you have the correct version of Python, at the terminal type:

    python -V

**NOTE:** You might need to use the command `python3` instead.

The output should be something like this:

    Python 3.9.2

Go to the [Python website](https://www.python.org/downloads/) if you don’t have Python installed or if it’s older than 3.6.

### Wasmer

The [Wasmer Python package](https://github.com/wasmerio/wasmer-python) brings the required API to execute WebAssembly modules from within a Python runtime system.

To install Wasmer, type at the terminal the following two commands:

    pip install wasmer==1.0.0
    pip install wasmer_compiler_cranelift==1.0.0

**NOTE:** If in the previous section you had to use the `python3` command, then you should use `pip3` here as well. Also, you might need to prepend `sudo` to run the command with admin privileges.

## How to Build

At the terminal type:

    make

## How to Run

At the terminal type:

    mono buttercup.exe <buttercup_source_file>

Where `<buttercup_source_file>` is the name of a Buttercup source file. You can try with these files:

* `prog1.bcup`
* `prog2.bcup`

To execute the resulting Wat files, type:

    ./execute.py <wat_file>

Where `<wat_file>` is a WebAssembly text file, for example:

* `prog1.wat`
* `prog2.wat`

## How to Clean

To delete all the files that get created automatically, at the terminal type:

    make clean
