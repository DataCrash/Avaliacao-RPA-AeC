using RPA.AeC.API.Configurations;
using RPA.AeC.API.Infra.Persistence.MongoDB.DBContext;



var builder = WebApplication.CreateBuilder(args);

MongoDBContext.ConnectionString = builder.Configuration.GetSection("MongoDBConnection:ConnectionString").Value;
MongoDBContext.DatabaseName = builder.Configuration.GetSection("MongoDBConnection:Database").Value;
MongoDBContext.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("MongoDBConnection:IsSSL").Value);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDependenceInjections();



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
