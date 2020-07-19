using System.Collections.Generic;
using System.Linq;

namespace BlockchainFiles.Models
{
    public class Blockchain
    {
        public List<Block> Blocks;

        public Blockchain() {
            var genesis = new Block(
                "Genesis",
                new byte[] { 0x0C, 0x0A },
                new byte[] { 0x00, 0x0D }
            );
            Blocks = new List<Block>();
            Blocks.Add(genesis);
        }

        public void Clear() => Blocks = new List<Block> { Blocks.First() };
    }
}
