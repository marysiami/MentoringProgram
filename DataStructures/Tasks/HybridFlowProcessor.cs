using System;
using System.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> _queue;
        
        public HybridFlowProcessor()
        {
            _queue = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (!_queue.Any())
            {
                throw new InvalidOperationException();
            }

            return _queue.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            _queue.Add(item);
        }

        public T Pop()
        {
            if (!_queue.Any())
            {
                throw new InvalidOperationException();
            }

            return _queue.RemoveAt(0);
        }

        public void Push(T item)
        {
            _queue.AddAt(0, item);
        }
    }
}
