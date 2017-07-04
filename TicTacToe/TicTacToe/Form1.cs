using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Panels;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        MenuGame game = new MenuGame();
        MenuMain mainMenu = new MenuMain();

        public MenuMain MainMenu { get => mainMenu;  }
        public MenuGame Game { get => game; }

        public TicTacToe()
        {
            InitializeComponent();
            pMain.Controls.Add(mainMenu);
        }

        public void _changeMenu(Object temp)
        {
            try
            {
                pMain.Controls.Clear();
                pMain.Controls.Add(temp as Control);
            }
            catch (Exception ex) { }
        }

        
        

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game._newGame();
            _changeMenu(game);

        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"Создал Паршин Олександр","Создатель");
        }



        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game._setSettings();
        }
    }
}
