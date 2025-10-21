using PeopleViewer.Presentation;
using PersonDataReader.CSV;
using PersonDataReader.Decorators;
using PersonDataReader.Service;
using PersonDataReader.SQL;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PeopleViewer.Common;

namespace PeopleViewer.Desktop.GenericHost;

public partial class App : Application
{
    IHost host;

    public App()
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureServices((hostContext, services) =>
            {
                //services.AddSingleton<IPersonReader, CSVReader>();

                services.AddSingleton<CSVReader>();
                services.AddSingleton<IPersonReader>(services =>
                    new CachingReader(services.GetService<CSVReader>()!));

                services.AddSingleton<PeopleViewModel>();
                services.AddSingleton<PeopleViewerWindow>();
            });
        host = builder.Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        this.MainWindow = host.Services.GetService<PeopleViewerWindow>();
        if (this.MainWindow is not null)
        {
            this.MainWindow.Title = "Generic Host";
            this.MainWindow.Show();
        }
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (host)
        {
            await host.StopAsync();
        }

        base.OnExit(e);
    }
}
