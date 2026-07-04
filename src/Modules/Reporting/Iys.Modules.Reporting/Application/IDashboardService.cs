using Iys.Modules.Reporting.Domain;

namespace Iys.Modules.Reporting.Application;

public interface IDashboardService
{
    DashboardSnapshot GetSnapshot();
}
