using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
namespace MVCWebApplication.DAL
{
    public class Mapper
    {
        private static volatile ISqlMapper _mapper = null;

        protected static void Configure(object obj)
        {
            _mapper = null;
        }

        protected static void InitMapper()
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            _mapper = builder.ConfigureAndWatch(handler);
        }

        public static ISqlMapper Instance
        {
            get
            {
                if (_mapper == null)
                {
                    lock (typeof(SqlMapper))
                    {
                        if (_mapper == null) // double-check
                        {
                            InitMapper();
                        }
                    }
                }
                return _mapper;
            }
        }
    }
}
