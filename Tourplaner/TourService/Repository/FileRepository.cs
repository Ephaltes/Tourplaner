using System;
using System.IO;
using System.Threading.Tasks;
using Serilog;

namespace TourService.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly string _rootPath;
        public async Task<bool> SaveFileToDisk(string filename,byte[] data)
        {
            try
            {
                await File.WriteAllBytesAsync(_rootPath + filename, data);
                return true;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return false;
            }
        }
        public FileRepository(string rootPath)
        {
            _rootPath = rootPath;
        }

        public async Task<byte[]> ReadFileFromDisk(string filename)
        {
            var fullpath = _rootPath + filename;
            if (File.Exists(fullpath))
                return await File.ReadAllBytesAsync(fullpath);
            return null;
        }
    }
}