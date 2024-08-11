using System;
using MoreMountains.TopDownEngine;
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
            Debug.Log(collision.gameObject.name);
            if (collision.transform.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Health>().Damage(DataMgr.Instance.GetShotDamage(),DataMgr.Instance.player,0,0,transform.position);
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Destroy the bullet on collision
            Debug.Log(other.gameObject.name);
            if (other.transform.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Health>().Damage(DataMgr.Instance.GetShotDamage(),DataMgr.Instance.player,0,0,transform.position);
            }
            Destroy(gameObject);
        }
    }
}
