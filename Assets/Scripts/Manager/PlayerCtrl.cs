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

        private void Start()
        {
            DataMgr.Instance.player = transform.parent.parent.gameObject;
            DataMgr.Instance.playerCtrl = this;
            //ikConstraint= GetComponent<SkeletonAnimation>().skeleton.FindIkConstraint("Z_GUN");
            // 获取所有的IK约束
            var ikConstraints = skeletonAnimation.Skeleton.IkConstraints;

            // 遍历所有的IK约束
            foreach (var ikConstraint in ikConstraints)
            {
                // 打印IK约束的名称
                Debug.Log("IK Constraint: " + ikConstraint.Data.Name);
            }
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
            
            // 计算角色位置和鼠标位置之间的距离
            var distance =direction.magnitude;

            // 设定IK的最大长度
            var maxLength = 1;
            if (distance > maxLength)
            {
                direction = direction.normalized;
                direction *= maxLength;
            }
            // 获取IK约束
            //IkConstraint ikConstraint = skeletonAnimation.Skeleton.FindIkConstraint("Yt");
            this.ikConstraint.transform.position = mousePosition;
            // 设置IK目标的位置
            // ikConstraint.Target.X = direction.x;
            // ikConstraint.Target.Y = direction.y;
            // ikConstraint.Update();

            // Calculate angle in radians and convert to degrees
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           
           

            // 更新IK约束
            
            
            // Rotate gunTrs towards mouse position
            //gunTrs.rotation = Quaternion.Euler(0, 0, angle);
            //Debug.Log(moveVertical);
            // Rotate character based on movement direction
            if (moveHorizontal != 0 || moveVertical != 0)
            {
                skeletonAnimation.AnimationName = "z_atk"; //"z_run";
            }
            else 
            {
                skeletonAnimation.AnimationName = "z_atk";
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