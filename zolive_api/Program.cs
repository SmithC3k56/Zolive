using Microsoft.AspNetCore.Mvc.Formatters;
using zolive_api;
using zolive_api.Services.Buyer;
using zolive_api.Services.Common;
using zolive_api.Services.Dynamic;
using zolive_api.Services.Home;
using zolive_api.Services.Interface;
using zolive_api.Services.Linkmic;
using zolive_api.Services.Live;
using zolive_api.Services.Livemanage;
using zolive_api.Services.Login;
using zolive_api.Services.Message;
using zolive_api.Services.Paidprogram;
using zolive_api.Services.Red;
using zolive_api.Services.User;
using zolive_api.Services.Video;
using zolive_db.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IDynamicSerivce, DynamicSerivce>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPaidprogram, PaidprogramService>();
builder.Services.AddScoped<ILivemanage, LivemanageService>();
builder.Services.AddScoped<ILiveService, LiveService>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<ILinkmicService, LinkmicService>();
builder.Services.AddScoped<IRedService, RedService>();
builder.Services.AddDbContext<newliveContext>(ServiceLifetime.Transient);
builder.Services.AddMvc(options =>
{
    options.AllowEmptyInputInBodyModelBinding = true;
    foreach (var formatter in options.InputFormatters)
    {
        if (formatter.GetType() == typeof(SystemTextJsonInputFormatter))

            ((SystemTextJsonInputFormatter)formatter).SupportedMediaTypes.Add(
            Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("*/*"));
    }
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

//builder.Services.AddTransient<newliveContext>();
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
