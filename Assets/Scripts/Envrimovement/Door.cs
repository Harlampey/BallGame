using UnityEngine;
public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallMovement>())
        {
            Level.ShowVictoryPanel();
        }
    }
}
