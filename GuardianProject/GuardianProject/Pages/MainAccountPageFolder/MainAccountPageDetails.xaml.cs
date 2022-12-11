using GuardianProject.Common;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardianProject.Pages.MainAccountPageFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAccountPageDetails : ContentPage
    {
        public MainAccountPageDetails()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            await DynamicMotion.FadeFrameAsync(frame_MainFrame);

            Thread.Sleep(DynamicMotion.READINGTIME * 4);

            await Navigation.PushAsync(new MainAccountPage());
        }
    }
}