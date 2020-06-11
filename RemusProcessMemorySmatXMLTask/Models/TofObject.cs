using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemusProcessMemorySmatXMLTask
{
    internal class TofObject : IDisposable
    {
        #region Variables

        private string factory;
        private string productID;
        private string serialNumber;
        private string workObject;
        private string orderNumber;
        private string regionFileName;
        private string fileName;
        private int memberID;

        #endregion Variables

        #region Constructors

        public TofObject() { }

        public TofObject(string factory, string productID, string serialNumber,
            string workObject, string orderNumber, string fileName,
            string regionFileName, int memberID)
        {
            this.factory = factory;
            this.productID = productID;
            this.serialNumber = serialNumber;
            this.workObject = workObject;
            this.orderNumber = orderNumber;
            this.fileName = fileName;
            this.regionFileName = regionFileName;
            this.memberID = memberID;
        }

        #endregion Constructors

        #region Destructors

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion Destructors

        #region Methods

        public String Factory
        {
            get { return factory; }
            set { factory = value; }
        }

        public String ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public String SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public String WorkObject
        {
            get { return workObject; }
            set { workObject = value; }
        }

        public String OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        public String FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public String RegionFileName
        {
            get { return regionFileName; }
            set { regionFileName = value; }
        }

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        #endregion Methods
    }
}
