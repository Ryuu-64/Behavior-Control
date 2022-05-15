using System;
using System.Collections.Generic;
using Ryuu.BehaviorControl.Core;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.BT
{
    public class SelectBTNode : BTNode
    {
        private List<BTConnection> Connections;

        public SelectBTNode(string name, List<string> tags) : base(name, tags)
        {
        }

        public void SetConnections(List<BTConnection> connections)
        {
            Connections = connections;
        }

        public override Status Execute()
        {
            var status = Status.Error;
            foreach (BTConnection connection in Connections)
            {
                status = connection.Execute();
                switch (status)
                {
                    case Status.Failure:
                        continue;
                    case Status.Success:
                        return status;
                    case Status.Error:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return status;
        }
    }
}