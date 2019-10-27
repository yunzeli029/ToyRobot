﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.ApplicationException
{
    public class InvalidCommandException: Exception
    {
        public InvalidCommandException() {

        }

        public InvalidCommandException(string message):base(message)
        {

        }
    }
}
