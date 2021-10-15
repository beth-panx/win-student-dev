using CommunityToolkit.Authentication;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpGraphQuickstartSample
{
    sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ConfigureGlobalAuthProvider();
        }

        private void ConfigureGlobalAuthProvider()
        {
            if (ProviderManager.Instance.GlobalProvider == null)
            {
                var clientId = "YOUR-CLIENT-ID-HERE";
                var scopes = new string[] { "User.Read" };

                ProviderManager.Instance.GlobalProvider = new MsalProvider(clientId, scopes); ;
            }
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }
    }
}
