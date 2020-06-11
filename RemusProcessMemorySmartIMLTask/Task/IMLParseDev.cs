using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RemusProcessMemorySmartIMLTask
{
    public class IMLParseDev
    {
        //private readonly string _path = @"C:\Users\morarich\OneDrive - Hewlett Packard Enterprise\Rich\Documents\1-Rich\20190501 MemorySmartPPR\iml_log.json";
        private readonly string _path = string.Empty;

        public IMLParseDev(string path) //Constructor
        {
        //_path = @"C:\Users\morarich\OneDrive - Hewlett Packard Enterprise\Rich\Documents\1-Rich\20190501 MemorySmartPPR\iml_log.json";
        _path = path;

        }

        public void run()
        {
                                                  
            string JasonIMLFile;
            StreamReader sr = new StreamReader(_path);
            JasonIMLFile = sr.ReadToEnd().Replace("@odata.", "odata");
            var iml = JsonConvert.DeserializeObject<List<IMLLogX>>(JasonIMLFile);

            //Console.WriteLine(iml[0].Oem.Hpe.odatatype.ToString());
            //Console.WriteLine(iml[0].Oem.Hpe.Categories.Length.ToString());
            foreach (var Log in iml)
            {

                Console.WriteLine(Log.Id.ToString());
                Console.WriteLine(Log.Oem.Hpe.EventNumber.ToString());
                Console.WriteLine("Category Length: " + Log.Oem.Hpe.Categories.Length.ToString());
                for (int x = 0; x < Log.Oem.Hpe.Categories.Length; x++)
                {
                    Console.WriteLine("Category: " + Log.Oem.Hpe.Categories[x].ToString());
                }
            }


            Console.Read();

            return;




            //Console.WriteLine("Serialization"); //Used to convert Class to Json
            //IMLLogDev IML = new IMLLogDev();
            //IML.Odata_type = "#LogEntry.v1_0_0.LogEntry";
            //IML.Name = "Itegrated Management Log";
            //IML.Created = "2019-05-06T16:54:56Z";
            //IML.Odata_id = "/redfish/v1/Systems/1/LogServices/IML/Entries/1/";
            //IML.Odata_context = "/redfish/v1/$metadata#LogEntry.LogEntry";
            //IML.Entrytype = "Oem";
            //IML.OemRecordFormat = "Hpe-IML";
            //IML.Message = "IML Cleared ( user: System Administrator)";
            //IML.Severity = "OK";
            //IML.Id = 1;
            //IML.Odata_etag = "W/\"50B0E6D2\"";

            //string results = JsonConvert.SerializeObject(IML); //Convert to Json

            //Console.WriteLine(results);
            ////Console.Read();

            //Console.WriteLine("\nDeserialization"); //Read from Json

            //IMLLogDev IMLNew = JsonConvert.DeserializeObject <IMLLogDev>(results);  //Convert from Json to Class

            //Console.WriteLine("IMLNew.Odata_type: " + IMLNew.Odata_type);
            //Console.WriteLine("IMLNew.Name: " + IMLNew.Name);
            //Console.WriteLine("IMLNew.Created: " + IMLNew.Created);
            //Console.WriteLine("IMLNew.Odata_id: " + IMLNew.Odata_id);
            //Console.WriteLine("IMLNew.Odata_context: " + IMLNew.Odata_context);
            //Console.WriteLine("IMLNew.Entrytype: " + IMLNew.Entrytype);
            ////Console.ReadLine();

            //Console.WriteLine("\nSerialization of Collection"); //Create Json file from class collection
            //List<IMLLogDev> IMLCollection = new List<IMLLogDev>
            //{
            //    new IMLLogDev{Odata_type="#LogEntry.v1_0_0.LogEntry",Name="Itegrated Management Log", Created="2019-05-06T16:54:56Z", Odata_id="/redfish/v1/Systems/1/LogServices/IML/Entries/1/", Odata_context="/redfish/v1/$metadata#LogEntry.LogEntry", Entrytype ="Oem",OemRecordFormat="Hpe-IML" ,Message="IML Cleared ( user: System Administrator)" ,Severity="OK" ,Id=1  ,Odata_etag="W/\"50B0E6D2\"" },
            //    new IMLLogDev{Odata_type="#LogEntry.v1_0_0.LogEntry",Name="Itegrated Management Log", Created="2019-05-06T16:54:56Z", Odata_id="/redfish/v1/Systems/1/LogServices/IML/Entries/2/", Odata_context="/redfish/v1/$metadata#LogEntry.LogEntry", Entrytype ="Oem",OemRecordFormat="Hpe-IML" ,Message="IML Cleared ( user: System Administrator)" ,Severity="OK" ,Id=2  ,Odata_etag="W/\"50B0E6D2\"" },
            //    new IMLLogDev{Odata_type="#LogEntry.v1_0_0.LogEntry",Name="Itegrated Management Log", Created="2019-05-06T16:54:56Z", Odata_id="/redfish/v1/Systems/1/LogServices/IML/Entries/3/", Odata_context="/redfish/v1/$metadata#LogEntry.LogEntry", Entrytype ="Oem",OemRecordFormat="Hpe-IML" ,Message="IML Cleared ( user: System Administrator)" ,Severity="OK" ,Id=3  ,Odata_etag="W/\"50B0E6D2\"" }

            //};

            //string resultsCollection = JsonConvert.SerializeObject(IMLCollection);
            //Console.WriteLine(resultsCollection);


            //Console.WriteLine("\nDeserialize of Collection"); //Read from  Json collection
            //List<IMLLogDev> IMLColl = JsonConvert.DeserializeObject<List<IMLLogDev>>(resultsCollection);  //Convert string to object
            //foreach (var item in   IMLCollection)
            //{
            //    Console.WriteLine(item.Id +"  "+ item.Odata_id);
            //}

            //Console.ReadLine();
            //Console.Read();

        }
    }
    public class IMLLogDev
    {
        public string Odata_type { get; set; }
        public string Name { get; set; }
        public string Created { get; set; }
        public string Odata_id { get; set; }
        public string Odata_context { get; set; }
        public string Entrytype { get; set; }
        public string OemRecordFormat { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
        public int Id { get; set; }
        public string Odata_etag { get; set; }
    }

    
}

 

