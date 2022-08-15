using Autofac;
using Autofac.Annotation;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceCollection = new ServiceCollection();

//配置
var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");
IConfiguration configuration = configBuilder.Build();
serviceCollection.AddSingleton<IConfiguration>(configuration);

//日志
serviceCollection.AddLogging(builder =>
{
    builder.AddConfiguration(configuration.GetSection("Logging")).AddConsole();
});

var builder = new ContainerBuilder();

//注入服务器集合
builder.Populate(serviceCollection);

// 注册autofac打标签模式
builder.RegisterModule(new AutofacAnnotationModule().SetAllowCircularDependencies(true));

builder.RegisterBuildCallback(c =>
{
    var logger = c.Resolve<ILogger<Program>>();
    logger.LogInformation("启动成功！");
});

builder.Build();

while (true)
{
    Thread.Sleep(1000);
}