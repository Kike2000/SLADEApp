using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CongresoServer.Data;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("SQLServer")));
//builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseNpgsql("User ID=zmxpfhzrpadcri;Password=f455f5337e1fbf39413d1ec463868b28bb81a7a0b5e75da891d6f9051714ab88;Host=ec2-52-20-166-21.compute-1.amazonaws.com; Port=5432;Database=d7m8dh5iuchsq5;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
     .AddDefaultTokenProviders(); ;
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddMudServices();
//builder.Services.AddSignalR().AddAzureSignalR(options =>
//{
//    options.ServerStickyMode = Microsoft.Azure.SignalR.ServerStickyMode.Required;
//    options.ConnectionString = "Endpoint=https://congresoslade.service.signalr.net;AccessKey=P+UmbkbmiN+Y7kwz5qtWtQNTLVU75ulL3OCQzYX4qU4=;Version=1.0;";
//});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});
app.Run();