using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DoublyLinkedList<T> _list;

        int position = -1;

        public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
        {
            _list = list;
        }

        public T Current => _list.ElementAt(position);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position++;
            return (position < _list.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}