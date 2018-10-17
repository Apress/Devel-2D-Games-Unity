using UnityEngine;

[RequireComponent(typeof(Character))]
public class MovementController : MonoBehaviour
{
    public float movementSpeed = 2.0f;

    [HideInInspector]
    public Vector2 movement = new Vector2();
    [HideInInspector]
    public Animator animator;

    Rigidbody2D rb2D;
    Character character;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateState();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    public void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    void UpdateState()
    {
        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            animator.SetBool("isWalking", false);
        } 
        else
        {
            animator.SetBool("isWalking", true);
        }

        animator.SetFloat("xDir", movement.x);
        animator.SetFloat("yDir", movement.y);
    }
}