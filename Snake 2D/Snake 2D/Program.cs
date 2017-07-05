using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_2D
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static public MainForm game;
        static public MainMenuForm menu;
        static public Records records;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            game = new MainForm();
            menu = new MainMenuForm();
            records = new Records();
            game.Visible = false;
            records.Visible = false;
            Application.Run(menu);
        }
    }
}
