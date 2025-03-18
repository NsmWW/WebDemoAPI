
using Microsoft.EntityFrameworkCore;
using WebDemoAPI.Infastructure.DataContext;
using WebDemoAPI.Application.ConstanConnection;
using WebDemoAPI.Application.InterfaceService;
using WebDemoAPI.Application.ImplemenService;
using WebDemoAPI.Domain.InterfaceREpository;
using WebDemoAPI.Domain;
using WebDemoAPI.Infastructure.ImplementRepository;
using WebDemoAPI.Application.Payload.Mapper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<ApplicationDBcontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString(Contans.AppSettingKey.DEFAULT_CONNECTION)));

builder.Services.AddScoped<IDbcontext, ApplicationDBcontext>();
builder.Services.AddScoped<IAservice, UserServices>();
builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<UserDataConverter>();
builder.Services.AddScoped<IUserReposytory, UserRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
