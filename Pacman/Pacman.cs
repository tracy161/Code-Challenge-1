using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Pacman
    {
        public Pacman()
        {
            Error = "";
        }
        private const int TABLE_SIZE = 5;
        private int? _x;
        private int? _y;
        private Facing _facing;

        public string Error { get; set; }

        public bool Place(int x, int y, Facing facing)
        {
            if (PacmanIsOnTable(x, y, "placed")) //{0}
            {
                _x = x;
                _y = y;
                _facing = facing;
                return true;
            }
            return false;
        }

        public bool Move()
        {
            if (PacmanIsPlaced("move")) //placeover index = {0}
            {
                int newx = GetXAfterMove();
                int newy = GetYAfterMove();
                if (PacmanIsOnTable(newx, newy, "moved"))
                {
                    _x = newx;
                    _y = newy;
                    return true;
                }
            }
            return false;
        }

        private int GetXAfterMove()
        {
            if (_facing == Facing.East)
            {
                return _x.Value + 1;
            }
            else
            {
                if (_facing == Facing.West)
                {
                    return _x.Value - 1;
                }
            }
            return _x.Value;
        }

        private int GetYAfterMove()
        {
            if (_facing == Facing.North)
            {
                return _y.Value + 1;
            }
            else
            {
                if (_facing == Facing.South)
                {
                    return _y.Value - 1;
                }
            }
            return _y.Value;
        }

        public bool Left()
        {
            return Turn(Direction.Left);
        }

        public bool Right()
        {
            return Turn(Direction.Right);
        }

        private bool Turn(Direction direction)
        {
            if (PacmanIsPlaced("turn")) //placeover index = {0}
            {
                var facingAsNumber = (int)_facing;
                facingAsNumber += 1 * (direction == Direction.Right ? 1 : -1);
                if (facingAsNumber == 5) facingAsNumber = 1;
                if (facingAsNumber == 0) facingAsNumber = 4;
                _facing = (Facing)facingAsNumber;
                return true;               
            }
            return false;
        }

        public string Report()
        {
            if (PacmanIsPlaced("report the position")) // placeover index = {0}
            {
                return String.Format("Output: {0},{1},{2}", _x.Value, _y.Value, _facing.ToString().ToUpper()); // placeover index for X, Y, Facing
            }
            return "";
        }

        private bool PacmanIsPlaced(string action) // with "turn", "move", and "report the position" input => use index {0}
        {
            if (!_x.HasValue || !_y.HasValue)
            {
                Error = String.Format("Pacman cannot {0} until it has been placed on the table.", action);
                return false;
            }
            return true;
        }
        
        private bool PacmanIsOnTable(int x, int y, string action) //with "placed" input
        {
            if (x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE)
            {
                Error = String.Format("Pacman cannot be {0} outside the table.", action);
                return false;
            }
            return true;
        }

    }

}
