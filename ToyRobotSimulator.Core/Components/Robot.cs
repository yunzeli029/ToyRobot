using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Core.Components
{
    public interface IRobot {
        void Move();
        void RotateLeft();
        void RotateRight();
        string Report();
    }
    public class Robot: IRobot
    {
        private readonly DirectionLinkedList<DirectionEnum> DirectionList;
        private readonly Boundary boundary;
        public DirectionNode<DirectionEnum> Direction;
        public Position position;
        public readonly int dimension = 5;
        /// <summary>Initializes a new instance of the <see cref="Robot"/> class.</summary>
        public Robot() {
            DirectionList = new DirectionLinkedList<DirectionEnum>(
                new List<DirectionEnum>() {
                    DirectionEnum.NORTH,
                    DirectionEnum.EAST,
                    DirectionEnum.SOUTH,
                    DirectionEnum.WEST,
                });
            position = new Position(0, 0);
            Direction = DirectionList.Head;
            boundary = new Boundary(0,0, dimension - 1, dimension-1);
        }


        /// <summary>Initializes a new instance of the <see cref="Robot"/> class.</summary>
        /// <param name="x"> x coordinate</param>
        /// <param name="y"> y coordinate</param>
        /// <param name="direction"> default robot direction.</param>
        /// <param name="boundary"> map boundary.</param>
        public Robot(int x, int y, DirectionEnum direction, Boundary boundary)
        {
            DirectionList = new DirectionLinkedList<DirectionEnum>(
                new List<DirectionEnum>() {
                    DirectionEnum.NORTH,
                    DirectionEnum.EAST,
                    DirectionEnum.SOUTH,
                    DirectionEnum.WEST,
                });
            position = new Position(x, y);
            Direction = DirectionList.GetNodeByKey(direction);
            this.boundary = boundary;
        }

        /// <summary>
        ///   <para> Robot Move.</para>
        ///   <para> If the robot would not fall down, then move </para>
        /// </summary>
        public void Move()
        {
            switch (Direction.value)
            {
                case DirectionEnum.NORTH:
                    if (position.Y < boundary.MaxY)
                    {
                        position.Y += 1;
                    }
                    break;
                case DirectionEnum.EAST:
                    if (position.X < boundary.MaxX)
                    {
                        position.X += 1;
                    }
                    break;
                case DirectionEnum.SOUTH:
                    if (position.Y > boundary.MinY)
                    {
                        position.Y -= 1;
                    }
                    break;
                case DirectionEnum.WEST:
                    if (position.X > boundary.MinX)
                    {
                        position.X -= 1;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>Rotates the robot left.</summary>
        public void RotateLeft()
        {
            Direction = Direction.prev;
        }

        /// <summary>Rotates the robot right.</summary>
        public void RotateRight()
        {
            Direction = Direction.next;
        }

        /// <summary>Report robot's position</summary>
        public string Report()
        {
            return String.Join(",", position.X, position.Y, Direction.value.ToString());
        }
    }
}
