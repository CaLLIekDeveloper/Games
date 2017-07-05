using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Snake_2D.Items
{
    public class Snake
    {
        public List<SnakePart> snake = new List<SnakePart>();
        public int _direction { get; set; }
        Brush brush;
        public Snake()
        {
            brush = Brushes.Green;
            snake.Add(new SnakePart((MainForm.SCALE / 2) * MainForm.WIDTH, ((MainForm.SCALE / 2) - 1) * MainForm.HEIGHT));
            snake.Add(new SnakePart(((MainForm.SCALE / 2)) * MainForm.WIDTH, ((MainForm.SCALE / 2) - 2) * MainForm.HEIGHT));
        }


        #region Snake actions

        public void Move()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i != 0 && _direction !=0)
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
                else
                {
                    switch (_direction)
                    {
                        case 1:
                            snake[0].X -= MainForm.WIDTH;
                            CheckFrame();
                            break;
                        case 2:
                            snake[0].X += MainForm.WIDTH;
                            CheckFrame();
                            break;
                        case 3:
                            snake[0].Y -= MainForm.HEIGHT;
                            CheckFrame();
                            break;
                        default:
                            snake[0].Y += MainForm.HEIGHT;
                            CheckFrame();
                            break;
                    }
                }
            }
        }

        public void AddSnakePart()
        {
            snake.Add(new SnakePart(snake[snake.Count - 1].X, snake[snake.Count - 1].Y));
        }

        public void Draw(Graphics canv)
        {
            for (int i = 0; i < snake.Count; i++)
            {
                canv.FillRectangle(this.brush, snake[i].X+1, snake[i].Y+1, MainForm.WIDTH-2, MainForm.HEIGHT-2);
            }
        }

        public void setBrush(Brush newBrush)
        {
            brush = newBrush;
        }

        internal bool CheckEat(int aX, int aY)
        {
            if (snake[0].X == aX && snake[0].Y == aY)
            {
                AddSnakePart();
                return true;
            }
            else return false;
        }

        public void CheckFrame()
        {
            if (snake[0].X < 0) snake[0].X = (MainForm.SCALE - 1) * MainForm.WIDTH;
            if (snake[0].X == MainForm.SCALE * MainForm.WIDTH) snake[0].X = 0;
            if (snake[0].Y < 0) snake[0].Y = (MainForm.SCALE - 1) * MainForm.HEIGHT;
            if (snake[0].Y == MainForm.SCALE * MainForm.HEIGHT) snake[0].Y = 0;
        }

        public bool CheckCollision()
        {
            for(int i = 1; i < snake.Count; i++)
            {
                if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
