using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 3f;

    private const float capsuleSize = 0.5f;

    private Transform targetTransform;
    private Rigidbody rg;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        if(rg)
        {
            rg.useGravity = false;
            rg.interpolation = RigidbodyInterpolation.Interpolate;
            rg.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rg.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) targetTransform = player.transform;
    }

    private void FixedUpdate()
    {
        if (targetTransform == null) return;

        /* Always move to player */
        Vector3 direction = targetTransform.position - transform.position;
        direction.y = 0f;

        float distance = direction.magnitude;
        if (distance <= 0.5f) return;

        if (distance > capsuleSize)
        {
            Vector3 newPos = rg.position + direction.normalized * (moveSpeed * Time.fixedDeltaTime);
            rg.MovePosition(newPos);
        }

        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        rg.MoveRotation(lookRot);
    }

}

