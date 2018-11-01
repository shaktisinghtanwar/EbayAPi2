using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTools_Lib.DBConnect
{
    public class DataAccess
    {
        /// <summary>
        /// Return a DataTable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DataTable SelectDT(DbCommand command)
        {
            // The DataTable to be returned 
            DataTable table;
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the data connection 
                command.Connection.Open();
                command.CommandTimeout = 120;
                // Execute the command and save the results in a DataTable
                IDataReader reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);

                // Close the reader 
                reader.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            return table;
        }

        /// <summary>
        /// Query database and return string value
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string SelectString(DbCommand command)
        {
            // The value to be returned 
            string value = "";
            // Execute the command making sure the connection gets closed in the end
            try
            {

                // Open the connection of the command
                command.Connection.Open();
                command.CommandTimeout = 120;
                // Execute the command and get the number of affected rows
                value = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them

                throw;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            // return the result
            return value;
        }

        public static int ExecuteNonQuery(DbCommand command)
        {
            // The number of affected rows 
            int affectedRows = -1;
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                command.Connection.Open();
                command.CommandTimeout = 120;
                // Execute the command and get the number of affected rows
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them

                throw;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            // return the number of affected rows
            return affectedRows;
        }

        /// <summary>
        /// Requires a SqlConnectionStringBuilder Object.
        /// </summary>
        /// <param name="DataBase"></param>
        /// <param name="UserID"></param>
        /// <param name="Password"></param>
        /// <param name="SQLServerURL"></param>
        /// <returns></returns>
        public static DbCommand CreateCommand(SqlConnectionStringBuilder cstr)
        {
            //SqlConnectionStringBuilder cstr = new SqlConnectionStringBuilder();
            //cstr.DataSource = SQLServerURL;
            //cstr.InitialCatalog = DataBase;
            //cstr.IntegratedSecurity = false;
            //cstr.UserID = UserID;
            //cstr.Password = Password;

            // Obtain the database provider name
            string dataProviderName = "System.Data.SqlClient";
            string connectionString = cstr.ConnectionString.ToString();
            // Create a new data provider factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
            // Obtain a database specific connection object
            DbConnection conn = factory.CreateConnection();
            // Set the connection string
            conn.ConnectionString = connectionString;
            // Create a database specific command object
            DbCommand comm = conn.CreateCommand();
            // Set the command type to stored procedure
            comm.CommandType = CommandType.Text;
            // Return the initialized command object
            return comm;
        }


         

    }
}
