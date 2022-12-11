using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GuardianProject.Common;
using GuardianProject.Pages.LanguagePageFolder.Resources;
using GuardianProject.Pages.LanguagePageFolder;
using GuardianProject.Pages.MainAccountPageFolder;

namespace GuardianProject.Pages.LanguagePageFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {

        /// <summary>
        /// View Model
        /// </summary>
        public LanguagePageViewModel LanguageModel { get; protected set; }

        #region Constructor
        /// <summary>
        /// Page ctor
        /// </summary>
        public LanguagePage()
        {
            InitializeComponent();

            ApplySettings();

        }
        #endregion

        #region Handler

        /// <summary>
        /// Next button handler to move to next screen
        /// </summary>
        private void NextButton_Clicked(object sender,EventArgs e) =>
            Navigation.PushAsync(new MainAccountPageDetails());

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await DynamicMotion.FadeFrameAsync(frame_MainFrame);
        }
        #endregion

        #region Method
        /// <summary>
        /// Apply init settings on creation
        /// </summary>
        private void ApplySettings()
        {

            LanguageModel = new LanguagePageViewModel();

        }

        
        #endregion

        
    }

}