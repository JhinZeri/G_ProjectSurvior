using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
    public partial class Enemy : ViewController
    {
        public float HP = 3;
        public float MovementSpeed = 2.0f;

        private void Start()
        {
            EnemyGenerator.EnemyCount.Value++;
        }

        private void OnDestroy()
        {
            EnemyGenerator.EnemyCount.Value--;
        }

        private void Update()
        {
            if (Player.Default)
            {
                var direction = (Player.Default.transform.position - transform.position).normalized;

                transform.Translate(direction * (Time.deltaTime * MovementSpeed));
            }

            if (HP <= 0)
            {
                Global.GeneratePowerUp(gameObject);
                this.DestroyGameObjGracefully();
            }
        }

        private bool mIgnoreHurt = false;

        public void Hurt(float value)
        {
            if (mIgnoreHurt) return;

            Sprite.color = Color.red;

            ActionKit.Delay(0.2f, () =>
            {
                this.HP -= Global.SimpleAbilityDamage.Value;
                this.Sprite.color = Color.white;
                mIgnoreHurt = false;
            }).Start(this);
        }
    }
}