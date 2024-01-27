using GrpcServer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace TestProject1.Dir3
{
    [Collection("Sequential")]
    public class UnitTest4 : TestFixture, IDisposable
    {
        public UnitTest4(ITestOutputHelper testOutputHelper): base(testOutputHelper)
        {
        }

        [Fact]
        public void Test1()
        {
            Print("UnitTest4.Test1");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Assert.Equal("1,", reply2.Games);
            Print($"UnitTest4.Test1: {reply2.Games}");

            var reply3 = client.AddUser(new AddUserRequest
            {
                Name = "test1"
            });
            Assert.True(reply3.IsSuccessful);

            var reply4 = client.GetUsersCount(new GetUsersCountRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test1: {reply4.Count}");
            Assert.Equal(1, reply4.Count);

            var reply5 = client.GetUsers(new GetUsersRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test1: {reply5.Users}");
            Assert.Equal("test1", reply5.Users);
        }

        [Fact]
        public void Test2()
        {
            Print("UnitTest4.Test2");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest4.Test2: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

            var reply3 = client.AddUser(new AddUserRequest
            {
                Name = "test2"
            });
            Assert.True(reply3.IsSuccessful);

            var reply4 = client.GetUsersCount(new GetUsersCountRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test2: {reply4.Count}");
            Assert.Equal(1, reply4.Count);

            var reply5 = client.GetUsers(new GetUsersRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test2: {reply5.Users}");
            Assert.Equal("test2", reply5.Users);
        }
        [Fact]
        public void Test4()
        {
            Print("UnitTest4.Test4");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest4.Test4: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

            var reply3 = client.AddUser(new AddUserRequest
            {
                Name = "test4"
            });
            Assert.True(reply3.IsSuccessful);

            var reply4 = client.GetUsersCount(new GetUsersCountRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test4: {reply4.Count}");
            Assert.Equal(1, reply4.Count);

            var reply5 = client.GetUsers(new GetUsersRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test4: {reply5.Users}");
            Assert.Equal("test4", reply5.Users);
        }
        [Fact]
        public void Test3()
        {
            Print("UnitTest4.Test3");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest4.Test3: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

            var reply3 = client.AddUser(new AddUserRequest
            {
                Name = "test3"
            });
            Assert.True(reply3.IsSuccessful);

            var reply4 = client.GetUsersCount(new GetUsersCountRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test3: {reply4.Count}");
            Assert.Equal(1, reply4.Count);

            var reply5 = client.GetUsers(new GetUsersRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test3: {reply5.Users}");
            Assert.Equal("test3", reply5.Users);
        }
        [Fact]
        public void Test5()
        {
            Print("UnitTest4.Test5");
            var client = new Game.GameClient(_channel);
            var reply = client.AddGame(new AddRequest());
            Assert.True(reply.IsSuccessful);
            Task.Delay(2000).Wait();
            var reply2 = client.GetGames(new GetGamesRequest());
            Print($"UnitTest4.Test5: {reply2.Games}");
            Assert.Equal("1,", reply2.Games);

            var reply3 = client.AddUser(new AddUserRequest
            {
                Name = "test5"
            });
            Assert.True(reply3.IsSuccessful);

            var reply4 = client.GetUsersCount(new GetUsersCountRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test5: {reply4.Count}");
            Assert.Equal(1, reply4.Count);

            var reply5 = client.GetUsers(new GetUsersRequest());
            _testOutputHelper.WriteLine($"UnitTest4.Test5: {reply5.Users}");
            Assert.Equal("test5", reply5.Users);

        }
    }
}