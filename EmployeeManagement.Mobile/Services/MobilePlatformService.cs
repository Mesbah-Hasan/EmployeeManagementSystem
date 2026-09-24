using EmployeeManagement.Shared.Services;

namespace EmployeeManagement.Mobile.Services;

public class MobilePlatformService : IPlatformService
{
    public bool IsWeb => false;
}