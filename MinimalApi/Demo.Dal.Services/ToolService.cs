using Demo.Dal.Interface;
using Demo.Dal.Interface.Types;

namespace Demo.Dal.Services
{
    public class ToolService : IToolService
    {
        private readonly DemoDbContext.DemoDbContext _context;
        public ToolService(DemoDbContext.DemoDbContext context)
        {
            _context = context;
        }

        public List<ToolDto> GetTools()
        {
            return _context.Tools.Select(x => new ToolDto 
            { 
                Id = x.Id, 
                Name = x.Name, 
                NominalValue = x.NominalValue, 
                ToolModel = x.Model.Name, 
                ToolManufacturer = x.Model.Manufacturer.Name 
            }).ToList();
        }
    }
}