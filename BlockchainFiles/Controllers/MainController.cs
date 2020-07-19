using BlockchainFiles.Interfaces;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BlockchainFiles.Controllers
{
    public class MainController
    {
        private readonly BlockchainController _blockchainController;
        private IMainView _view;

        public MainController(BlockchainController blockchainController) {
            _blockchainController = blockchainController;
            var path = Path.Combine(Directory.GetCurrentDirectory(), AppSettings.PathSaveFiles);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public void SetView(IMainView view)
        {
            var blocks = _blockchainController.Blocks
                .Select(b => b.ToFileItem()).ToArray();
            _view = view;
            _view.Update(blocks);
            ValidateBlocks();
        }

        public void SaveFile(string[] pathFiles)
        { 
            foreach(var path in pathFiles) { 
                var block = _blockchainController.AddFile(path);
                _view.Append(block.ToFileItem());
            }
        } 

        public void ViewFiles()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), AppSettings.PathSaveFiles);
            Process.Start("explorer.exe", $"{path}");
        }

        public void ValidateBlocks()
        {
            //var blocks = _blockchainController.Blocks;
            //var files = _blockchainController.Files;
            //foreach (var file in files)
            //{
            //    var block = blocks.FirstOrDefault(b => b.Name == file.Name);
            //    var prevBlock = blocks.ElementAt(blocks.ToList().IndexOf(block) - 1);
            //    if (block == null)
            //    {
            //        file.IsBlockValid = false;
            //        file.IsFileValid = false;
            //        continue;
            //    }
            //    var path = Path.Combine(AppSettings.PathSaveFiles, file.Name);
            //    var data = new DataFile(path);
            //    var hash = data.GenerateHash(prevBlock.Hash);
            //    file.IsFileValid = block.Hash.SequenceEqual(hash);
            //    file.IsBlockValid = block.Hash.SequenceEqual(hash);
            //}
            //_view.Update(files.ToArray());
        }

        public void Reset()
        {
            _blockchainController.Clear();
            _view.Clear();
        }

        public void SaveChanges() => _blockchainController.SaveChanges();
    }
}
