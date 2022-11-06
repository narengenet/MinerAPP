using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinerAPP.Application;
using MinerAPP.Application.Interfaces;
using MinerAPP.Infrastructure;
using MinerAPP.Infrastructure.Contexts;
using MinerAPP.Infrastructure.Repositories;
using MinerAPP.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


//builder.Services.AddScoped<IUsersRepository, UserRepository>();
//builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddRazorPages();
builder.Services.AddIoCService();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddApplicationLayer();

builder.Services.AddRazorPages();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));





var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseAuthorization();
app.MapRazorPages();

app.MapGet("/", () => "Hello World!");

app.Run();
