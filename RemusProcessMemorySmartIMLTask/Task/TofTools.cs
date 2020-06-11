using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;

namespace RemusProcessMemorySmartIMLTask
{
     class TofTools
    {
       public static void TofLogEvent(string Task_Name, string FactoryName, string message, string TestOutput_FileName, string Region_File_nm, long Scan_log_ky, long ProductInstanceKey, int TransferServerPairKey, string SerialNumber, string SqlConnString)
        {

            //Int64 id = 0;
            SqlConnection oConn = new SqlConnection(SqlConnString);
            SqlCommand oCmd = new SqlCommand();
            try
            {
                oCmd.Connection = oConn;
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandText = "[DataServicesManagement].[dbo].[RemusTofEventLogCreate]";
        
                oCmd.Parameters.Add("@PackageName", SqlDbType.NVarChar).Value = Task_Name;
                oCmd.Parameters.Add("@FactoryName", SqlDbType.NVarChar).Value = FactoryName;
                oCmd.Parameters.Add("@EventDescription", SqlDbType.NVarChar).Value = message;
                oCmd.Parameters.Add("@FileType", SqlDbType.NVarChar).Value = TestOutput_FileName;
                oCmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = Region_File_nm;
                oCmd.Parameters.Add("@ScanLogKey", SqlDbType.BigInt).Value = Scan_log_ky;
                oCmd.Parameters.Add("@ProductInstanceKey", SqlDbType.BigInt).Value = ProductInstanceKey;
                oCmd.Parameters.Add("@TransferServerPairKey", SqlDbType.Int).Value = TransferServerPairKey;
                oCmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar).Value = SerialNumber;
                oConn.Open();
                oCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (oCmd != null)
                {
                    oCmd.Dispose();
                }
            }
        }
    }
}
