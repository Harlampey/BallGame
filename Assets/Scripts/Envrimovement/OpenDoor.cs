using UnityEngine;
using DG.Tweening;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private float _openingDuration;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallMovement>())
        {
            Open();
        }
    }

    private void Open()
    {
        _door.DORotate(_targetRotation, _openingDuration);
    }
}
