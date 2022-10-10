using System.Linq;
using System.Windows;
using LrExtension.Commands;
using LightningReview.ExtensionFramework;

namespace LrExtension
{
    /// <summary>
    /// エクステンションの説明
    /// </summary>
    [ExtensionExport("LrExtension", "拡張機能の日本語の表示名", "Extension's Display Name")]
    public class LrExtension : Extension
    {
        #region オーバーライド

        /// <summary>
        /// アクティベート処理
        /// </summary>
        protected override void OnActivate()
        {
            // メインメニューの [ツール] - [プロパティの表示順を変更] の1つ上(Before)にメニューを作成する例
            RegisterMenu()
                .Location("ReviewWindow/MainMenu")
                .Parent("ツール")
                .Before("プロパティの表示順を変更")
                .Command<AddIssuesCommand>()
                .Build();

            // メインメニューの [ツール] - [プロパティの表示順を変更] の1つ上(Before)にメニューを作成する例
            // WithSeparatorAfter()でメニューの下にセパレーターを置くことができる
            RegisterMenu()
                .Location("ReviewWindow/MainMenu")
                .Parent("ツール")
                .Before("プロパティの表示順を変更")
                .Command<MessageSettingCommand>()
                .WithSeparatorAfter()
                .Build();

            // ツールバーのピポット分析ボタンの後(After)にボタンを作成する例
            // SetButtonでボタンを配置できる。SetTextでテキスト形式のボタンを配置できる。
            RegisterToolBarItem()
                .Location("ReviewWindow/ToolBar")
                .After("ピボット分析")
                .SetButton()
                .SetTextStyle()
                .Command<MessageSettingCommand>()
                .Build();

            // ツールバーのピポット分析ボタンの後(After)に、メニューを作成する例
            // SetToggleButtonでトグルボタンを配置できる。SetImageStyleでイメージで表現するボタンを配置できる。
            RegisterToolBarItem()
                .Location("ReviewWindow/ToolBar")
                .After("ピボット分析")
                .WithSeparatorBefore()
                .SetButton()
                .SetImageStyle()
                .Command<AddIssuesCommand>()
                .Build();

            // 保存後イベントを使う例
            // 保存が完了すると、メッセージボックスが出る
            App.ReviewAfterSave += AppOnReviewAfterSave;
        }

        #endregion

        #region イベントハンドラ

        /// <summary>
        /// レビューファイル保存後にメッセージボックスを出すイベントハンドラ
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void AppOnReviewAfterSave(object arg1, ReviewEventArgs arg2)
        {
            // ドキュメントの数と指摘の数を取得
            var documentCount = arg2.ReviewWindow.Review.Documents.Count();
            var issueCount = arg2.ReviewWindow.Review.GetAllIssues().Count();

            var saveMassage = $"ドキュメントが{documentCount}件、 指摘は{issueCount}件です！";
            MessageBox.Show(saveMassage, "Lightning Review", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

    }
}
