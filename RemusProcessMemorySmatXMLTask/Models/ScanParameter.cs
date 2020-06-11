using System;

namespace RemusProcessMemorySmatXMLTask
{
    internal class ScanParameter
    {
        #region Variables

        string scanFrom = String.Empty;
        string scanTo = String.Empty;
        Int64 scanLogKey = 0;

        #endregion Variables

        #region Constructors

        public ScanParameter() { }

        #endregion Constructors

        #region Methods

        public String ScanFrom
        {
            get { return scanFrom; }
            set { scanFrom = value; }
        }

        public String ScanTo
        {
            get { return scanTo; }
            set { scanTo = value; }
        }

        public Int64 ScanLogKey
        {
            get { return scanLogKey; }
            set { scanLogKey = value; }
        }


        #endregion Methods
    }
}
