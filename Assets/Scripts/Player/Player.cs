using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private InputReader _inputReader;
   [SerializeField] private PlayerMover _playerMover;

   private void Awake()
   {
      _playerMover.Init(_inputReader);
   }
}
