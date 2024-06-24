using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using NICRegister.Automaping;
using NICRegister.DbContexts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//di
//DI DB Context
builder.Services.AddDbContext<NICDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NICConn")));
builder.Services.AddScoped<NICDBContext>();
builder.Services.AddAutoMapper(typeof(Automapping));

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100MB, adjust as needed
});


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
