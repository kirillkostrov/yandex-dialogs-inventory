﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceInventory.Logic.Parser
{
    public class ParsedCommand
    {
        public ParsedCommandType Type { get; set; }
        public object Data { get; set; }
    }
}