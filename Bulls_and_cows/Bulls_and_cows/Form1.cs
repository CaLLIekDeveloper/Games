using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulls_and_cows
{
    public partial class Form1 : Form
    {
        static public int[] randNumber = new int[4];
        static public int[] myNumber = new int[4];
        Random r = new Random();
        int cows = 0;
        int bulls = 0;
        int step = 0;
        int defeatStep = 10;
        public Form1()
        {
            InitializeComponent();
            startGame();
        }
        private void startGame()
        {
            for (int i = 0; i < randNumber.Length; i++) randNumber[i] = r.Next(0, 9);
            if (randNumber[0] == 0) randNumber[0] = 1;
            for (int i = 0; i < randNumber.Length; i++) lRand.Text += randNumber[i].ToString();
            newGame.Visible = false;
            setButtons(true);
            lRand.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int temp = int.Parse(b.Text);
            temp++;
            if (temp == 10) temp = 0;
            b.Text = temp.ToString();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            parse();
            check();
            setScore();
            if (bulls == 4) endGame(true);
            cows = 0;
            bulls = 0;
            step++;
            if (step == defeatStep) endGame(false);
        }

        private void setScore()
        {
            Score.Text = cows.ToString() + ":";
            Score.Text += bulls.ToString();
        }

        private void parse()
        {
            myNumber[0] = int.Parse(b1.Text);
            myNumber[1] = int.Parse(b2.Text);
            myNumber[2] = int.Parse(b3.Text);
            myNumber[3] = int.Parse(b4.Text);
        }
        private void check()
        {
            for(int i=0; i<randNumber.Length; i++)
            {
                if (myNumber[i] == randNumber[i]) bulls++;
            }

            for (int i = 0; i < randNumber.Length; i++)
                for (int j = 0; j < myNumber.Length; j++)
                    if (randNumber[j] == myNumber[i]) cows++;
        }
        private void endGame(bool win)
        {
            if (win) MessageBox.Show("Поздравляю с победой.Вам потребовалоись "+step.ToString()+" ходов.", "Победа");
            else
                MessageBox.Show("Ничего повезет в другой раз", "Поражение");

            setButtons(false);
            newGame.Enabled = true;
            newGame.Visible = true;
           
        }

    private void setButtons(bool newStatus)
    {
        foreach (Control c in Controls)
        {
            try
            {
                Button b = (Button)c;
                b.Enabled = newStatus;
            }
            catch { }
        }
    }

        private void newGame_Click(object sender, EventArgs e)
        {
            cows = 0; bulls = 0;
            step = 0;
            lRand.Text = "";
            b1.Text = "0"; 
            b2.Text = "0";
            b3.Text = "0";
            b4.Text = "0";
            setScore();
            startGame();
        }
    }
}
