using System;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Random = UnityEngine.Random;

namespace ProjectSurvivor
{
    [Serializable]
    public class EnemyWave
    {
        public float GenerateDuration = 1;
        public GameObject EnemyPrefab;
        public int Seconds = 10;
    }

    public partial class EnemyGenerator : ViewController
    {
        private float mCurrentGenerateSeconds = 0;
        private float mCurrentWaveSeconds = 0;

        public static BindableProperty<int> EnemyCount = new BindableProperty<int>();

        public List<EnemyWave> EnemyWaves = new List<EnemyWave>();

        private Queue<EnemyWave> mEnemyWavesQueue = new Queue<EnemyWave>();

        public int WaveCount = 0;

        public bool LastWave => WaveCount == EnemyWaves.Count;

        public EnemyWave CurrentWave => mCurrentEnemyWave;

        private void Start()
        {
            foreach (var enemyWave in EnemyWaves)
            {
                mEnemyWavesQueue.Enqueue(enemyWave);
            }
        }

        private EnemyWave mCurrentEnemyWave = null;

        private void Update()
        {
            if (mCurrentEnemyWave == null)
            {
                if (mEnemyWavesQueue.Count > 0)
                {
                    WaveCount++;
                    mCurrentEnemyWave = mEnemyWavesQueue.Dequeue();
                    mCurrentGenerateSeconds = 0;
                    mCurrentWaveSeconds = 0;
                }
            }


            if (mCurrentEnemyWave != null)
            {
                mCurrentGenerateSeconds += Time.deltaTime;
                mCurrentWaveSeconds += Time.deltaTime;

                if (mCurrentGenerateSeconds >= mCurrentEnemyWave.GenerateDuration)
                {
                    mCurrentGenerateSeconds = 0;

                    var player = Player.Default;
                    if (player)
                    {
                        var randomAngle = Random.Range(0, 360f);
                        // 角度转弧度
                        var randomRadian = randomAngle * Mathf.Deg2Rad;
                        var direction = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian));
                        var generatePos = player.transform.position + direction * 10;

                        mCurrentEnemyWave.EnemyPrefab.Instantiate()
                            .Position(generatePos)
                            .Show();
                    }
                }

                if (mCurrentWaveSeconds >= mCurrentEnemyWave.Seconds)
                {
                    // 置空，走第一个流程
                    mCurrentEnemyWave = null;
                }
            }
        }
    }
}