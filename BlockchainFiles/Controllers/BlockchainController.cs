using BlockchainFiles.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockchainFiles.Controllers
{
    public class BlockchainController
    {
        private Blockchain _blockchain;

        public BlockchainController() 
            => LoadBlockchain();

        ~BlockchainController() 
            => SaveChanges();

        public void AddFile(string path)
        {
            var fileInfo = new FileInfo(path);
            var file = new DataFile(path);
            _blockchain.AddFile(file);
            file.Save(Path.Combine(AppSettings.PathSaveFiles, fileInfo.Name));
        }

        private void LoadBlockchain()
        {
            if (!File.Exists(AppSettings.FileBlockchain)) { 
                _blockchain = new Blockchain();
                return;    
            }
            var json = File.ReadAllText(AppSettings.FileBlockchain, Encoding.UTF8);
            _blockchain = JsonConvert.DeserializeObject<Blockchain>(json);
        }

        private void SaveChanges()
        {
            var json = JsonConvert.SerializeObject(_blockchain);
            File.WriteAllText(AppSettings.FileBlockchain, json, Encoding.UTF8);
        }
    }
}
