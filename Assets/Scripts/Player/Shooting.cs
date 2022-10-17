using UnityEngine;

[RequireComponent(typeof(BallMesh))]
[RequireComponent(typeof(Shooting))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _minBulletSize, _maxBulletSize, _increaseMultipler, _bulletSizeMultipler = 2f;

    [Space]
    [SerializeField] private float _minBallSize = 0.7f;

    private BallMesh _ballMesh;
    private BallMovement _ballMovement;
    private float _bulletSize;

    private void Start()
    {
        _ballMesh = GetComponent<BallMesh>();
        _ballMovement = GetComponent<BallMovement>();
        _bulletSize = _minBulletSize;
    }

    public void SpawnBullet()
    {
        GameObject spawnedBullet = Instantiate(_bulletPrefab, _ballMesh.GetCenter(), Quaternion.identity);
        spawnedBullet.transform.localScale = Vector3.one * Mathf.Clamp(_bulletSize * _bulletSizeMultipler, _minBallSize, _ballMesh.Size / 2f);
    }

    private void Update()
    {
        IncreaseBulletSize();
        Shoot();
    }

    private void IncreaseBulletSize()
    {
        if (Input.GetMouseButton(0))
        {
            _bulletSize += _increaseMultipler * Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonUp(0) && !_ballMovement.IsMoving)
        {
            SpawnBullet();
            _ballMesh.DecreaseSize(_bulletSize);

            if (_bulletSize / 2 > _ballMesh.Size || _ballMesh.Size - _bulletSize / 2 < _minBallSize)
            {
                Level.ShowGameOverPanel();
                Destroy(gameObject);
            }

            _bulletSize = _minBulletSize;
        }
    }
}
