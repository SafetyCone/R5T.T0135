using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0135
{
    public static class AddNodeResultExtensions
    {
        /// <summary>
        /// An add-node result is valid if the node contains a descendant with the descendant annotation.
        /// </summary>
        public static bool IsValid<TNode>(this AddNodeResult<TNode> result)
            where TNode : SyntaxNode
        {
            var output = result.ParentNode.HasAnnotatedNode(result.DescendantAnnotation);
            return output;
        }

        /// <summary>
        /// Tests if the node is valid, and if not, throws an exception.
        /// </summary>
        public static void Verify<TNode>(this AddNodeResult<TNode> result)
            where TNode : SyntaxNode
        {
            var isValid = result.IsValid();
            if (!isValid)
            {
                throw new Exception("Invalid add-node result: node did not have a descendant node with the descendant annotation.");
            }
        }
    }
}
