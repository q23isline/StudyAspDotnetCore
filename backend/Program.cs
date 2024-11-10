using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Serilog;

using StudyAspDotnetCore.Models;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .WriteTo.Console()
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MyContext")
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
    policy =>
    {
        // TODO: ローカル用の設定になっているので、環境変数を読み込んで動的に設定できるようにする
        policy.WithMethods("GET").WithOrigins("http://localhost:5173");
    });
});

var app = builder.Build();

app.UseCors("CorsPolicy");

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    await Seed.Initialize(provider);
}

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
