using GuardianProject.Common;
using GuardianProject.Pages.LanguagePageFolder.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;

namespace GuardianProject.Pages.LanguagePageFolder
{
    public class LanguagePageViewModel : INotifyPropertyChanged
    {
        #region Members
        private List<Language> _Languages;
        public List<Language> Languages
        {
            get { return _Languages; }
            protected set {
                _Languages = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Languages"));

            } 
        }

        // To use with the whell picker
        public Command<(int, int, IList<int>)> LanguageSelectedCallback { get; }


        private IList<int> _selectedItemsIndex;
        public IList<int> SelectedItemsIndex
        {
            get => _selectedItemsIndex;
            set {
                _selectedItemsIndex = value;
                LocalizationResourceManager<RLanguagePage>.Instance.SetCulture(GetSelectedCulture());
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedIndex"));
            }
        }

        public Language CurrentLanguage
        {
            get => _selectedItemsIndex[0] >= 0 ? Languages[_selectedItemsIndex[0]] : null;
            set
            {
                var newIndex = Languages.FindIndex(0, o => o.Equals(value));
                if (newIndex >= 0)
                    SelectedItemsIndex =  new[] { newIndex };
            }
        }
        #endregion

        #region Constructor
        public LanguagePageViewModel()
        {

            Languages = new List<Language>()
            {
                new Language("Français","France"),
                new Language("English","USA"),
                new Language("Español","Spain")
            };

            CurrentLanguage = new Language("English","USA");

            LanguageSelectedCallback = new Command<(int, int, IList<int>)>(tuple =>
            {
                var (selectedWheelIndex, selectedItemIndex, SelectedItemsIndex) = tuple;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedIndex"));
            });
        }

        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        private CultureInfo GetSelectedCulture()
        {
            switch (CurrentLanguage.Name)
            {
                case "Français":
                    {
                        return new CultureInfo("fr-FR");
                    }
                case "English":
                    {
                        return new CultureInfo("en-US");
                    }
                case "Español":
                    {
                        return new CultureInfo("es-ES");
                    }
                default:
                    {
                        return new CultureInfo("en-US");
                    }

            }
        }

        #endregion
    }

    public class Language : IEquatable<Language>
    {
        public string Name { get; private set; }

        public string Country { get; private set; }

        public Language(string name, string country)
        {
            Name = name;
            Country = country;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Equals(Language other)
        {
            try
            {
                return this.Name == other.Name && this.Country == other.Country;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Exception message : " + ex.Message);
                Debug.WriteLine("Exception stacktrace : " +ex.StackTrace);
                return false;
            }
        }
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
                Source = LocalizationResourceManager<RLanguagePage>.Instance,
            };
            return binding;
        }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
