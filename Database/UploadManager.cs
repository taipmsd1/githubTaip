using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Database
{
    public class UploadManager
    {
        private const string AccountName = "mediudocs";
        private const string AccountKey = "mqdJ3zmEJHjo/HonW1gXysv0MGZnCc5VuSM05AwhH7wfNXAEhn+HhW1KEtDjN+6Y/YoKNb+p5HFk/r9jeLIuoA==";

        public void Upload(String fileName,Stream inStream)
        {
            try
            {

                var creds = new StorageCredentials(AccountName, AccountKey);
                var account = new CloudStorageAccount(creds, useHttps: true);

                var client = account.CreateCloudBlobClient();

                var sampleContainer = client.GetContainerReference("docs");
                sampleContainer.CreateIfNotExists();
                var blob = sampleContainer.GetBlockBlobReference(fileName);
                     blob.UploadFromStream(inStream);
              //  blob.Uri.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
