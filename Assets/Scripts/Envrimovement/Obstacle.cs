using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour, IObstacle
{
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void Infect()
    {
        transform.DOPunchScale(Vector3.one * 0.15f, 0.4f);
        _meshRenderer.material.DOColor(Color.red, 0.4f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
