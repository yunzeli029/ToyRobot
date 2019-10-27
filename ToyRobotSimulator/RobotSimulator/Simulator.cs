using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.ApplicationException;
using ToyRobotSimulator.Core.Components;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.RobotSimulator
{
    public class Simulator
    {
        private readonly int width = 5;
        private readonly int length = 5;
        private readonly Boundary boundary;
        private Robot robot;
        public Simulator()
        {
            boundary = new Boundary(0, 0, width - 1, length - 1);
        }


        /// <summary>Commands the specified command.</summary>
        /// <param name="command">The command.</param>
        /// <param name="inputs">The inputs.</param>
        /// <returns></returns>
        /// <exception cref="InvalidCommandException">Robot does not exist
        /// or
        /// Invalid command</exception>
        public string Command(CommandEnum command, string inputs = "")
        {
            if (command != CommandEnum.PLACE && robot == null)
            {
                throw new InvalidCommandException("Robot does not exist");
            }
            switch (command)
            {
                case CommandEnum.PLACE:
                    Place(inputs);
                    break;
                case CommandEnum.MOVE:
                    robot.Move();
                    break;
                case CommandEnum.LEFT:
                    robot.RotateLeft();
                    break;
                case CommandEnum.RIGHT:
                    robot.RotateRight();
                    break;
                case CommandEnum.REPORT:
                    return robot.Report();
                default:
                    throw new InvalidCommandException("Invalid command");
            }
            return "";
        }

        /// <summary>Place the robot with the specified inputs.</summary>
        /// <param name="inputs">The inputs.</param>
        /// <exception cref="InvalidCommandException">
        /// Invalid number of arguments. PLACE X,Y,F
        /// or
        /// X must be an integer
        /// or
        /// Y must be an integer
        /// or
        /// Invalid Direction
        /// or
        /// X is out of boundary
        /// or
        /// Y is out of boundary
        /// </exception>
        public void Place(string inputs)
        {
            var args = inputs.Split(',');
            if (args.Length < 3)
            {
                throw new InvalidCommandException("Invalid number of arguments. PLACE X,Y,F");
            }
            var parseX = Int32.TryParse(args[0], out int x);
            var parseY = Int32.TryParse(args[1], out int y);
            var parseDirection = Enum.TryParse(args[2], true, out DirectionEnum direction);
            if (!parseX)
            {
                throw new InvalidCommandException("X must be an integer");
            }
            else if (!parseY)
            {
                throw new InvalidCommandException("Y must be an integer");
            }
            else if (!parseDirection)
            {
                throw new InvalidCommandException("Invalid Direction");
            }
            else if (CheckOutOfBoundary(x,boundary.MinX,boundary.MaxX))
            {
                throw new InvalidCommandException("X is out of boundary");
            }
            else if (CheckOutOfBoundary(y, boundary.MinY, boundary.MaxY))
            {
                throw new InvalidCommandException("Y is out of boundary");
            }
            else
            {
                robot = new Robot(x, y, direction, boundary);
            }
        }

        private Boolean CheckOutOfBoundary(int val, int min, int max) {
            if (val < min || val > max) {
                return true;
            }
            return false;
        }

    }
}
