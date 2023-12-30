using System;
using UnityEngine;
using QFramework;
using Random = UnityEngine.Random;

namespace ProjectSurvivor
{
    public partial class EnemyGenerator : ViewController
    {
        private float mCurrentSeconds = 0;

        private void Update()
        {
            mCurrentSeconds += Time.deltaTime;

            if (mCurrentSeconds >= 1f)
            {
                mCurrentSeconds = 0;

                var player = Player.Default;
                if (player)
                {
                    var randomAngle = Random.Range(0, 360f);
                    // 角度转弧度
                    var randomRadian = randomAngle * Mathf.Deg2Rad;
                    var direction = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian));
                    var generatePos = player.transform.position + direction * 10;

                    Enemy.Instantiate()
                        .Position(generatePos)
                        .Show();
                }
            }
        }
    }
}