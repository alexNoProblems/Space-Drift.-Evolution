using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    [SerializeField] private float _idleRotationSpeed = 20f;
    [SerializeField] private float _moveRotationSpeed = 200f;

    private Transform _parent;
    private Vector3 _lastParentPosition;

    private void Start()
    {
        _parent = transform.parent;
        _lastParentPosition = _parent.position;
    }

    private void Update()
    {
        Vector3 currentParentPosition = _parent.position;
        Vector3 moveDirection = currentParentPosition - _lastParentPosition;

        if (moveDirection.sqrMagnitude < 0.000001f)
        {
            transform.Rotate(Vector3.up * _idleRotationSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            Vector3 axis = Vector3.Cross(moveDirection.normalized, Vector3.forward );
            transform.Rotate(axis,_moveRotationSpeed * Time.deltaTime, Space.World);
        }

        _lastParentPosition = currentParentPosition;
    }
}
