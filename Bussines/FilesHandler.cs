using System;
using Database;

namespace Bussines
{
    public class FilesHandler
    {
        private readonly FilesManager _filesManager;

        public FilesHandler()
        {
            _filesManager=new FilesManager();
        }

        public void GetAllFiles()
        {
            _filesManager.GetAllFiles();
        }

        public void AddFile(String filepath)
        {
            _filesManager.AddFile(filepath);
        }
    }
}
