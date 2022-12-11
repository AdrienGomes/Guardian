using GuardianProject.Common;
using GuardianProject.Pages.LanguagePageFolder;
using System.Threading;
using Xamarin.Forms;

namespace GuardianProject.Pages.WelcomePageFolder
{
    public partial class WelcomPage : ContentPage
    {
        #region Properties

        

        #endregion

        #region Constructor
        public WelcomPage()
        {
            InitializeComponent();

            ApplySettings();
        }
        #endregion

        #region Handler
        /// <summary>
        /// Handler for when the page loads (overriden)
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Fade all labels
            await DynamicMotion.FadeStackAsync(stack_MainStackLayout);

            Thread.Sleep(DynamicMotion.READINGTIME);

            await Navigation.PushAsync(new LanguagePage());

        }

        #endregion

        #region Methods
        /// <summary>
        /// Apply default settings 
        /// </summary>
        private void ApplySettings()
        {
        }
        #endregion
    }
}
