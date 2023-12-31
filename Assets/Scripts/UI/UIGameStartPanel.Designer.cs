using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
	// Generate Id:92c25295-e6e0-44e1-b63e-81eada3ea180
	public partial class UIGameStartPanel
	{
		public const string Name = "UIGameStartPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnCoinUpgrade;
		[SerializeField]
		public UnityEngine.UI.Button BtnStartGame;
		[SerializeField]
		public UnityEngine.UI.Image CoinUpgradePanel;
		[SerializeField]
		public UnityEngine.UI.Button BtnCoinPercentUpgrade;
		[SerializeField]
		public UnityEngine.UI.Button BtnExpPercentUpgrade;
		[SerializeField]
		public UnityEngine.UI.Button BtnClose;
		[SerializeField]
		public UnityEngine.UI.Text CoinText;
		
		private UIGameStartPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnCoinUpgrade = null;
			BtnStartGame = null;
			CoinUpgradePanel = null;
			BtnCoinPercentUpgrade = null;
			BtnExpPercentUpgrade = null;
			BtnClose = null;
			CoinText = null;
			
			mData = null;
		}
		
		public UIGameStartPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameStartPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameStartPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
