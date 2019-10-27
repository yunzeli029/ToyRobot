using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core.Models
{
    /// <summary>
    /// Doubly Circular Linked List, the next of the last node will point to the first node
    /// and the previous pointer of the first node will point to the last node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DirectionLinkedList<T>
    {
        private DirectionNode<T> _head;
        private DirectionNode<T> _tail;
        public DirectionNode<T> Head => _head == null ? throw new NullReferenceException() : _head;
        public DirectionNode<T> Tail => _tail == null ? throw new NullReferenceException() : _tail;

        public DirectionLinkedList()
        {

        }

        public DirectionLinkedList(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                InsertLast(item);
            }
        }

        /// <summary>Gets the node by key.</summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public DirectionNode<T> GetNodeByKey(T key)
        {
            DirectionNode<T> temp = _head;

            while (temp != null && !EqualityComparer<T>.Default.Equals(temp.value, key))
            {
                temp = temp.next;
                if (EqualityComparer<T>.Default.Equals(temp.value, _tail.value))
                {
                    return null;
                }
            }

            return temp;
        }
        /// <summary>Inserts an item at front of the linked list</summary>
        /// <param name="data">The data.</param>
        public void InsertFront(T data)
        {
            DirectionNode<T> newNode = new DirectionNode<T>(data);

            if (_head == null && _tail == null)
            {
                _head = newNode;
                _tail = newNode;
                _head.next = _tail;
                _head.prev = _tail;
                _tail.next = _head;
                _tail.prev = _head;
            }
            else
            {
                newNode.next = _head;
                newNode.prev = _tail;
                if (_head != null)
                {
                    _head.prev = newNode;
                }
                if (_tail != null)
                {
                    _tail.next = newNode;
                }
                _head = newNode;
            }

        }

        /// <summary>Inserts an item at the end of a linked list</summary>
        /// <param name="data">The data.</param>
        public void InsertLast(T data)
        {
            DirectionNode<T> newNode = new DirectionNode<T>(data);
            if (_head == null && _tail == null)
            {
                _head = newNode;
                _tail = newNode;
                _head.next = _tail;
                _head.prev = _tail;
                _tail.next = _head;
                _tail.prev = _head;
            }
            else
            {
                newNode.prev = _tail;
                _tail.next = newNode;
                newNode.next = _head;
                _head.prev = newNode;
                _tail = newNode;
            }
        }
    }
}
