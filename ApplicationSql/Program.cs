using ApplicationSql.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.PlayerRepo;
using TaskDataBaseSql.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\TaskDataBaseSql\TaskDataBaseSql\Data\DataBase.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepo>();
    services.AddScoped<ClientRepo>();
    services.AddScoped<ContactRepo>();
    services.AddScoped<RoleRepo>();
    services.AddScoped<UserRepo>();

    services.AddScoped<AddressService>();
    services.AddScoped<ClientService>();
    services.AddScoped<ContactService>();
    services.AddScoped<RoleService>();
    services.AddScoped<UserService>();

    services.AddSingleton<PlayerMenuUI>();


}).Build();

var player = builder.Services.GetRequiredService<PlayerMenuUI>();
//player.CreatePlayer();
//player.GetPlayer();
//player.UpdatePlayer();
player.DeletePlayer();