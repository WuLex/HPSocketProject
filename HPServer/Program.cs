
using HPServer.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HpSocketServer>(); // ���� HP-Socket ����

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
// ����Ӧ�ó�����ս�㣬����·���ս��
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapRazorPages(); // ����Razorҳ��·�ɣ����ʹ��Razorҳ�棩
     // �����ս������
});

app.Run();