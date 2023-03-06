// See https://aka.ms/new-console-template for more information
using Status;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/status", () =>
{
    var statusMessage = new StatusMessage(Guid.NewGuid(), "Learning .NET", DateTimeOffset.Now);
    return Results.Ok(statusMessage);
});

app.Run();

//var statusMessage = new StatusMessage(Guid.NewGuid(), "Learning .NET", DateTimeOffset.Now);

//Console.WriteLine($"The id {statusMessage.Id} status: {statusMessage.Message} at {statusMessage.when}");