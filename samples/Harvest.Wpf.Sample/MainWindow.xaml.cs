namespace Harvest.Wpf.Sample;

using System;
using System.Windows;
using Harvest.Authentication;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly HarvestServiceClient client;
    private readonly AuthCredential authCredential;

    public MainWindow()
    {
        this.InitializeComponent();

        this.authCredential = new OAuthCredential(
            "CLIENT_ID",
            "CLIENT_SECRET",
            new Uri("http://localhost:8080"));

        this.client = new HarvestServiceClient(this.authCredential, "HarvestWpfSample");

        if (this.authCredential is not OAuthCredential)
        {
            return;
        }

        this.webBrowser.Visibility = Visibility.Visible;
        this.webBrowser.Source = this.client.BuildAuthorizationUrl();

        this.webBrowser.NavigationStarting += async (sender, args) =>
        {
            if (!args.Uri.StartsWith("http://localhost:8080"))
            {
                return;
            }

            if (this.authCredential.AccessToken == null || string.IsNullOrEmpty(this.authCredential.AccessToken.Token))
            {
                await this.client.AuthorizeAsync(new Uri(args.Uri));
            }
            else
            {
                this.webBrowser.Visibility = Visibility.Collapsed;
            }
        };
    }
}