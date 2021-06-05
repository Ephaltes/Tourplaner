using System.Threading.Tasks;

namespace TourService.Repository
{
    /// <summary>
    /// Repository for saving a File to Disk
    /// </summary>
    public interface IFileRepository
    {
        /// <summary>
        /// Saves a file to disk
        /// </summary>
        /// <param name="filename">Name of the file to be saved as</param>
        /// <param name="data">data to be saved</param>
        /// <returns>true on success else false</returns>
        public Task<bool> SaveFileToDisk(string filename, byte[] data);
        /// <summary>
        /// Read file from disk
        /// </summary>
        /// <param name="filename">File to be read</param>
        /// <returns>data if read successfull else null</returns>
        public Task<byte[]> ReadFileFromDisk(string filename);

        /// <summary>
        /// Deletes a file on disk
        /// </summary>
        /// <param name="filename">file to be deleted</param>
        /// <returns>true if successful, else false</returns>
        public Task<bool> DeleteFile(string filename);
    }
}