using Xunit.Abstractions;

namespace GrpcServer
{
    public class Manager:IDisposable
    {
        private readonly List<int> _games = new List<int>();

        public Manager()
        {
            Console.WriteLine("Manager.Manager");
        }
        public List<int> GetGames()
        {
            return _games;
        }

        private static int _gameId = 0;
        public void AddGame()
        {
            _gameId++;
            _games.Add(_gameId);
        }

        public override string ToString()
        {
            string result = "";
            foreach (int game in _games)
            {
                result += game + ",";
            }
            return result;
        }

        public void Dispose()
        {
            // TODO release managed resources here
            _gameId = 0;
            _games.Clear();
        }
    }
}
