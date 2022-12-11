using GuardianProject.Common;
using GuardianProject.Pages.LanguagePageFolder.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using GuardianProject.Pages.WelcomePageFolder.Resources;

namespace GuardianProject.Pages.WelcomePageFolder
{
    public class WelcomPageViewModel : INotifyPropertyChanged
    {

        #region Members

        #endregion

        #region Constructor

        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
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
                Source = LocalizationResourceManager<RWelcomePage>.Instance,
            };
            return binding;
        }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
