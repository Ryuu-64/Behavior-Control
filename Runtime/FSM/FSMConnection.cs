using System;
using System.Collections.Generic;
using Ryuu.BehaviorControl.Core;

// ReSharper disable SuggestBaseTypeForParameterInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.FSM
{
    public class FSMConnection : Connection<FSMNode>
    {
        public readonly List<Func<FSMNode, FSMNode, bool>> Conditions;

        public FSMConnection(FSMNode sourceNode, FSMNode targetNode, List<Func<FSMNode, FSMNode, bool>> conditions) :
            base(sourceNode, targetNode)
        {
            Conditions = conditions;
        }
    }
}