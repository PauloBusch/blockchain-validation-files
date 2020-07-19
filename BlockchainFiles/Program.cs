using BlockchainFiles.Controllers;
using System;
using System.Windows.Forms;

namespace BlockchainFiles
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var blockchainController = new BlockchainController();
            var controller = new MainController(blockchainController);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(controller));
        }
    }
}
