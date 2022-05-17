using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace Ryuu.BehaviorControl.Core
{
    public abstract class Master<TNode> : IDisposable where TNode : Node
    {
        [SerializeField] protected readonly List<TNode> AllNodes;
        [SerializeField] protected readonly TNode PrimeNode;
        [SerializeField] protected readonly MonoUpdater MonoUpdater;
        [SerializeField] private UpdateMode updateMode;

        public UpdateMode UpdateMode
        {
            get => updateMode;
            set
            {
                updateMode = value;
                MonoUpdater.Subscribe(OnUpdate, updateMode);
            }
        }

        protected Master(List<TNode> allNodes, TNode primeNode, MonoUpdater monoUpdater, UpdateMode updateMode)
        {
            AllNodes = allNodes;
            PrimeNode = primeNode;
            MonoUpdater = monoUpdater;
            UpdateMode = updateMode;
        }

        public T GetNodeWithTag<T>(string tagName) where T : Node
        {
            return AllNodes.OfType<T>().FirstOrDefault(node => node.Tags.Contains(tagName));
        }

        public IEnumerable<T> GetNodesWithTag<T>(string tagName) where T : Node
        {
            return AllNodes.OfType<T>().Where(node => node.Tags.Contains(tagName));
        }

        public IEnumerable<T> GetAllNodesOfType<T>() where T : Node
        {
            return AllNodes.OfType<T>();
        }

        public abstract void OnUpdate();

        public void Dispose() => MonoUpdater.Unsubscribe(OnUpdate);
    }
}