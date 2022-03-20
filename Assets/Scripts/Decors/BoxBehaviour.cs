using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float deceleration;
    [SerializeField] private int pv = 2;


    void OnCollisionEnter2D(Collision2D c)
    {
        pv -= 1;

        if (pv <= 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity -= rb2d.velocity * (deceleration * Time.deltaTime);
        rb2d.angularVelocity -= rb2d.angularVelocity * (deceleration * Time.deltaTime);
    }
}
