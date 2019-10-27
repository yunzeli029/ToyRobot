using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core.Models
{
    public class DirectionLinkedList<T>
    {
        private DirectionNode<T> _head;
        private DirectionNode<T> _tail;
        public DirectionNode<T> Head => _head == null ? throw new NullReferenceException() : _head;
        public DirectionNode<T> Tail => _tail == null ? throw new NullReferenceException() : _tail;

        public DirectionLinkedList()
        {

        }

        /// <summary>Inserts a direction at front of the linked list</summary>
        /// <param name="data">The data.</param>
        public void InsertFront(T data)
        {

        }

        public void InsertLast(T data)
        {
        }
        }
}
