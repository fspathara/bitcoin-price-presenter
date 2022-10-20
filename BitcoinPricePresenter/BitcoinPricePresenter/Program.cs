using BitcoinPricePresenter.Abstractions.Configuration;
using BitcoinPricePresenter.Abstractions.Models.Requests;
using BitcoinPricePresenter.Abstractions.Policies;
using BitcoinPricePresenter.Abstractions.Services;
using BitcoinPricePresenter.Abstractions.Utils;
using BitcoinPricePresenter.Abstractions.Validators;
using BitcoinPricePresenter.Concrete.Services;
using BitcoinPricePresenter.Data;
using BitcoinPricePresenter.Data.Abstractions.Repositories;
using BitcoinPricePresenter.Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(s =>
{
    s.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    s.JsonSerializerOptions.Converters.Add(new DecimalFormatConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:PricesDb"]), ServiceLifetime.Singleton);

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

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<GetHistoryRequest>, GetHistoryRequestValidator>();

var app = builder.Build();

var context = app.Services.GetRequiredService<RepositoryContext>();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
