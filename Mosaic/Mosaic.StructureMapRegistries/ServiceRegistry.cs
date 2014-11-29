using Mosaic.Services;
using Mosaic.Services.Implementation;
using StructureMap.Configuration.DSL;
using StructureMap.Web;
namespace Mosaic.StructureMapRegistries
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IToDoService>().HybridHttpOrThreadLocalScoped().Use<ToDoService>();
        }
    }
}
