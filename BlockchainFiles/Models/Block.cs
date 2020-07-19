using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace BlockchainFiles.Models
{
    public class Block
    {
        public byte[] Hash { get; private set; }
        public byte[] Data { get; private set; }

        public Block(byte[] data, byte[] hash)
        {
            Data = data;
            Hash = hash;
        }
    }
}
