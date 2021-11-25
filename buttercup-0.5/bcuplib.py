# Buttercup runtime library.
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

from wasmer import ImportObject, Function

def make_import_object(store):

    #----------------------------------------------------------------
    # Functions to be imported from the Wasm module
    def print_int(arg: int):
        print(arg)

    def print_bool(arg: int):
        print('#t' if arg else '#f')
    #----------------------------------------------------------------

    import_object = ImportObject()

    import_object.register(
        "buttercup",
        {
            "print_int": Function(store, print_int),
            "print_bool": Function(store, print_bool)
        }
    )

    return import_object
