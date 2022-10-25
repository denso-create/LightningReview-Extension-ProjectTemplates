using System;

namespace LrExtension.Model
{
	/// <summary>
	/// 本エクステンションにおけるチュートリアル用の設定値を保持する
	/// </summary>
	public class TutorialSettings
	{
		/// <summary>
		/// メッセージ
		/// </summary>
        public string Message { get; set; } = "Hello";

		/// <summary>
		/// 日付
		/// </summary>
        public DateTime? Date { get; set; }
	}
}
