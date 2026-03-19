using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private InputReader _inputReader;
    private Vector2 _moveDirection;

    public void Init(InputReader inputReader)
    {
        _inputReader = inputReader;

        _inputReader.MoveChanged += OnMoveChanged;
    }

    private void Update()
    {
        Vector3 direction = new Vector3(_moveDirection.x, _moveDirection.y, 0f);
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
            _inputReader.MoveChanged -= OnMoveChanged;
    }

    private void OnMoveChanged(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }
}
