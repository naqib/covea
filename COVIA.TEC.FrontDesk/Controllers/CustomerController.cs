using COVIA.TEC.BL.ChainOfResponsibility.Interface;
using COVIA.TEC.Domain;
using COVIA.TEC.FrontDesk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace COVIA.TEC.FrontDesk.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRuleSet _ruleSet;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IRuleSet RuleSet,
                                  ILogger<CustomerController> logger)
        {
            _ruleSet = RuleSet;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View(new RequestDto());
        }

        [HttpPost]
        public IActionResult Calculate(RequestDto request)
        {
            if (ModelState.IsValid)
            {
                // Need to use automapper and shall not do auto mapping in controller
                var _request = new RequestBo { Age = request.Age, AssuredSum = request.AssuredSum };

                var assuredDetail = _ruleSet.Process(_request);
                return View(assuredDetail);
            }

            return View("Index");
        }
    }
}
