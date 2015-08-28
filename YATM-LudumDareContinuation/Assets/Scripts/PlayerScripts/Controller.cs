using UnityEngine;

public class Controller : MonoBehaviour {
    [SerializeField] private float walkingAcceleration;
    [SerializeField] private float maxWalkingVelocity;

    [SerializeField] private float runningAcceleration;
    [SerializeField] private float maxVelocity;

    [SerializeField] private float jumpVelocity;
    [SerializeField] private float jumpAcceleration;
    [SerializeField] private float jumpTimer;
    [SerializeField] private float gravity;
    
    [SerializeField] private float wallJumpAcceleration;
    [SerializeField] private float maxWallJumpVelocity;

    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    private bool grounded = false;
    private bool jumping = false;
    private bool doubleJumped = false;
    private float againstWall = 0.0f;
    private float wallJumping = 0.0f;
    private float timer = 0.0f;

    private void Update() {
        float axis = Input.GetAxisRaw("Horizontal");

        if (wallJumping == 0.0f) {
            if (axis != 0.0f) {
                float sign = Mathf.Sign(velocity.x);

                if (Mathf.Abs(velocity.x) < maxWalkingVelocity) {
                    velocity.x += axis * walkingAcceleration * Time.deltaTime;
                    if (Mathf.Abs(velocity.x) > maxWalkingVelocity) {
                        velocity.x = maxWalkingVelocity * sign;
                    }
                } else {
                    velocity.x += axis * runningAcceleration * Time.deltaTime;
                    if (Mathf.Abs(velocity.x) > maxVelocity) {
                        velocity.x = maxVelocity * sign;
                    }
                }
            } else if (grounded) {
                velocity.x = 0.0f;
            }
        } else {
            velocity.x += wallJumping * wallJumpAcceleration * Time.deltaTime;
            if (Mathf.Abs(velocity.x) > maxWallJumpVelocity) {
                velocity.x = maxWallJumpVelocity;
                wallJumping = 0.0f;
            }
        }

        if (grounded) {
            if (Input.GetButtonDown("Jump")) {
                jumping = true;
                velocity.y = jumpVelocity;
            }
        } else {
            velocity.y -= gravity * Time.deltaTime;

            if (againstWall != 0.0f && Input.GetButtonDown("Jump")) {
                velocity.x = 0.0f;
                velocity.y = jumpVelocity;
                wallJumping = againstWall;
                againstWall = 0.0f;
            } else if (!doubleJumped && Input.GetButtonDown("Jump")) {
                doubleJumped = true;
                jumping = true;
                velocity.y = jumpVelocity;
            }
        }

        if (jumping) {
            if (Input.GetButtonUp("Jump")) {
                jumping = false;
                timer = 0.0f;
            } else if (timer < jumpTimer) {
                velocity.y += jumpAcceleration * Time.deltaTime;
                timer += Time.deltaTime;
            } else {
                jumping = false;
                timer = 0.0f;
            }
        }

        transform.Translate(velocity * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            if (collision.contacts[0].normal == Vector2.up) {
                grounded = true;
                doubleJumped = true;
                velocity.y = 0.0f;
            } else if (collision.contacts[0].normal != -Vector2.up) {
                againstWall = collision.contacts[0].normal.x;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (grounded) {
            grounded = false;
            doubleJumped = false;
            againstWall = 0.0f;
        }
    }
}
