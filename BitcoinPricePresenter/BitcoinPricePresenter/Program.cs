using BitcoinPricePresenter.Abstractions.Configuration;
using BitcoinPricePresenter.Abstractions.Policies;
using BitcoinPricePresenter.Abstractions.Services;
using BitcoinPricePresenter.Concrete.Services;
using BitcoinPricePresenter.Data.Abstractions.Repositories;
using BitcoinPricePresenter.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<SourcesConfiguration>(builder.Configuration);
builder.Services.AddSingleton<ISourcesConfigurationService, SourcesConfigurationService>();

builder.Services.AddSingleton<IBitcoinPriceService, BitcoinPriceService>();

builder.Services.AddSingleton<IBitcoinPriceProviderFactory, BitcoinPriceProviderFactory>();
builder.Services.AddSingleton<BitfinexPriceProvider>()
    .AddSingleton<IBitcoinPriceProvider, BitfinexPriceProvider>(s => s.GetService<BitfinexPriceProvider>());
builder.Services.AddSingleton<BitstampPriceProvider>()
    .AddSingleton<IBitcoinPriceProvider, BitstampPriceProvider>(s => s.GetService<BitstampPriceProvider>());

builder.Services.AddSingleton<IPricesRepository, PriceRepository>();

var sourcesConfiguration = builder.Configuration.Get<SourcesConfiguration>();

builder.Services.AddHttpClient<IBitstampClient, BitstampClient>(c => c.BaseAddress = new Uri(sourcesConfiguration.Sources[SourceEnum.Bitstamp.ToString()].BaseUrl))
                .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());

builder.Services.AddHttpClient<IBitfinexClient, BitfinexClient>(c => c.BaseAddress = new Uri(sourcesConfiguration.Sources[SourceEnum.Bitfinex.ToString()].BaseUrl))
                .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
