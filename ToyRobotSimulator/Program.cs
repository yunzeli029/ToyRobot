using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.ApplicationException;
using ToyRobotSimulator.Core.Models;
using ToyRobotSimulator.RobotSimulator;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter command (press CTRL+Z to exist)");
            Console.WriteLine("");

            string line;
            var simulator = new Simulator();
            do
            {
                line = Console.ReadLine();
                if (line != null)
                {
                    var input = line.Trim().Split(' ');
                    var isValid = Enum.TryParse(input[0], true, out CommandEnum command);
                    if (isValid)
                    {
                        string arguments = "";
                        if (input.Length > 1)
                        {
                            arguments = input[1];
                        }
                        try
                        {
                            var result = simulator.Command(command, arguments);
                            if (result != "")
                            {
                                Console.WriteLine(result);
                            }
                        }
                        catch (InvalidCommandException e) {
                            Console.WriteLine(e.Message);
                        }                       
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }
                }
            } while (line != null);
        }
    }
}
