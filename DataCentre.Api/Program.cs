using DataCentre.Api.Extensions;
using DataCentre.Api.PreProcess;
using NLog;
var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerServices();
builder.Services.ConfigureMySqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureConstants(builder.Configuration);
builder.Services.ConfigureFilterServices();
builder.Services.AddControllers();
var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions()
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
}) ;
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
