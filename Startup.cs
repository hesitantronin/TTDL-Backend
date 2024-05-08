public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IUserservice, UserService>();

    services.AddControllers();
}