using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _radius, _delay;

    [Space]
    [SerializeField] private float _jumpLength;
    [SerializeField] private float _jumpForce, _jumpDuration = 0.5f;
    private WaitForSeconds _waitDelay;

    public bool IsMoving;

    private void Start()
    {
        _waitDelay = new WaitForSeconds(_delay);
        StartCoroutine(PathChecking());
    }
    private IEnumerator PathChecking()
    {
        IsMoving = false;
        while (true)
        {
            if (!IsAnyObstacleInRadius())
            {
                IsMoving = true;
                Jump();
                break;
            }

            yield return _waitDelay;
        }
    }

    private void Jump()
    {
        transform.DOJump(transform.position + Vector3.forward * _jumpLength, _jumpForce, 1, _jumpDuration).OnComplete(() => StartCoroutine(PathChecking()));
    }

    private bool IsAnyObstacleInRadius()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, transform.localScale.x * _radius);

        foreach (Collider hitCollider in hitColliders)
            if (hitCollider.GetComponent(typeof(IObstacle)))
                return true;

        return false;
    }
}
