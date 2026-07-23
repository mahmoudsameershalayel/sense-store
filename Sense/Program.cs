using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Sense.Application;
using Sense.Application.Abstractions;
using Sense.Application.UseCases.Auth.Commands.RegisterUserCommand;
using Sense.Domain;
using Sense.Domain.DBEntities;
using Sense.Infrastructure;
using Sense.Infrastructure.Extensions;
using Sense.Infrastructure.Helpers;
using Sense.Infrastructure.Hubs;
using Sense.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SenseConnection");
builder.Services.AddDbContext<SenseDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationProfile).Assembly);

builder.Services.AddIdentity<ApplicationUserTbl, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<SenseDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(Program).Assembly,                  // Assembly A (where Program.cs is located)
    typeof(RegisterUserCommand).Assembly
));


builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


            
builder.Services.AddScoped<IImageServices, ImageServices>();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{

    var supportedCulture = new[]
   {
        new CultureInfo("en-US"),
        new CultureInfo("ar"),

    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture: "ar", uiCulture: "ar");
    options.SupportedCultures = supportedCulture;
    options.SupportedUICultures = supportedCulture;

});

builder.Services.AddScoped<IOtpService, OtpServiceDb>();
builder.Services.AddScoped<ITwilioService, TwilioService>();
builder.Services.AddScoped<ISmtpEmailService, SmtpEmailService>();
builder.Services.AddScoped<IProviderRegistrationUploadService, ProviderRegistrationUploadService>();


builder.Services.AddSession();

builder.Services.AddSignalR(); 

builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
name: "MyArea",
pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
