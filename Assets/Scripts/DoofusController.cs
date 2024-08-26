using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoofusController : MonoBehaviour
{
    private float speed;

    void Start()
    {
        GameData gameData = GameDataLoader.LoadGameData();
        speed = gameData.player_data.speed;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
