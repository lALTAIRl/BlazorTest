using BlazorTest.Orders.Persistence;
using Microsoft.EntityFrameworkCore;
using NetMQ;
using NetMQ.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<BlazorTestOrdersDbContext>();
//    db.Database.Migrate();
//}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

//TODO:move to separate service and handle request
using (var server = new ResponseSocket())
{
    server.Bind("tcp://blazortest.orders:5555");
    while (true)
    {
        var message = server.ReceiveFrameString();
        Console.WriteLine("Received {0}", message);
        //TODO: handle request
        Console.WriteLine("Sending Success");
        server.SendFrame("Success");
    }
}

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
