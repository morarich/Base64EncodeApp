using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using DataServicesGlobalReportingDataLogger;

namespace RemusProcessMemorySmartIMLTask
{
    public class IMLParse
    {
        DataLogger Logger = new DataLogger();
    
        string FileContent = string.Empty;
        string Task_Name = string.Empty;
        string SqlConnString = string.Empty;
        string File_Type = string.Empty;
        string TestOutput_FileName = string.Empty;
        string File_nm = string.Empty;
        string Region_File_nm = string.Empty;
        string FactoryName = string.Empty;
        string SerialNumber = string.Empty;
        string Born_dt = string.Empty;
        int Geography_ky = 0;
        int Test_System_ky = 0;
        int MemberID = 0;
        long Product_ky = 0;
        long Scan_log_ky = 0;
        long MemorySmartPprIMLLogTOF_ky = 0;
        long ProductInstanceKey = 0;

        public IMLParse(string fileContent, int ProdKey,  int GeoKey, int test_System_ky, int memberID, string factoryFileName, string regionFileName, long ScanLogKey, string SqlConnectionString, string factoryName, string TaskName, long productInstanceKey,string FileType, string TestOutputFileName, string serialNumber, string sourceCreateTime) //Constructor
        {
            Product_ky = ProdKey;
            Geography_ky = GeoKey;
            FileContent = fileContent;
            Test_System_ky = test_System_ky;
            MemberID = memberID;
            File_nm = factoryFileName;
            Region_File_nm = regionFileName;
            Scan_log_ky = ScanLogKey;
            SqlConnString = SqlConnectionString;
            FactoryName = factoryName;
            Task_Name = TaskName;
            ProductInstanceKey = productInstanceKey;
            File_Type = FileType;
            TestOutput_FileName = TestOutputFileName;
            SerialNumber = serialNumber;
            Born_dt = sourceCreateTime;
        }

