using BlockchainFiles.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace BlockchainFiles.Controllers
{
    public class MainController
    {
        private readonly BlockchainController _blockchainController;

        private IMainView _view;
        public void SetView(IMainView view) => _view = view;

        public MainController(BlockchainController blockchainController) {
            _blockchainController = blockchainController;
            Init();
        }

        public void Init() {
            var path = Path.Combine(Directory.GetCurrentDirectory(), AppSettings.PathSaveFiles);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public void SaveFile(string path) 
            => _blockchainController.AddFile(path);

        public void ViewFiles()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), AppSettings.PathSaveFiles);
            Process.Start("explorer.exe", $"{path}");
        }
    }
}
