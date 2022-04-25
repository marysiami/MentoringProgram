using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private ListNode<T> _startNode;
        private int _length = 0;
        public int Length { get { return _length; } }

        //test note for commit
        public void Add(T e)
        {
            var node = new ListNode<T>(e);

            if (_startNode == null)
            {
                _startNode = node;
            }
            else
            {
                var currentNode = _startNode;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = node;
                node.Previous = currentNode;
            }     
            
            _length++;
        }

        public void AddAt(int index, T e)
        {
            var node = new ListNode<T>(e);

            if (!IsValidAddAtPosition(index))
            {
                throw new IndexOutOfRangeException();
            }

            if (_startNode == null)
            {
                _startNode = node;

                return;
            }
            
            if (IsFirstPosition(index))
            {
                _startNode.Previous = node;
                
                node.Next = _startNode;
                
                _startNode = node;
            }            
            else if (IsLastValidAddPosition(index))
            {
                var lastNode = NodeElementAt(index - 1);

                lastNode.Next = node;
                node.Previous = lastNode;
            }
            else
            {
                var nodeAtInsertPosition = NodeElementAt(index);

                node.Previous = nodeAtInsertPosition.Previous;
                node.Next = nodeAtInsertPosition;

                nodeAtInsertPosition.Previous.Next = node;
                nodeAtInsertPosition.Previous = node;
            }

            _length++;
        }

        private bool IsValidAddAtPosition(int index)
        {
            return index >= 0 && index <= _length;
        }

        private bool IsFirstPosition(int index)
        {
            return index == 0;
        }
        private bool IsLastPosition(int index)
        {
            return index == _length - 1;
        }

        private bool IsLastValidAddPosition(int index)
        {
            return index == _length;
        }

        public T ElementAt(int index)
        {
            return NodeElementAt(index).Data;
        }

        public ListNode<T> NodeElementAt(int index)
        {
            if (!IsValidAtPosition(index))
            {
                throw new IndexOutOfRangeException();
            }

            int currentPosition = 0;
            var currentNode = _startNode;

            while (currentPosition < index)
            {
                currentNode = currentNode.Next;

                currentPosition++;
            }

            return currentNode;
        }

        private bool IsValidAtPosition(int index)
        {
            return index >= 0 && index < _length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this);
        }

        public void Remove(T item)
        {
            var currentNode = _startNode;
            var currentPosition = 0;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    RemoveNode(currentNode, currentPosition);

                    return;
                }

                currentNode = currentNode.Next;
                currentPosition++;
            }
        }

        public T RemoveAt(int index)
        {
            if (!IsValidAtPosition(index))
            {
                throw new IndexOutOfRangeException("index");
            }

            var currentNode = _startNode;
            var currentPosition = 0;

            while (currentNode != null)
            {
                if (currentPosition == index)
                {
                    RemoveNode(currentNode, currentPosition);

                    return currentNode.Data;
                }

                currentNode = currentNode.Next;
                currentPosition++;
            }

            throw new ArgumentException("Element not found!");
        }

        private void RemoveNode(ListNode<T> node, int nodePosition)
        {
            if (IsFirstPosition(nodePosition))
            {
                _startNode = node.Next;
                _startNode.Previous = null;
            }
            else if (IsLastPosition(nodePosition))
            {
                node.Previous.Next = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }

            _length--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
