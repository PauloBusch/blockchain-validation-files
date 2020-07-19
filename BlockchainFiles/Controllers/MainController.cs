using BlockchainFiles.Interfaces;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            var previousHash = _blockchainController.Blocks.First().CurrentHash;
            var blocks = _blockchainController.Blocks.Skip(1)
                .Select(block => {
                    var fileItem = block.ToFileItem(previousHash);
                    previousHash = block.GenerateHash(previousHash);
                    return fileItem;
                }).ToArray();
            _view = view;
            _view.Update(blocks);
            MessageBox.Show(
                "Esta solução é apenas um exemplo\\protótipo demonstrativo da " +
                "ferramenta que será desenvolida e não deve ser " +
                "utilizada como ferramenta de trabalho", 
                "Aviso", 
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public void SaveFile(string[] pathFiles)
        { 
            foreach(var path in pathFiles) { 
                var block = _blockchainController.AddFile(path);
                _view.Append(block.ToFileItem(block.PreviousHash));
            }
        } 

        public void ViewFiles()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), AppSettings.PathSaveFiles);
            Process.Start("explorer.exe", $"{path}");
        }

        public void ValidateBlocks()
        {
            var previousHash = _blockchainController.Blocks.First().CurrentHash;
            var blocks = _blockchainController.Blocks.Skip(1)
                .Select(block => {
                    var path = Path.Combine(AppSettings.PathSaveFiles, block.Name.ToString());
                    var bytes = File.Exists(path) 
                        ? File.ReadAllBytes(path)
                        : new byte[0];
                    block.Reload(bytes);
                    var fileItem = block.ToFileItem(previousHash);
                    previousHash = block.GenerateHash(previousHash);
                    return fileItem; 
                }).ToArray();
            _view.Update(blocks);
        }

        public void Reset()
        {
            _blockchainController.Clear();
            _view.Clear();
        }

        public void SaveChanges() => _blockchainController.SaveChanges();
    }
}
