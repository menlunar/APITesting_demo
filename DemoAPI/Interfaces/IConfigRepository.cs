using DemoAPI.Models;

namespace DemoAPI.Interfaces
{
    public interface IConfigRepository
    {
        ConfigModel GetConfig();
    }
}
