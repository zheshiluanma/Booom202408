using System;
using UnityEngine;

namespace Manager
{
    public class BulletCtrl : MonoBehaviour
    {
        public float speed = 10f;

        
        //Update is called once per frame
        void Update()
        {
            // Move the bullet forward
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // Destroy the bullet on collision
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Destroy the bullet on collision
            Destroy(gameObject);
        }
    }
}
