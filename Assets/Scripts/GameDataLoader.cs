using UnityEngine;
using System.IO;

[System.Serializable]
public class GameData
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

public class GameDataLoader : MonoBehaviour
{
    public static GameData LoadGameData()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/doofus_diary.json");
        return JsonUtility.FromJson<GameData>(json);
    }
}
