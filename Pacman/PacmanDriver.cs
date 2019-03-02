using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    // this class is responsible for recieving and parsing commands for the pacman 
    public class PacmanDriver
    {
        public PacmanDriver(Pacman pacman)
        {
            this.Pacman = pacman;
        }

        public Pacman Pacman { get; set; }

        public string Command(string command)
        {
            string response = "";
            InstructionArguments args = null;
            var instruction = GetInstruction(command, ref args);

            switch (instruction)
            {
                case Instruction.Place:
                    var placeArgs = (PlaceInstructionArguments)args;
                    if (Pacman.Place(placeArgs.X, placeArgs.Y, placeArgs.Facing))
                    {
                        response = "Done";
                    }
                    else
                    {
                        response = Pacman.Error;
                    }
                    break;
                case Instruction.Move:
                    if(Pacman.Move())
                    {
                        response = "Done";
                    }
                    else
                    {
                        response = Pacman.Error;
                    }
                    break;
                case Instruction.Left:
                    if (Pacman.Left())
                    {
                        response = "Done";
                    }
                    else
                    {
                        response = Pacman.Error;
                    }
                    break;
                case Instruction.Right:
                    if (Pacman.Right())
                    {
                        response = "Done";
                    }
                    else
                    {
                        response = Pacman.Error;
                    }
                    break;
                case Instruction.Report:
                    response = Pacman.Report();
                    break;
                default:
                    response = "Invalid command.";
                    break;
            }
            return response;

        }

        private Instruction GetInstruction(string command, ref InstructionArguments args)
        {
            Instruction result;
            string argString = "";

            int argsSperatorPosition = command.IndexOf(" ");
            if (argsSperatorPosition > 0)
            {
                argString = command.Substring(argsSperatorPosition + 1);
                command = command.Substring(0, argsSperatorPosition);
            }
            command = command.ToUpper();

            if (Enum.TryParse<Instruction>(command, true, out result))
            {
                if (result == Instruction.Place)
                {
                    if(!TryParsePlaceArgs(argString, ref args))
                    {
                        result = Instruction.Invalid;
                    }
                }
            }
            else
            {
                result = Instruction.Invalid;
            }
            return result;
        }

        private bool TryParsePlaceArgs(string argString, ref InstructionArguments args)
        {
            var argParts = argString.Split(',');
            int x, y;
            Facing facing;

            if (argParts.Length == 3 &&
                TryGetCoordinate(argParts[0], out x) &&
                TryGetCoordinate(argParts[1], out y) &&
                TryGetFacingDirection(argParts[2], out facing))
            {
                args = new PlaceInstructionArguments
                {
                    X = x,
                    Y = y,
                    Facing = facing,
                };
                return true;
            }
            return false;
        }

        private bool TryGetCoordinate(string coordinate, out int coordinateValue)
        {
            return int.TryParse(coordinate, out coordinateValue);
        }

        private bool TryGetFacingDirection(string direction, out Facing facing)
        {
            return Enum.TryParse<Facing>(direction, true, out facing);
        }
    }
}
