using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2D.Items
{
    public class Mouse: SnakePart
    {
        Random rnd = new Random();
        static Brush[] randBrush = new Brush[5] {Brushes.Gray,Brushes.LightGray,Brushes.White,Brushes.WhiteSmoke,Brushes.GhostWhite};
        Brush brush;
        
        public Brush getBrush()
        {
            return brush;
        }

        public Mouse(List<SnakePart> s)
        {
            NewMouse(s);
        }
        #region Apple actions
        public void NewMouse(List<SnakePart> s)
        {
            brush = randBrush[rnd.Next(0, randBrush.Length - 1)];
            X = rnd.Next(0, 19) * MainForm.HEIGHT;
            Y = rnd.Next(0, 19) * MainForm.WIDTH;
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].X == X && s[i].Y == Y)
                {
                    NewMouse(s);
                    break;
                }
            }
        }
        
        public void Draw(Graphics canv)
        {
            canv.FillRectangle(this.brush,X+5, Y+5, MainForm.WIDTH-10, MainForm.HEIGHT-10);
        }

        #endregion

    }
}
