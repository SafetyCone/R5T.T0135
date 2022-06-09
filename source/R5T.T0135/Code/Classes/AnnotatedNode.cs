using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0135
{
    /// <summary>
    /// Allows a node and an annotation to that node to travel together.
    /// </summary>
    public class AnnotatedNode<TNode> : INodeResultWithAnnotation<TNode>
        where TNode : SyntaxNode
    {
        #region Static

        public static implicit operator TNode(AnnotatedNode<TNode> annotatedNode)
        {
            return annotatedNode.Node;
        }

        public static implicit operator SyntaxAnnotation(AnnotatedNode<TNode> annotatedNode)
        {
            return annotatedNode.SyntaxAnnotation;
        }

        #endregion


        /// <summary>
        /// The syntax node.
        /// </summary>
        public TNode Node { get; }
        /// <summary>
        /// An annotation to the syntax node.
        /// </summary>
        public SyntaxAnnotation SyntaxAnnotation { get; }


        public AnnotatedNode(
            TNode node,
            SyntaxAnnotation annotation)
        {
            this.Node = node;
            this.SyntaxAnnotation = annotation;
        }
    }


    public static class AnnotatedNode
    {
        public static AnnotatedNode<TNode> From<TNode>(
            TNode node,
            SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var output = new AnnotatedNode<TNode>(
                node,
                annotation);

            return output;
        }
    }
}