using System;
using System.Reflection;

namespace RemusProcessMemorySmatXMLTask
{
    internal class ProductObject : TofObject
    {
        #region Variables

        private Int64 productKey;
        private int geographyKey;

        #endregion Variables

        #region Constructors

        public ProductObject() { }

        public ProductObject(Int64 productKey, int geographyKey)
        {
            this.productKey = productKey;
            this.geographyKey = geographyKey;
        }

        public ProductObject(TofObject tof)
        {
            foreach (PropertyInfo p in tof.GetType().GetProperties())
            {
                PropertyInfo prop2 = tof.GetType().GetProperty(p.Name);
                prop2.SetValue(this, p.GetValue(tof, null), null);
            }
        }

        #endregion Constructors

        #region Destructors

        #endregion Destructors

        #region Methods

        public Int64 ProductKey
        {
            get { return productKey; }
            set { productKey = value; }
        }

        public int GeographyKey
        {
            get { return geographyKey; }
            set { geographyKey = value; }
        }

        #endregion Methods
    }
}
