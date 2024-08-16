using System;
using System.Collections;
using Spine;
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
        public GameObject ikConstraint;
        Coroutine _coolDownShot;

        private Camera _mainCamera;
        private void Start()
        {
            DataMgr.Instance.player = transform.parent.parent.gameObject;
            DataMgr.Instance.playerCtrl = this;
            _mainCamera = Camera.main;
            var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            this.ikConstraint.transform.position = mousePosition;
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
       
            var mousePosition =_mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            
            // 计算角色位置和鼠标位置之间的距离

            // 获取IK约束
            //IkConstraint ikConstraint = skeletonAnimation.Skeleton.FindIkConstraint("Yt");
            
            //this.ikConstraint.transform.position = mousePosition;
            // 计算玩家位置和鼠标位置之间的向量
            // 计算玩家位置和鼠标位置之间的角度

            // 设定扇形区域的角度范围
   
            if(transform.rotation.eulerAngles.y>30&&mousePosition.x>transform.position.x)
                ikConstraint.transform.position = mousePosition;
            if(transform.rotation.eulerAngles.y<30&&mousePosition.x<transform.position.x)
                ikConstraint.transform.position = mousePosition;
           

            // 更新IK约束
            
            
            // Rotate gunTrs towards mouse position
            //gunTrs.rotation = Quaternion.Euler(0, 0, angle);
            //Debug.Log(moveVertical);
            // Rotate character based on movement direction
            if (moveHorizontal != 0 || moveVertical != 0)
            {
                skeletonAnimation.AnimationName = "z_run"; //"z_run";
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
            var rotation = gunTrs.rotation;
            bullet.transform.position = gunTrs.position;

            bullet.transform.rotation = Quaternion.Euler(gunTrs.eulerAngles.x, gunTrs.eulerAngles.y, gunTrs.eulerAngles.z+180);
        }
        
    }
}