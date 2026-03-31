using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 15f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
