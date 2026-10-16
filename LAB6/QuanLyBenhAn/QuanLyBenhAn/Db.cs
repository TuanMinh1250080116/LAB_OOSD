using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBenhAn
{
    internal static class Db
    {
        internal static string ConnectionString
        {
            get
            {
                string test = Environment.GetEnvironmentVariable("LAB06_CONNECTION");
                return string.IsNullOrWhiteSpace(test) ? ConfigurationManager.ConnectionStrings["BenhAnDb"].ConnectionString : test;
            }
        }

        internal static SqlParameter P(string name, object value)
        {
            return new SqlParameter("@" + name, value ?? DBNull.Value);
        }

        internal static SqlConnection Open()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        internal static SqlCommand Command(SqlConnection connection, SqlTransaction transaction, string sql, params SqlParameter[] parameters)
        {
            var command = new SqlCommand(sql, connection) { Transaction = transaction };
            command.Parameters.AddRange(parameters);
            return command;
        }

        internal static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (var connection = Open())
            using (var command = Command(connection, null, sql, parameters))
            using (var adapter = new SqlDataAdapter(command))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        internal static object Scalar(string sql, params SqlParameter[] parameters)
        {
            using (var connection = Open())
            using (var command = Command(connection, null, sql, parameters))
                return command.ExecuteScalar();
        }

        internal static string Id(SqlConnection connection, SqlTransaction transaction, string sequence, string prefix)
        {
            using (var command = Command(connection, transaction, "SELECT NEXT VALUE FOR " + sequence))
                return prefix + Convert.ToInt64(command.ExecuteScalar()).ToString("000000");
        }

        internal static void Exec(SqlConnection connection, SqlTransaction transaction, string sql, params SqlParameter[] parameters)
        {
            using (var command = Command(connection, transaction, sql, parameters)) command.ExecuteNonQuery();
        }

        internal static T Atomic<T>(Func<SqlConnection, SqlTransaction, T> action)
        {
            using (var connection = Open())
            using (var transaction = connection.BeginTransaction())
            {
                try { T value = action(connection, transaction); transaction.Commit(); return value; }
                catch { transaction.Rollback(); throw; }
            }
        }
    }
}
