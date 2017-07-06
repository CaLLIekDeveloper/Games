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
        Menus.MainMenu mainMenu = new Menus.MainMenu();
        GameMenu gameMenu = new GameMenu();
        Menus.Settings settingsMenu = new Menus.Settings();
        public Form1()
        {
            InitializeComponent();
            _setMenu(mainMenu);
        }

        public void _setMenu(Object temp)
        {
            mainPanel.Controls.Clear();
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
            _setMenu(gameMenu);
            gameMenu._newGame();
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
    }
}
