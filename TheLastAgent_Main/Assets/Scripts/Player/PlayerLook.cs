using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private GameObject _playerLight;
    private Vector2 _aimPoint;

    void OnAim(InputValue input)
    {
        _aimPoint = input.Get<Vector2>();
    }

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(_aimPoint) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _playerLight.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
