using GrpcServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace TestProject1.Dir1
{
    [Collection("Sequential")]
    public class UnitTest1 : IDisposable
    {
        private readonly WebApplicationFactory<Program> _appFactory;
        private readonly GrpcChannel _channel;
        private readonly ITestOutputHelper _testOutputHelper;
        private MyDbContext _dbContext;
        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            Print("UnitTest1.UnitTest1");
            _appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddDbContext<MyDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("UnitTest1");
                    });
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

        [Fact]
        public void Test1()
        {
            Print("UnitTest1.Test1");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Assert.Equal("1,", reply2.Games);
            Print($"UnitTest1.Test1: {reply2.Games}");
        }

        [Fact]
        public void Test2()
        {
            Print("UnitTest1.Test2");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest1.Test2: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

        }
        [Fact]
        public void Test4()
        {
            Print("UnitTest1.Test4");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest1.Test4: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

        }
        [Fact]
        public void Test3()
        {
            Print("UnitTest1.Test3");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest1.Test3: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

        }
        [Fact]
        public void Test5()
        {
            Print("UnitTest1.Test5");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest1.Test5: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

        }
        public void Dispose()
        {
            Print("UnitTest1.Dispose");
            _appFactory.Dispose();
            _channel.Dispose();
        }

        public void Print(string message)
        {
            //message = time + message;
            message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + message;
            _testOutputHelper.WriteLine(message);
        }
    }
}