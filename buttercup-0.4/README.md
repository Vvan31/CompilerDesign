# Buttercup compiler, version 0.4

This program is free software. You may redistribute it under the terms of the GNU General Public License version 3 or later. See `license.txt` for details.

Included in this release:

* Lexical analysis
* Syntactic analysis
* AST construction
* Semantic analysis

## How to Build

At the terminal type:

    make

## How to Run

At the terminal type:

    mono buttercup.exe <buttercup_source_file>

Where `<buttercup_source_file>` is the name of a Buttercup source file. You can try with these files:

* `prog1.bcup`
* `prog2.bcup`

## How to Clean

To delete all the files that get created automatically, at the terminal type:

    make clean
