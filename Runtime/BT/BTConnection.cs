using Ryuu.BehaviorControl.Core;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.BT
{
    public class BTConnection : Connection<BTNode>
    {
        public BTConnection(BTNode sourceNode, BTNode targetNode) :
            base(sourceNode, targetNode)
        {
        }

        public virtual Status Execute() => TargetNode.Execute();
    }
}