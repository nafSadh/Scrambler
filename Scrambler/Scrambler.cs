using System;

namespace ns7.sadhontoon {
	class Scrambler {
		public static string scrableTheText(string text, bool allUp, bool allLower, bool trimSpace, bool insertSpace) {
			System.Random random = new System.Random();
			char[] set = text.ToCharArray();
			int count = set.Length;
			if (allUp) {
				for (int i = 0; i < set.Length; i++) {
					if (Char.IsLower(set[i])) set[i] = Char.ToUpper(set[i]);
				}
			}
			if (allLower) {
				for (int i = 0; i < set.Length; i++) {
					if (Char.IsUpper(set[i])) set[i] = Char.ToLower(set[i]);
				}
			}
			if (trimSpace) {
				for (int i = 0; i < set.Length; i++) {
					if (Char.IsWhiteSpace(set[i])) {
						while (Char.IsWhiteSpace(set[--count])) ;
						set[i] = set[count];
					}
				}
			}
			System.Text.StringBuilder sbt = new System.Text.StringBuilder();
			int a;
			if (insertSpace) {
				while (count > 0) {
					a = random.Next(count);
					sbt.Append(set[a]);
					sbt.Append(' ');
					set[a] = set[--count];
				}
			} else {
				while (count > 0) {
					a = random.Next(count);
					sbt.Append(set[a]);
					set[a] = set[--count];
				}
			}
			return sbt.ToString();
		}
	}
}