using System;
using System.Windows;
using LightningReview.ExtensionFramework;

namespace LrExtension.Views
{
	/// <summary>
	/// MessageSettingDialog.xaml の相互作用ロジック
	/// </summary>
	public partial class MessageSettingDialog : Window
	{
		#region 構築

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageSettingDialog()
		{
			InitializeComponent();

			// ダイアログの背景色と文字色をテーマ色に合わせる
			this.SetThemeColor();
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// テキストボックスに設定するテキスト
		/// </summary>
		public string Text
		{
			get => m_TextBox.Text;
			set => m_TextBox.Text = value;
		}

		/// <summary>
		/// 選択された日付
		/// </summary>
		public DateTime? SelectedDateTime
		{
			get => m_DateTimePicker.SelectedDateTime;
			set => m_DateTimePicker.SelectedDateTime = value;
		}

		#endregion


		#region 内部サービス

		/// <summary>
		/// OKボタンクリック時のイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void M_OKButton_OnClick(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		#endregion
	}
}
