
using Asp.Versioning.ApiExplorer;
using HM_Admin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Extensions.AspNetCore.Configuration.Secrets;


var builder = WebApplication.CreateBuilder(args);

// Replace the Key Vault configuration section with the following code:

#region create Key vault client
//var secretClient = new SecretClient(
//    new Uri("https://babukeyvaulttest.vault.azure.net/"),
//    new DefaultAzureCredential());

//builder.Configuration.AddAzureKeyVault(secretClient, new AzureKeyVaultConfigurationOptions());
#endregion

// 1. Define a unique string for the policy name
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
// 1. Add the CORS service and define a policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            //policy.WithOrigins("http://localhost:5174") // Your frontend URL
            policy.AllowAnyOrigin()//allowing all domain
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// 1. Add CORS services and define an "AllowAll" policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()   // Allows all domains
              .AllowAnyHeader()   // Allows all custom headers
              .AllowAnyMethod();  // Allows GET, POST, PUT, DELETE, etc.
    });
});



// Add services to the container.

#region Retrieve the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}
builder.Services.AddDbContext<HMAdminDBContext>(options =>
    options.UseSqlServer(connectionString));
#endregion
builder.Services.AddHMAdminServices();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region  Configure the API Versioning Engine correctly (using Asp.Versioning)
builder.Services.AddApiVersioning(options =>
{
    //options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = Asp.Versioning.ApiVersionReader.Combine(
        new Asp.Versioning.UrlSegmentApiVersionReader(),
        new Asp.Versioning.QueryStringApiVersionReader("api-version"),
        new Asp.Versioning.HeaderApiVersionReader("X-Api-Version")
    );
})
.AddApiExplorer(options =>
{
    // This is the specific line that fixes your error
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();//registroing the service for swagger documentation
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    #region Swagger UI configuration
    app.UseSwaggerUI(options =>
    {
        var assemblyTitle = System.Reflection.Assembly.GetExecutingAssembly()
    .GetCustomAttribute<System.Reflection.AssemblyTitleAttribute>()?.Title
    ?? "HM Admin API";
        // Dynamically build the Swagger UI endpoints for each version discovered
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {

            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = $"{assemblyTitle}"+ description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
    #endregion
}

// 3. Enable CORS middleware (Must be placed before MapControllers)
app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        var projectName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo
            {
                Title = $"{projectName} API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                //Description = description.IsDeprecated
                //    ? "This API version has been deprecated. Please upgrade to a newer version."
                //    : "HM Admin Application Backend Services API."
            });
        }
    }
}

