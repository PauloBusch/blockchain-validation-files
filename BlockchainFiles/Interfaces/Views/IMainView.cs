using BlockchainFiles.Models;

namespace BlockchainFiles.Interfaces
{
    public interface IMainView
    {
        void Clear();
        void Update(FileItem[] files);
        void Append(FileItem file);
    }
}
