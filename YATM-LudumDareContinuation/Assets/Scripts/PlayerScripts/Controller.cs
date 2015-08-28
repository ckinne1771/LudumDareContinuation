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

    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    private bool grounded = false;
    private bool jumping = false;
    private float timer = 0.0f;

    private void Update() {
        float axis = Input.GetAxisRaw("Horizontal");

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
        } else {
            velocity.x = 0.0f;
        }

        if (grounded) {
            if (Input.GetButtonDown("Jump")) {
                jumping = true;
                velocity.y = jumpVelocity;
            }
        } else {
            velocity.y -= gravity * Time.deltaTime;
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
            grounded = true;
            velocity.y = 0.0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (grounded) {
            grounded = false;
        }
    }
}
