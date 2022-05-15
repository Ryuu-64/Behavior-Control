using System.Collections.Generic;
using Ryuu.BehaviorControl.Core;

// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.BT
{
    public class Master : Master<BTNode>
    {
        public Master(List<BTNode> allNodes, BTNode primeNode, MonoUpdater monoUpdater, UpdateMode updateMode) : 
            base(allNodes, primeNode, monoUpdater, updateMode)
        {
            monoUpdater.Subscribe(OnUpdate, updateMode);
        }

        public void OnUpdate()
        {
            PrimeNode.Execute();
        }

        public override void Dispose() => MonoUpdater.Unsubscribe(OnUpdate);
    }
}