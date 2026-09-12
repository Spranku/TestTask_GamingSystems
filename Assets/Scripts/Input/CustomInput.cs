using UnityEngine;

public class CustomInput : MonoBehaviour
{
    public Vector2 Move => new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));

    public bool HitPressed => UnityEngine.Input.GetMouseButton(0);

    public Vector3 AimPoint(Vector3 origin)
    {
        var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        var plane = new Plane(Vector3.up, origin);
        return plane.Raycast(ray, out float distance) ? ray.GetPoint(distance) : origin + transform.forward;
    }
}
