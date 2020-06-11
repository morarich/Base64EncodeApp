using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Base64EncodeApp
{
    class Program

    {
        static void Main(string[] args)

        {
            //Testing Changes 2020-06-10 9:48PM
            string ErrorMessage = string.Empty;

            Console.WriteLine("Testing Base64 Encoded, Connection and Coverity");

            string Pswrd = "d$D$ql#09";

            Console.WriteLine("pswrd before Encoded: " + Pswrd);

            //convert to binary
            byte[] bytes1 = Encoding.UTF8.GetBytes(Pswrd);
            //use Covert Class and Static Method ToBase64String
            var encodedPswrd = Convert.ToBase64String(bytes1);

            Console.WriteLine("pswrd after Encoded: " + encodedPswrd);

            byte[] bytes2 = Convert.FromBase64String(encodedPswrd);
            var dencodedPswrd = Encoding.UTF8.GetString(bytes2);
            Console.WriteLine("pswrd  after Decoded : " + dencodedPswrd);
            
            //Console.WriteLine("End");
            //Console.Read();

            string SqlConnectionString = "Data Source=15.114.145.60;User ID=sa;Password=" + dencodedPswrd + ";Initial Catalog=NextGenDW;Persist Security Info=True;";

            string sql = string.Empty;
            sql =
            " select Region_nm, Factory_nm, Geography_ky " +
            " from DimRef_Geography with(Nolock) " +
            " where is_lab_fg = 0 " +
            " order by Region_nm, Factory_nm";
            
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = SqlConnectionString;
            SqlDataReader oReader = null;
            try
            {
                oConn.Open();
                Console.WriteLine("Connecting to: " + SqlConnectionString);
                Console.WriteLine("oConn.State to: " + oConn.State.ToString());
  
                using (SqlCommand oCmd = new SqlCommand())
                {
                    oCmd.Connection = oConn;
                    oCmd.CommandType = CommandType.Text;
                    oCmd.CommandText = sql;

                    oReader = oCmd.ExecuteReader();

                    while (oReader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}", oReader.GetString(0), oReader.GetString(1), oReader.GetInt32(2));
                    }
                    oReader.Close();
                }
                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message.ToString();
                Console.WriteLine("ex.Message: " + ErrorMessage);
            }
            finally {
                if (oConn.State == ConnectionState.Open) { oConn.Dispose(); }
                if (oReader != null) { oReader = null; }
            }
            

            Console.Read();



        }
    }
}
