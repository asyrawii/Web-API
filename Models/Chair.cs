using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChairLibrary
{
    public class Chair
    {

        public Chair()
        {

        }
        public int ChairID { get; set; }
        public bool HasWheels { get; set; }

        public int Height
        {
            set;
            get;
        }

        public int Length
        {
            set;
            get;
        }

        public int Width
        {
            set;
            get;
        }

        public string Colour
        {
            set;
            get;
        }

        public bool IsBig(int x, int y, int z)
        {
            if (Height > 200 || Width > 75 || Length > 75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValid(int x, int y, int z)
        {
            if (Height < 0 || Width < 0 || Length < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
