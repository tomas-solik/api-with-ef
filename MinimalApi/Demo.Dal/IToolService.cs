using Demo.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dal.Interface
{
    public interface IToolService
    {
        Tool GetTool(int id);

        List<Tool> GetTools();

        void CreateTool(string name, string modelName, string manufacturer);

        void DeleteTool(int id);

        void UpdateTool(Tool tool);
    }
}
