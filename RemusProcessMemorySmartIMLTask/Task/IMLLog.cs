using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemusProcessMemorySmartIMLTask
{

    //public class IMLLogX
    //{
    //    public Class1[] Property1 { get; set; }
    //}

    public class IMLLogX
    {
        public string odatatype { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string odataid { get; set; }
        public string odatacontext { get; set; }
        public string EntryType { get; set; }
        public Oem Oem { get; set; }
        public string OemRecordFormat { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
        public string Id { get; set; }
        public string odataetag { get; set; }
    }

    public class Oem
    {
        public Hpe Hpe { get; set; }
    }

    public class Hpe
    {
        public string odatatype { get; set; }
        public int Count { get; set; }
        public string Updated { get; set; }
        public int Code { get; set; }
        public int EventNumber { get; set; }
        public string odatacontext { get; set; }
        public int Class { get; set; }
        public string[] Categories { get; set; }
        public string RecommendedAction { get; set; }
        public string LearnMoreLink { get; set; }
        public bool Repaired { get; set; }
    }

}
