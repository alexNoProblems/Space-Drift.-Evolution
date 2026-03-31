using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
   [SerializeField] private AsteroidMover _asteroidPrefab;
   [SerializeField] private int _count = 20;
   [SerializeField] private float _spawnInterval = 10f;
   [SerializeField] private Vector2 _spawnAreaMin = new Vector2(-10f, -5f);
   [SerializeField] private Vector2 _spawnAreaMax = new Vector2(10f, 5f);
   
   private WaitForSeconds _waitForSeconds;

   private void Awake()
   {
      _waitForSeconds = new WaitForSeconds(_spawnInterval);
   }

   private void Start()
   {
      StartCoroutine(SpawnRoutine());
   }

   private IEnumerator SpawnRoutine()
   {
      while (enabled)
      {
         for (int i = 0; i < _count; i++)
            Spawn();
         
         yield return _waitForSeconds;
      }
   }

   private void Spawn()
   {
      Vector3 position = new  Vector3(Random.Range(_spawnAreaMin.x, _spawnAreaMax.x), Random.Range(_spawnAreaMin.y, _spawnAreaMax.y), 0f);
      
      AsteroidMover asteroid = Instantiate(_asteroidPrefab, position, Quaternion.identity);
      
      Vector3 direction = Random.insideUnitCircle.normalized;
      
      asteroid.Init(direction);
   }

   private Vector3 GetRandomDirection()
   {
      Vector2 direction2D = Random.insideUnitCircle.normalized;

      if (direction2D == Vector2.zero)
         direction2D = Vector2.right;
      
      return new Vector3(direction2D.x, direction2D.y, 0f);
   }
}
