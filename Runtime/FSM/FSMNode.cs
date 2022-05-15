using System;
using System.Collections.Generic;
using Ryuu.BehaviorControl.Core;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.FSM
{
    public class FSMNode : Node
    {
        public readonly Action<FSMNode, FSMNode> OnEnter;
        public readonly Action OnUpdate;
        public readonly Action<FSMNode, FSMNode> OnExit;
        public List<FSMConnection> Connections;

        public FSMNode(string name, List<string> tags, Action<FSMNode, FSMNode> onEnter, Action onUpdate, Action<FSMNode, FSMNode> onExit) : base(name, tags)
        {
            OnEnter = onEnter;
            OnUpdate = onUpdate;
            OnExit = onExit;
        }

        public void SetConnections(List<FSMConnection> connections)
        {
            Connections = connections;
        }
    }
}