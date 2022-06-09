using System;

using Microsoft.CodeAnalysis;

using R5T.T0135;


namespace System
{
    public static class INodeResultWithAnnotationExtensions
    {
        public static TNode DiscardAnnotation<TNode>(this INodeResultWithAnnotation<TNode> hasNodeResult)
            where TNode : SyntaxNode
        {
            var output = hasNodeResult.Node;
            return output;
        }
    }
}
