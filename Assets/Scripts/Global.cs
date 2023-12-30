using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace ProjectSurvivor
{
    public class Global
    {
        /// <summary>
        /// 经验值
        /// </summary>
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);

        /// <summary>
        /// 等级
        /// </summary>
        public static BindableProperty<int> Level = new BindableProperty<int>(1);

        public static BindableProperty<float> CurrentSeconds = new BindableProperty<float>(0);

        public static BindableProperty<float> SimpleAbilityDamage = new BindableProperty<float>(1);
    }
}