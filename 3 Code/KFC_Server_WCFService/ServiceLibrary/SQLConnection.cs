using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web;

namespace ServiceLibrary
{

    public class SQLConnection
    {
        public SqlConnection sqlCn;
        private string strErrorMessage;
        private int intErrorNumber;
        private string mErrorMsg;
        private int mErrorCode;
        private string sConnectionString = ServiceLibrary.Properties.ConnectionSettings.ConnectionString;
        public string ConnectionString 
        {
            get
            {
                return sConnectionString;
            }
            set
            {
                sConnectionString = value;
            }
        }
        // Ham mo ket noi
        public void OpenConnection(string Module)
        {
            sConnectionString = ServiceLibrary.Properties.ConnectionSettings.ConnectionString;
        }
        /// <summary>
        /// String: Câu thông báo lỗi khi truy cập SQL
        /// </summary>
        /// 
        public string ErrorMessage
        {
            get
            {
                return strErrorMessage;
            }
        }
        /// <summary>
        /// int: Số lỗi khi truy cập SQL
        /// </summary>
        public int ErrorNumber
        {
            get
            {
                return intErrorNumber;
            }
        }

        /// <summary>
        /// Thực thi 1 StoreProcedure có trả về dữ liệu là 1 bảng
        /// </summary>
        /// <return>
        /// DataTable
        /// </return>>
        public DataTable ThucThiStoreTraVeBang(string TenStoreProcedure, SqlParameter[] sqlParam)
        {
            DataTable dtbTmp = new DataTable();
            try
            {
                sqlCn = MoKetNoi();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandTimeout = 2000;
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                for (int i = 0; i < sqlParam.Length; i++)
                {
                    sqlCmd.Parameters.Add(sqlParam[i]);
                }
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(dtbTmp);
                DongKetNoi(sqlCn);
            }
            catch (SqlException sqlEx)
            {
                strErrorMessage = sqlEx.Message;
                intErrorNumber = sqlEx.Number;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();

            }
            return dtbTmp;
        }
        /// <summary>
        /// Thuc thi 1 store tra ve du lieu la dataset
        /// </summary>
        /// <param name="TenStoreProcedure"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        protected DataSet ThucThiStoreTraVeDataSet(string TenStoreProcedure, SqlParameter[] sqlParam)
        {
            DataSet dtbTmp = new DataSet();
            try
            {
                sqlCn = MoKetNoi();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandTimeout = 2000;
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                for (int i = 0; i < sqlParam.Length; i++)
                {
                    sqlCmd.Parameters.Add(sqlParam[i]);
                }
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(dtbTmp);
                DongKetNoi(sqlCn);
            }
            catch (SqlException sqlEx)
            {
                strErrorMessage = sqlEx.Message;
                intErrorNumber = sqlEx.Number;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();

            }
            return dtbTmp;
        }
        /// <summary>
        /// Thực thi 1 StoreProcedure không trả lại giá trị
        /// </summary>
        public void ThucThiStore(string TenStoreProcedure, SqlParameter[] sqlParam)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandTimeout = 2000;
                sqlCn = MoKetNoi();
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                for (int i = 0; i < sqlParam.Length; i++)
                {
                    sqlCmd.Parameters.Add(sqlParam[i]);
                }
                sqlCmd.ExecuteNonQuery();
                DongKetNoi(sqlCn);
            }
            catch (SqlException sqlEx)
            {
                strErrorMessage = sqlEx.Message;
                intErrorNumber = sqlEx.Number;
            }

            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
        }
        /// <summary>
        /// Thực thi 1 câu lệnh SQL dạng select có trả về dữ liệu là 1 bảng
        /// </summary>
        /// <return>
        /// DataTable
        /// </return>>
        public DataTable ThucThiCauTruyVan_TraVeBang(string strSQL)
        {
            sqlCn = MoKetNoi();
            SqlDataAdapter Adapter = new SqlDataAdapter(strSQL, sqlCn);
            DataTable ds = new DataTable();
            try
            {
                Adapter.Fill(ds);
                DongKetNoi(sqlCn);
            }
            catch (SqlException E)
            {
                string strDescriptionError = E.Message;
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return ds;

        }
        /// <summary>
        /// Thực thi 1 câu lệnh SQL dạng select có trả về dữ liệu là DataSet
        /// </summary>
        /// <return>
        /// DataSet
        /// </return>>
        public DataSet ThucThiCauTruyVan_TraVeDataSet(string strSQL)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(strSQL, sqlCn);
            DataSet ds = new DataSet();
            try
            {
                Adapter.Fill(ds);
                DongKetNoi(sqlCn);
            }
            catch (SqlException E)
            {
                string strDescriptionError = E.Message;
            }
            return ds;
        }
        /// <summary>
        /// Thực thi 1 câu lệnh SQL dạng select không trả lại giá trị
        /// </summary>
        public string ThucThiLenhSQL(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 2000;
            sqlCn = MoKetNoi();
            sqlCommand.Connection = sqlCn;
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = strSQL;
            sqlCommand.CommandType = CommandType.Text;
            try
            {
                intErrorNumber = sqlCommand.ExecuteNonQuery();
                mErrorCode = 0;
                mErrorMsg = "";
                DongKetNoi(sqlCn);
            }
            catch (SqlException ex)
            {
                intErrorNumber = ex.Number;
                mErrorMsg = ex.Message;
                System.Console.Write(ex.StackTrace);
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return mErrorCode.ToString() + ":" + mErrorMsg;

        }

        public SQLConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region KetNoi CSDL
        public SqlConnection MoKetNoi()
        {
            SqlConnection sqlCn = new SqlConnection(ConnectionString);
            try
            {
                sqlCn.Open();
            }
            catch
            {
                return null;
            }
            return sqlCn;
        }

        public void DongKetNoi(SqlConnection sqlCn)
        {
            if (sqlCn != null)
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
        }
        #endregion
    }
}
