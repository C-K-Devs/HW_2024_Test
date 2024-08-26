using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public DoofusController doofusController;
    public PulpitManager pulpitManager;

    void Start()
    {
        // Load the JSON file from the Resources folder
        TextAsset jsonTextAsset = Resources.Load<TextAsset>("doofus_diary");

        if (jsonTextAsset != null)
        {
            GameData data = JsonUtility.FromJson<GameData>(jsonTextAsset.text);

            // Set values based on JSON data
            doofusController.speed = data.player_data.speed;
            pulpitManager.minDestroyTime = data.pulpit_data.min_pulpit_destroy_time;
            pulpitManager.maxDestroyTime = data.pulpit_data.max_pulpit_destroy_time;
            pulpitManager.spawnTime = data.pulpit_data.pulpit_spawn_time;
        }

        else
        {
            Debug.LogError("JSON file not found in Resources folder.");
        }
    }
}

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
