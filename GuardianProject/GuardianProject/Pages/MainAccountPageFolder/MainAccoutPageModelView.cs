using GuardianProject.Common;
using GuardianProject.Pages.LanguagePageFolder.Resources;
using GuardianProject.Pages.MainAccountPageFolder.Resources;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianProject.Pages.MainAccountPageFolder
{
    public class MainAccoutPageModelView : INotifyPropertyChanged
    {
        #region Members

        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        #endregion

        #region Methods

        #endregion
    }
    public class TranslateExtension : IMarkupExtension<BindingBase>
    {

        public string Text { get; set; }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = LocalizationResourceManager<RMainAccount>.Instance,
            };
            return binding;
        }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
