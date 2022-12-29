using Android.App;
using Android.Widget;
using GuardianProject.Common.SpecificServices.Contract;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(GuardianProject.Droid.SpecificServices.SpecificServices.Services.ToasytService))]
namespace GuardianProject.Droid.SpecificServices.SpecificServices.Services
{
    /// <summary>
    /// Implementation of <see cref="IToasytService"/>
    /// </summary>
    internal class ToasytService : BaseService, IToasytService
    {
        private static Toast _toastInstance;

        protected override IEnumerable<string> DevicePermissions { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void ShowToast(string message, bool isLongToast = false)
        {
            ToastLength toastLength = isLongToast
                ? ToastLength.Long
                : ToastLength.Short;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                _toastInstance?.Cancel();
                _toastInstance = Toast.MakeText(Application.Context,
                    message, toastLength);
                _toastInstance?.Show();
            });
        }
    }
}