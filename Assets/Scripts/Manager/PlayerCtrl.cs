using System;
using System.Collections;
using Spine.Unity;
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
        public SkeletonAnimation skeletonAnimation;
        private bool _canShot=true;
        public float waitAtkAnimTime = 0.15f;

        public float attachmentThreshold = 0.5f;
        public float mixDuration=0.15f;
        
        Coroutine _coolDownShot;

        private void Start()
        {
            DataMgr.Instance.player = transform.parent.parent.gameObject;
            DataMgr.Instance.playerCtrl = this;
        }

        private IEnumerator CoolDownShot()
        {
            yield return new WaitForSeconds(fireRate);
            _canShot = true;
            if (skeletonAnimation.AnimationName=="z_atk")
            {
                skeletonAnimation.AnimationName = "z_idle";
            }
        }
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
            //gunTrs.rotation = Quaternion.Euler(0, 0, angle);
            //Debug.Log(moveVertical);
            // Rotate character based on movement direction
            if (moveHorizontal != 0 || moveVertical != 0)
            {
                skeletonAnimation.AnimationName = "z_run";
            }
            else 
            {
                skeletonAnimation.AnimationName = "z_idle";
            }
            if (moveHorizontal > 0)
            {
                // transform.rotation = Quaternion.Euler(0, 180, 0); // Face right
                // _isFacingRight = true;
            }
            else if (moveHorizontal < 0)
            {
                // transform.rotation = Quaternion.Euler(0, 0, 0); // Face left
                // _isFacingRight = false;
            }

            // var movement = new Vector3(moveHorizontal, moveVertical, 0);
            // rb.velocity=(movement * movementSpeed );

            // Handle shooting
            if (Input.GetMouseButtonDown(0) && _canShot)
            {
                _canShot = false;
                ShotAnim();
                _coolDownShot=StartCoroutine(CoolDownShot());
                Invoke(nameof(Shot), waitAtkAnimTime);
            }

            if (skeletonAnimation.AnimationName != "z_idle")
            {
                DataMgr.Instance.noisePos = transform.position;
            }
        }

        void ShotAnim()
        {
            var track =skeletonAnimation.AnimationState.SetAnimation(1, "z_atk", false);
            track.AttachmentThreshold = attachmentThreshold;
            track.MixDuration = mixDuration;
            var empty = skeletonAnimation.state.AddEmptyAnimation(1, mixDuration, 0.15f);
            empty.AttachmentThreshold = attachmentThreshold;
        }
        
        void Shot()
        {
            var bullet= Instantiate(bulletPrefab);
            bullet.transform.position = gunTrs.position;
            bullet.transform.rotation = gunTrs.rotation;
        }
        
    }
}