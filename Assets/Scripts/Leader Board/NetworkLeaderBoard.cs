using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace LeaderBoard
{
    public class NetworkLeaderBoard : MonoBehaviour, ILeaderBoard
    {
        private const string leaderboardUrl = "https://www.my-server.com/api/leaderboard";

        public Task<IReadOnlyList<LeaderBoardData>> GetLeaderBoardAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task NoteAsync(string name, float time, int attempts)
        {
            var leaderboardEntry = new LeaderBoardData
            {
                Name = name,
                Time = time,
                Attempts = attempts
            };

            string jsonData = JsonUtility.ToJson(leaderboardEntry);

            using (UnityWebRequest www = UnityWebRequest.Post(leaderboardUrl, jsonData))
            {
                www.SetRequestHeader("Content-Type", "application/json");
                
                //yield return www.SendWebRequest();
                var request = www.SendWebRequest();
                while (!request.isDone)
                {
                    await Task.Yield();
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Error: " + www.error);
                }
                else
                {
                    Debug.Log("Form upload complete: " + www.downloadHandler.text);
                }
            }
        }
    }
}