using CloudWebApplication.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CloudDbContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/add", async (AnimalZooRegistration registration, CloudDbContext context) =>
{
    context.Add(registration);
    await context.SaveChangesAsync();

    return registration;
});

app.MapGet("/all", async (CloudDbContext context) =>
{
    return await context.ZooRegistrations.ToListAsync();
});

app.MapGet("/get/{registrationId:int}", async (int registrationId, CloudDbContext context) =>
{
    AnimalZooRegistration? thisRegistration = await context.ZooRegistrations.
        FirstOrDefaultAsync(registration => registration.Id == registrationId);

    return thisRegistration;
});

app.MapDelete("/delete/{registrationId:int}", async (int registrationId, CloudDbContext context) =>
{
    AnimalZooRegistration? deletedRegistration = await context.ZooRegistrations.
        FirstOrDefaultAsync(registration => registration.Id == registrationId);

    if (deletedRegistration != null)
    {
        context.Remove(deletedRegistration);
        await context.SaveChangesAsync();

        return deletedRegistration;
    }
    return null;
});

app.MapPost("/update", async (AnimalZooRegistration newRegistration, CloudDbContext context) =>
{
    AnimalZooRegistration? oldRegistration = await context.ZooRegistrations.
        FirstOrDefaultAsync(registration => registration.Id == newRegistration.Id);

    if (oldRegistration != null)
    {
        oldRegistration.Kind = newRegistration.Kind; 
        oldRegistration.Name = newRegistration.Name;
        oldRegistration.DateOfBirth = newRegistration.DateOfBirth;
        oldRegistration.Sex = newRegistration.Sex;
        oldRegistration.Ration = newRegistration.Ration;
        oldRegistration.Caretaker = newRegistration.Caretaker;         
        await context.SaveChangesAsync();

        return oldRegistration;
    }
    return null;
});

app.Run();
