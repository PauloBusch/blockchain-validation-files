using BlockchainFiles.Controllers;
using BlockchainFiles.Interfaces;
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
    }
}
