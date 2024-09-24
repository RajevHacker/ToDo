using toDo.Interfaces;
using toDo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
// builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDapperDBConnectInterface, DapperDBConnectService>();
builder.Services.AddTransient<INewTask, insertNewTaskService>();
builder.Services.AddTransient<ICloseTask, closeTaskService>();
builder.Services.AddTransient<IOpenTasks, openTaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
