using UnityEngine;

public class AICollisionDetection : MonoBehaviour
{
    public bool collisionDetected = false;
    public bool won = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            collisionDetected = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
            won = true;
    }
}
