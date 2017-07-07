using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bulls_and_cows.Menus;

namespace Bulls_and_cows
{
    public partial class Form1 : Form
    {
        Menus.Settings settingsMenu = new Menus.Settings();
        Menus.MainMenu mainMenu = new Menus.MainMenu();
        GameMenu gameMenu = new GameMenu();
        public Form1()
        {
            InitializeComponent();
            _setMenu(mainMenu);
        }

        public void _setMenu(Object temp)
        {
            mainPanel.Controls.Clear();
            Console.WriteLine(temp.GetType().Name);
            mainPanel.Controls.Add(temp as Control);
        }

        public Menus.MainMenu _getMainMenu()
        {
            return mainMenu;
        }

        public GameMenu _getGameMenu()
        {
            return gameMenu;
        }

        public Menus.Settings _getSettingsMenu()
        {
            return settingsMenu;
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.getApp()._setMenu(Program.getApp()._getGameMenu());
            Program.getApp()._getGameMenu()._newGame();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.getApp()._setMenu(Program.getApp()._getSettingsMenu());
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Суть игры: ваш соперник, будь то компьютер или друг, загадывает 4-значное число, состоящее из неповторяющихся цифр. Ваша задача - угадать его за ограниченное число ходов. В качестве подсказок выступают “коровы” (цифра угадана, но её позиция - нет) и “быки” (когда совпадает и цифра и её позиция). То есть если загадано число “1234”, а вы называете “6531”, то результатом будет 1 корова (цифра “1”) и 1 бык (цифра “3”) .", "Правила игры");
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
         "Перейти на страницу автора на www.linkedin.com?", "Автор", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.linkedin.com/in/%D0%B0%D0%BB%D0%B5%D0%BA%D1%81%D0%B0%D0%BD%D0%B4%D1%80-%D0%BF%D0%B0%D1%80%D1%88%D0%B8%D0%BD-b2a938118/");
            }
        }
    }
}
