using SignalGrapher.Application;
using SignalGrapher.Infrastructure;
using SignalGrapher.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("reactApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("reactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();
