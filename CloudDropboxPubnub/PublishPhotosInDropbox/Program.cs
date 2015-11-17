namespace Dropbox
{
    using DropNet;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class StartUp
    {
        private const string DropboxAppKey = "4ontlh9zrqcu72a";
        private const string DropboxAppSecret = "pp52ym7v7rmuo00";

        public static void Main()
        {
            var client = new DropNetClient(DropboxAppKey, DropboxAppSecret);

            var token = client.GetToken();
            var url = client.BuildAuthorizeUrl();

            Console.WriteLine("COPY?PASTE Link: {0}", url);
            Console.WriteLine("Press enter when clicked allow");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", url);

            Console.ReadLine();
            var accessToken = client.GetAccessToken();

            client.UseSandbox = true;
            var metaData = client.CreateFolder("NewUpload" + DateTime.Now.ToString());

            string[] dir = Directory.GetFiles("../../images/", "*.JPG");
            foreach (var item in dir)
            {
                Console.WriteLine("Reading file.....");
                FileStream stream = File.Open(item, FileMode.Open);
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                Console.WriteLine(bytes.Length + " bytes uploading...");
                client.UploadFile("/" + metaData.Name.ToString(), item.Substring(6), bytes);
                Console.WriteLine("{0} uploaded!", item);

                stream.Close();
            }
            Console.WriteLine("Job Done!");
            var picUrl = client.GetShare(metaData.Path);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", picUrl.Url);
        }
    }
}