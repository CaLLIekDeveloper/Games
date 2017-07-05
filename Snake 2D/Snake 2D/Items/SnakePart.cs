using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2D.Items
{
    public class SnakePart
    {
        public int X;
        public int Y;

        #region Constructors
        public SnakePart()
        {
            X = 0;
            Y = 0;
        }

        public SnakePart( int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        #endregion
    }
}
