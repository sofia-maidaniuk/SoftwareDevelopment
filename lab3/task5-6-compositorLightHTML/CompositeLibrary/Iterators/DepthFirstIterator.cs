using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Iterators
{
    public class DepthFirstIterator : ILightNodeIterator
    {
        private readonly Stack<LightNode> _pendingNodes = new Stack<LightNode>();
        private readonly LightNode _startNode;
        private LightNode _currentNode;

        public DepthFirstIterator(LightNode root)
        {
            _startNode = root ?? throw new ArgumentNullException(nameof(root));
            _pendingNodes.Push(_startNode);
        }

        public bool MoveNext()
        {
            if (_pendingNodes.Count == 0)
                return false;

            _currentNode = _pendingNodes.Pop();

            PushChildren(_currentNode);

            return true;
        }

        public LightNode Current => _currentNode;

        public void Reset()
        {
            _pendingNodes.Clear();
            if (_startNode != null)
                _pendingNodes.Push(_startNode);
            _currentNode = null;
        }

        private void PushChildren(LightNode node)
        {
            if (node is LightElementNode element && element.Children != null)
            {
                // у зворотному порядку для правильного DFS
                for (int i = element.Children.Count - 1; i >= 0; i--)
                {
                    _pendingNodes.Push(element.Children[i]);
                }
            }
        }
    }
}
