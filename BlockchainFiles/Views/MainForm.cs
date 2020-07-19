using BlockchainFiles.Controllers;
using BlockchainFiles.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainFiles
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainController _controller;

        public MainForm(MainController controller)
        {
            _controller = controller;
            _controller.SetView(this);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e) { }

        private void BtnSearchFile_Click(object sender, System.EventArgs e)
        {
            if (OpenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var path = Path.Combine(OpenFileDialog.InitialDirectory, OpenFileDialog.FileName);
                _controller.SaveFile(path);
            }
        }

        private void BtnViewFiles_Click(object sender, System.EventArgs e)
        {
            _controller.ViewFiles();
        }

        private void BtnValidate_Click(object sender, System.EventArgs e)
        {

        }
    }
}
