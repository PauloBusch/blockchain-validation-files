using System.Collections.Generic;
using System.Linq;

namespace BlockchainFiles.Models
{
    public class Blockchain
    {
        public List<Block> _blocks;
        public IReadOnlyCollection<Block> Bloks => _blocks.AsReadOnly();

        public Blockchain() {
            var genesis = new Block(new byte[0], new byte[0]);
            _blocks = new List<Block>();
            _blocks.Add(genesis);
        }

        public void AddFile(DataFile file)
        {
            var lastHash = _blocks.Last().Hash;
            var block = new Block(file.Content, file.GenerateHash(lastHash));
            _blocks.Add(block);
        }
    }
}
