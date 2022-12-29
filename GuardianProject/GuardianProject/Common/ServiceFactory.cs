using GuardianProject.Common.SpecificServices.Contract;
using Xamarin.Forms;

namespace GuardianProject.Common
{
    /// <summary>
    /// Service factory to use every available services
    /// </summary>
    public static class ServiceFactory
    {
        // Services
        public static IToasytService toastService = DependencyService.Get<IToasytService>();
        public static ISoundMeterService soundMeterService = DependencyService.Get<ISoundMeterService>();

        // Logger
        public static ILogger logger = DependencyService.Get<ILogManager>().GetLog();

    }
}
