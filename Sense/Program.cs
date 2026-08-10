using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.ResponseCompression;
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
using Sense.Performance;
using System.Globalization;
using System.IO.Compression;

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
builder.Services.AddTransient<IHtmlSanitizer>(_ =>
{
    var sanitizer = new HtmlSanitizer();

    sanitizer.AllowedTags.Clear();
    foreach (var tag in new[] { "p", "br", "h2", "h3", "h4", "strong", "b", "em", "i", "ul", "ol", "li", "blockquote", "a" })
    {
        sanitizer.AllowedTags.Add(tag);
    }

    sanitizer.AllowedAttributes.Clear();
    foreach (var attribute in new[] { "href", "target", "rel" })
    {
        sanitizer.AllowedAttributes.Add(attribute);
    }

    sanitizer.AllowedSchemes.Clear();
    foreach (var scheme in new[] { "http", "https", "mailto" })
    {
        sanitizer.AllowedSchemes.Add(scheme);
    }

    return sanitizer;
});
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


builder.Services.AddSession();

builder.Services.AddSignalR(); 

builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<StorefrontDataCache>();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});
builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
    options.Level = CompressionLevel.Fastest);
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    options.Level = CompressionLevel.Fastest);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SenseDbContext>();

    var categoryNames = new[]
    {
        "إلكترونيات",
        "الجوالات والإكسسوارات",
        "الحاسبات والأجهزة اللوحية",
        "الأجهزة المنزلية",
        "أزياء رجالية",
        "أزياء نسائية",
        "أزياء أطفال",
        "أحذية",
        "حقائب ومحافظ",
        "ساعات",
        "مجوهرات وإكسسوارات",
        "الجمال والعناية الشخصية",
        "عطور",
        "الصحة والعافية",
        "مستلزمات الأم والطفل",
        "ألعاب وهوايات",
        "الرياضة واللياقة البدنية",
        "أثاث منزلي",
        "أدوات المطبخ والطعام",
        "ديكور المنزل",
        "الحدائق والأثاث الخارجي",
        "أدوات ومعدات",
        "قطع غيار واكسسوارات السيارات",
        "كتب وقرطاسية",
        "آلات موسيقية وصوتيات",
        "مستلزمات الحيوانات الأليفة",
        "البقالة والمواد الغذائية",
        "مستلزمات المكاتب",
        "ألعاب الفيديو والإلكترونيات الترفيهية",
        "كاميرات وتصوير",
        "سماعات وصوتيات",
        "الساعات الذكية والأجهزة القابلة للارتداء",
        "مستلزمات السفر",
        "الفنون والحرف اليدوية",
        "الإضاءة المنزلية",
        "مستلزمات التنظيف",
        "الهدايا والمناسبات",
        "الطاقة الشمسية والأجهزة الكهربائية",
        "مستلزمات المناسبات والحفلات",
        "منتجات صحية وعضوية"
    };

    var existingNames = dbContext.CategoryTbls
        .Select(c => c.Name)
        .ToHashSet(StringComparer.OrdinalIgnoreCase);

    var newCategories = categoryNames
        .Where(name => !existingNames.Contains(name))
        .Select(name => new CategoryTbl { Name = name, CreatedAt = DateTime.UtcNow })
        .ToList();

    if (newCategories.Count > 0)
    {
        dbContext.CategoryTbls.AddRange(newCategories);
        dbContext.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseResponseCompression();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        if (context.Context.Request.Query.ContainsKey("v"))
        {
            context.Context.Response.Headers.CacheControl = "public,max-age=31536000,immutable";
        }
    }
});

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
