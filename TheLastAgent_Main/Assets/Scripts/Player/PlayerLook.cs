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
        // gets the direction of the mouse form the player
        Vector2 direction = Camera.main.ScreenToWorldPoint(_aimPoint) - transform.position;

        // get the angle of the direction of the pointer form the player 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // rotates the player light to the location of the pointer
        _playerLight.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
