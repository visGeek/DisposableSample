using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisGeek.Test.DisposableUsage {
	internal class Program {
		internal static void Main(string[] args) {
			Console.WriteLine("■using を使った破棄処理の例です。");
			Samples.CleanupObjectByUsing();

			// ※実行するときはコメントを外してください。
			//Console.WriteLine("");
			//Console.WriteLine("■デストラクターを使った破棄処理の例です。");
			//Samples.CleanupObjectByDestructor();

			Console.WriteLine("");
			Console.WriteLine("■処理が終わったあとに任意の処理を実行する例です。");
			Samples.CleanupAfterAction();

			Console.WriteLine("");
			Console.WriteLine("終了");
			Console.ReadKey();
		}
	}
}
