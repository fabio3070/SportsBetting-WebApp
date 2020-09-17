using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.HtmlControls;

namespace StatsBet
{
    /// <summary>
    /// Classe de ligação à base de dados
    /// </summary>
    public class Data:IDisposable
	{
		private SqlConnection _cn;
		private SqlTransaction _trans;
		private SqlCommand _cmd;
        ArrayList _paramCol = new ArrayList();

		public Data()
		{
			_cn = new SqlConnection(this.connectionString);
			_trans = null;
			connect();
		}

		public Data(bool withTransaction)
		{
			_cn = new SqlConnection(this.connectionString);
			connect();
			_trans = null;
			if (withTransaction) beginTransaction();
		}

		public Data(string sql) 
		{
			_cn = new SqlConnection(this.connectionString);
			_trans = null;
			connect();
			executeSql(sql);
			disconnect();
		}

		public SqlTransaction Transaction
		{
			get 
			{
				return _trans;
			}
		}

		public SqlConnection Connection
		{
			get 
			{
				return _cn;
			}
		}

		
		private string connectionString 
		{
			get 
			{
				return ConfigurationManager.AppSettings["cn"];
			}
		}


		public string SessionID 
		{
			get 
			{
				return HttpContext.Current.Session.SessionID;
			}
		}

		public void connect() 
		{
			try 
			{
				_cn.Open();
			} 
			catch (SqlException ex)
			{
				throw new Exception("Erro ao iniciar a conexão à base de dados", ex);
			}
		}

		public void disconnect() 
		{
			try 
			{
				commitTransaction();
				if (_cn.State == ConnectionState.Open) _cn.Close();
			} 
			catch (SqlException ex)
			{
				throw new Exception("Erro ao fechar a conexão à base de dados", ex);
			}
		}

		public void beginTransaction() 
		{
			try 
			{
				if (_trans != null) 
				{
					_trans = _cn.BeginTransaction();
				}
			} 
			catch (SqlException ex) 
			{
				throw new Exception("Ocorreu um erro ao iniciar a transacção", ex);
			}
		}

		public void commitTransaction() 
		{
			try 
			{
				if (_trans != null) 
				{
					if (_trans.Connection != null) 
					{
						_trans.Commit();
						_trans.Dispose();
					}
				}
			} 
			catch (SqlException ex) 
			{
				throw new Exception("Ocorreu um erro ao efectuar o commit da transacção.", ex);
			}
		}

		public void rollBackTransaction() 
		{
			try 
			{
				if (_trans != null) 
				{
					if (_trans.Connection != null) 
					{
						_trans.Rollback();
						_trans.Dispose();
					}
				}
			} 
			catch(SqlException ex) 
			{
				throw new Exception("Ocorreu um erro ao efectuar o rollback da transacção.", ex);
			}
		}

        public void addParameter(string paramName, object paramValue)
        {
            _paramCol.Add(new SqlParameter(paramName, paramValue));
        }

        public void clearParameters()
        {
            _paramCol.Clear();
        }

        private void getSqlParameters()
        {
            for (int i = 0; i < _paramCol.Count; i++)
            {
                _cmd.Parameters.Add(_paramCol[i]);
            }
        }

        public SqlDataReader query(string sql) 
		{

			using (_cmd = new SqlCommand(sql, _cn)) 
			{
                _cmd.Parameters.AddRange(_paramCol.ToArray());

				if (_trans != null) _cmd.Transaction = _trans;

				try 
				{
					return _cmd.ExecuteReader();
				} 
				catch (SqlException ex)
				{
					throw new Exception("Ocorreu um erro ao exececutar a query: " + sql, ex);
				}
			}
		}

		public DataView getDataView(string sql) 
		{
			using (SqlDataAdapter da = new SqlDataAdapter(sql, _cn)) 
			{
                da.SelectCommand.Parameters.AddRange(_paramCol.ToArray());
				DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro em getDataView\nQuery: " + sql, ex);
                }
				return ds.Tables[0].DefaultView;
			}
		}


        public DataTable getDataTable(string sql)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _cn))
            {
                da.SelectCommand.Parameters.AddRange(_paramCol.ToArray());
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro em getDataView\nQuery: " + sql, ex);
                }
                return ds.Tables[0];
            }
        }

		public object executeScalar(string sql) 
		{
			using (_cmd = new SqlCommand(sql, _cn)) 
			{
                _cmd.Parameters.AddRange(_paramCol.ToArray());
				if (_trans != null) _cmd.Transaction = _trans;
				try 
				{
					return _cmd.ExecuteScalar();
				} 
				catch(SqlException ex) 
				{
					throw new Exception("Ocorreu um erro ao executar a query (scalar): " + sql, ex);
				}
			}
		}



		public int executeSql(string sql) 
		{
			int results = 0;

			using (_cmd = new SqlCommand(sql, _cn)) 
			{
                _cmd.Parameters.AddRange(_paramCol.ToArray());
				if (_trans != null) _cmd.Transaction = _trans;

                
					results = _cmd.ExecuteNonQuery();
					return results;
                
			}			
		}



		public ArrayList getFields(string sql) 
		{
			ArrayList myFields = new ArrayList();
			
			SqlDataReader dr = query(sql);
			if (dr.Read()) 
			{
				for (int i=0;i<dr.FieldCount;i++) 
				{
					myFields.Add(dr.GetValue(i));
				}
			}
			dr.Close();

			return myFields;
		}

		public string getFieldAsString(string sql)  
		{
            ArrayList myFields = getFields(sql);

            return (myFields.Count>0 ? getFields(sql)[0].ToString() : null);
		}

		public int getFieldAsInt(string sql) 
		{
			return Convert.ToInt32(getFields(sql)[0]);
		}

		public double getFieldAsDouble(string sql) 
		{
			return Convert.ToDouble(getFields(sql)[0]);
		}

		public DateTime getFieldAsDateTime(string sql) 
		{
			return Convert.ToDateTime(getFields(sql)[0]);
		}



		/*public void getImageLink(int file_id, string width, string height) 
		{
			DatabaseFile myFile = new DatabaseFile();
			myFile.placeImage(file_id, width, height);
		}


		public string getInputFilename(HtmlInputFile fileInputField) 
		{
			DatabaseFile myFile = new DatabaseFile();
			return myFile.getFilename(fileInputField);
		}

		public string getInputFileExtension(HtmlInputFile fileInputField) 
		{
			DatabaseFile myFile = new DatabaseFile();
			return myFile.getExtension(fileInputField);
		}

		public void deleteFile(string file_id) 
		{
			DatabaseFile myFile = new DatabaseFile();
			myFile.deleteFile(_cn, _trans, file_id);
		}

		public long uploadFile(HtmlInputFile fileInputField) 
		{
			
			DatabaseFile myFile = new DatabaseFile();
			long file_id = myFile.uploadFile(fileInputField, "", _cn, _trans, null, null);
			return file_id;
		}

		public long swapFile(int lastFileId, HtmlInputFile fileInputField) 
		{
			DatabaseFile myFile = new DatabaseFile();
			long file_id = myFile.swapFile(lastFileId, fileInputField, _cn, _trans, null, null);
			return file_id;
		}*/

		#region IDisposable Members

		public void Dispose()
		{
			disconnect();
		}

		#endregion
	}
}
