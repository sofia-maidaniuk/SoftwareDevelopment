using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Iterators
{
    public class BreadthFirstIterator : ILightNodeIterator
    {
        private readonly Queue<LightNode> _pendingNodes = new Queue<LightNode>();
        private readonly HashSet<LightNode> _visitedNodes = new HashSet<LightNode>();
        private readonly LightNode _startNode;
        private LightNode _current;

        public BreadthFirstIterator(LightNode startNode)
        {
            _startNode = startNode ?? throw new ArgumentNullException(nameof(startNode));
            _pendingNodes.Enqueue(_startNode);
        }

        public bool MoveNext()
        {
            while (_pendingNodes.Count > 0)
            {
                var candidate = _pendingNodes.Dequeue();

                if (_visitedNodes.Contains(candidate))
                    continue;

                _visitedNodes.Add(candidate);
                _current = candidate;

                EnqueueChildren(candidate);

                return true;
            }

            return false;
        }

        public LightNode Current => _current;

        public void Reset()
        {
            _pendingNodes.Clear();
            _visitedNodes.Clear();
            if (_startNode != null)
                _pendingNodes.Enqueue(_startNode);
            _current = null;
        }

        private void EnqueueChildren(LightNode node)
        {
            if (node is LightElementNode element && element.Children != null)
            {
                foreach (var child in element.Children)
                {
                    if (!_visitedNodes.Contains(child))
                        _pendingNodes.Enqueue(child);
                }
            }
        }
    }
}
