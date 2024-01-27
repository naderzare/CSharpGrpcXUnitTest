using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services
{
    public class GameService : Game.GameBase
    {
        private readonly ILogger<GameService> _logger;
        private readonly Manager _manager;
        private readonly MyDbContext _context;

        public GameService(ILogger<GameService> logger, Manager manager, MyDbContext context)
        {
            _logger = logger;
            _manager = manager;
            _context = context;
        }

        public override Task<AddResponse> AddGame(AddRequest request, ServerCallContext context)
        {
            _manager.AddGame();
            return Task.FromResult(new AddResponse
            {
                IsSuccessful = true
            });
        }

        public override Task<GetGamesResponse> GetGames(GetGamesRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetGamesResponse
            {
                Games = _manager.ToString()
            });
        }

        public override Task<AddUserResponse> AddUser(AddUserRequest request, ServerCallContext context)
        {
            _context.Users.Add(new User
            {
                Name = request.Name
            });
            _context.SaveChanges();
            return Task.FromResult(new AddUserResponse
            {
                IsSuccessful = true
            });
        }

        public override Task<GetUsersCountResponse> GetUsersCount(GetUsersCountRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetUsersCountResponse
            {
                Count = _context.Users.Count()
            });
        }

        public override Task<GetUsersResponse> GetUsers(GetUsersRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetUsersResponse
            {
                Users = string.Join(",", _context.Users.Select(x => x.Name))
            });
        }
    }
}
