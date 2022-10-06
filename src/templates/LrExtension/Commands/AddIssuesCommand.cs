using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using LrExtension.Model;
using LightningReview.ExtensionFramework;

namespace LrExtension.Commands
{
	/// <summary>
	/// メッセージに設定した文字列を指摘内容にした指摘を2つ追加するコマンド
	/// </summary>
	public class AddIssuesCommand : ExtensionCommand
	{
		#region 構築

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AddIssuesCommand()
		{
			// メニュー名
			Title = "指摘の追加(_U)";

			// ショートカットを指定する場合はこのようにします(Ctrl+D) 
			Key = Key.D;
			Modifiers = ModifierKeys.Control;

			// Properties/Resources.resxに登録されているアイコンリソース名を指定することで
			// アイコンが表示できます。
			// ここでは、Properties/Resources.resxにAddIssuesIconというイメージが登録されているとします。
			IconResourceName = "AddIssuesIcon";
		}

		#endregion

		#region 公開サービス

		/// <summary>
		/// コマンドの実行
		/// </summary>
		/// <param name="parameter"></param>
		protected override void OnExecute(object parameter = null)
		{
			// アクティブなレビューウィンドウを取得
			var reviewWindow = App.ActiveReviewWindow;

			// 次のようにSettingオブジェクトを経由して永続化したメッセージを取得できる。
			var settings = Extension.Settings.GetValue<TutorialSettings>("tutorialSettings");

			// 永続化情報が無ければ初期化
			if (settings == null)
			{
				settings = new TutorialSettings();
			}

			// 指摘内容の文字列を作成
			var description = $"{settings.Message}{Environment.NewLine}{settings.Date?.ToString("yyyy/MM/dd")}";
			
			// BeginEdit()で囲んだ範囲の編集操作を1つの編集単位とする。
			using (reviewWindow.BeginEdit())
			{
				// レビューウィンドウにドキュメントを追加
				var document = reviewWindow.Review.AddDocument();

				// ドキュメントに"ノード"という名前のアウトラインノードを追加
				var outlineNode = document.OutlineTree.AddChild("ノード");

				// アウトラインノードに指摘を追加
				var issue1 = outlineNode.AddIssue();

				// 指摘内容にメッセージと日付を追加
				issue1.Description = description;

				// 2つ目の指摘を追加
				var issue2 = outlineNode.AddIssue();
				issue2.Description = description;

				// 同じ指摘だったら(GIDが同じだったら)
				if (issue1.Equals(issue2))
				{
					//.... 
				}
			}
		}

		/// <summary>
		/// コマンドが有効か
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		protected override bool OnCanExecute(object parameter = null)
		{
			// アクティブなレビューウィンドウを取得
			var reviewWindow = App.ActiveReviewWindow;

			// レビューウィンドウが持つ全ての指摘を取得
			var issues = reviewWindow.Review.GetAllIssues();

			// 指摘が4個以下であれば、メニューを実行できる
			if (issues.Count() <= 4)
			{
				return true;
			}

			// 5個以上あるとできない
			return false;
		}

		#endregion

	}
}
