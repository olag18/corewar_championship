﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_génétique.Parameters;

namespace test_génétique.Instruction_possibles
{
    class Zjmp : Instruction
    {
        public const string RED_CODE = "zjmp";

        public Zjmp(List<Parameter> parameters) : base(parameters)
        {
           // para_possible.Add(new Direct());
            
        }
    }
}
