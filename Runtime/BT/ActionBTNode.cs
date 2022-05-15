using System;
using System.Collections.Generic;
using Ryuu.BehaviorControl.Core;

// ReSharper disable InconsistentNaming

namespace Ryuu.BehaviorControl.BT
{
    public class ActionBTNode : BTNode
    {
        private readonly Func<Status> onExecute;

        public ActionBTNode(string name, List<string> tags, Func<Status> onExecute) : base(name, tags)
        {
            this.onExecute = onExecute;
        }

        public override Status Execute() => onExecute.Invoke();
    }
}