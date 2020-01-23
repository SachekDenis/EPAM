using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Connections;

namespace Task6
{
    /// <summary>
    /// Class ExcelDataLayer.
    /// Implements the <see cref="Task6.IExcelDataLayer{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Task6.IExcelDataLayer{T}" />
    internal class ExcelDataLayer<T> : IExcelDataLayer<T> where T : class
    {

        /// <summary>
        /// The connection
        /// </summary>
        private readonly ExcelConnection _connection;

        /// <summary>
        /// The formatter
        /// </summary>
        private readonly SqlCommadFormatter<T> _formatter;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelDataLayer{T}"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="ArgumentNullException">connection</exception>
        public ExcelDataLayer(ExcelConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));

            _formatter = new SqlCommadFormatter<T>();
        }

        /// <summary>
        /// Creates the sheet.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public void CreateSheet()
        {
            string sqlCommand;
            try
            {
                sqlCommand = _formatter.FormCreateSqlCommand();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connection.ConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sqlCommand, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Inserts the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">item</exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public void Insert(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            List<OleDbParameter> sqlParameters;

            string sqlCommand;

            try
            {
                sqlParameters = _formatter.GetOleDbParameters(item).ToList();

                sqlCommand = _formatter.FormInsertSqlCommand(item);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connection.ConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sqlCommand, connection))
                    {
                        sqlParameters.ForEach(sqlParameter => cmd.Parameters.Add(sqlParameter));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}