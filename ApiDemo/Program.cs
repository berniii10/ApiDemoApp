using ApiDemo.Models;
using ApiDemo.Services;
using System.Reflection;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configure Kestrel to listen on all network interfaces
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(80); // Listen on port 80 for HTTP
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Define the data service
    var dataService = new DataService();

    // Define the model
    Model? model = null;

    // Tries to load the model from the Json file
    if (dataService.loadData(ref model))
    {
        if (model != null) // It will never be null because it is tested in loadData, but it is also to get rid of warnings
        {
            builder.Services.AddSingleton(new ModelService(model));
        }
        else
        {
            // Handle case where model is null
            // Throw an exception and terminate the application
            throw new Exception("Error: Loaded model is null.");
        }
    }
    else
    {
        // Handle case where data loading fails
        // Throw an exception and terminate the application
        throw new Exception("Error: Failed to load model data.");
    }

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during application startup: {ex.Message}");
    // Optionally: Log the exception or perform other error handling actions
}
