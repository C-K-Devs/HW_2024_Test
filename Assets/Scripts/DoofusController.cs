using UnityEngine;

public class DoofusController : MonoBehaviour
{
    public float speed;
    private Collider currentPulpit; // Track the currently active Pulpit

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PulpitTrigger"))
        {
            if (currentPulpit == null || currentPulpit != other)
            {
                ScoreManager.instance.IncreaseScore();
                currentPulpit = other; // Update the currently active Pulpit
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PulpitTrigger"))
        {
            // Clear the currentPulpit only if exiting the currently active Pulpit
            if (currentPulpit == other)
            {
                currentPulpit = null;
            }
        }
    }
}
