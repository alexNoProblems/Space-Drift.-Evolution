using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
   [SerializeField] private float _speed = 2f;

   private Vector3 _direction;

   public void Init(Vector3 direction)
   {
      _direction = direction.normalized;
   }

   private void Update()
   {
      transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
   }
}
