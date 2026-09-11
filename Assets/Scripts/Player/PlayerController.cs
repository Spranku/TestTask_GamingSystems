using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private CustomInput myInput;
    [SerializeField] 
    private float moveSpeed = 5f;

    private Rigidbody rg;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        if(rg)
        {
            rg.useGravity = false;
            rg.interpolation = RigidbodyInterpolation.Interpolate;
            rg.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rg.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }    

    private void FixedUpdate() 
    {
        Vector2 move = myInput.Move.normalized;

        Vector3 velocity = new Vector3(move.x, 0f, move.y) * moveSpeed;

        /* Fix bug with flying Y */
        rg.linearVelocity = new Vector3(velocity.x, 0f, velocity.z);  

        var target = myInput.AimPoint(rg.position);
        var direction = target - rg.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
            rg.MoveRotation(Quaternion.LookRotation(direction));

    }

    private void Update()
    {
        var target = myInput.AimPoint(transform.position);
        var direction = target - transform.position;

        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
            transform.rotation = Quaternion.LookRotation(direction);
    }
}

