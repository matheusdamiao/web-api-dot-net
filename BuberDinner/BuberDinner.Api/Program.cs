using Buber.Application;
using Buber.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("FreePolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000/")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
        });
    });
}


var app = builder.Build();
{
    app.UseCors();
    // Had to disable it, so I could develop locally without SSL errors
    // app.UseHttpsRedirection(); 
    app.MapControllers();
    app.Run();
}


