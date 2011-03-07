using System;
using System.Collections;
using System.Linq;
using System.Text;
using IBatisNet.DataAccess.Interfaces;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.Configuration;
using IBatisNet.DataAccess.DaoSessionHandlers;
using IBatisNet.DataAccess.Exceptions;
using IBatisNet.DataMapper;
namespace MVCWebApplication.DAL
{
    public class BaseDAO:IDao
    {
        protected const int PAGE_SIZE = 4;
        private ISqlMapper sqlMapper = null;

        protected ISqlMapper GetLocalSqlMap
        {
            get
            {
                if (sqlMapper == null)
                {
                    lock (typeof(SqlMapper))
                    {
                        if (sqlMapper == null)
                        {
                            DomDaoManagerBuilder builder = new DomDaoManagerBuilder();
                            builder.Configure();
                            IDaoManager daoManager = DaoManager.GetInstance(this);
                            SqlMapDaoSession sqlMapDaoSession = (SqlMapDaoSession)daoManager.LocalDaoSession;
                            sqlMapper = sqlMapDaoSession.SqlMap;
                        }
                    }
                }
                return sqlMapper;
            }
        }

        protected IList ExecuteQueryForList(string statementName, object parameterObject)
        {
            try
            {
                return GetLocalSqlMap.QueryForList(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataAccessException("Error executing query '" + statementName + "' for list. Cause: " + e.Message, e);
            }
        }

        protected IList ExecuteQueryForList(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            try
            {
                return GetLocalSqlMap.QueryForList(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new DataAccessException("Error executing query '" + statementName + "' for list. Cause: " + e.Message, e);
            }
        }
        protected void ExecuteUpdate(string statementName, object parameterObject)
        {
            try
            {
                GetLocalSqlMap.Update(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new DataAccessException("Error executing query '" + statementName + "' for list. Cause: " + e.Message, e);
            }
        }

    }
}
