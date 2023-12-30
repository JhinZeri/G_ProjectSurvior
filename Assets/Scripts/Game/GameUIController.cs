using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
    public partial class GameUIController : ViewController
    {
        void Start()
        {
            // Code Here
            UIKit.OpenPanel<UIGamePanel>();
        }

        private void OnDestroy()
        {
            UIKit.ClosePanel<UIGamePanel>();
        }
    }
}