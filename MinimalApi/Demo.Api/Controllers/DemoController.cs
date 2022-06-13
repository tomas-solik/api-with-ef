using Demo.Api.Entities;
using Demo.Dal.DemoDbContext;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : Controller
    {
        private readonly ILogger<DemoController> _logger;

        private readonly DemoDbContext _dbContext;

        public DemoController(ILogger<DemoController> logger, DemoDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetTools")]
        public IEnumerable<Tool> Get()
        {
            var tools = _dbContext.Tools.ToList();
            return tools;
        }
    }
}
