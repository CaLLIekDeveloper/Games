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
    public partial class MenuMain : UserControl
    {
        public MenuMain()
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            Program.getApp()._changeMenu(Program.getApp().Game);
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            Program.getApp().Game._setSettings();
        }
    }
}
