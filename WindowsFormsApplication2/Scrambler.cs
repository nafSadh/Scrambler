using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.VisualBasic;

namespace ScramblerNS {
	public class Scrambler {
		private const string RUSSIAN_CHARACTERS = "ёйцукенгшщзхъэждлорпавыфячсмитьбюЁЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮ";
		private const string ENGLISH_CHARACTERS = "abcdefghiklmnopqrstuvwxyzABCDEFGHIKLMNOPQRSTUVWXYZ";
		private const string OTHER_CHARACTERS = "><!@#$%&*1234567890";
		private const string ALL_CHARACTERS = RUSSIAN_CHARACTERS + ENGLISH_CHARACTERS + OTHER_CHARACTERS;
		private const int BINARY_LENGTH = 16;

		public delegate void LogMessageEventHandler(string message);
		public event LogMessageEventHandler LogMessage;

		public delegate void ProgressIncrementEventHandler(int progressCount);
		public event ProgressIncrementEventHandler ProgressIncrement;

		#region Scrambler

		public string ScrambledString(string mainString) {
			byte[] bin = binaryWork(mainString);
			ProgressIncrement(10);
			LogMessage("Translated into binary format finalized");
			string scrambler = scrambleBinaryString(bin);
			LogMessage("Scrambler Binary finalized");
			return scrambler;
		}

		private byte[] binaryWork(string workString) {
			return Encoding.Unicode.GetBytes(workString);
		}

		private string scrambleBinaryString(byte[] ScrString) {
			int rndRep;
			Random random = new Random();
			string newString = "";
			string sourceChars = ALL_CHARACTERS;
			string oneChar = sourceChars.Substring(random.Next(sourceChars.Length), 1);
			sourceChars = sourceChars.Replace(oneChar, "");
			string zeroChar = sourceChars.Substring(random.Next(sourceChars.Length), 1);
			sourceChars = sourceChars.Replace(zeroChar, "");
			int IntStrLength = ScrString.Length;

			#region InitializeProgress

			int progressInc = 1;
			const int UNSCRAMBLE_PROGRESS = 90;
			bool everyCicle = true;
			if (IntStrLength > UNSCRAMBLE_PROGRESS) {
				progressInc = IntStrLength / UNSCRAMBLE_PROGRESS;
				everyCicle = false;
			} else {
				progressInc = UNSCRAMBLE_PROGRESS / IntStrLength;
			}
			int index = 0;

			#endregion

			foreach (byte oneZeroChar in ScrString) {
				rndRep = random.Next(3);
				switch (oneZeroChar) {
					case 1:
						newString += oneAndZero(rndRep, oneChar) + oneAndZero(rndRep, ";");
						break;
					case 0:
						newString += oneAndZero(rndRep, zeroChar) + oneAndZero(rndRep, ":");
						break;
				}

				#region Progress

				if (everyCicle) {
					ProgressIncrement(progressInc);
				} else {
					if (++index % progressInc == 0) {
						ProgressIncrement(1);
					}
				}

				#endregion

				newString += oneAndZero(random.Next(1, 3), sourceChars.Substring(random.Next(sourceChars.Length), 1));
			}
			return oneAndZero(random.Next(1, 3), sourceChars.Substring(random.Next(sourceChars.Length), 1))
				+ newString + oneAndZero(random.Next(3), oneChar) + oneAndZero(random.Next(3), zeroChar)
				+ oneAndZero(random.Next(1, 3), sourceChars.Substring(random.Next(sourceChars.Length), 1));
		}

		private string oneAndZero(int length, string oneZeroString) {
			for (int i = 0; i < length; i++) {
				oneZeroString += oneZeroString.Substring(0, 1);
			}
			return oneZeroString;
		}

		#endregion


		#region UnScrambler

		public string UnScramblerString(string passingString) {
			string bin = unScrambleBinaryText(passingString);
			LogMessage("Translated into binary format finalized");
			string unScram = DecodeBinary(bin);
			LogMessage("UnScrambler Binary finalized");
			return unScram;
		}

		private string unScrambleBinaryText(string unScrambleString) {
			string sourceChars = ALL_CHARACTERS;

			// Cut last 9 characters of the text
			// Last 9 characters contain the extra character with 1 & 0 characters
			const int NINE_CHARS = 9;
			string lastNineChars = reverseString(unScrambleString.Substring(unScrambleString.Length - NINE_CHARS));

			// A unique way to find unique characters once ;)
			string uniqueChars = new string(lastNineChars.Distinct().ToArray());

			// We need array "1" and "2". "0" is extra
			sourceChars = sourceChars.Replace(uniqueChars[1], '\0');
			sourceChars = sourceChars.Replace(uniqueChars[2], '\0');
			for (int i = 0; i < sourceChars.Length; i++) {
				unScrambleString = unScrambleString.Replace(sourceChars.Substring(i, 1), "");
			}

			// I wrote a method to make things simpler.
			unScrambleString = SingleString(uniqueChars[1].ToString(), unScrambleString);
			unScrambleString = SingleString(uniqueChars[2].ToString(), unScrambleString);

			unScrambleString = unScrambleString.Replace(";", "");
			unScrambleString = unScrambleString.Replace(":", "");
			unScrambleString = unScrambleString.Replace(uniqueChars[1], '0');
			unScrambleString = unScrambleString.Replace(uniqueChars[2], '1');

			return unScrambleString.Substring(0, (unScrambleString.Length - 2));
		}

		#endregion

		private string DecodeBinary(string passingString) {
			string charResult = "";
			for (int i = 0; i < passingString.Length; i += BINARY_LENGTH) {
				try {
					charResult += getCharacter(passingString.Substring(i, BINARY_LENGTH));
				} catch (OverflowException) { }
			}
			return charResult;
		}

		// Replace dublicate characters with single
		private string SingleString(string MultiString, string StrFull) {
			while (StrFull.IndexOf(MultiString + MultiString) != -1) {
				StrFull = StrFull.Replace(MultiString + MultiString, MultiString);
			}
			return StrFull;
		}

		private string reverseString(string ReverseThis) {
			return new string(ReverseThis.Reverse().ToArray());
		}

		//private string getCharacter(string strBinary){

		//    return getCharacter(strBinary).ToString();
		//}

		private char getCharacter(string strBinary) {
			return (char)Convert.ToInt32(strBinary, 2);
		}

		private string getBinary(char strChr) {
			return Convert.ToString(strChr, 2).PadLeft(BINARY_LENGTH, '0');
		}
	}
}