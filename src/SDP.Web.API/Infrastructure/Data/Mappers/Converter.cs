using Microsoft.Data.SqlClient;
using SDP.Web.API.UseCases.Orders;
using System.Data;
using System.Reflection;

namespace SDP.Web.API.Infrastructure.Data.Mappers
{
    /// <summary>
    /// Summary description for Converter.
    /// </summary>
    public class Converter
    {
        private Converter() { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(Object o)
        {

            PropertyInfo[] properties = o.GetType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            FillData(properties, dt, o);

            return dt;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(Object[] array)
        {

            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);

            if (array.Length != 0)
            {

                foreach (object o in array)
                    FillData(properties, dt, o);
            }

            return dt;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc;

            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;
                dt.Columns.Add(dc);
            }

            return dt;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="dt"></param>
        /// <param name="o"></param>
        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
                dr[pi.Name] = pi.GetValue(o, null);
            dt.Rows.Add(dr);
        }

        public static SqlParameter ConvertToStructuredSQLParameter(DataTable dataTable, string ParamName, string ParamTypeName)
        {
            SqlParameter NewParam = new SqlParameter();
            NewParam.ParameterName = ParamName;
            NewParam.SqlDbType = SqlDbType.Structured;
            NewParam.TypeName = ParamTypeName;
            NewParam.Value = dataTable;

            return NewParam;
        }
    }
}
