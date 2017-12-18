using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows;
using System.Xml.Linq;

namespace FusilDataBaseConnectionLib
{
    public class DataBaseConnection
    {        
        string ConnectionString = "Integrated Security=true;Data Source=HTML5-PC\\R2;Initial Catalog=Aziz";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public DataBaseConnection()
        {            
            con = new SqlConnection(ConnectionString);   
        }

        public void GetDBConnection(string str)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();                
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message);
            } 
        }

        public void DML(string cmdString)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(cmdString, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        
        public string GetMethod(string Strcmd)
        {
            string str = string.Empty;
            try
            {
                con.Open();
                cmd = new SqlCommand(Strcmd, con);                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str = dr[0].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw ex;
            }

            return  str;
        }

        public string GetDBConection(string spName, XElement input, string transType)
        {
            string result = string.Empty;
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
                connection.Open();
                using (connection)
                {
                    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = spName;
                    command.Parameters.Add("@input", System.Data.SqlDbType.Xml);
                    command.Parameters.Add("@transType", System.Data.SqlDbType.NVarChar);
                    command.Parameters["@input"].Value = input.ToString();
                    command.Parameters["@transType"].Value = transType;
                    command.CommandTimeout = 0;

                    using (System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        while (reader.Read())
                        {
                            result += reader[0];
                        }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
                MessageBox.Show(result);
            }
            return result;
        }
    }
}
