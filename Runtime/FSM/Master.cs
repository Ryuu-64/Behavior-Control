using System.Collections.Generic;
using System.Linq;
using Ryuu.BehaviorControl.Core;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.FSM
{
    public class Master : Master<FSMNode>
    {
        [SerializeField] private readonly FSMNode anyState;
        [SerializeField] private FSMNode currentState;
        [SerializeField] public string CurrentStateName => currentState?.Name;

        public Master(List<FSMNode> allNodes, FSMNode primeNode, FSMNode anyState, MonoUpdater monoUpdater,
            UpdateMode updateMode) :
            base(allNodes, primeNode, monoUpdater, updateMode)
        {
            this.anyState = anyState;
            currentState = primeNode;
            monoUpdater.Subscribe(OnUpdate, updateMode);
        }

        public void OnUpdate()
        {
            if (anyState is {Connections: { }})
            {
                foreach (FSMConnection transition in anyState.Connections)
                {
                    foreach (var condition in transition.Conditions)
                    {
                        if (condition.Invoke(transition.SourceNode, transition.TargetNode))
                        {
                            ToState(transition.TargetNode);
                            currentState.OnUpdate?.Invoke();
                            return;
                        }
                    }
                }
            }

            if (currentState is {Connections: { }})
            {
                foreach (FSMConnection transition in currentState.Connections)
                {
                    foreach (var condition in transition.Conditions)
                    {
                        if (condition.Invoke(transition.SourceNode, transition.TargetNode))
                        {
                            ToState(transition.TargetNode);
                            currentState.OnUpdate?.Invoke();
                            return;
                        }
                    }
                }
            }

            currentState.OnUpdate?.Invoke();
        }

        public void ToState(FSMNode to)
        {
            FSMNode from = currentState;
            currentState.OnExit?.Invoke(from, to);
            currentState = to;
            currentState.OnEnter?.Invoke(from, to);
        }

        public string[] GetStateNames() => AllNodes.Select(node => node.Name).ToArray();

        public FSMNode GetStateWithName(string name) => AllNodes.Find(node => node.Name == name);

        public override void Dispose() => MonoUpdater.Unsubscribe(OnUpdate);
    }
}