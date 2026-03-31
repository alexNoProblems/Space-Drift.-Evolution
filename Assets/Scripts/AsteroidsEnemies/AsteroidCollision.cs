using UnityEngine;
public class AsteroidCollision : MonoBehaviour
{
   [SerializeField] private ParticleSystem _explosionPrefab;
   
   private ScoreCounter _scoreCounter;

   private void Start()
   {
      _scoreCounter = FindObjectOfType<ScoreCounter>();
   }
   
   private void OnTriggerEnter(Collider other)
   {
      if(other.GetComponentInParent<Player>() == null)
         return;
      
      _scoreCounter.AddHit();
      
      Explode();
   }

   private void Explode()
   {
      if (_explosionPrefab != null)
      {
         ParticleSystem explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
         
         Destroy(explosion.gameObject, explosion.main.duration + explosion.main.startLifetime.constantMax);
      }
      
      Destroy(gameObject);
   }
}
