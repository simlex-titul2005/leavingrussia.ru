﻿using System.Web.Mvc;
using LR.WebUI.Infrastructure.Repositories;
using LR.WebUI.ViewModels;
using SX.WebCore;
using System;
using SX.WebCore.ViewModels;
using LR.WebUI.Models;

namespace LR.WebUI.Controllers
{
    public sealed class ArticlesController : MaterialsController<Article, VMArticle>
    {
        static ArticlesController()
        {
            if (Repo == null)
                Repo = new RepoArticle();
        }

        public ArticlesController() : base(Enums.ModelCoreType.Article) { }

        [ChildActionOnly]
        public override PartialViewResult Last(Enums.ModelCoreType? mct = null, int amount = 5, int? mid=null)
        {
            var viewModel = Repo.Last(Enums.ModelCoreType.Article, amount, mid);
            return PartialView("_Last", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Categories()
        {
            return PartialView("_Categories");
        }

        [ChildActionOnly]
        public PartialViewResult ReadNow()
        {
            var date = DateTime.Now;
            var viewModel= new VMArticle
            {
                Id = 10,
                Title = "Beautiful Forest in Europe-" + 10,
                TitleUrl = UrlHelperExtensions.SeoFriendlyUrl("Beautiful Forest in Europe-" + 10),
                DateCreate = date.AddDays(10),
                DateOfPublication = date.AddDays(-1)
            };

            return PartialView("_ReadNow", viewModel);
        }

        [ChildActionOnly]
        public sealed override PartialViewResult Popular(int? mid = null, int amount = 4)
        {
            var date = DateTime.Now;
            var fakeData = new VMArticle[3];
            for (int i = 0; i < 3; i++)
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
            return PartialView("_Popular", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Subscribe()
        {
            var viewModel = new SxVMSubscriber();
            return PartialView("_Subscribe", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult ForHome(int amount=11)
        {
            var viewModel = (Repo as RepoArticle).ForHome(amount);
            return PartialView("_ForHome", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Gallery(int boxesCount=3)
        {
            var date = DateTime.Now;
            var fakeData = new VMArticle[9];
            for (int i = 0; i < 9; i++)
            {
                fakeData[i] = new VMArticle
                {
                    Id = i + 1,
                    Title = "Beautiful Forest in Europe-" + (i + 1),
                    TitleUrl = UrlHelperExtensions.SeoFriendlyUrl("Beautiful Forest in Europe-" + (i + 1)),
                    DateCreate = date.AddDays(-1),
                    DateOfPublication = date.AddDays(-1),
                    Foreword = @"Lorem ipsum dolor sit amet, consectetuer adipiscing. Aenean commodo ligula eget dolor. Aenean masssociis nat penatibus et magnis dis parturient monteios, nascetur ridiculus mus. Nulla onsequat mas quis enim. Pede justo, fringilla vel, aliquet nec loremt, vulputate eget. Nemo enim ipsam voluptatem quia voluptas sit pernatur aut odit aut fugit, sed quia consequuntur magni dolores.",
                    Html = @"<p>Lorem ipsum dolor sit amet, consectetuer adipiscing. Aenean commodo ligula eget dolor. Aenean masssociis nat penatibus et magnis dis parturient monteios, nascetur ridiculus mus. Nulla onsequat mas quis enim. Pede justo, fringilla vel, aliquet nec loremt, vulputate eget. Nemo enim ipsam voluptatem quia voluptas sit pernatur aut odit aut fugit, sed quia consequuntur magni dolores.</p>
                    <p>
                        Rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer cidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Lorem ipsum. vitae dicta sunt.
                    </p>",
                    User = new SxVMAppUser { NikName = "simlex" },
                    Category = new SxVMMaterialCategory { Id = "europe", Title = "Europe" }
                };
            }

            ViewBag.BoxesCount = boxesCount;

            return PartialView("_Gallery", fakeData);
        }
    }
}