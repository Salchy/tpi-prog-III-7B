using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace negocio
{
    public class Database
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public Database()
        {
            try
            {
                //connection = new SqlConnection(ConfigurationManager.AppSettings["databaseConnection"]);
                connection = new SqlConnection("server =.\\SQLEXPRESS; database = RestoBar; integrated security = true");

                command = new SqlCommand();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        /// <summary>
        /// Setea la consulta a ejecutar en la base de datos.
        /// </summary>
        /// <param name="consulta"></param>
        public void setQuery(string consulta)
        {
            command.Parameters.Clear();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }

        /// <summary>
        /// Setea el procedimiento almacenado para ejecutar en la base de datos.
        /// </summary>
        /// <param name="procedure"></param>
        public void setProcedure(string procedure)
        {
            command.Parameters.Clear();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procedure;
        }

        /// <summary>
        /// Para consultas de tipo SELECT
        /// </summary>
        public void execQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Para consultas de tipo INSERT, UPDATE o DELETE
        /// </summary>
        public void execNonQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Para ejecutar consultas de tipo SCALAR (Retorna un valor entero), Funciones de resumen de SQL
        /// </summary>
        /// <returns>Retorna valores enteros de las funciones de resumen de SQL</returns>
        public int execScalar()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    return 0;
                }
                return int.Parse(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Agrega un parámetro a la consulta o procedimiento almacenado.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="valor"></param>
        public void setParameter(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);
        }

        public void closeConnection()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }
    }
}