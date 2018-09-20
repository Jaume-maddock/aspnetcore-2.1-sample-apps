using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace FlexibleSQLProvider
{
    /// <summary>
    /// Repository containig business query
    /// </summary>
    public class BusinessRepository
    {
        /// <summary>
        /// SQL connection to DB
        /// </summary>
        private const string SQLConnection = "test.db.anycompany";
        // samples at http://dapper-tutorial.net/query

            /// <summary>
            /// Dynamic implementation of a db query
            /// </summary>
            /// <param name="productId"></param>
            /// <param name="productType"></param>
            /// <param name="startDate"></param>
            /// <param name="endDate"></param>
            /// <returns></returns>
        public dynamic GetDynamicPromotions(int productId, string productType, DateTime startDate, DateTime endDate)
        {
            string sql = $"SELECT TOP 10 * FROM Promotions p WITH(NOLOCK) " +
                $"WHERE p.productId = {productId} " +
                $"AND p.productType = {productType} " +
                $"AND p.startDate >= {startDate.ToShortDateString()} " +
                $"AND p.endDate <= {endDate.ToShortDateString()}";

            using (var connection = new SqlConnection(SQLConnection))
            {
                var result = connection.Query(sql).FirstOrDefault();
                return result;
            }
        }
    }
}
