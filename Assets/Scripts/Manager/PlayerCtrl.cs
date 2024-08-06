using UnityEngine;
using UnityEngine.Serialization;

namespace Manager
{
    public class PlayerCtrl : MonoBehaviour
    {
        public float movementSpeed = 5f;
        public GameObject bulletPrefab;
        public float fireRate = 0.5f;
        private float _nextFire;
        private bool _isFacingRight = true;
        public Transform gunTrs;
        public Rigidbody2D rb;

        void Update()
        {
            // Handle movement
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
       
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var position = transform.position;
            var direction = new Vector2(
                position.x-mousePosition.x,
                position.y-mousePosition.y 
            );
            // Calculate angle in radians and convert to degrees
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate gunTrs towards mouse position
            gunTrs.rotation = Quaternion.Euler(0, 0, angle);
            
            // Rotate character based on movement direction
            if (moveHorizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0); // Face right
                _isFacingRight = true;
            }
            else if (moveHorizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0); // Face left
                _isFacingRight = false;
            }

            var movement = new Vector3(moveHorizontal, moveVertical, 0);
            rb.velocity=(movement * movementSpeed );

            // Handle shooting
            if (Input.GetMouseButtonDown(0) && Time.time > _nextFire)
            {
                _nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, gunTrs.position, gunTrs.rotation);
            }
        }
    }
}