using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpStrength = 5f;

    public GameObject jumpParticle;

    Rigidbody2D rb;
    bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = vel;

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void OnCollisionEnter2D()
    {
        grounded = true;
    }

    void OnCollisionExit2D()
    {
        grounded = false;
    }

    void Jump()
    {
        Vector2 vel = rb.velocity;
        if (Mathf.Round(vel.y) != 0 || !grounded)
            return;

        // Particle
        Destroy(Instantiate(jumpParticle, transform.position, Quaternion.identity), 3f);

        // Force
        rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
    }
}
