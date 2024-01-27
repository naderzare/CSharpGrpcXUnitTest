using GrpcServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace TestProject1.Dir3
{
    public class TestFixture : IDisposable
    {
        private readonly WebApplicationFactory<Program> _appFactory;
        public readonly GrpcChannel _channel;
        public readonly ITestOutputHelper _testOutputHelper;
        private MyDbContext _dbContext;
        public TestFixture(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            Print("UnitTest1.UnitTest1");
            _appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddDbContext<MyDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("UnitTest2");
                    });
                    //services.AddSingleton<Manager>(new Manager(_testOutputHelper));
                });
            });

            var serverHandler = _appFactory.Server.CreateHandler();

            _channel = GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
            {
                HttpClient = new HttpClient(serverHandler)
            });

            var scope = _appFactory.Services.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            _dbContext.Database.EnsureCreated();
            //delete db if exists
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.Migrate();
        }
        public void Dispose()
        {
            Print("UnitTest1.Dispose");
            _appFactory.Dispose();
            _channel.Dispose();
            _dbContext.Dispose();
        }

        public void Print(string message)
        {
            //message = time + message;
            message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + message;
            _testOutputHelper.WriteLine(message);
        }
    }
}