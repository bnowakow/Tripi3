using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace Tripi.data
{
    public class DataBase : IDisposable
    {
        private static string dbFileName = "tripi.sdf";
        private static string dbFilePath = @"/STORAGE CARD/" + dbFileName;
        private string connString = "Data Source=\"" + dbFilePath + "\"";

        private SqlCeConnection myConnection = new SqlCeConnection();
        private SqlCeDataAdapter mySqlDataAdapter = new SqlCeDataAdapter();
        private DataTable myDataTable = new DataTable();
        private StringBuilder query = new StringBuilder();
       
        private bool connected = false;
        private string error = "";
        
        #region CONNECTION

        public DataBase()
        {
            try
            {
                myConnection.ConnectionString = connString;
                myConnection.Open();
                connected = true;
            }
            catch (SqlCeException ex)
            {
                connected = false;
                error = ex.Message;
            }
            finally
            {

            }
        }

        public void closeDataBase()
        {
            myConnection.Close();
            connected = false;
        }

        void IDisposable.Dispose()
        {
            closeDataBase();
        }
        #endregion

        #region PRIVATE COMMANDS

        private DataTable select()
        {
            try
            {
                myDataTable = new DataTable();
                mySqlDataAdapter.SelectCommand.ExecuteReader();
                myConnection.Close();
                myConnection.Open();
                mySqlDataAdapter.Fill(myDataTable);
                connected = true;
            }
            catch (SqlCeException ex0)
            {
                connected = false;
                error = ex0.ToString();
            }
            finally
            {

            }
            return myDataTable;
        }

        private bool insert()
        {
            try
            {
                mySqlDataAdapter.InsertCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Open();
                connected = true;
            }
            catch (SqlCeException ex0)
            {
                connected = false;
                error = ex0.ToString();
            }
            finally
            {

            }
            return connected;
        }

        private bool update()
        {
            try
            {
                mySqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Open();
                connected = true;
            }
            catch (SqlCeException ex0)
            {
                connected = false;
                error = ex0.ToString();
            }
            finally
            {

            }
            return connected;
        }

        private bool delete()
        {
            try
            {
                mySqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Open();
                connected = true;
            }
            catch (SqlCeException ex0)
            {
                connected = false;
                error = ex0.ToString();
            }
            finally
            {

            }
            return connected;
        }

        #endregion

        #region PROPERTIES

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        public string ErrorString
        {
            get { return error; }
        }
        #endregion
    }
}
