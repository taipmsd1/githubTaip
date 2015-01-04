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
        public void Upload(String fileName,Stream inputStream)
        {
            _uploadManager.Upload(fileName,inputStream);
        }
    }
}
