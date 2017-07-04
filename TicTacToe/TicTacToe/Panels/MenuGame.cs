using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.Panels
{
    public partial class MenuGame : UserControl
    {
        int turn = 1;
        bool gameOver = false;
        bool gameComputer = false;

        public MenuGame()
        {
            InitializeComponent();
        }

        private void check()
        {
            //наискось
            if (A1.Text != "" && (A1.Text == B2.Text && B2.Text == C3.Text)) gameOver = true;
            if (A3.Text != "" && (A3.Text == B2.Text && B2.Text == C1.Text)) gameOver = true;
            //vertical
            if (A1.Text != "" && (A1.Text == B1.Text && B1.Text == C1.Text)) gameOver = true;
            if (A2.Text != "" && (A2.Text == B2.Text && B2.Text == C2.Text)) gameOver = true;
            if (A3.Text != "" && (A3.Text == B3.Text && B3.Text == C3.Text)) gameOver = true;
            //gorizontal
            if (B1.Text != "" && (B1.Text == B2.Text && B2.Text == B3.Text)) gameOver = true;
            if (A1.Text != "" && (A1.Text == A2.Text && A2.Text == A3.Text)) gameOver = true;
            if (C1.Text != "" && (C1.Text == C2.Text && C2.Text == C3.Text)) gameOver = true;


            if (gameOver)
            {
                if ((turn - 1) % 2 == 0)
                {
                    if (gameComputer) MessageBox.Show("Победил компьютер", "Игра");
                    else
                        MessageBox.Show("Победил второй игрок", "Игра");
                }
                else
                    MessageBox.Show("Победил первый игрок", "Игра");

                turnButtons(false);
            }
            if (turn == 10 && gameOver == false)
            {
                MessageBox.Show("Ничья", "Игра");
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            if (turn % 2 == 0)
                b.Text = "O";
            else
                b.Text = "X";

            if (gameComputer && turn % 2 != 0) b.Enabled = false;
            else
                b.Enabled = false;

            turn++;
            check();

            if (gameComputer && !gameOver)
                stepCompter();
        }

        private void stepCompter()
        {
            bool f = false;
            try
            {
                while (true)
                {
                    int k = 0;
                    Random r = new Random();
                    foreach (Control c in Controls)
                    {
                        k++;
                        if (k == r.Next(8))
                        {
                            Button t = (Button)c;
                            if (t.Enabled == true)
                            {
                                t.Text = "O";
                                t.Enabled = false;
                                f = true;
                                break;
                            }
                        }
                    }
                    if (f) break;
                }
            }
            catch { }
            turn++;
            check();
        }

        public void _newGame()
        {
            turn = 1;
            gameOver = false;
            turnButtons(true);

            A1.Text = ""; A2.Text = ""; A3.Text = "";
            B1.Text = ""; B2.Text = ""; B3.Text = "";
            C1.Text = ""; C2.Text = ""; C3.Text = "";
        }


        private void turnButtons(bool state)
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = state;
                }
            }
            catch { }
        }

        public void _setSettings()
        {
            DialogResult result = MessageBox.Show("Играть против компьютера?", "Настройки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                gameComputer = true;
                _newGame();
            }
        }

        private void A1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            if (turn % 2 == 0)
            {
                b.Text = "O";
                //b.ForeColor = Color.Blue;
            }
            else
            {
                b.Text = "X";
                b.ForeColor = System.Drawing.Color.Blue;
            }

            if (gameComputer && turn % 2 != 0) b.Enabled = false;
            else
                b.Enabled = false;

            turn++;
            check();

            if (gameComputer && !gameOver)
                stepCompter();
        }
    }
}
