﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using test_génétique.Instruction_possibles;
using test_génétique.Parameters;

namespace test_génétique
{
    class Program
    {

        public const string CHAMPIONS_FOLDER = @"D:\path\corewar_championship\ressources\champstest\"; //TODO: ASSIGN THIS VALUE
        public const string CHAMPIONS_NEW_FOLDER = @"D:\path\corewar_championship\ressources\champ_generated\";

        static void Main(string[] args)
        {
            // rates are to be optimyze latter on
            double selection_rate = 0.5;
            double hybridation_rate = 2;
            double mutation_rate = 0.01;

            int begining_pop = 100;
            int nb_generation = 300;



            List<Champion> champions = new List<Champion>();
            List<Champion> Kids = new List<Champion>();

            champions = initChampions(champions);
            Kids = Evolution.Hybridation(champions, 0.5, 1);

            foreach (Champion kid in Kids)
                champions.Add(kid);

            generateChampionsfiles(champions);


            //Console.ReadKey();
            /*Field range = new Field(10, 20);
            Randomyzer randomyse = new Randomyzer(range);
            Factory facto = new Factory(randomyse);
            Genetics Darwin = new Genetics(randomyse, facto, range, nb_generation, begining_pop, hybridation_rate, mutation_rate, selection_rate);

            Champion Champ = Darwin.Run_genetics();*/

        }

        public static List<Champion> initChampions(List<Champion> champions)
        {
            string[] filePaths = Directory.GetFiles(CHAMPIONS_FOLDER);
            int i = 0;

            foreach(string filename in filePaths)
            {
                
                if (filename.IndexOf(".dmp") > -1) {
                    i += 1;
                    Champion champion = new Champion(readInstructions(filename),  new ID(0,i,0));
                    champion.Nb_instruction = champion.Instructions.Count();
                    champions.Add(champion);
                }
            }

            return champions;
        }

        public static void generateChampionsfiles(List<Champion> champions)
        {
            foreach(Champion champion in champions){
                champion.generateRedCode(); //TODO:: A TESTER
            }
        }

        public static List<Instruction> readInstructions(string filePath)
        {
            int width = 0;

            //string path = @"D:\Hugo\corewar_championship\ressources\champstest\Asombra.cor.dmp";

            // Init str_instruction list
            List<Instruction> listInstructions = new List<Instruction>();

            //System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
            StreamReader file = new System.IO.StreamReader(filePath);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                // If it's a comment line then go to the next one
                if (line.Equals(null) || line == string.Empty) //TODO pensser a ignorer les lignes vides
                    continue;

                if (line[0] == '.')
                    continue;

                // clean the line
                line = line.Replace("\t", "");

                // Separate the str_instruction from the str_parameters.Split(',');
                string str_instruction = line.Substring(0, line.IndexOf(' '));
                string str_parameters = line.Substring(line.IndexOf(' '), line.Length- line.IndexOf(' '));

                // Init param list
                List<Parameter> listParameters = new List<Parameter>();

                // Separate each param (separated by ',')
                foreach (string str_parameter in str_parameters.Split(','))
                {
                    string str_parameter_ = str_parameter.Replace(" ", "");

                    // Define str_parameter_'s value
                    string parameter_value = str_parameter_.Replace("%", "");
                    parameter_value = parameter_value.Replace("r", "");


                    Parameter parameter;
                    // Define str_parameter_'s type
                    //if (str_parameter_.IndexOf('%') > -1)
                    if(str_parameter_.IndexOf(Direct.getRedCode()) > 1)
                        parameter = new Direct(parameter_value);
                    //else if (str_parameter_.IndexOf('r') > -1)
                    else if (str_parameter_.IndexOf(Registre.getRedCode()) > -1)
                        parameter = new Registre(parameter_value);
                    else
                        parameter = new Indirect(parameter_value);

                    parameter.value = parameter_value;
                    listParameters.Add(parameter);
                }

                // Define Instruction type
                Instruction instruction;
                switch(str_instruction)
                {
                  case "add":
                      instruction = new Add_();
                      break;

                  case "and":
                      instruction = new And_();
                      break;

                  case "fork":
                      instruction = new Fork_();
                      break;

                  case "ld":
                      instruction = new Ld();
                      break;

                  case "ldi":
                      instruction = new Ldi();
                      break;

                  case "lfork":
                      instruction = new Lfork_();
                      break;

                  case "live":
                      instruction = new Live();
                      break;

                  case "lld":
                      instruction = new Lld_();
                      break;

                  case "lldi":
                      instruction = new Lldi_();
                      break;

                  case "or":
                      instruction = new Or_();
                      break;

                  case "st":
                      instruction = new St();
                      break;

                  case "sti":
                      instruction = new Sti();
                      break;

                  case "sub":
                      instruction = new Sub();
                      break;

                  case "xor":
                      instruction = new Xor();
                      break;

                  case "zjmp":
                      instruction = new Zjmp();
                      break;

                  default:
                      instruction = new Instruction();
                      break;
                }
                instruction.parameters = listParameters;
                listInstructions.Add(instruction);
            }

            file.Close();

            return listInstructions;

        }
    }

}
