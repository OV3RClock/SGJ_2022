using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        public float rotationSpeed;
        [SerializeField] private float deceleration;
        [SerializeField] private float maxSpeed;

        [FormerlySerializedAs("rb")] [SerializeField]
        private Rigidbody2D rb2d;

        private Vector2 moveDirection;
        private bool active = true;

        public Transform RespawnPoint;



        // Update is called once per frame
        void Update()
        {
            ProcessInputs();
        }

        void FixedUpdate()
        {
            if (active)
                Move();
        }

        public void Respawn()
        {
            gameObject.transform.position = RespawnPoint.position;
        }

        void ProcessInputs()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;

            var dir = new Vector3(moveDirection.x, moveDirection.y, 0);

            if (dir != Vector3.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        void Move()
        {
            Vector2 dir = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

            if (rb2d.velocity.magnitude > maxSpeed)
            {
                rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
            }
            else if (dir.Equals(Vector2.zero))
            {
                rb2d.velocity -= rb2d.velocity * deceleration * Time.deltaTime;
            }
            else
            {
                rb2d.AddForce(dir, ForceMode2D.Impulse);
            }
           // graphics.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Mathf.Deg2Rad * Time.time));
        }

        public void Stop(bool stop)
        {
            active = !stop;
            if (!active)
                rb2d.velocity = Vector2.zero;
        }
    }
}