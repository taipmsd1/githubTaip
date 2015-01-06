using System;
using Database;
using System.IO;

namespace Bussines
{
    public class UploadHandler
    {
        private readonly UploadManager _uploadManager;

        public UploadHandler()
        {
            _uploadManager = new UploadManager();
        }
        public string Upload(String filepath,Stream inputStream)
        {
            return _uploadManager.Upload(filepath, inputStream);
        }
    }
}
