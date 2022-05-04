using library.Data;
using library.Models;
using library.Repository;
using library.Repository.Interfaces;
using library.Service;
using library.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BillService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped <PublisherService>();

// Add identity
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<IdentityAppContext>();

builder.Services.AddDbContext<IdentityAppContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
});

//configuring connection string for db context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
