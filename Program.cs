using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShortenUrl.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShortenContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ShortenContext") ?? throw new InvalidOperationException("Connection string 'ShortenContext' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ShortenContext>();
    context.Database.EnsureCreated();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
