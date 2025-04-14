using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // Anade los Views contenidos en carpetas guardadas en la carpeta Account.
    options.ViewLocationFormats.Add("/Views/Account/{1}/{0}.cshtml");
}
);

builder.Services.AddSession();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    // Anade los .chtml.css anidados a las Views que lo contengan.
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Views")),
    RequestPath = "/Views"
});

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
