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
        {   // Initially, I set to only port:3000, but it was throwing some errors, so I changed to all
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
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


