using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TryDapper.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TryDapper.Controllers
{
    [Route("api/[controller]")]
    public class ProvincesController : Controller
    {
        private QueryProcessor _processor;
        // GET: api/valuesprivate QueryProcessor _processor;
        public ProvincesController()
        {
            _processor = new QueryProcessor(new DatabaseConnectionProvider());
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<StateProvince> Get()
        {
            return _processor.GetProvinces();
        }
    }
}
