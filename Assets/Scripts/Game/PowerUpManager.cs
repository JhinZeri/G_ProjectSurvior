using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
    public partial class PowerUpManager : ViewController
    {
        public static PowerUpManager Default;

        private void Awake()
        {
            if (Default == null)
            {
                Default = this;
            }
        }

        private void OnDestroy()
        {
            Default = null;
        }

       
    }
}