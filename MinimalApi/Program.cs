var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var app = builder.Build();

app.Run();