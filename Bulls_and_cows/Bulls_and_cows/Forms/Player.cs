using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulls_and_cows.Forms
{
    public partial class Player : Form
    {
        bool Correct = false;
        public Player()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Program.getApp()._setMenu(Program.getApp()._getMainMenu());
            this.Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            try {
                int numb = int.Parse(tbNumber.Text);
            if (tbNumber.Text.Length==4)
            {
                    int n1 = numb / 1000;
                    int n2 = numb / 100 % 10;
                    int n3 = numb % 100 / 10;
                    int n4 = numb % 10;
                    int[] arr = new int[10];
                    arr[n1]++; arr[n2]++; arr[n3]++; arr[n4]++;
                    bool flag = true;
                    for(int i=0; i<arr.Length; i++)
                    {
                        if(arr[i]>1)
                        {
                            flag = false;
                            MessageBox.Show(this, "Число не должно содержать повторяющихся цифр", "Ошибка");
                            break;
                        }
                    }
                    if(flag)
                    {
                        Program.getApp()._getGameMenu()._setNumbersFromHuman(n1, n2, n3, n4);
                        Correct = true;
                        this.Close();
                    }
            }else
            {
                MessageBox.Show(this,"Число должно быть четырехзначным","Ошибка");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Введите число", "Ошибка");
            }
        }

        private void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!Correct)Program.getApp()._setMenu(Program.getApp()._getMainMenu());
        }

        private void bRandom_Click(object sender, EventArgs e)
        {
            Program.getApp()._getGameMenu()._setNumbersFromComputer();
            Correct = true;
            this.Close();
        }
    }
}
