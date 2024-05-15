using AspNetCoreRateLimit;
using LogisticsDataCore.Constants;
using LogisticsDataCore.Interfaces.IEmailService;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsEntity.EmailService;
using LogisticsEntity.UnitOfWork;
using LogisticsProject.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Services.AddCORSService();

builder.Services.AddRateLimitService(configuration);

builder.Services.AddDBContextService(configuration);

builder.Services.AddJWTService(configuration);

builder.Services.AddSwaggerService(configuration);

#region DI 

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEmailService, EmailService>();

#endregion

var app = builder.Build();

app.UseExceptionHandler(GlobalConstants.ExceptionEndPointName);
app.UseHsts();

app.UseIpRateLimiting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks(GlobalConstants.HealthCheckEndPointName);

app.Run();
