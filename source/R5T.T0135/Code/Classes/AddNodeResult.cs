using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0135
{
    /// <summary>
    /// Represents the result of adding a descendant to a node.
    /// Allows the node to which a descendant was added, and an annotation to the descendant was added, to travel together.
    /// </summary>
    public class AddNodeResult<TParentNode> : INodeResultWithAnnotation<TParentNode>
        where TParentNode : SyntaxNode
    {
        #region Static

        public static implicit operator TParentNode(AddNodeResult<TParentNode> annotatedNode)
        {
            return annotatedNode.ParentNode;
        }

        public static implicit operator SyntaxAnnotation(AddNodeResult<TParentNode> annotatedNode)
        {
            return annotatedNode.DescendantAnnotation;
        }

        #endregion


        /// <summary>
        /// The parent node to which a descendant was added.
        /// </summary>
        public TParentNode ParentNode { get; }
        /// <summary>
        /// An annotation to the descendant that was added.
        /// </summary>
        public SyntaxAnnotation DescendantAnnotation { get; }

        TParentNode INodeResultWithAnnotation<TParentNode>.Node => this.ParentNode;
        SyntaxAnnotation INodeResultWithAnnotation<TParentNode>.SyntaxAnnotation => this.DescendantAnnotation;


        public AddNodeResult(
            TParentNode parentNode,
            SyntaxAnnotation descendantAnnotation)
        {
            this.ParentNode = parentNode;
            this.DescendantAnnotation = descendantAnnotation;
        }

        public void Deconstruct(
            out TParentNode parentNode,
            out SyntaxAnnotation descendantAnnotation)
        {
            parentNode = this.ParentNode;
            descendantAnnotation = this.DescendantAnnotation;
        }
    }


    public static class AddNodeResult
    {
        public static AddNodeResult<TParentNode> From<TParentNode>(
            TParentNode parentNode,
            SyntaxAnnotation descendantAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = new AddNodeResult<TParentNode>(
                parentNode,
                descendantAnnotation);

            return output;
        }
    }
}
