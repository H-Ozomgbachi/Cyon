using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using System.Reflection;
using FluentValidation;
using Cyon.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Cyon.Infrastructure.Mappers;
using Cyon.Domain.Services;
using Cyon.Application.Services;
using Cyon.Api.Middlewares;
using Cyon.Domain;
using Cyon.Infrastructure;
using Serilog;
using Cyon.Infrastructure.Extension;
using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });
builder.Services.AddEndpointsApiExplorer();

// Add services to pipeline
builder.Services.AddMvc();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load));
builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(ChaplainMappingProfile).Assembly);
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddOptions<AppSettings>().Bind(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IChaplainService, ChaplainService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IMinutesService, MinutesService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddScoped<IAttendanceTypeService, AttendanceTypeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IOccupationService, OccupationService>();
builder.Services.AddScoped<IAttendanceRegisterService, AttendanceRegisterService>();
builder.Services.AddScoped<IApologyService, ApologyService>();
builder.Services.AddScoped<IAccountManagementService, AccountManagementService>();
builder.Services.AddScoped<IUserFinanceService, UserFinanceService>();
builder.Services.AddScoped<IOrganisationFinanceService, OrganisationFinanceService>();
builder.Services.AddScoped<IYearProgrammeService, YearProgrammeService>();
builder.Services.AddScoped<IUpcomingEventService, UpcomingEventService>();
builder.Services.AddScoped<IDecisionService, DecisionService>();
builder.Services.AddScoped<IDecisionResponseService, DecisionResponseService>();
builder.Services.AddScoped<INotificationsService, NotificationsService>();

builder.Services.AddScoped<IUtilityRepository, UtilityRepository>();

//string client = builder.Configuration.GetSection("ClientHost").Value;

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
       builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
      );
});

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureClientFactory(builder.Configuration);
builder.Services.ConfigureEmailService(builder.Configuration);

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Cyon Shomolu AP1 v1");
});

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

// Use Exception Middleware
app.UseMiddleware<ExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
