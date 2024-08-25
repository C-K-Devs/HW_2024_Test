using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DoofusMovement : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        LoadPlayerData();
    }

    private void Update()
    {
        MoveDoofus();
    }

    private void LoadPlayerData()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/doofus_diary.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        speed = data.player_data.speed;
    }

    private void MoveDoofus()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, moveZ));
    }
}

[System.Serializable]
public class PlayerData
{
    public PlayerInfo player_data;
}

[System.Serializable]
public class PlayerInfo
{
    public float speed;
}
