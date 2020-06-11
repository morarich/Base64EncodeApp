using System;

namespace RemusProcessMemorySmatXMLTask
{
    internal class TOFdataObject : IDisposable
    {
        #region Variables

        Int64 productKey;
        int geographyKey;
        long parentKey;
        string deviceNumber;
        string name;
        string value_at;
        //string sourceCreateTime;

        #endregion Variables

        #region Constructors

        public TOFdataObject(Int64 productKey, int geographyKey, string deviceNumber,  string name, string value_at, long parentKey)
        
        {
            this.productKey = productKey;
            this.geographyKey = geographyKey;
            this.deviceNumber = deviceNumber;
            this.ParentKey = parentKey;
            this.Name = name;
            this.Value = value_at;
            //this.sourceCreateTime = sourceCreateTime;
        }

        #endregion Constructors

        #region Destructors

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion Destructors

        #region Methods

        public Int64 Product
        {
            get { return productKey; }
            set { productKey = value; }
        }

        public int GeographyKey
        {
            get { return geographyKey; }
            set { geographyKey = value; }
        }
        public long ParentKey
        {
            get { return parentKey; }
            set { parentKey = value; }
        }
        public String DeviceNumber
        {
            get { return deviceNumber; }
            set { deviceNumber = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Value
        {
            get { return value_at; }
            set { value_at = value; }
        }

        //public String SouceCreateTime
        //{
        //    get { return sourceCreateTime; }
        //    set { sourceCreateTime = value; }
        //}

        #endregion Methods

    }
}
