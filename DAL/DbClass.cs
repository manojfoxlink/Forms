using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbClass
    {
        static private object _synRoot = new Object();
        private static string _strConnection = string.Empty;

        static public string GetConnnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();
        }
        static private DbClass _instance = null;

        private DbClass(string connectionString)
        {

        }
        static public DbClass GetInstance()
        {
            return GetInstance(null);
        }

        static public DbClass GetInstance(string connectionString)
        {

            if (_instance == null)
            {
                lock (_synRoot)
                {
                    if (_instance == null)
                    {

                        _instance = new DbClass(_strConnection);


                    }
                }
            }
            return _instance;
        }

        public DataTable ExecuteQueryForDataTable(string statementName)
        {


            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(GetConnnection()))
            {
                try
                {
                    SqlCommand command = new SqlCommand(statementName, conn);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                    command = null;
                    da = null;
                }
                catch (Exception e)
                {
                    dt = null;
                    throw new Exception("Error executing query '" + statementName + "' for list.  Cause: " + e.Message);
                }

            }
            return dt;
        }

        public object ExecuteQueryForObject(string statementName)
        {
            object obj = new object();
            using (SqlConnection conn = new SqlConnection(GetConnnection()))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand command = new SqlCommand(statementName, conn);
                    obj = command.ExecuteScalar();

                    command = null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return obj;
        }


        public void ExecuteNonQuery(string statementName)
        {

            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand command = new SqlCommand(statementName, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {

                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataTable ExecuteProcedureForDataTable(string statementName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandText = statementName;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpt = new SqlDataAdapter(oCommand);

                    adpt.Fill(dt);
                    oCommand = null;
                    adpt = null;
                }
                catch (Exception e)
                {
                    dt = null;
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
            }

            return dt;
        }

        public DataTable ExecuteProcedureWithParameterForDataTable(string statementName, SqlParameter[] Parameter)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandText = statementName;
                    oCommand.CommandTimeout = 1200;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameter)
                    {
                        oCommand.Parameters.Add(param);
                    }

                    SqlDataAdapter adpt = new SqlDataAdapter(oCommand);

                    adpt.Fill(dt);

                    oCommand = null;
                    adpt = null;
                }
                catch (Exception e)
                {
                    dt = null;
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
            }
            return dt;
        }

        public DataSet ExecuteProcedureForDataSet(string statementName)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandText = statementName;
                    oCommand.CommandTimeout = 1200;
                    oCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adpt = new SqlDataAdapter(oCommand);

                    adpt.Fill(ds);
                    oCommand = null;
                    adpt = null;
                }
                catch (Exception e)
                {
                    ds = null;
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
            }
            return ds;
        }

        public DataSet ExecuteProcedureWithParameterForDataSet(string statementName, SqlParameter[] Parameter)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandText = statementName;
                    oCommand.CommandTimeout = 1200;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameter)
                    {
                        oCommand.Parameters.Add(param);
                    }

                    SqlDataAdapter adpt = new SqlDataAdapter(oCommand);

                    adpt.Fill(ds);
                    oCommand = null;
                    adpt = null;
                }
                catch (Exception e)
                {
                    ds = null;
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
            }
            return ds;
        }

        public static DataTable ExecuteProcedureWithParameterForDataTablestatic(string statementName, SqlParameter[] Parameter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandText = statementName;
                    oCommand.CommandTimeout = 1200;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameter)
                    {
                        oCommand.Parameters.Add(param);
                    }

                    SqlDataAdapter adpt = new SqlDataAdapter(oCommand);

                    adpt.Fill(dt);

                    oCommand = null;
                    adpt = null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
            }
            return dt;
        }

        public object ExecuteProcedureWithParameter(string statementName, SqlParameter[] Parameter)
        {
            object obj = new object();
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandTimeout = 1200;
                    oCommand.CommandText = statementName;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameter)
                    {
                        oCommand.Parameters.Add(param);
                    }
                    obj = oCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return obj;
        }
        public int ExecuteNonQueryWithParameter(string statementName, SqlParameter[] Parameter)
        {
            int Result = 0;
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandTimeout = 1200;
                    oCommand.CommandText = statementName;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameter)
                    {
                        oCommand.Parameters.Add(param);
                    }
                    Result = (Int32)oCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return Result;
        }
        public static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {

                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }

                command.Parameters.Add(p);
            }
        }

        public static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                return;
            }

            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }
        }

        public static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command.Connection = connection;
            command.CommandText = commandText;
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        public static int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            using (SqlConnection cn = new SqlConnection(GetConnnection()))
            {
                cn.Open();
                return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
            }
        }

        public static int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {

                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(GetConnnection(), spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(CommandType.StoredProcedure, spName, commandParameters);
            }

            else
            {
                return ExecuteNonQuery(CommandType.StoredProcedure, spName);
            }
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return retval;
        }

        public static DataSet ExecuteDataset(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection cn = new SqlConnection(GetConnnection()))
            {
                cn.Open();
                return ExecuteDataset(cn, commandType, commandText, commandParameters);
            }
        }

        public static DataSet ExecuteDataset(string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(GetConnnection(), spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(GetConnnection(), CommandType.StoredProcedure, spName, commandParameters);

            }
            else
            {
                return ExecuteDataset(GetConnnection(), CommandType.StoredProcedure, spName);
            }
        }

        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }

        public static object ExecuteScalar(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection cn = new SqlConnection(GetConnnection()))
            {
                cn.Open();

                return ExecuteScalar(cn, commandType, commandText, commandParameters);
            }
        }

        public static object ExecuteScalar(string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(GetConnnection(), spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(GetConnnection(), CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteScalar(GetConnnection(), CommandType.StoredProcedure, spName);
            }
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

            object retval = cmd.ExecuteScalar();

            cmd.Parameters.Clear();
            return retval;
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(GetConnnection()))
            {

                try
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Parameters.Clear();
                    return rdr;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static SqlDataReader ExecuteReader(string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(GetConnnection(), spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteReader(GetConnnection(), CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteReader(GetConnnection(), CommandType.StoredProcedure, spName);
            }
        }

        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                connection.Close();
                return rdr;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        public static DataTable ExecuteProcedureForDataTable_AutoComplete(int type, string statementName, string typetext)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {

                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandText = statementName;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@type", type);
                    oCommand.Parameters.AddWithValue("@serchtext", typetext);
                    SqlDataAdapter adpt = new SqlDataAdapter(oCommand);

                    adpt.Fill(dt);
                    oCommand = null;
                    adpt = null;
                }
                catch (Exception e)
                {
                    dt = null;
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
            }
            return dt;
        }

        public DataTable ExecuteProcedureWithParameterForDataTableLoginDB(string statementName, SqlParameter[] Parameter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(GetConnnection()))
            {
                try
                {
                    SqlCommand oCommand = new SqlCommand();
                    oCommand.Connection = con;
                    oCommand.CommandText = statementName;
                    oCommand.CommandTimeout = 1200;
                    oCommand.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in Parameter)
                    {
                        oCommand.Parameters.Add(param);
                    }

                    SqlDataAdapter adpt = new SqlDataAdapter(oCommand);

                    adpt.Fill(dt);

                    oCommand = null;
                    adpt = null;
                }
                catch (Exception e)
                {
                    dt = null;
                    throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message);
                }
            }
            return dt;
        }

    }
}





public sealed class SqlHelperParameterCache
{
    private SqlHelperParameterCache() { }

    private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

    private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(spName, cn))
        {
            cn.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlCommandBuilder.DeriveParameters(cmd);

            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }

            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
            cmd.Parameters.CopyTo(discoveredParameters, 0);

            return discoveredParameters;
        }
    }

    private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
    {

        SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
        for (int i = 0, j = originalParameters.Length; i < j; i++)
        {
            clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
        }

        return clonedParameters;
    }

    public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
    {
        string hashKey = connectionString + ":" + commandText;
        paramCache[hashKey] = commandParameters;
    }

    public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
    {
        string hashKey = connectionString + ":" + commandText;
        SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
        if (cachedParameters == null)
        {
            return null;
        }
        else
        {
            return CloneParameters(cachedParameters);
        }
    }

    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
    {
        return GetSpParameterSet(connectionString, spName, false);
    }

    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
    {
        string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
        SqlParameter[] cachedParameters;
        cachedParameters = (SqlParameter[])paramCache[hashKey];
        if (cachedParameters == null)
        {
            cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
        }
        return CloneParameters(cachedParameters);
    }
}
