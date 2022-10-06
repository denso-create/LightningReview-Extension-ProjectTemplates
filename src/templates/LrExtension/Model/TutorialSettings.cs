using System;
using Newtonsoft.Json;

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
		[JsonProperty("message")]
		public string Message { get; set; } = "Hello";

		/// <summary>
		/// 日付
		/// </summary>
		[JsonProperty("date")]
		public DateTime? Date { get; set; }
	}
}
