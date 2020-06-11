using System;
using System.IO;
using Renci.SshNet;

namespace RemusProcessMemorySmartIMLTask
{
    public sealed class LinuxSftpClient : IDisposable
    {
        #region Variables

        private string host;
        private int port;
        private string username;
        private string password;

        private SftpClient client;
        #endregion Variables

        #region Constructors

        public LinuxSftpClient() { }

        public LinuxSftpClient(string host, int port, string username, string password)
        {
            this.host = host;
            this.port = port;
            this.username = username;
            this.password = password;
        }

        #endregion Constructors

        #region Destructors

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion Destructors

        #region Methods

        public SftpClient Client
        {
            get { return client; }
            set { client = value; }
        }

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="path">The path.</param>
        public void DownloadFile(Stream output, string path)
        {
            try
            {
                client.DownloadFile(path, output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: \r\n" + ex.ToString());
            }
        }

        public long GetFileSize(string path)
        {
            long size = 0;

            try
            {
                size = client.GetAttributes(path).Size;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: \r\n" + ex.ToString());
            }

            return size;
        }

        public bool IsConnected
        {
            get { return (client.IsConnected ? true : false); }
        }

        /// <summary>
        /// Opens this instance.
        /// </summary>
        public void Open()
        {
            client = new SftpClient(new PasswordConnectionInfo(host, port, username, password));

            if (!client.IsConnected)
            {
                client.Connect();
            }
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            if (client != null)
            {
                client.Disconnect();
                client.Dispose();
            }
        }

        #endregion Methods
    }
}
