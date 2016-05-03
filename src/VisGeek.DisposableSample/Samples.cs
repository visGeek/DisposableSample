using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.DisposableSample {
	/// <summary>処理の例
	/// </summary>
	internal static class Samples {
		/// <summary>using を使った破棄処理の例です。
		/// </summary>
		internal static void CleanupObjectByUsing() {
			using (var obj = new DisposableEx()) {
			}
		}

		/// <summary>デストラクターを使った破棄処理の例です。
		/// </summary>
		internal static void CleanupObjectByDestructor() {
			{
				var obj = new DisposableEx();
			}

			// obj をガベージコレクト対象とするためにメモリ消費します。
			var list = new LinkedList<int>();
			while (true) {
				try {
					list.AddLast(0);
				} catch (Exception) {
					break;
				}
			}
		}

		/// <summary>処理が終わったあとに任意の処理を実行する例です。
		/// </summary>
		public static void CleanupAfterAction() {
			bool isRunning = false; // 処理中フラグ

			Console.WriteLine("処理開始");
			using (new Disposable(() => isRunning = false)) { // ブロック終了後にフラグを下げる
				isRunning = true;
				Console.WriteLine("{0} = {1}", nameof(isRunning), isRunning);
			}

			Console.WriteLine("処理完了");
			Console.WriteLine("{0} = {1}", nameof(isRunning), isRunning);
		}
	}
}
