using Enterprise.Manager.Contracts.ServiceLibrary.Contracts;
using Enterprise.Manager.Contracts.ServiceLibrary.Implementations;
using Enterprise.Manager.DB.Infrastructure.Repositories;
using Enterprise.Manager.Library.Contracts;
using Enterprise.Manager.Library.Implementations;
using Enterprise.Manager.Library.InfraestructureContracts.UnitOfWork;
using Enterprise.Manager.ServiceLibrary.Mapper.ProfileMapper;
using Enterprise.Manager.WebApi.Authentication;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/CompanyManagerWebApilog.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();
// Add services to the container.
// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddTransient<IEnterpriseApplicationService, EnterpriseApplicationService>();
builder.Services.AddTransient<IEnterpriseDomainService, EnterpriseDomainService>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Api Key required",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "X-Api-Key",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();
app.UseCors("AllowLocalhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
