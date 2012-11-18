using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tetris.Controllers;
using Tetris.Views;

namespace Tetris
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ModelController.Init();
            Application.Run(new MainForm());
        }
    }
}
