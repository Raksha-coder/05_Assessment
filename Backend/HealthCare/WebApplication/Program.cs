using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//FOR CONNECTIVITY WITH ANGULAR
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin",
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowedToAllowWildcardSubdomains());
});


// add database
builder.Services.AddDbContext<HealthDbContext>(options =>
    options.UseSqlServer(
        builder.
        Configuration.GetConnectionString("DefaultConnection"),
        builder => builder.MigrationsAssembly(typeof(HealthDbContext).Assembly.FullName)));

builder.Services.AddScoped(
    (Func<IServiceProvider, IHealthDbContext>)(provider => provider.GetRequiredService<HealthDbContext>())
);




//registering mediator
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
