using SX.WebCore.Repositories;
using SX.WebCore.ViewModels;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace LR.WebUI.Infrastructure.Repositories
{
    public sealed class RepoPicture : SxRepoPicture<DbContext>
    {
        public SxVMPicture[] Last(int amount=10)
        {
            var query = @"SELECT TOP(@amount) dp.Id FROM D_PICTURE AS dp ORDER BY dp.DateCreate DESC";
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<SxVMPicture>(query, new { amount = amount }).ToArray();
            }
        }
    }
}