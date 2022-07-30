using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Petaverse.Enums;
using Petaverse.Helpers;
using Petaverse.Interfaces;
using Petaverse.Services;
using System;
using System.Net.Http;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Petaverse
{
    sealed partial class App : Application
    {
        private IServiceCollection _serviceCollection;

        public App()
        {
            this.InitializeComponent();
            this.InitializeEnvironment();
            this.Suspending += OnSuspending;
        }


        private void InitializeEnvironment()
        {

            if (_serviceCollection == null)
            {
                _serviceCollection = new ServiceCollection();
            }
            ConfigureServices(_serviceCollection);
            Ioc.Default.ConfigureServices(_serviceCollection.BuildServiceProvider());
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Func<HttpClientEnum, HttpClient>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case HttpClientEnum.Petaverse:
                        return new HttpClient(
                                            new HttpClientHandler()
                                            {
                                                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
                                            })
                                            {
                                                BaseAddress = new Uri("http://localhost:44371/api")
                                            };
                    case HttpClientEnum.TotechIdentity:
                        return new HttpClient(
                                            new HttpClientHandler()
                                            {
                                                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
                                            })
                                            { 
                                                BaseAddress = new Uri("http://localhost:4300/api")
                                            };
                    default:
                        return null;
                }
            });

            services.AddSingleton((_) => new ToolkitSerializer());
            services.AddSingleton((_) => Windows.Storage.ApplicationData.Current.LocalSettings);

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IUploadPetFileService, HttpClientUploadPetFileService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }

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

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }
    }
}
