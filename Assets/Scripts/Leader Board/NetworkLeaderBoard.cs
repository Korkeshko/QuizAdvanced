
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace LeaderBoard
{
    public class NetworkLeaderBoard : MonoBehaviour, ILeaderBoard
    {
        public Task<IReadOnlyList<LeaderBoardData>> GetLeaderBoardAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task NoteAsync(string name, float time)
        {
            throw new System.NotImplementedException();
        }
    }
}