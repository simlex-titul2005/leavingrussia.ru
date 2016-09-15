using Dapper;
using LR.WebUI.Models;
using LR.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Repositories;
using SX.WebCore.ViewModels;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LR.WebUI.Infrastructure.Repositories
{
    public sealed class RepoArticle : SxRepoMaterial<Article, VMArticle>
    {
        public RepoArticle() : base(Enums.ModelCoreType.Article) { }

        public VMArticle[] ForHome(int amount=11)
        {
            var query = new StringBuilder();
            query.Append(@"SELECT TOP (@amount) dm.*, dmc.*, anu.*, dp.Id FROM DV_MATERIAL AS dm
LEFT JOIN D_MATERIAL_CATEGORY AS dmc ON dmc.Id = dm.CategoryId
LEFT JOIN AspNetUsers AS anu ON anu.Id = dm.UserId
LEFT JOIN D_PICTURE AS dp ON dp.Id = dm.FrontPictureId
WHERE dm.Show=1 AND dm.DateOfPublication<=GETDATE()
ORDER BY dm.DateOfPublication DESC");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMArticle, SxVMMaterialCategory, SxVMAppUser, SxVMPicture, VMArticle>(query.ToString(), (m, c, u, p)=> {
                    m.Category = c;
                    m.User = u;
                    m.FrontPicture = p;
                    return m;
                }, new { amount=amount, mct=ModelCoreType}, splitOn:"Id");

                return data.ToArray();
            }
        }

        public VMArticle[] Gallery(int boxesCount=3)
        {
            var materialsCountInBox = 3;

            var query = new StringBuilder();
            query.Append(@"SELECT TOP (@amount) dm.*, dmc.*, anu.*, dp.Id FROM DV_MATERIAL AS dm
LEFT JOIN D_MATERIAL_CATEGORY AS dmc ON dmc.Id = dm.CategoryId
JOIN AspNetUsers AS anu ON anu.Id = dm.UserId
JOIN D_PICTURE AS dp ON dp.Id = dm.FrontPictureId
WHERE dm.Show=1 AND dm.DateOfPublication<=GETDATE()
ORDER BY dm.DateOfPublication DESC");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMArticle, SxVMMaterialCategory, SxVMAppUser, SxVMPicture, VMArticle>(query.ToString(), (m, c, u, p) => {
                    m.Category = c;
                    m.User = u;
                    m.FrontPicture = p;
                    return m;
                }, new { amount = boxesCount*materialsCountInBox, mct = ModelCoreType }, splitOn: "Id");

                return data.ToArray();
            }
        }

        public override VMArticle[] GetLikeMaterials(SxFilter filter, int amount = 10)
        {
            var query = new StringBuilder();
            query.Append(@"SELECT TOP(@amount) dm.*, dmc.*, anu.*, dp.Id, dp.Caption
  FROM DV_MATERIAL AS dm
LEFT JOIN D_MATERIAL_CATEGORY AS dmc ON dmc.Id = dm.CategoryId
LEFT JOIN AspNetUsers AS anu ON anu.Id = dm.UserId
LEFT JOIN D_PICTURE AS dp ON dp.Id = dm.FrontPictureId
WHERE dm.Show=1 AND dm.DateOfPublication<=GETDATE() AND dm.ModelCoreType=@mct AND dm.Id NOT IN(@mid) AND dm.FrontPictureId IS NOT NULL
ORDER BY dm.DateOfPublication DESC");
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMArticle, SxVMMaterialCategory, SxVMAppUser, SxVMPicture, VMArticle>(query.ToString(), (m, c, u, p)=> {
                    m.Category = c;
                    m.User = u;
                    m.FrontPicture = p;
                    return m;
                }, new { amount = amount, mid = filter.MaterialId, mct = filter.ModelCoreType }, splitOn:"Id");

                return data.ToArray();
            }
        }

        public override VMArticle[] Last(Enums.ModelCoreType? mct = Enums.ModelCoreType.Article, int amount = 5, int? mid=null)
        {
            var query = new StringBuilder();
            query.Append(@"SELECT TOP(@amount) dm.*, dmc.*, anu.*, dp.Id, dp.Caption
  FROM DV_MATERIAL AS dm
LEFT JOIN D_MATERIAL_CATEGORY AS dmc ON dmc.Id = dm.CategoryId
LEFT JOIN AspNetUsers AS anu ON anu.Id = dm.UserId
LEFT JOIN D_PICTURE AS dp ON dp.Id = dm.FrontPictureId
WHERE dm.Show=1 AND dm.DateOfPublication<=GETDATE() AND dm.ModelCoreType=@mct AND ((@mid IS NOT NULL and dm.Id NOT IN(@mid)) OR @mid IS NULL) AND dm.FrontPictureId IS NOT NULL
ORDER BY dm.DateOfPublication DESC");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMArticle, SxVMMaterialCategory, SxVMAppUser, SxVMPicture, VMArticle>(query.ToString(), (m, c, u, p)=> {
                    m.Category = c;
                    m.User = u;
                    m.FrontPicture = p;
                    return m;
                }, new { mct=ModelCoreType, amount=amount, mid=mid  }, splitOn:"Id");

                return data.ToArray();
            }
        }

        public override VMArticle[] GetPopular(Enums.ModelCoreType mct, int? mid = null, int amount = 10)
        {
            var query = new StringBuilder();
            query.Append(@"SELECT TOP(@amount) dm.*, dmc.*, anu.*, dp.Id, dp.Caption
  FROM DV_MATERIAL AS dm
LEFT JOIN D_MATERIAL_CATEGORY AS dmc ON dmc.Id = dm.CategoryId
LEFT JOIN AspNetUsers AS anu ON anu.Id = dm.UserId
LEFT JOIN D_PICTURE AS dp ON dp.Id = dm.FrontPictureId
WHERE dm.Show=1 AND dm.DateOfPublication<=GETDATE() AND dm.ModelCoreType=@mct AND ((@mid IS NOT NULL and dm.Id NOT IN(@mid)) OR @mid IS NULL) AND dm.FrontPictureId IS NOT NULL
ORDER BY dm.DateOfPublication DESC");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMArticle, SxVMMaterialCategory, SxVMAppUser, SxVMPicture, VMArticle>(query.ToString(), (m, c, u, p) => {
                    m.Category = c;
                    m.User = u;
                    m.FrontPicture = p;
                    return m;
                }, new { mct = ModelCoreType, amount = amount, mid = mid }, splitOn: "Id");

                return data.ToArray();
            }
        }
    }
}