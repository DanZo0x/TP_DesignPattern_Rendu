using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    
    [Space]
    [Header("Variables")]
    [SerializeField] private float playerSpeed = 7f;
    [SerializeField] private float playerOffset = -45f;
    [SerializeField] private float turnSpeed = 360f;
    [SerializeField] private Vector2 movementVector2D;
    [SerializeField] private Vector3 movementVector3D;
    
    public Vector2 MovementVector2D
    {
        get => movementVector2D;
        set => movementVector2D = value;
    }

    public Vector3 MovementVector3D
    {
        get => movementVector3D;
        set => movementVector3D = value;
    }
    
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
    }
    
    private void Move()
    {
        if (movementVector2D == Vector2.zero)
        {
            return;
        }

        movementVector3D = new Vector3(movementVector2D.x, 0f, movementVector2D.y) * (Time.deltaTime * playerSpeed);

        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0f, playerOffset, 0f));
        var skewedInput = matrix.MultiplyPoint3x4(movementVector3D);

        rb.MovePosition(transform.position + skewedInput);
        anim.SetFloat("WalkSpeed", movementVector3D.magnitude * 100f);
    }

    private void Look()
    {
        if (movementVector3D == Vector3.zero)
        {
            return;
        }
        
        var relative = (rb.transform.position + movementVector3D) - rb.transform.position;
        var rotation = Quaternion.LookRotation(relative, Vector3.up);
        var offsetRotation = rotation * Quaternion.AngleAxis(-playerOffset, Vector3.down);

        rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, offsetRotation, turnSpeed * Time.deltaTime);
    }
    
    private void Update()
    {
        Move();
        Look();
        
        if (movementVector2D == Vector2.zero)
        {
            anim.SetFloat("WalkSpeed", 0);
        }
    }
}
