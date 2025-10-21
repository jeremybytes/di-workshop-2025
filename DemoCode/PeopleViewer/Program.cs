using PeopleViewer.Common;
using PeopleViewer.Logging;
using PersonDataReader.CSV;
using PersonDataReader.Decorators;
using PersonDataReader.Flaky;
using PersonDataReader.Service;
using PersonDataReader.SQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPersonReader, CSVReader>();
builder.Services.AddSingleton<IPersonReader>(s => GetReader());
builder.Services.AddKeyedSingleton<IPersonReader, SQLReaderProxy>("method");

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static IPersonReader GetReader()
{
    return new CachingReader(new SQLReaderProxy());

    // CODE TO TEST DECORATORS
    //var logger = new ConsoleLogger();
    //var reader = new FlakyReader(100);
    //var retry = new RetryReader(reader, new TimeSpan(0, 0, 3), 
    //    logger);
    //return new ExceptionLoggingReader(retry, logger);
}