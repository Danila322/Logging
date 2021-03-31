using System.IO;
using System.Threading.Tasks;

namespace Logging.LogDeleting
{
    public class FileLogDeleter : ILogDeleter
    {
        private string filepath;

        public FileLogDeleter(string filepath)
        {
            this.filepath = filepath;
        }

        public Task DeleteLogs()
        {
            return Task.Run(() =>
            {
                File.Delete(filepath);
                File.Create(filepath).Close();
            });
        }
    }
}
