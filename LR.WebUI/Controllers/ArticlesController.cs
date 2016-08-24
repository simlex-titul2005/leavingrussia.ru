using System.Web.Mvc;
using LR.WebUI.Infrastructure.Repositories;
using LR.WebUI.ViewModels;
using SX.WebCore;
using System;

namespace LR.WebUI.Controllers
{
    public sealed class ArticlesController : MaterialsController<VMArticle>
    {
        static ArticlesController()
        {
            if (Repo == null)
                Repo = new RepoArticle();
        }

        public ArticlesController() : base(Enums.ModelCoreType.Article) { }

        public sealed override PartialViewResult Last(Enums.ModelCoreType? mct = null, int amount = 5)
        {
            var date = DateTime.Now;
            var fakeData = new VMArticle[6];
            for (int i = 0; i < 6; i++)
            {
                fakeData[i] = new VMArticle
                {
                    Id = i + 1,
                    Title = "Beautiful Forest in Europe-" + (i + 1),
                    TitleUrl = UrlHelperExtensions.SeoFriendlyUrl("Beautiful Forest in Europe-" + (i + 1)),
                    DateCreate = date.AddDays(-1),
                    DateOfPublication = date.AddDays(-1)
                };
            }

            //var viewModel = Repo.Last(mct, amount);
            var viewModel = fakeData;
            return PartialView("_Last", viewModel);
        }

        public PartialViewResult Categories()
        {
            return PartialView("_Categories");
        }
    }
}