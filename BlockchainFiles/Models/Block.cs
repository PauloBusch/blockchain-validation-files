using System.IO;
using System.Security.Cryptography;

namespace BlockchainFiles.Models
{
    public class Block
    {
        public string Name { get; private set; }
        public byte[] OriginalHash { get; private set; }
        public byte[] CurrentHash { get; private set; }
        public byte[] Data { get; private set; }

        public Block(
            string name,
            byte[] data, 
            byte[] prevHash,
            byte[] originalHash = null
        ) {
            Name = name;
            Data = data;
            OriginalHash = originalHash;
            CurrentHash = GenerateHash(prevHash);
        }

        private byte[] GenerateHash(byte[] lastHash)
        {
            using (var sha = new SHA256Managed())
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(Name);
                bw.Write(Data);
                bw.Write(lastHash);
                var array = ms.ToArray();
                return sha.ComputeHash(array);
            }
        }

        public FileItem ToFileItem() => new FileItem(Name, CurrentHash);
    }
}
