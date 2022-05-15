// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.Core
{
    public abstract class Connection<TNode> where TNode : Node
    {
        public readonly TNode SourceNode;
        public readonly TNode TargetNode;

        protected Connection(TNode sourceNode, TNode targetNode)
        {
            SourceNode = sourceNode;
            TargetNode = targetNode;
        }
    }
}