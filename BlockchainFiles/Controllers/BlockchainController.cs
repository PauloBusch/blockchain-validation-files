using BlockchainFiles.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BlockchainFiles.Controllers
{
    public class BlockchainController
    {
        public Block[] Blocks => _blockchain.Blocks.Skip(1).ToArray();

        private readonly Blockchain _blockchain;

        public BlockchainController()
        {
            _blockchain = new Blockchain();
            LoadBlockchain();
        }

        public Block AddFile(string path, byte[] originalHash = null)
        {
            var lastHash = _blockchain.Blocks.Last().CurrentHash;
            var file = new FileInfo(path);
            var bytes = File.ReadAllBytes(path);
            var block = new Block(file.Name, bytes, lastHash, originalHash);
            var newPath = Path.Combine(AppSettings.PathSaveFiles, file.Name);
            File.WriteAllBytes(newPath, bytes);
            _blockchain.Blocks.Add(block);
            return block;
        }

        public void Clear()
        {
            _blockchain.Clear();
            var pathFiles = Directory.GetFiles(AppSettings.PathSaveFiles);
            foreach(var path in pathFiles) 
                new FileInfo(path).Delete();
        }

        public void SaveChanges()
        {
            var blocks = Blocks.Select(b => new { 
                b.Name, 
                Hash = BitConverter.ToString(b.OriginalHash ?? b.CurrentHash)
            });
            var json = JsonConvert.SerializeObject(blocks, Formatting.Indented);
            File.WriteAllText(AppSettings.FileBlockchain, json, Encoding.UTF8);
        }

        private void LoadBlockchain()
        {
            if (!File.Exists(AppSettings.FileBlockchain)) return;
            var json = File.ReadAllText(AppSettings.FileBlockchain, Encoding.UTF8);
            var blocks = JsonConvert.DeserializeObject<dynamic[]>(json);
            foreach(var block in blocks) { 
                var path = Path.Combine(AppSettings.PathSaveFiles, block.Name.ToString());
                var hashStr = block.Hash.ToString() as string;
                var hash = hashStr.Split('-').Select(str => Convert.ToByte(str, 16)).ToArray();
                AddFile(path, hash);
            }
        }
    }
}
