using System.Collections;
using UnityEngine;

public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab;
    public float minDestroyTime;
    public float maxDestroyTime;
    public float spawnTime;

    private GameObject currentPulpit;
    private GameObject previousPulpit;

    void Start()
    {
        // Start by spawning the first pulpit
        currentPulpit = Instantiate(pulpitPrefab, Vector3.zero, Quaternion.identity);

        // Start the pulpit spawning cycle
        StartCoroutine(SpawnPulpits());
    }

    IEnumerator SpawnPulpits()
    {
        while (true)
        {
            // Wait until it's time to spawn the next pulpit
            yield return new WaitForSeconds(spawnTime);

            // Ensure the previous pulpit is destroyed before spawning a new one
            if (previousPulpit != null)
            {
                Destroy(previousPulpit);
            }

            // Calculate an adjacent position for the new pulpit
            Vector3 newPosition = GetAdjacentPosition(currentPulpit.transform.position);

            // Spawn the new pulpit and update references
            previousPulpit = currentPulpit;
            currentPulpit = Instantiate(pulpitPrefab, newPosition, Quaternion.identity);

            // Start the destruction timer for the new pulpit
            StartCoroutine(DestroyPulpitAfterDelay(previousPulpit));
        }
    }

    Vector3 GetAdjacentPosition(Vector3 currentPos)
    {
        // Randomly choose an adjacent direction (left, right, forward, or backward)
        Vector3[] directions = new Vector3[]
        {
            Vector3.left * pulpitPrefab.transform.localScale.x,
            Vector3.right * pulpitPrefab.transform.localScale.x,
            Vector3.forward * pulpitPrefab.transform.localScale.z,
            Vector3.back * pulpitPrefab.transform.localScale.z
        };

        // Pick a random direction
        Vector3 chosenDirection = directions[Random.Range(0, directions.Length)];

        // Return the new adjacent position
        return currentPos + chosenDirection;
    }

    IEnumerator DestroyPulpitAfterDelay(GameObject pulpit)
    {
        // Wait for a random time between minDestroyTime and maxDestroyTime
        float destroyDelay = Random.Range(minDestroyTime, maxDestroyTime);
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the pulpit
        Destroy(pulpit);
    }
}
