using MTRPZ4;
using MTRPZ4.Repository;
using MTRPZ4.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IDeviceRepository, DeviceRepository>();
builder.Services.AddSingleton<IPriceRepository, PriceRepository>();
builder.Services.AddSingleton<IButtonColorRepository, ButtonColorRepository>();
builder.Services.AddSingleton<IDataStorage, DataStorage>();
builder.Services.AddControllers();

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