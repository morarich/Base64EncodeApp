using System;
using System.IO;

namespace RemusProcessMemorySmartIMLTask
{
    internal class EventLogger : IDisposable
    {
        #region Variables

        private string m_fileName;
        private bool m_append;
        private TextWriter m_writer;
        private bool m_logged = false;

        #endregion Variables

        #region Constructors

        public EventLogger() { }

        public EventLogger(string fileName, bool append)
        {
            m_fileName = fileName;
            m_append = append;
        }

        #endregion Constructors

        #region Destructors

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion Destructors

        #region Methods

        protected void DeleteFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected TextWriter Writer
        {
            get { return this.m_writer; }
        }

        public void Write(string value)
        {
            try
            {
                this.Writer.WriteLine(value);
                m_logged = true;
            }
            catch (Exception ex)
            {
                m_logged = false;
                Console.WriteLine("Event Log Create Error: " + ex.ToString());
            }
        }

        public void Open()
        {
            lock (this)
            {
                Directory.CreateDirectory((new FileInfo(m_fileName)).DirectoryName);

                m_writer = new StreamWriter(m_fileName, m_append);
            }
        }

        public void Close()
        {
            this.Writer.Close();
        }

        public bool IsLogged
        {
            get { return this.m_logged; }
        }

        #endregion Methods
    }
}
