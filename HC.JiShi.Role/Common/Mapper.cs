using IBatisNet.DataMapper;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper.Configuration;

namespace HC.JiShi.UserRole.Common
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
            var handler = new ConfigureHandler(Configure);
            var builder = new DomSqlMapBuilder();
            _mapper = builder.ConfigureAndWatch(handler);
        }
 
        public static ISqlMapper Instance()
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
 
        public static ISqlMapper Get()
        {
            return Instance();
        }
 
 
        /// <summary>
        /// RealMarket Mapper
        /// </summary>
        public static ISqlMapper GetMaper
        {
            get
            {
                if (_mapper == null)
                {
                    lock (typeof(ISqlMapper))
                    {
                        if (_mapper == null)
                        {
                            var hander = new ConfigureHandler(Configure);
                            var builder = new DomSqlMapBuilder();
                            _mapper = builder.ConfigureAndWatch("config/sqlmap.config", hander);
                        }
                    }
                }
                return _mapper;
            }
        }
    }
}