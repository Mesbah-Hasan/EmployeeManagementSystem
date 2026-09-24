using EmployeeManagement.Shared.Services;

namespace EmployeeManagement.Web;

public class WebPlatformService : IPlatformService
{
    public bool IsWeb => true;
}