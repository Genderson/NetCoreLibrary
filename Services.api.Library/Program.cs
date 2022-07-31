using Services.api.Library.Core;
using Services.api.Library.Core.ContextMongoDB;
using Services.api.Library.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoSettings>(
        options => {
            options.ConnectionString = builder.Configuration.GetSection("MongoDb:ConnectionString").Value;
            options.Database = builder.Configuration.GetSection("MongoDb:Database").Value;
        });

builder.Services.AddSingleton<MongoSettings>();
builder.Services.AddTransient<IAutorContext, AutorContext>();
builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
