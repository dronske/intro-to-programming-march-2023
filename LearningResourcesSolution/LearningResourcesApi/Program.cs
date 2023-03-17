using LearningResourcesApi.Adapters;
using LearningResourcesApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var apiUrl = builder.Configuration.GetValue<string>("onCallApiUrl");
if (apiUrl == null)
{
    throw new Exception("Don't have an API URL!");
}
builder.Services.AddHttpClient<OnCallDeveloperLookupApiAdapter>(client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

builder.Services.AddScoped<ILookupOnCallDevelopers, ApiOnCallDeveloperLookup>();

builder.Services.AddCors(config =>
{
    config.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyMethod();
        pol.AllowAnyHeader();
    }
    );
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LearningResourcesDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("resources"));
});

builder.Services.AddScoped<IManageLearningResources, EntityFrameworkResourceManager>();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
