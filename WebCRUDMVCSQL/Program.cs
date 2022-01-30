using Microsoft.EntityFrameworkCore;
using WebCRUDMVCSQL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer
    //("Data Source=DESKTOP-NFKMOF8\\SQLBIA;Initial Catalog=CRUD_MVC_SQL_CANAL_DEV;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));
    //("Data Source=DESKTOP-NFKMOF8\\SQLBIA;Initial Catalog=CRUD_MVC_SQL_CANAL_DEV;Integrated Security=True"));
    ("Data Source=DESKTOP-NFKMOF8\\SQLBIA;Initial Catalog=CRUD_MVC_SQL_CANAL_DEV;User ID=sa;Password=1234"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
