﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_génétique.Parameters;

namespace test_génétique.Instruction_possibles
{
    class Fork_ : Instruction
    {
        public const string RED_CODE = "fork";

        public Fork_(List<Parameter> parameters) : base(parameters)
        {
            //para_possible.Add(new Direct ());
        }
    }
}
