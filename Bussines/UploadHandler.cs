using System;
using Database;

namespace Bussines
{
    public class UploadHandler
    {
        private readonly UploadManager _uploadManager;

        public UploadHandler()
        {
            _uploadManager = new UploadManager();
        }
        public void Upload(String fileName)
        {
            _uploadManager.Upload(fileName);
        }
    }
}
