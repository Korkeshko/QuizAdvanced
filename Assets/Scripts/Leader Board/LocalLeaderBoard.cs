using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace LeaderBoard
{
    public class LocalLeaderBoard : MonoBehaviour, ILeaderBoard
    {
        public Task<IReadOnlyList<LeaderBoardData>> GetLeaderBoardAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task NoteAsync(string name, float time)
        {
            await Task.Run(() =>
            {
                Debug.Log($"{name} {time}");
            });
        }
    }
}

