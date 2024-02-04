using ContactAPIs.Bll.Services;
using ContactAPIs.Core.Services;
using ContactAPIs.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .ConfigureCors()
    .ConfigureDatabase(builder.Configuration)
    .AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("Policy");
app.UseAuthorization();
app.MapControllers();

app.Run();
