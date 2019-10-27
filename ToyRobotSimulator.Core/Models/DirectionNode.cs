using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core.Models
{
    public class DirectionNode<T>
    {

        public T current;
        public DirectionNode<T> prev;
        public DirectionNode<T> next;
        public DirectionNode(T d)
        {
            current = d;
            prev = null;
            next = null;
        }
    }
}
