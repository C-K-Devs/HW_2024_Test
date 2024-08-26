using UnityEngine;
using System.Collections;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab;
    private float minTime, maxTime;
    private GameObject currentPulpit, previousPulpit;

    private void Start()
    {
        LoadPulpitData();
        StartCoroutine(SpawnPulpits());
    }

    private void LoadPulpitData()
    {
        GameData gameData = GameDataLoader.LoadGameData();
        minTime = gameData.pulpit_data.min_pulpit_destroy_time;
        maxTime = gameData.pulpit_data.max_pulpit_destroy_time;
    }

    private IEnumerator SpawnPulpits()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0); // Initial spawn position

        while (true)
        {
            // Instantiate a new Pulpit before destroying the previous one
            if (currentPulpit != null)
            {
                previousPulpit = currentPulpit;
                float destroyTime = Random.Range(minTime, maxTime); // Random destroy time between minTime and maxTime
                currentPulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);
                spawnPosition = GenerateAdjacentPosition(currentPulpit.transform.position);

                // Start destroying the previous Pulpit after the new Pulpit is created
                Destroy(previousPulpit, destroyTime); // Destroy previous pulpit after the calculated destroy time
                yield return new WaitForSeconds(destroyTime); // Wait for the destroy time before continuing the loop
            }
            else
            {
                // Initial case: No previous Pulpit, just create the first one
                currentPulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);
                spawnPosition = GenerateAdjacentPosition(currentPulpit.transform.position);
                yield return new WaitForSeconds(Random.Range(minTime, maxTime)); // Wait for a random destroy time
            }
        }
    }

    private Vector3 GenerateAdjacentPosition(Vector3 previousPosition)
    {
        Vector3[] possibleOffsets = new Vector3[]
        {
            new Vector3(9, 0, 0),   // Right
            new Vector3(-9, 0, 0),  // Left
            new Vector3(0, 0, 9),   // Forward
            new Vector3(0, 0, -9)   // Backward
        };

        Vector3 newPosition;
        do
        {
            Vector3 offset = possibleOffsets[Random.Range(0, possibleOffsets.Length)];
            newPosition = previousPosition + offset;
        }
        while (newPosition == previousPosition); // Ensure the new position is different from the previous one

        return newPosition;
    }
}
