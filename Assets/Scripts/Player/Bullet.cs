using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed, _radiusMultipler, _maxRadius = 4;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        float radius = Mathf.Clamp(transform.localScale.x * transform.localScale.x * _radiusMultipler, 0, _maxRadius);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out IObstacle obstacle))
            {
                obstacle.Infect();
            }
        }
        
        Destroy(gameObject);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
