using Demo.Dal.Interface.Types;

namespace Demo.Dal.Interface
{
    public interface IToolService
    {
        List<ToolDto> GetTools(); 
    }
}