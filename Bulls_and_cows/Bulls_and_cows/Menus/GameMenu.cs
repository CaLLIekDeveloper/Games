using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulls_and_cows.Menus
{
    public partial class GameMenu : UserControl
    {
        static public int[] randNumber = new int[4];
        static public int[] myNumber = new int[4];
        Random r = new Random();

        int cows = 0;
        int bulls = 0;
        int step = 0;
        int defeatStep;
        bool gameAgainstHuman;

        public GameMenu()
        {
            InitializeComponent();
        }

        public void _setDefearSteps(int newStep)
        {
            defeatStep = newStep;
        }
        public void _setGameAgainstHuman(bool temp)
        {
            gameAgainstHuman = temp;
        }

        private void startGame()
        {
            if (!gameAgainstHuman) _setNumbersFromComputer();
            else
            {
                Forms.Player player = new Forms.Player();
                player.ShowDialog();
                //player = null;
            }
            
            //for (int i = 0; i < randNumber.Length; i++) lRand.Text += randNumber[i].ToString();
            bNewGame.Visible = false;
            setButtons(true);
            lRand.Visible = false;
        }

        public void _setNumbersFromHuman(int n1, int n2, int n3, int n4)
        {
            randNumber[0] = n1;
            randNumber[1] = n2;
            randNumber[2] = n3;
            randNumber[3] = n4;
        }

        public void _setNumbersFromComputer()
        {
            int[] arr = new int[11];
            for (int i = 0; i < randNumber.Length; i++)
            {
                while (true)
                {
                    int newNumb = r.Next(0, 9);
                    if (arr[newNumb] == 0)
                    {
                        randNumber[i] = newNumb;
                        arr[randNumber[i]]++;
                        break;
                    }
                }
            }
        }



        private void setScore()
        {
            Score.Text = cows.ToString() + ":";
            Score.Text += bulls.ToString();
            if(step>0)Info.Text =
                "Ход: "+step +"|   "+ myNumber[0].ToString() + myNumber[1].ToString() + myNumber[2].ToString() + myNumber[3].ToString()
                + ": коров - " + cows.ToString() + ", быков - " + bulls.ToString();
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
            for (int i = 0; i < randNumber.Length; i++)
            {
                if (myNumber[i] == randNumber[i]) bulls++;
            }

            for (int i = 0; i < randNumber.Length; i++)
                for (int j = 0; j < myNumber.Length; j++)
                    if (randNumber[j] == myNumber[i] && i!=j) cows++;
        }

        private void endGame(bool win)
        {
            if (win) MessageBox.Show("Поздравляю с победой. Вам потребовалось " + step.ToString() + " ходов.", "Победа");
            else
                MessageBox.Show("Ничего повезет в другой раз", "Поражение");

            setButtons(false);
            bNewGame.Enabled = true;
            bNewGame.Visible = true;
            Info.Text = "";

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

        public void _newGame()
        {
            cows = 0; bulls = 0;
            step = 0;
            lRand.Text = "";
            b1.Text = "0";
            b2.Text = "0";
            b3.Text = "0";
            b4.Text = "0";

            defeatStep = Program.getApp()._getSettingsMenu()._getMaxSteps();
            gameAgainstHuman = Program.getApp()._getSettingsMenu()._returnTypeGameAgainstHuman();
            setScore();
            startGame();
        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            _newGame();
        }

        private void b4_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            int temp = int.Parse(b.Text);
            if (e.Button == MouseButtons.Left) temp++;
            if (e.Button == MouseButtons.Right) temp--;
            if (temp == 10) temp = 0;
            if (temp == -1) temp = 9;
            b.Text = temp.ToString();
        }

        private void bOk_Click_1(object sender, EventArgs e)
        {
            step++;
            parse();
            check();
            setScore();
            if (bulls == 4) endGame(true);
            cows = 0;
            bulls = 0;
            if (step == defeatStep) endGame(false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            string path = @"C:\Users\parsh\Desktop\github\Games\Bulls_and_cows\Bulls_and_cows\Resources\sound\wav\Корова.wav";
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            string path = @"C:\Users\parsh\Desktop\github\Games\Bulls_and_cows\Bulls_and_cows\Resources\sound\wav\Мычание-быка.wav";
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }
    }
}
