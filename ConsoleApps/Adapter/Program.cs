using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // var customerManager = new CustomerManager(new MegaFileUploaderAdapter());
            var customerManager = new CustomerManager(new GoogleDriveUploaderAdapter());

            customerManager.Add();
        }

        //this is external service we dont have control in it
        class MegaFileUploader{
            public void Upload(){
                Console.WriteLine("file was uploaded to Mega");
            }
        }

        //this is external service we dont have control in it
        class GoogleDriveFileUploader{
            public void Upload(){
                Console.WriteLine("file was uploaded to Google Drive");
            }
        }

        interface IFileUploader{
            void Upload();
        }

        class MegaFileUploaderAdapter : IFileUploader
        {
            public void Upload()
            {
                MegaFileUploader uploader = new MegaFileUploader();
                uploader.Upload();
            }
        }

         class GoogleDriveUploaderAdapter : IFileUploader
        {
            public void Upload()
            {
                GoogleDriveFileUploader uploader = new GoogleDriveFileUploader();
                uploader.Upload();
            }
        }

        class CustomerManager{
            private readonly IFileUploader _uploader;
            public CustomerManager(IFileUploader uploader){
                _uploader = uploader;
            }

            public void Add(){
                _uploader.Upload();
                Console.WriteLine("Person added.");
            }
        }
    }
}
