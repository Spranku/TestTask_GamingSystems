using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private CustomInput myInput;
    [SerializeField] 
    private float moveSpeed = 5f;

    private Rigidbody rg;

    private void Awake() => rg = GetComponent<Rigidbody>();

    private void FixedUpdate() 
    { 
        Vector2 move = myInput.Move.normalized; 

        rg.MovePosition(rg.position + new Vector3(move.x, 0f, move.y) * (moveSpeed * Time.fixedDeltaTime)); 

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

