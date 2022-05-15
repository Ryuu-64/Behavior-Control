using System.Collections.Generic;
using Ryuu.BehaviorControl.Core;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Ryuu.BehaviorControl.BT
{
    public abstract class BTNode : Node
    {
        protected BTNode(string name, List<string> tags) : base(name, tags)
        {
        }

        public abstract Status Execute();
    }
}