using Duende.IdentityServer.Models;
using Identity;
using Identity.Extensions;
using Identity.Interface;
using Identity.Mappings;
using Identity.Security;
using Identity.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDbHelper;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Logging Configuration ---
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// --- 2. Configure Services (The old ConfigureServices) ---

// MongoDB Settings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));


builder.Services.AddTransient<IMongoRepository, MongoRepository>();

// Identity Server Configuration
builder.Services.AddOidcStateDataFormatterCache();

var identityBuilder = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // Explicitly disabling automatic key management as per your original code
    options.KeyManagement.Enabled = false;
})
.AddDeveloperSigningCredential()
.AddClients()                 // Your custom extension method
.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
.AddUsers()                   // Your custom extension method
.AddResources();              // Your custom extension method

// Add Controllers with NewtonsoftJson (as requested)
builder.Services.AddControllers().AddNewtonsoftJson();

// Add CORS if needed for your independent websites
builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// --- 3. Configure Pipeline (The old Configure) ---

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware order is critical for Identity Server
app.UseCors();
app.UseIdentityServer(); // This handles OIDC/OAuth2 endpoints
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
