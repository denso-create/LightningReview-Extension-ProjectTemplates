using System;
using LightningReview.ExtensionFramework;
using System.Windows;
using LrExtension.Model;
using LrExtension.Views;

namespace LrExtension.Commands
{
	/// <summary>
	/// メッセージの設定コマンド
	/// 拡張機能の設定を行うコマンドの例
	/// </summary>
	public class MessageSettingCommand : ExtensionCommand
	{
		#region 構築

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageSettingCommand()
		{
			// メニュー名
			Title = "メッセージの設定";
		}

		#endregion

		#region 公開サービス

		/// <summary>
		/// コマンドの実行
		/// </summary>
		/// <param name="parameter"></param>
		protected override void OnExecute(object parameter = null)
		{
			// 次のようにSettingオブジェクトを経由して永続化したメッセージを取得できる
			var tutorialSettings = Extension.Settings.GetValue<TutorialSettings>("tutorialSettings");

			// 永続化情報が無ければ初期化
			if (tutorialSettings == null)
			{
				tutorialSettings = new TutorialSettings();
			}

			// ダイアログを開く
			var settingDialog = new MessageSettingDialog
			{
				Owner = App.ActiveReviewWindow.GetWindow(), 

				// テキストボックスに前回設定した値を表示
				Text = tutorialSettings.Message,

				// DateTimePickerに前回設定した値を表示
				SelectedDateTime = tutorialSettings.Date
			};
			var dialogResult = settingDialog.ShowDialog();

			// OKボタンが押されたら、設定値をテキストボックスの内容で更新
			if (dialogResult == true)
			{
				tutorialSettings.Message = settingDialog.Text;
				tutorialSettings.Date = settingDialog.SelectedDateTime;

				// 設定値を保存
				Extension.Settings.SetValue("tutorialSettings", tutorialSettings);
			}
		}

		#endregion
	}
}
