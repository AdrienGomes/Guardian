using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Threading;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace GuardianProject.Common
{

    /// <summary>
    /// ResourceManager to use in bindings to react to language changes
    /// </summary>
    public class LocalizationResourceManager<T> : INotifyPropertyChanged where T : class
    {

        public static LocalizationResourceManager<T> Instance = new LocalizationResourceManager<T>();
        public string this[string text]
        {
            get
            {
                return new ResourceManager(typeof(T)).GetString(text, Thread.CurrentThread.CurrentUICulture);
            }
        }

        public void SetCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = language;

            Invalidate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
