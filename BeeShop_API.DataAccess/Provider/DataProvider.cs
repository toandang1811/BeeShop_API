using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BeeShop_API.DataAccess.Provider
{
    public class DataProvider
    {
        private static DataProvider instance;
        private static string _connectString;
        public static string ConnectString
        { 
            set { _connectString = value; }
        }
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        public DataSet GetData(CommandType commanType, string query, object[] parameter = null)
        {
            DataSet data = new DataSet();using (SqlConnection connection = new SqlConnection(_connectString))
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = commanType;
                if (parameter != null)
                {
                    List<string> paraNames = new List<string>();
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            paraNames.Add(item);
                            i++;
                        }
                    }

                    command.Parameters.AddRange(ConvertObjectParamsToSqlParams(paraNames.ToArray(), parameter));
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Truy vẫn đã xảy ra lỗi.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Đã có lỗi xảy ra trong quá trình xử lý.", ex);
            }
            finally
            {
                connection.Close();
            }
                
            return data;
        }

        public int SaveData(CommandType commanType, string query, object[] parameter = null)
        {
            int data = 0;
            DbTransaction trans = null;
            using (SqlConnection connection = new SqlConnection(_connectString))
            {
                try
                {
                    connection.Open();
                    trans = connection.BeginTransaction();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = commanType;
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (SqlException sqlEx) 
                {
                    trans?.Rollback();
                    throw new Exception("Truy vẫn đã xảy ra lỗi.", sqlEx);
                }
                catch (Exception ex) 
                {
                    trans?.Rollback();
                    throw new Exception("Đã có lỗi xảy ra trong quá trình xử lý.", ex);
                }
                finally
                {
                    if (trans != null)
                    {
                        trans = null;
                    }
                    connection.Close();
                }

            }

            return data;
        }

        public object GetObject(CommandType commanType, string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(_connectString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = commanType;
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteScalar();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Truy vẫn đã xảy ra lỗi.", sqlEx);
                }
                catch (Exception ex) 
                {
                    throw new Exception("Đã có lỗi xảy ra trong quá trình xử lý.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return data;
        }

        private SqlParameter[] ConvertObjectParamsToSqlParams(string[] parameterName, object[] parameters)
        {
            SqlParameter[] sqlParameters = new SqlParameter[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var p = parameters[i];
                switch (p)
                {
                    case string strValue:
                        sqlParameters[i] = new SqlParameter(parameterName[i], SqlDbType.NVarChar);
                        sqlParameters[i].Value = strValue;
                        break;

                    case int intValue:
                        sqlParameters[i] = new SqlParameter(parameterName[i], SqlDbType.Int);
                        sqlParameters[i].Value = intValue;
                        break;

                    case bool boolValue:
                        sqlParameters[i] = new SqlParameter(parameterName[i], SqlDbType.Bit);
                        sqlParameters[i].Value = boolValue;
                        break;

                    case decimal decimalValue:
                        sqlParameters[i] = new SqlParameter(parameterName[i], SqlDbType.Decimal);
                        sqlParameters[i].Value = decimalValue;
                        break;

                    case DateTime dateTimeValue:
                        sqlParameters[i] = new SqlParameter(parameterName[i], SqlDbType.DateTime);
                        sqlParameters[i].Value = dateTimeValue;
                        break;

                    default:
                        break;
                }
                i++;
            }
            return sqlParameters;
        }
    }
}
