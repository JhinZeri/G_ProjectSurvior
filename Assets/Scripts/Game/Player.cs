using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
    public partial class Player : ViewController
    {
        public float MovementSpeed = 5;

        public static Player Default;

        private void Awake()
        {
            Default = this;
        }

        private void OnDestroy()
        {
            Default = null;
        }

        void Start()
        {
            HurtBox.OnTriggerEnter2DEvent(coll =>
                {
                    var hitBox = coll.GetComponent<HitBox>();
                    if (hitBox)
                    {
                        if (hitBox.Owner.CompareTag("Enemy"))
                        {
                            this.DestroyGameObjGracefully();
                            UIKit.OpenPanel<UIGameOverPanel>();
                        }
                    }
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            var direction = new Vector2(horizontal, vertical).normalized;

            SelfRigidbody2D.velocity = direction * MovementSpeed;
        }
    }
}