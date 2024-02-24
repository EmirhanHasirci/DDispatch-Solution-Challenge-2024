
using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Extensions;
using DisasterDispatch.Core.Repositories;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Core.UnitOfWork;
using DisasterDispatch.Repository.DbContexts;
using DisasterDispatch.Repository.Repositories;
using DisasterDispatch.Repository.UnitOfWork;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace DisasterDispatch.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
            #region dependency injection implementetions
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITitleRepository, TitleRepository>();
            builder.Services.AddScoped<ITitleTypeRepository, TitleTypeRepository>();
            builder.Services.AddScoped<ITitleTypeService, TitleTypeService>();
            builder.Services.AddScoped<ITitleService, TitleService>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<ISkillCategoryRepository, SkillCategoryRepository>();
            builder.Services.AddScoped<ISkillCategoryService, SkillCategoryService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();
            builder.Services.AddScoped<IDisasterCategoryRepository, DisasterCategoryRepository>();
            builder.Services.AddScoped<IDisasterCategoryService, DisasterCategoryService>();
            builder.Services.AddScoped<IDisasterOperationRepository, DisasterOperationRepository>();
            builder.Services.AddScoped<IDisasterOperationService, DisasterOperationService>();
            builder.Services.AddScoped<IEmergencyReportRepository, EmergencyReportRepository>();
            builder.Services.AddScoped<IEmergencyReportService, EmergencyReportService>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
            builder.Services.AddScoped<ICertificateService, CertificateService>();
            builder.Services.AddScoped<ICustomOperationRepository, CustomOperationRepository>();
            builder.Services.AddScoped<ICustomOperationService, CustomOperationService>();
            builder.Services.AddScoped<IOperationEmployeeRepository, OperationEmployeeRepository>();
            builder.Services.AddScoped<IOperationEmployeeService, OperationEmployeeService>();
            builder.Services.AddScoped<INeederRepository, NeederRepository>();
            builder.Services.AddScoped<INeederService, NeederService>();
            builder.Services.AddScoped<IRoleService, RoleService>();



            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            builder.Services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, ApplicationUserClaimsPrincipalFactory>();
            #endregion
            //Currently disabled
            builder.Services.AddIdentity<AppUser, AppRole>(opts =>
            {

                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoöpqrsþtuvwxyzABCÇDEFGÐHIÝJKLMNOÖPQRSÞTUVWXYZ0123456789-._";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();

            //builder.Services.AddAuthorization();
            //builder.Services.AddAuthentication().AddCookie();           
            /*
            builder.Services.ConfigureApplicationCookie(opts =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "DispatchCookie";
                cookieBuilder.SameSite = SameSiteMode.Lax;
                opts.LoginPath = new PathString("/Home/Login");
                opts.LogoutPath = new PathString("/Member/LogOut");
                opts.Cookie = cookieBuilder;
                opts.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                opts.SlidingExpiration = true;

            });
            */

            builder.Services.Configure<SecurityStampValidatorOptions>(opts =>
            {
                opts.ValidationInterval = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
            builder.Services.AddCors(options => options.AddDefaultPolicy(pol =>

    pol.AllowCredentials().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(x => true)

));

            builder.Services.Configure<DataProtectionTokenProviderOptions>(opts =>
            {
                opts.TokenLifespan = TimeSpan.FromMinutes(20);
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}