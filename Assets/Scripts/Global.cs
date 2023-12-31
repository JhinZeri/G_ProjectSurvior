using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProjectSurvivor
{
    public class Global
    {
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);

        public static BindableProperty<int> Coin = new BindableProperty<int>(0);

        public static BindableProperty<int> Level = new BindableProperty<int>(1);

        public static BindableProperty<float> CurrentSeconds = new BindableProperty<float>(0);

        public static BindableProperty<float> SimpleAbilityDamage = new BindableProperty<float>(1);

        public static BindableProperty<float> SimpleAbilityDuration = new BindableProperty<float>(1.5f);


        public static BindableProperty<float> ExpPercent = new BindableProperty<float>(0.3f);
        public static BindableProperty<float> CoinPercent = new BindableProperty<float>(0.1f);

        [RuntimeInitializeOnLoadMethod]
        public static void AutoInit()
        {
            Coin.Value = PlayerPrefs.GetInt("coin", 0);

            ExpPercent.Value = PlayerPrefs.GetFloat(nameof(ExpPercent), 0.4f);
            CoinPercent.Value = PlayerPrefs.GetFloat(nameof(CoinPercent), 0.1f);

            Coin.Register(coin => { PlayerPrefs.SetInt(nameof(coin), coin); });
            ExpPercent.Register(expPercent => { PlayerPrefs.SetFloat(nameof(ExpPercent), expPercent); });
            CoinPercent.Register(coinPercent => { PlayerPrefs.SetFloat(nameof(CoinPercent), coinPercent); });
        }

        public static void ResetData()
        {
            Exp.Value = 0;
            Level.Value = 1;
            CurrentSeconds.Value = 0;
            SimpleAbilityDamage.Value = 1;
            SimpleAbilityDuration.Value = 1;
            EnemyGenerator.EnemyCount.Value = 0;
        }

        public static int ExpToNextLevel()
        {
            return Level.Value * 5;
        }

        public static void GeneratePowerUp(GameObject gameObject)
        {
            // 70% 掉落经验值

            var percent = Random.Range(0f, 1f);

            if (percent < ExpPercent.Value)
            {
                // 掉落经验值
                PowerUpManager.Default.Exp.Instantiate()
                    .Position(gameObject.Position())
                    .Show();
            }

            percent = Random.Range(0f, 1f);

            if (percent < CoinPercent.Value)
            {
                PowerUpManager.Default.Coin.Instantiate()
                    .Position(gameObject.Position())
                    .Show();
            }
        }
    }
}