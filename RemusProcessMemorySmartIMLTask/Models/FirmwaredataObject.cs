using System;

namespace RemusProcessMemorySmartIMLTask
{
    internal class FirmwaredataObject : IDisposable
    {
        #region Variables

        string productInstanceKey;
        string geographyKey;
        string deviceNumber;
        string category;
        string name;
        string data;
        string sourceCreateTime;

        #endregion Variables

        #region Constructors

        public FirmwaredataObject(string productInstanceKey, string geographyKey, string deviceNumber, string category, string name, string data, string sourceCreateTime)
        {
            this.productInstanceKey = productInstanceKey;
            this.geographyKey = geographyKey;
            this.deviceNumber = deviceNumber;
            this.category = category;
            this.name = name;
            this.data = data;
            this.sourceCreateTime = sourceCreateTime;
        }

        #endregion Constructors

        #region Destructors

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion Destructors

        #region Methods

        public String ProductInstanceKey
        {
            get { return productInstanceKey; }
            set { productInstanceKey = value; }
        }

        public String GeographyKey
        {
            get { return geographyKey; }
            set { geographyKey = value; }
        }

        public String DeviceNumber
        {
            get { return deviceNumber; }
            set { deviceNumber = value; }
        }

        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        public String SouceCreateTime
        {
            get { return sourceCreateTime; }
            set { sourceCreateTime = value; }
        }

        #endregion Methods

    }
}
