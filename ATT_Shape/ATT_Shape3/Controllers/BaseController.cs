using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ATT_Shape.domain.Models;

namespace ATT_Shape3.Controllers
{
    public abstract class BaseController : System.Web.Mvc.Controller
    {


        public abstract string EntityId { get; }

        public virtual string BodyPageCss
        {

            get
            {
                return "landing-page";
            }

        }


        //[Microsoft.Practices.Unity.Dependency]
        //public Services.IUserService UserService { get; set; }

        //[Microsoft.Practices.Unity.Dependency]
        //public Sabio.Web.Services.IConfigService ConfigService { get; set; }


        //[Microsoft.Practices.Unity.Dependency]
        //public IMetaTagsService MetaTagsService { get; set; }
        //[Microsoft.Practices.Unity.Dependency]
        //public ICMSPagesService CMSPagesService { get; set; }
        //[Microsoft.Practices.Unity.Dependency]
        //public IAccountsService AccountsService { get; set; }


        //set to virtual
        protected virtual T GetViewModel<T>() where T : BaseViewModel, new()
        {
            T model = new T();

            //model.IsLoggedIn = this.UserService.IsLoggedIn();
            //model.BodyPage = BodyPageCss;
            //model.ContentUrl = this.ConfigService.ContentUrl;
            //model.MapApiKey = this.ConfigService.GoogleApiKey;
            //model.User = this.UserService.GetAccountBase();


            //bool high = true;
            //model.Highlights = AccountsService.GetHighlighted(high);

            //if (model.IsLoggedIn)
            //{
            //    model.IsAdmin = UserService.IsInRole(AuthRoles.Admin);
            //    model.IsInfluencer = UserService.IsInRole(AuthRoles.Influencer);
            //    model.IsSuperAdmin = UserService.IsInRole(AuthRoles.SuperAdmin);
            //    model.IsBlogAdmin = UserService.IsInRole(AuthRoles.BlogAdmin);
            //    model.IsContentManager = UserService.IsInRole(AuthRoles.ContentManager);
            //}

            //model.EntityId = EntityId;
            //model.OwnerType = (int)OwnerType;


            return model;
        }

        //protected virtual List<PageMetaTagWName> GetMetaTags()
        //{
        //    return MetaTagsService.GetByIds(EntityId, (int)OwnerType);
        //}

        protected new ViewResult View()
        {
            BaseViewModel model = GetViewModel<BaseViewModel>();

            return base.View(model);
        }

        protected new ViewResult View(string viewName)
        {
            BaseViewModel model = GetViewModel<BaseViewModel>();

            return base.View(viewName, model);
        }


    }
}