        public void Run()
        {
       
            string JasonIMLFile;
            //StreamReader sr = new StreamReader(_path);
            //JasonIMLFile = sr.ReadToEnd().Replace("@odata.", "odata");
            JasonIMLFile = FileContent.Replace("@odata.", "odata");
        
                var iml = JsonConvert.DeserializeObject<List<IMLLogX>>(JasonIMLFile);
                string Categories = string.Empty;
               
                MemorySmartPprIMLLogTOF_ky = InertMemorySmartPprIMLLogTOF(  //Inserting records into Master Table
                                                        Product_ky,
                                                        MemberID,
                                                        Scan_log_ky,
                                                        Geography_ky,
                                                        Test_System_ky,
                                                        File_nm,
                                                        Region_File_nm,
                                                        Born_dt);
        
            if (MemorySmartPprIMLLogTOF_ky == 0)
            {
                string ErrorMessage = Task_Name+ ". IMLParse.cs: Line 78: Master Table [NextGenTOF].[TOF].[MemorySmartPprIMLLogTOF] Returned Zero while trying to insert";
                TofTools.TofLogEvent(Task_Name, FactoryName, ErrorMessage, TestOutput_FileName, Region_File_nm, Scan_log_ky, ProductInstanceKey, 1, SerialNumber, SqlConnString);
                return;    
            }

                DataTable dtMemorySmartPprIMLLogTOF_Log = new DataTable();
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("MemorySmartPprIMLLogTOF_Log_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("MemorySmartPprIMLLogTOF_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Product_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Geography_ky", typeof(int));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("scan_log_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("OdataType_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Name_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Created_Log_dt", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Odataid_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Odatacontext_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("EntryType_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("OemRecordFormat", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Message", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Severity_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("Logid_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_Log.Columns.Add("OdataEtag_at", typeof(string));

                DataTable dtMemorySmartPprIMLLogTOF_OemHpe = new DataTable();
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("MemorySmartPprIMLLogTOF_OemHpe_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("MemorySmartPprIMLLogTOF_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Product_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Geography_ky", typeof(int));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("scan_log_ky", typeof(long));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Logid_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("OdataType_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Count_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Updated_Log_dt", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Code_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("EventNumber_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("OdataContext_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Class_at", typeof(string));
                dtMemorySmartPprIMLLogTOF_OemHpe.Columns.Add("Categories_at", typeof(string));



            foreach (var Log in iml)
                {
                    //Console.WriteLine("======Insert dtMemorySmartPprIMLLogTOF_Log ========================================================="); 
                    //Console.WriteLine("MemorySmartPprIMLLogTOF_ky: " + MemorySmartPprIMLLogTOF_ky.ToString());
                    //Console.WriteLine(Log.odatatype.ToString());
                    //Console.WriteLine(Log.Name.ToString());
                    //Console.WriteLine(Log.Created.ToString());
                    //Console.WriteLine(Log.odataid.ToString());
                    //Console.WriteLine(Log.odatacontext.ToString());
                    //Console.WriteLine(Log.EntryType.ToString());
                    //Console.WriteLine(Log.OemRecordFormat.ToString());
                    //Console.WriteLine(Log.Message.ToString());
                    //Console.WriteLine(Log.Severity.ToString());
                    //Console.WriteLine(Log.Id.ToString());
                    //Console.WriteLine(Log.odataetag.ToString());

                    //Console.WriteLine("======Insert dtMemorySmartPprIMLLogTOF_OemHpe =========================================================");
                    //Console.WriteLine("MemorySmartPprIMLLogTOF_ky: " + MemorySmartPprIMLLogTOF_ky.ToString());
                    //Console.WriteLine(Product_ky);
                    //Console.WriteLine(Geography_ky);
                    //Console.WriteLine(scan_log_ky);
                    //Console.WriteLine(Log.Id.ToString());
                    //Console.WriteLine(Log.Oem.Hpe.odatatype.ToString()) ;
                    //Console.WriteLine(Log.Oem.Hpe.Count.ToString());
                    //Console.WriteLine(Log.Oem.Hpe.Updated.ToString());
                    //Console.WriteLine(Log.Oem.Hpe.Code.ToString());
                    //Console.WriteLine(Log.Oem.Hpe.EventNumber.ToString());
                    //Console.WriteLine(Log.Oem.Hpe.odatacontext.ToString());
                    //Console.WriteLine(Log.Oem.Hpe.Class.ToString());
                for (int x = 0; x < Log.Oem.Hpe.Categories.Length; x++)
                {
                    //Console.WriteLine(Log.Oem.Hpe.Categories[x].ToString());
                    Categories = Categories + Log.Oem.Hpe.Categories[x].ToString() + ", ";
                }

                Categories=Categories.Substring(0, Categories.LastIndexOf(","));


                dtMemorySmartPprIMLLogTOF_Log.Rows.Add(
                            1,
                            Convert.ToInt64(MemorySmartPprIMLLogTOF_ky),
                            Product_ky,
                            Geography_ky,
                            Scan_log_ky,
                            Log.odatatype.ToString(),
                            Log.Name.ToString(),
                            Log.Created.ToString(),
                            Log.odataid.ToString(),
                            Log.odatacontext.ToString(),
                            Log.EntryType.ToString(),
                            Log.OemRecordFormat.ToString(),
                            Log.Message.ToString(),
                            Log.Severity.ToString(),
                            Log.Id.ToString(),
                            Log.odataetag.ToString());

                dtMemorySmartPprIMLLogTOF_OemHpe.Rows.Add(
                            1,
                            Convert.ToInt64(MemorySmartPprIMLLogTOF_ky),
                            Product_ky,
                            Geography_ky,
                            Scan_log_ky,
                            Log.Id.ToString(),
                            Log.Oem.Hpe.odatatype.ToString(),
                            Log.Oem.Hpe.Count.ToString(),
                            Log.Oem.Hpe.Updated.ToString(),
                            Log.Oem.Hpe.Code.ToString(),
                            Log.Oem.Hpe.EventNumber.ToString(),
                            Log.Oem.Hpe.odatacontext.ToString(),
                            Log.Oem.Hpe.Class.ToString(),
                            Categories);

                Categories = String.Empty;

                //Console.WriteLine(Log.Oem.Hpe.EventNumber.ToString());
                //Console.WriteLine("Category Length: " + Log.Oem.Hpe.Categories.Length.ToString());
                //for (int x = 0; x < Log.Oem.Hpe.Categories.Length; x++)
                //{
                //    Console.WriteLine("Category: " + Log.Oem.Hpe.Categories[x].ToString());
                //}
            }
            try
            {
                using (SqlBulkCopy sqlBulk = new SqlBulkCopy(SqlConnString))
                {
                    sqlBulk.DestinationTableName = "[NextGenTOF].[TOF].[MemorySmartPprIMLLogTOF_Log]";
                    sqlBulk.WriteToServer(dtMemorySmartPprIMLLogTOF_Log);

                    sqlBulk.DestinationTableName = "[NextGenTOF].[TOF].[MemorySmartPprIMLLogTOF_OemHpe]";
                    sqlBulk.WriteToServer(dtMemorySmartPprIMLLogTOF_OemHpe);

                }
            }
            catch (Exception ex)
            {
                //TofLogEvent(ex.Message, FactoryName + "", "MemorySmartPpr.zip", Region_File_nm, 1, 000 );
                TofTools.TofLogEvent(Task_Name,  FactoryName, ex.Message, TestOutput_FileName, Region_File_nm, Scan_log_ky, ProductInstanceKey, 1, SerialNumber, SqlConnString);
                string error = ex.ToString();
                // Log to NextGenTestServices 
                Logger.LogEvent(System.Diagnostics.EventLogEntryType.Error,
                    " IMLLog.cs: Line: 53, Failed : Run()",
                    (int)ApplicationEventID.TOFTaskAction,
                    (short)EventCategoryID.Tasks);

            }

            //Console.Read();
        }


        private Int64 InertMemorySmartPprIMLLogTOF(
                                        long Product_ky,
                                        int MemberID,
                                        long scan_log_ky,
                                        int Geography_ky,
                                        int Test_System_ky,
                                        string File_nm,
                                        string Region_File_nm,
                                        string Born_dt)
        {
            Int64 Results = 0;
            try
            {
                using (SqlConnection oConn = new SqlConnection(SqlConnString))
                {
                    SqlDataAdapter oAdapt = new SqlDataAdapter();
                    SqlCommand oCmd = new SqlCommand();
                    DataTable dtMemorySmartPprIMLLogTOF_ky = new DataTable();

                    oConn.Open();
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.CommandText = "[NextGenTOF].[TOF].[tsk_CreateMemorySmartPprIMLTOF]";
                    oCmd.Connection = oConn;
                    oCmd.Parameters.AddWithValue("@ProductKey", Product_ky);
                    oCmd.Parameters.AddWithValue("@MemberID", MemberID);
                    oCmd.Parameters.AddWithValue("@Born_dt", Born_dt);
                    oCmd.Parameters.AddWithValue("@ScanLogKey", scan_log_ky);
                    oCmd.Parameters.AddWithValue("@GeographyKey", Geography_ky);
                    oCmd.Parameters.AddWithValue("@TestSystemKey", Test_System_ky);
                    oCmd.Parameters.AddWithValue("@FileName", File_nm);
                    oCmd.Parameters.AddWithValue("@RegionFileName", Region_File_nm); // Hard Coded to 1


                    oAdapt.SelectCommand = oCmd;
                    oAdapt.Fill(dtMemorySmartPprIMLLogTOF_ky);
                    oAdapt.Dispose();
                    Results = Convert.ToInt64( dtMemorySmartPprIMLLogTOF_ky.Rows[0][0].ToString());
                   
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Log to NextGenTestServices 
                Logger.LogEvent(System.Diagnostics.EventLogEntryType.Error,
                    " IMLLog.cs: Line: 85, Failed Method: InertMemorySmartPprIMLLogTOF(long Product_ky, MemberID,  long scan_log_ky, Geography_ky, Test_System_ky,File_nm, Region_File_nm)",
                    (int)ApplicationEventID.TOFTaskAction,
                    (short)EventCategoryID.Tasks);
               
            }

            return Results;
        }



    }

    
}

 

