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
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            cbDifficult.SelectedIndex = Properties.Settings.Default.Difficult;
            rComputer.Checked = Properties.Settings.Default.TypeGame;
        }

        public int _getMaxSteps()
        {
            if (cbDifficult.SelectedIndex == 0) return 20;
            if (cbDifficult.SelectedIndex == 1) return 15;
            if (cbDifficult.SelectedIndex == 2) return 10;
            return 5;
        }

        public bool _returnTypeGameAgainstHuman()
        {
            if (rHuman.Checked) return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.getApp()._getGameMenu()._setDefearSteps(_getMaxSteps());
            Program.getApp()._getGameMenu()._setGameAgainstHuman(_returnTypeGameAgainstHuman());
            Properties.Settings.Default.Difficult = cbDifficult.SelectedIndex;
            Properties.Settings.Default.TypeGame = !_returnTypeGameAgainstHuman();
            Program.getApp()._setMenu(Program.getApp()._getMainMenu());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.getApp()._setMenu(Program.getApp()._getMainMenu());
        }
    }
}
