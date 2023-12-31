using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
    public class UIGamePanelData : UIPanelData
    {
    }

    public partial class UIGamePanel : UIPanel
    {
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            // please add init code here

            EnemyGenerator.EnemyCount.RegisterWithInitValue(enemyCount =>
                {
                    EnemyCountText.text = "敌人：" + $"{enemyCount}";
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.CurrentSeconds.RegisterWithInitValue(currentSeconds =>
            {
                if (Time.frameCount % 30 == 0)
                {
                    var currentSecondsInt = Mathf.FloorToInt(currentSeconds);
                    var seconds = currentSecondsInt % 60;
                    var minutes = currentSecondsInt / 60;
                    TimeText.text = "时间：" + $"{minutes:00}:{seconds:00}";
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);


            Global.Exp.RegisterWithInitValue(exp => { ExpText.text = $"经验值：({exp}/{Global.ExpToNextLevel()})"; })
                .UnRegisterWhenGameObjectDestroyed(gameObject);


            Global.Level.RegisterWithInitValue(lv => { LevelText.text = "等级：" + lv; })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Level.Register(lv =>
            {
                Time.timeScale = 0;
                UpgradeRoot.Show();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Exp
                .RegisterWithInitValue(exp =>
                {
                    if (exp >= Global.ExpToNextLevel())
                    {
                        Global.Exp.Value -= Global.ExpToNextLevel();
                        Global.Level.Value++;
                    }
                }).UnRegisterWhenGameObjectDestroyed(gameObject);

            UpgradeRoot.Hide();

            BtnUpgrade.onClick.AddListener(() =>
            {
                Time.timeScale = 1.0f;
                Global.SimpleAbilityDamage.Value *= 1.5f;
                UpgradeRoot.Hide();
            });
            BtnSimpleDurationUpgrade.onClick.AddListener(() =>
            {
                Time.timeScale = 1.0f;
                Global.SimpleAbilityDuration.Value *= 0.8f;
                UpgradeRoot.Hide();
            });


            var enemyGenerator = FindObjectOfType<EnemyGenerator>();
            ActionKit.OnUpdate.Register(() =>
                {
                    Global.CurrentSeconds.Value += Time.deltaTime;
                    if (enemyGenerator.LastWave && enemyGenerator.CurrentWave == null &&
                        EnemyGenerator.EnemyCount.Value == 0)
                    {
                        UIKit.OpenPanel<UIGamePassPanel>();
                    }
                })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Coin.RegisterWithInitValue(coin => { CoinText.text = "金币：" + coin; })
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        protected override void OnOpen(IUIData uiData = null)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
        }
    }
}