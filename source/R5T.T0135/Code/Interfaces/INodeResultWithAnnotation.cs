using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0135
{
    public interface INodeResultWithAnnotation<TNode>
        where TNode : SyntaxNode
    {
        TNode Node { get; }
        SyntaxAnnotation SyntaxAnnotation { get; }
    }
}
