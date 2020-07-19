using System;

namespace BlockchainFiles.Models
{
    public class FileItem
    {
        public string Name { get; private set; }
        public string Hash { get; private set; }
        public bool IsFileValid { get; set; }
        public bool IsBlockValid { get; set; }

        public FileItem(
            string name,
            byte[] hash,
            bool isFileValid = true,
            bool isBlockValid = true
        ) { 
            Name = name;
            Hash = BitConverter.ToString(hash).Replace("-", "");
            IsFileValid = isFileValid;
            IsBlockValid = isBlockValid;
        }

        public string[] ToArray() 
            => new [] { 
                Name,
                Hash,
                IsFileValid ? "Sim" : "Não",
                IsBlockValid ? "Sim" : "Não"
            };
    }
}
