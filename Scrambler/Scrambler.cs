using System;
using System.Text;

namespace Scrambler {
	public class Scrambler {
		public static bool AllUp = false;
		public static bool TrimSpace = false;
		public static bool InsertSpace = false;

		public static string scrableTheText(string text) {
			Random random = new Random();
			int count = text.Length;
			if (AllUp) {
				for (int i = 0; i < text.Length; i++) {
					if (Char.IsLower(text[i])) {
						text = ChangeChar(text, i);
					}
				}
			} else {
				for (int i = 0; i < text.Length; i++) {
					if (Char.IsUpper(text[i])) {
						text = ChangeChar(text, i);
					}
				}
			}
			if (TrimSpace) {
				for (int i = 0; i < text.Length; i++) {
					if (Char.IsWhiteSpace(text[i])) {
						while (Char.IsWhiteSpace(text[--count])) ;
						text = setChar(text, i, text[count]);
					}
				}
			}
			System.Text.StringBuilder sbt = new System.Text.StringBuilder();
			while (count > 0) {
				int a = random.Next(count);
				sbt.Append(text[a]);
				if (InsertSpace == false) {
					sbt.Append(' ');
				}
				text = setChar(text, a, text[--count]);
			}
			return sbt.ToString();
		}

		private static string ChangeChar(string text, int index) {
			StringBuilder str = new StringBuilder(text);
			if (AllUp) {
				str[index] = Char.ToUpper(text[index]);
			} else {
				str[index] = Char.ToLower(text[index]);
			}
			return str.ToString();
		}

		private static string setChar(string text, int index, char c) {
			StringBuilder str = new StringBuilder(text);
			str[index] = c;
			return str.ToString();
		}
	}
}