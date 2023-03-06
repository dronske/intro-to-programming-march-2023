// See https://aka.ms/new-console-template for more information
using Marten;
using Status;

var builder = WebApplication.CreateBuilder(args);

// This is where we configure "services" - Entities, Values, Services
var connectionString = "host=localhost;database=status_dev;username=postgres;password=TokyoJoe138!;port=5432";
builder.Services.AddMarten(options => 
{
    options.Connection(connectionString);
    options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
});

var app = builder.Build();

app.MapGet("/status", async (IDocumentSession db) =>
{
    var response = await db.Query<StatusMessage>()
    .OrderByDescending(sm => sm.When)
    .FirstOrDefaultAsync();

    if(response == null)
    {
        return Results.Ok(new StatusMessage(Guid.NewGuid(), "No status to report", DateTimeOffset.Now));
    }
    else
    {
        return Results.Ok(response);
    }
});

app.MapPost("/status", async (StatusChangeRequest request, IDocumentSession db) =>
{
    // Save this in the database
    var statusMessage = new StatusMessage(Guid.NewGuid(), request.Message, DateTimeOffset.Now);
    
    db.Store<StatusMessage>(statusMessage);
    await db.SaveChangesAsync();
    return Results.Ok(statusMessage);
});

app.Run();

//var statusMessage = new StatusMessage(Guid.NewGuid(), "Learning .NET", DateTimeOffset.Now);

//Console.WriteLine($"The id {statusMessage.Id} status: {statusMessage.Message} at {statusMessage.when}");