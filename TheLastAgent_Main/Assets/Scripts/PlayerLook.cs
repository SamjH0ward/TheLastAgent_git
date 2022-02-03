using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private GameObject playerLight;
    private Vector2 aimPoint;

    void OnAim(InputValue input)
    {
        aimPoint = input.Get<Vector2>();
    }

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(aimPoint) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        playerLight.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
