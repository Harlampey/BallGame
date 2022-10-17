using UnityEngine;
using DG.Tweening;

public class BallMesh : MonoBehaviour
{
    [SerializeField] private Transform _mesh;

    public float Size => _mesh.localScale.x;

    public Vector3 GetCenter()
    {
        Vector3 pos = _mesh.position;
        pos.y = _mesh.localScale.y / 2;
        return pos;
    }

    public void DecreaseSize(float size)
    {
        _mesh.DOScale(_mesh.localScale.x - size / 1.2f, 0.3f);
    }
}
