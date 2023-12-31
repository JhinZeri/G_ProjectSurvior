using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace ProjectSurvivor
{
	// Generate Id:515ec262-c6f4-416d-b146-56e9b5f14378
	public partial class UIGamePassPanel
	{
		public const string Name = "UIGamePassPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnBackToStart;
		
		private UIGamePassPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnBackToStart = null;
			
			mData = null;
		}
		
		public UIGamePassPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePassPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePassPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
