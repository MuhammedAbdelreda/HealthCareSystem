using System.Text;
using HealthCareSystem.API.Helper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices;
using HealthCareSystem.Core.IServices.Appointment;
using HealthCareSystem.Core.IServices.Department;
using HealthCareSystem.Core.IServices.Doctor;
using HealthCareSystem.Core.IServices.Hospital;
using HealthCareSystem.Core.IServices.MedicalRecord;
using HealthCareSystem.Core.IServices.Prescription;
using HealthCareSystem.Core.IServices.Staff;
using HealthCareSystem.Core.Models;
using HealthCareSystem.Core.Models.Identity;
using HealthCareSystem.Infrastructure;
using HealthCareSystem.Infrastructure.GenericRepo;
using HealthCareSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


#region ConnectionString
builder.Services.AddDbContext<Context>(opt=>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    // Add a security definition for Bearer token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter token in the format **'Bearer {your token}'**",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    // Require the Bearer token for all operations
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
#endregion

#region Mapping
builder.Services.AddAutoMapper(typeof(Mapping));
#endregion

#region IRepo
builder.Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
#endregion

#region IService
builder.Services.AddScoped<IPatientService,PatientService>();
 builder.Services.AddScoped<IAppointmentService,AppointmentService>();
 builder.Services.AddScoped<IDepartmentService,DepartmentService>();
 builder.Services.AddScoped<IDoctorService,DoctorService>();
 builder.Services.AddScoped<IHospitalService,HospitalService>();
 builder.Services.AddScoped<IMedicalRecordService,MedicalRecordService>();
 builder.Services.AddScoped<IPrescriptionService,PrescriptionService>();
 builder.Services.AddScoped<IStaffService,StaffService>();
 builder.Services.AddScoped<IAdminService,AdminService>();
#endregion

#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

