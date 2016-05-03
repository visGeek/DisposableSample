using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.DisposableUsage {
	/// <summary>Disposable クラスを継承したクラスです。
	/// </summary>
	internal class DisposableEx : Disposable {
		/// <summary>このオブジェクトに含まれている Dispose 対象です。
		/// </summary>
		private readonly IDisposable innerDisposable = null;

		/// <summary>このクラスに含まれている非マネージリソースのクリーンナップ処理です。Close() というメソッド名で実装されている場合があります。
		/// </summary>
		private void CleanUpMyUnmanagedResources() {
			Console.WriteLine("非マネージリソースのクリーンナップ処理");
		}

		/// <summary>ベースクラスの Dispose 処理をオーバーライドします。
		/// このクラスの Dispose 処理のあとにベースクラスの Dispose 処理を実行します。
		/// </summary>
		/// <param name="disposiong"></param>
		protected override void DisposeInternal(bool disposiong) {
			// このクラス内の Dispose 対象。
			if (disposiong) {
				Console.WriteLine("このクラス内の Dispose 対象のクリーンナップ処理");
				this.innerDisposable?.Dispose();
			}

			// このクラスの非マネージリソースのクリーンナップ。
			this.CleanUpMyUnmanagedResources();

			// ベースクラスの Dispose 処理を実行する。
			base.DisposeInternal(disposiong);
		}
	}
}
