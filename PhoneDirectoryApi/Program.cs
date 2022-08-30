


using Core.Settings;
using Data.Repository;
using PhoneDirectoryApi.Core.Repository.Abstract;
using Services.Concrets;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped( typeof(IRepository<>),typeof(MongoRepositoryBase<>));
//builder.Services.AddScoped(typeof(IRepository<>),typeof(MongoRepositoryBase<>));
builder.Services.Configure<MongoSettings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("MongoConnections:ConnectionString").Value;
    options.Database = builder.Configuration.GetSection("MongoConnections:Database").Value;
});
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
