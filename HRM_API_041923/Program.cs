using System.Net;
using HRM_API_041923.Utility;
using HRM_API_ApplicationCore.Contracts.Repositories;
using HRM_API_ApplicationCore.Contracts.Services;
using HRM_API_Infrastructure.Data;
using HRM_API_Infrastructure.Repositories;
using HRM_API_Infrastructure.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RHRM_API_ApplicationCore.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddLogging();

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();
builder.Services.AddScoped<IJobRequirementService, JobRequirementService>();

builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();

builder.Services.AddDbContext<RecruitingDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbContext"));
});

/*builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddDbContext<WeatherDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    option.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDbContext"));
});*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // use for api endpoint
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // EnvironmentName: Development, Production, Staging
{
    app.UseSwagger(); // Use: use Middleware
    app.UseSwaggerUI();

     app.UseMiddleware<MiddlewareExtension>();
    // Global handling -> a pre-defined exception handler
    /*app.UseExceptionHandler(options => {
        options.Run(async context => {
            //context.Response.StatusCode = 500;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
                // Log exception here, another way to log exception: use serilog
                await context.Response.WriteAsync("An unexpected Error has occured.\n" + ex.Error.Message);
            }
        });
    });*/
}

app.UseAuthorization();

app.MapControllers(); // Map the address of the controller
//app.UseEndpoints();
app.Run();

