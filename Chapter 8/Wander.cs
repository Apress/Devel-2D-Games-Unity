using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
public class Wander : MonoBehaviour
{
    public float pursuitSpeed;
    public float wanderSpeed;
    float currentSpeed;

    public float directionChangeInterval;
    // We can reuse this script to make other creatures in the game wander about without chasing the player.
    // Use this flag to turn off the player-chasing behavior.
    public bool followPlayer;

    Coroutine moveCoroutine;

    CircleCollider2D circleCollider;
    Rigidbody2D rb2d;
    Animator animator;

    // only used when we have a target to pursue
    Transform targetTransform = null;

    Vector3 endPosition;
    float currentAngle = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentSpeed = wanderSpeed;

        circleCollider = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        StartCoroutine(WanderRoutine());
    }

    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndpoint();

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));

            // wait directionChangeInterval seconds then change direction
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void ChooseNewEndpoint()
    {
        currentAngle += Random.Range(0, 360); // degrees

        // if currentAngle is greater than 360, loop so it starts at 0 again, keeping the value between 0 and 360
        currentAngle = Mathf.Repeat(currentAngle, 360);
        endPosition += Vector3FromAngle(currentAngle);
    }

    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        // equal to (PI * 2) / 360, the degrees to radians conversion constant
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;

        return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
    }

    public IEnumerator Move(Rigidbody2D rigidBodyToMove, float speed)
    {
        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        while (remainingDistance > float.Epsilon)
        {
            // When in pursuit, the targetTransform won't be null.
            if (targetTransform != null)
            {
                endPosition = targetTransform.position;
            }

            if (rigidBodyToMove != null)
            {
                animator.SetBool("isWalking", true);

                Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition, speed * Time.deltaTime);
                rb2d.MovePosition(newPosition);
                remainingDistance = (transform.position - endPosition).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }

        // enemy has reached endPosition and waiting for new direction selection
        animator.SetBool("isWalking", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            currentSpeed = pursuitSpeed;

            // Set this variable so the Move coroutine can use it to follow the player.
            targetTransform = collision.gameObject.transform;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            // At this point, endPosition is now player object's transform, ie: will now move towards the player
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isWalking", false);
            currentSpeed = wanderSpeed;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            // Since we no longer have a target to follow, set this to null
            targetTransform = null;
        }
    }

    //////////////////////////// Debugging / Diagnostic

    void OnDrawGizmos()
    {
        if (circleCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
        }
    }

    void Update()
    {
        // target line
        Debug.DrawLine(rb2d.position, endPosition, Color.red);
    }
}
