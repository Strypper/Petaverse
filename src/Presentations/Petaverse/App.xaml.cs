using Petaverse.ApplicationStructure;
using Petaverse.BlackList;
using Petaverse.BlackListDetail;
using Petaverse.FosterCenter;
using Petaverse.Home;
using Windows.ApplicationModel.Core;

namespace Petaverse;

sealed partial class App : Application
{
    #region [ Fields ]

    private ThemeService _themeService;
    private IServiceCollection _serviceCollection;
    #endregion

    #region [ CTor ]

    public App()
    {
        this.InitializeComponent();
        this.InitializeEnvironment();
        this.Suspending += OnSuspending;

        SettingsHelper.CreateSettings();
    }
    #endregion

    #region [ Overrides ]

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;

        var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
        coreTitleBar.ExtendViewIntoTitleBar = true;

        _themeService = new(Window.Current);
        _themeService.SetTheme();

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
                rootFrame.Navigate(typeof(TheMainFrame), e.Arguments);
            }

            Window.Current.Activate();
        }
    }
    #endregion

    #region [ DI ]

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
                case HttpClientEnum.PetaverseLocal:
                    var httpClient = new HttpClient(
                                        new HttpClientHandler()
                                        {
                                            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
                                        })
                    {
                        BaseAddress = new Uri(AppConstants.PetaverseLocalBaseUrl)
                    };
                    httpClient.Timeout = TimeSpan.FromMinutes(2);
                    return httpClient;
                case HttpClientEnum.TotechIdentityLocal:
                    return new HttpClient(
                                        new HttpClientHandler()
                                        {
                                            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
                                        })
                    {
                        BaseAddress = new Uri(AppConstants.TotechsIdentityLocalBaseUrl)
                    };

                case HttpClientEnum.Petaverse:
                    var petaverseHttpClient = new HttpClient() { BaseAddress = new Uri(AppConstants.PetaverseBaseUrl) };
                    petaverseHttpClient.Timeout = TimeSpan.FromMinutes(2);
                    return petaverseHttpClient;

                case HttpClientEnum.TotechIdentity:
                    return new HttpClient() { BaseAddress = new Uri(AppConstants.TotechsIdentityBaseUrl) };
                default:
                    return null;

            }
        });

        services.AddSingleton((_) =>
        {
            var httpService = Ioc.Default.GetRequiredService<Func<HttpClientEnum, HttpClient>>();
            return httpService(HttpClientEnum.PetaverseLocal);
        });

        services.AddSingleton((_) => new ToolkitSerializer());
        services.AddSingleton((_) => Windows.Storage.ApplicationData.Current.LocalSettings);

        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IUploadPetFileService, HttpClientUploadPetFileService>();

        services.AddSingleton<IAnimalService, AnimalService>();
        services.AddSingleton<ISpeciesService, SpeciesService>();
        services.AddSingleton<IPetShortService, PetShortService>();
        services.AddSingleton<IPetaverseUserService, PetaverseUserService>();
        //services.AddSingleton<IAuthenticationService, AuthenticationService>();

        services.AddTransient<IHomePageService, HomePageService>();
        services.AddTransient<HomePageViewModel>();

        services.AddTransient<FosterCenterPageViewModel>();

        services.AddTransient<IBlackListDetailPageService, BlackListDetailPageService>();
        services.AddTransient<BlackListPageViewModel>();

        services.AddTransient<IBlackListPageService, BlackListPageService>();
        services.AddTransient<BlackListDetailPageViewModel>();

        services.AddSingleton<LoginUserControl>();

        services.RegisterLogicProvider();
    }
    #endregion

    #region [ Event Handlers ]

    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }

    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        deferral.Complete();
    }
    #endregion
}
