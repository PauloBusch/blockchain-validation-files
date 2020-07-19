using BlockchainFiles.Controllers;
using BlockchainFiles.Interfaces;
using BlockchainFiles.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace BlockchainFiles
{
    public partial class MainForm : Form, IMainView
    {
        private readonly MainController _controller;

        public MainForm(MainController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            ResetListFiles();
            _controller.SetView(this);
        }

        private void BtnSearchFile_Click(object sender, System.EventArgs e)
        {
            if (OpenFileDialog.ShowDialog(this) == DialogResult.OK)
                _controller.SaveFile(OpenFileDialog.FileNames);
        }

        private void BtnViewFiles_Click(object sender, System.EventArgs e)
        {
            _controller.ViewFiles();
        }

        private void BtnValidate_Click(object sender, System.EventArgs e)
        {
            _controller.ValidateBlocks();
        }

        public void Update(FileItem[] files)
        {
            ResetListFiles();
            foreach(var file in files) Append(file);
        }

        public void Append(FileItem file)
        {
            ListFiles.Items.Add(new ListViewItem(file.ToArray()));
        }

        private void ResetListFiles()
        {
            Func<float, int> calcPercent = 
                (percent) => (int)(ListFiles.Width * percent);
            ListFiles.View = View.Details;
            ListFiles.GridLines = true;
            ListFiles.Items.Clear();
            ListFiles.Columns.Clear();
            ListFiles.Columns.Add("Arquivo", calcPercent(0.25f) - 15, HorizontalAlignment.Left);
            ListFiles.Columns.Add("Assinatura", calcPercent(0.55f), HorizontalAlignment.Center);
            ListFiles.Columns.Add("Arquivo Válido", calcPercent(0.10f), HorizontalAlignment.Center);
            ListFiles.Columns.Add("Bloco Válido", calcPercent(0.10f), HorizontalAlignment.Center);
        }

        private void BtnReset_Click(object sender, EventArgs e) => _controller.Reset();

        public void Clear() => ResetListFiles();

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => _controller.SaveChanges();
    }
}
