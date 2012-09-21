using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace HyperCache.Sql
{
    public class SqlCacheManager
    {
        protected CacheManager cacheManager;
        public string ConnectionString { get; protected set; }
        public SqlCacheManager(string connectionString)
        {
            cacheManager = new CacheManager(null);
        }

        public string Process(string query, DateTimeOffset absoluteExpiration)
        {
            return cacheManager.Process<string>(query, () =>
            {
                var val = string.Empty;
                using (var sqlConnection = new SqlConnection())
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(query + " for xml"))
                    {
                        var reader = sqlCommand.ExecuteXmlReader();
                        if (reader.Read())
                        {
                            while (reader.ReadState != System.Xml.ReadState.EndOfFile)
                            {
                                val = reader.ReadOuterXml();
                            }
                        }
                    }
                }
                return val;
            }, absoluteExpiration);
        }

    }
}
