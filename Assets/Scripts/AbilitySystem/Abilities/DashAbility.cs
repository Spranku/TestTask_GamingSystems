using UnityEngine;

[CreateAssetMenu(fileName = "DashAbility", menuName = "Scriptable Objects/DashAbility")]
public class DashAbility : AbilityBase
{
    public float distance = 5f;

    public override void ActivateAbility(GameObject owner)
    {
        var playerInput = owner.GetComponent<CustomInput>();
        var rb = owner.GetComponent<Rigidbody>();
        if (playerInput == null || rb == null) return;

        var playerPosition = owner.transform.position;
        var cursorPosition = playerInput.AimPoint(playerPosition);

        var direction = cursorPosition - playerPosition;
        direction.y = 0f; // Z ignore
        direction.Normalize();

        /* Launch dash */
        rb.AddForce(direction * distance, ForceMode.VelocityChange);
    }
}
