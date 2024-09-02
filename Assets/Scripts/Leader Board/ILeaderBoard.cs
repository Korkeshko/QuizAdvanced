using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaderBoard
{
    public interface ILeaderBoard
    {
        public Task NoteAsync(string name, float time);
        public Task<IReadOnlyList<LeaderBoardData>> GetLeaderBoardAsync();
    }

    public class LeaderBoardData
    {
        public string Name { get; set; }
        public float Time { get; set; }
    }
}