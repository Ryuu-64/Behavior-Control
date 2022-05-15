using System.Collections.Generic;

// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.Core
{
    public abstract class Node
    {
        public readonly string Name;
        public readonly List<string> Tags;

        protected Node(string name, List<string> tags)
        {
            Name = name;
            Tags = tags;
        }
    }
}