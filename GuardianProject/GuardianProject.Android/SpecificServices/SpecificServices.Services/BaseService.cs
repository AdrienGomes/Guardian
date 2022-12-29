using Android.Content.PM;
using AndroidX.Core.App;
using GuardianProject.Common;
using GuardianProject.Common.SpecificServices.Contract;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuardianProject.Droid.SpecificServices.SpecificServices.Services
{
    /// <summary>
    /// Implementation of <see cref="IBaseService"/>
    /// </summary>
    public abstract class BaseService : IBaseService
    {
        /// <summary>
        /// List of device permissions required by the service (to be hidden if herited classes)
        /// </summary>
        protected abstract IEnumerable<string> DevicePermissions { get; set; }

        /// <inheritdoc/>
        public async Task<object> Call(Func<object> method)
        {
            object res = null;

            try
            {
                await RequestPermissionsAsync(DevicePermissions);
                res = method.Invoke();
            }
            catch (Exception ex)
            {
                ServiceFactory.logger.Error(ex.Message);
            }

            return res;

        }

        /// <inheritdoc/>
        public async Task RequestPermissionsAsync(IEnumerable<string> permissions)
        {
            int requestCodes = 0;
            foreach (string permission in permissions)
            {
                if (ActivityCompat.CheckSelfPermission(MainActivity.GetContext(), permission) != Permission.Granted)
                {
                    await Task.Run(() => ActivityCompat.RequestPermissions(CrossCurrentActivity.Current.Activity, new[] { permission }, requestCodes++));
                }
            }
        }
    }
}