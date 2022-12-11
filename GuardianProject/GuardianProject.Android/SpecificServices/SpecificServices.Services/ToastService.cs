using Android.App;
using Android.Widget;
using GuardianProject.Common.SpecificServices.Contract;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(GuardianProject.Droid.SpecificServices.SpecificServices.Services.ToasytService))]
namespace GuardianProject.Droid.SpecificServices.SpecificServices.Services
{
    /// <summary>
    /// Implementation of <see cref="IToasytService"/>
    /// </summary>
    internal class ToasytService : IToasytService
    {
        private static Toast _toastInstance;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void ShowToast(string message, bool isLongToast = false)
        {
            var toastLength = isLongToast
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