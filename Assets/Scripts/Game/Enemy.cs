using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
    public partial class Enemy : ViewController
    {
        public float HP = 3;
        public float MovementSpeed = 2.0f;

        private void Update()
        {
            if (Player.Default)
            {
                var direction = (Player.Default.transform.position - transform.position).normalized;

                transform.Translate(direction * (Time.deltaTime * MovementSpeed));
            }

            if (HP <= 0)
            {
                this.DestroyGameObjGracefully();
                Global.Exp.Value++;
            }
        }
    }
}