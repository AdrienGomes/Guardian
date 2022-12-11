using System;
using System.Collections.Generic;
using System.Text;
using GuardianProject.Common.SpecificServices.Contract;
using Xamarin.Forms;

namespace GuardianProject.Common
{
    /// <summary>
    /// Service factory to use every available services
    /// </summary>
    public static class ServiceFactory
    {
        public static IToasytService toastService = DependencyService.Get<IToasytService>();
    }
}
