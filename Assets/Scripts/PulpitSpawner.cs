using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab;
    private float minTime, maxTime, spawnTime;
    private GameObject currentPulpit, nextPulpit;

    private void Start()
    {
        LoadPulpitData();
        StartCoroutine(SpawnPulpits());
    }

    private void LoadPulpitData()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/doofus_diary.json");
        PulpitData data = JsonUtility.FromJson<PulpitData>(json);
        minTime = data.pulpit_data.min_pulpit_destroy_time;
        maxTime = data.pulpit_data.max_pulpit_destroy_time;
        spawnTime = data.pulpit_data.pulpit_spawn_time;
    }

    private IEnumerator SpawnPulpits()
    {
        while (true)
        {
            if (currentPulpit != null)
            {
                Destroy(currentPulpit, Random.Range(minTime, maxTime));
            }

            currentPulpit = Instantiate(pulpitPrefab, GeneratePosition(), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private Vector3 GeneratePosition()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-9, 9),
            0,
            Random.Range(-9, 9)
        );

        return randomPos;
    }
}

[System.Serializable]
public class PulpitData
{
    public PulpitInfo pulpit_data;
}

[System.Serializable]
public class PulpitInfo
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}
