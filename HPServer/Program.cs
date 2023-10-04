
using HPServer.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HpSocketServer>(); // 添加 HP-Socket 服务

// Add services to the container.
builder.Services.AddControllersWithViews();

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
// 配置应用程序的终结点，包括路由终结点
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapRazorPages(); // 配置Razor页面路由（如果使用Razor页面）
     // 其他终结点配置
});

app.Run();
