using GuardianProject.Common;
using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianProject.Pages.MainAccountPageFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAccountPage : ContentPage
    {
        public MainAccountPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await DynamicMotion.FadeFrameAsync(frame_MainFrame);

            Thread.Sleep(DynamicMotion.READINGTIME);
        }

        private void Handler_btnSoundMeterClicked(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task<object> amp = ServiceFactory.soundMeterService.Call(() =>
            {
                return ServiceFactory.soundMeterService.GetSoundAmplitude();
            });

            _ = ServiceFactory.toastService.Call(() =>
            {
                ServiceFactory.toastService.ShowToast($"The amplitude recoded is {amp.Result ?? 0}", true);
                return null;
            });
        }

        private void Handler_btnShowToastMessageClicked(object sender, EventArgs e)
        {

            ServiceFactory.toastService.Call(() =>
            {
                ServiceFactory.toastService.ShowToast("This is a toast example message", true);
                return null;
            });
        }
    }
}