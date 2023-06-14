using EmployeeMgmt.Services;
using EmployeeMgMt.Data;

namespace EmployeeMgmt
{
    public class RegisterService
    {
        public static class RegisterServe
        {
            public static void RegisterServices(IServiceCollection services)
            {
                Configure(services, DataRegister.GetTypes());
                Configure(services, RegisterServicesss.GetTypes());
            }
            public static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
            {
                foreach (var type in types)
                {
                    services.AddScoped(type.Key, type.Value);

                }

            }
        }
    }
}
