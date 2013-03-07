using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScramblerNS {
	static class StopWatchOneTime {
		private static DateTime begin;
		private static DateTime end;
		public static void Start() {
			begin = DateTime.Now;
		}
		public static void Stop() {
			end = DateTime.Now;
		}
		public static TimeSpan Result {
			get {
				return end - begin;
			}
		}
	}
}
