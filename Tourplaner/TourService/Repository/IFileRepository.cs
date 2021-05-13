using System.Threading.Tasks;

namespace TourService.Repository
{
    public interface IFileRepository
    {
        public Task<bool> SaveFileToDisk(string filename, byte[] data);
        public Task<byte[]> ReadFileFromDisk(string filename);

        public Task<bool> DeleteFile(string filename);
    }
}