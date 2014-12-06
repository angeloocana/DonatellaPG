
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Filters;
using Donatella.Models;
using Donatella.Helpers;

namespace Donatella.Controllers
{
    [CustomAuthorize]
    public class FaqController : Controller
    {
        private readonly IFaqApp _faqApp;
        public FaqController(IFaqApp faqApp)
        {
            _faqApp = faqApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Index()
        {
            return View(_faqApp.GruposEFaqs());
        }
    }
}
