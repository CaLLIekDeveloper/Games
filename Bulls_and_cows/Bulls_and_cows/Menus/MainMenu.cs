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
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void bNewGame_Click(object sender, EventArgs e)
        {
            Program.getApp()._setMenu(Program.getApp()._getGameMenu());
            Program.getApp()._getGameMenu()._newGame();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            Program.getApp()._setMenu(Program.getApp()._getSettingsMenu());
        }
    }
}
