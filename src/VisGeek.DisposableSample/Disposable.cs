using System;
using System.Diagnostics;

namespace VisGeek {
	/// <summary>割り当てられたリソースを解放するメソッドを実装したクラスです。
	/// </summary>
	[DebuggerStepThrough]
	public class Disposable : IDisposable {
		// コンストラクタ
		/// <summary>解放処理を指定して初期化します。
		/// </summary>
		/// <param name="disposeAction"></param>
		public Disposable(Action disposeAction) {
			this.IsDisposed = false;
			this.Disposing = false;
			this.disposeAction = disposeAction;
		}

		/// <summary>初期化します。
		/// </summary>
		protected Disposable() : this(null) {
		}

		// フィールド
		private readonly Action disposeAction;

		// イベント
		/// <summary>リソースが解放されると発生します。
		/// </summary>
		public event EventHandler Disposed;

		// プロパティ
		/// <summary>リソースが解放されたかどうかを判断します。
		/// </summary>
		public bool IsDisposed { get; private set; }

		/// <summary>リソースの解放処理中であるかどうかを取得します。
		/// </summary>
		public bool Disposing { get; private set; }

		// メソッド
		/// <summary>すでに破棄処理が行われてあとである場合に例外を発生させます。
		/// </summary>
		protected void ThrowExceptionIfDisposed() {
			if (this.IsDisposed) {
				throw new ObjectDisposedException(this.GetType().Name);
			}
		}

		/// <summary>リソースを解放します。
		/// </summary>
		public void Dispose() {
			// 解放処理。このオブジェクトに含まれるマネージリソースの解放処理も行います。
			this.Dispose(true);

			// ファイナライザー呼び出し待ちをしない。
			GC.SuppressFinalize(this);
		}

		/// <summary>リソースを解放します。2回目以降の実行を無視します。
		/// </summary>
		/// <param name="disposiong"></param>
		private void Dispose(bool disposiong) {
			if (!this.IsDisposed) {
				// Dispose 開始
				this.Disposing = true;

				this.DisposeInternal(true);

				// Dispose 終了
				this.Disposing = false;
				this.IsDisposed = true;

				// Disposed のイベントを発生させる。
				this.Disposed?.Invoke(this, EventArgs.Empty);
			}
		}

		/// <summary>リソース解放の処理のみを実装します。複数回実行などの対応処理を行う必要はありません。
		/// </summary>
		/// <param name="disposiong">true の場合はこのオブジェクトに含まれるマネージリソースの解放します。</param>
		protected virtual void DisposeInternal(bool disposiong) {
			if (disposiong) {
			}

			this.disposeAction?.Invoke();
		}

		// デストラクター
		/// <summary>リソース解放処理を実行します。
		/// </summary>
		~Disposable() {
			// 解放処理。このオブジェクトに含まれるマネージリソースの解放処理は行いません。
			this.Dispose(false);
		}
	}
}
