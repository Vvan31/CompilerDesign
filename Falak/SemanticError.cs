using System;

namespace Buttercup {

    class SemanticError: Exception {

        public SemanticError(string message, Token token):
            base($"Semantic Error: {message} \n"
                 + $"at row {token.Row}, column {token.Column}.") {
        }
    }
}
