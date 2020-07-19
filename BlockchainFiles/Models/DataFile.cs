using System;
using System.IO;
using System.Security.Cryptography;

namespace BlockchainFiles.Models
{
    public class DataFile
    {
        public string Name { get; private set; }
        public byte[] Content { get; private set; }

        public DataFile(string path)
        {
            Name = new FileInfo(path).Name;
            if (!File.Exists(path)) throw new InvalidOperationException(nameof(Name));
            Content = File.ReadAllBytes(path);
        }

        public byte[] GenerateHash(byte[] lastHash)
        {
            using (var sha = new SHA256Managed())
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(Name);
                bw.Write(Content);
                bw.Write(lastHash);
                var array = ms.ToArray();
                return sha.ComputeHash(array);
            }
        }

        public void Save(string path) 
            => File.WriteAllBytes(path, Content);  
    }
}
