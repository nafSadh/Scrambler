using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ScramblerNS {
	public class Scrambler {
		private const string RUSSIAN_CHARACTERS = "ёйцукенгшщзхъэждлорпавыфячсмитьбюЁЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮ";
		private const string ENGLISH_CHARACTERS = "abcdefghiklmnopqrstuvwxyzABCDEFGHIKLMNOPQRSTUVWXYZ";
		private const string OTHER_CHARACTERS = "><!@#$%&*1234567890";
		private const int BINARY_LENGTH = 16;

		public delegate void LogMessageEventHandler(string message);
		public event LogMessageEventHandler LogMessage;

		public delegate void ProgressIncrementEventHandler(int progressCount);
		public event ProgressIncrementEventHandler ProgressIncrement;

		public string ScrambledString(string mainString) {
			byte[] bin = binaryWork(mainString);
			ProgressIncrement(10);
			LogMessage("Translated into binary format finalized");
			string scrambler = scrambleBinaryString(bin);	
			LogMessage("Scrambler Binary finalized");
			return scrambler;
		}

		public string MainString(string passingString) {
			string bin = UnScrambstrBinaryext(passingString);
			LogMessage("Translated into binary format finalized");
			string unScram = DecodeBinary(bin);
			LogMessage("UnScrambler Binary finalized");
			return unScram;
		}

		private byte[] binaryWork(string workString) {
			return Encoding.Unicode.GetBytes(workString);
		}

		private string DecodeBinary(string passingString) {
			string charResult = "";
			for (int i = 0; i < passingString.Length; i += BINARY_LENGTH) {
				try {
					charResult += getCharacter(passingString.Substring(i, BINARY_LENGTH));
				} catch (OverflowException) { }
			}
			return charResult;
		}

		private string UnScrambstrBinaryext(string Uscr) {

			// Cut last 9 characters of the text
			// Last 9 characters contain the extra character with 1 & 0 characters
			string[] strOneToZero = new string[3];
			string ScrChrs = OTHER_CHARACTERS;
			int ii;

			string LastNine = rvsString(Uscr.Substring(Uscr.Length - 9));

			// A unique way to find unique characters once ;)
			foreach (char ChrNine in LastNine) {
				if (strOneToZero[0] == null) {
					strOneToZero[0] = ChrNine.ToString(); continue;
				}
				if (strOneToZero[0] == ChrNine.ToString()) continue;
				if (strOneToZero[1] == null) {
					strOneToZero[1] = ChrNine.ToString(); continue;
				}
				if (strOneToZero[1] == ChrNine.ToString()) continue;
				strOneToZero[2] = ChrNine.ToString();
				break;
			}

			// We need array "1" and "2". "0" is extra
			ScrChrs = ScrChrs.Replace(strOneToZero[1], "");
			ScrChrs = ScrChrs.Replace(strOneToZero[2], "");

			for (ii = 0; ii < ScrChrs.Length; ii++) {
				Uscr = Uscr.Replace(ScrChrs.Substring(ii, 1), "");
			}

			// I wrote a method to make things simpler.
			Uscr = SingleString(strOneToZero[1], Uscr);
			Uscr = SingleString(strOneToZero[2], Uscr);

			Uscr = Uscr.Replace(";", "");
			Uscr = Uscr.Replace(":", "");
			Uscr = Uscr.Replace(strOneToZero[1], "0");
			Uscr = Uscr.Replace(strOneToZero[2], "1");

			return Uscr.Substring(0, (Uscr.Length - 2));
		} // Last two was our guys remember?

		// Replace dublicate characters with single
		private string SingleString(string MultiString, string StrFull) {
			while (StrFull.IndexOf(MultiString + MultiString) != -1) {
				StrFull = StrFull.Replace(MultiString + MultiString, MultiString);
			}

			return StrFull;
		}

		// I wrote this reverser for the last 9 characters of the scrambled text
		private string rvsString(string ReverseThis) {
			string rvSt = "";
			int ii;
			for (ii = (ReverseThis.Length - 1); ii > 0; ii--) {
				rvSt += ReverseThis.Substring(ii, 1);
			}
			return rvSt;
		}

		private string scrambleBinaryString(byte[] ScrString) {
			int rndRep;
			Random random = new Random();
			string newString = "";
			string sourceChars = OTHER_CHARACTERS;
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
						newString += OneAndZero(rndRep, oneChar) + OneAndZero(rndRep, ";");
						break;
					case 0:
						newString += OneAndZero(rndRep, zeroChar) + OneAndZero(rndRep, ":");
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
				
				newString += OneAndZero(random.Next(1, 3), sourceChars.Substring(random.Next(sourceChars.Length), 1));
			}

			// When return, the first and the last character is random to confuse people. Before that two characters are our guys
			return OneAndZero(random.Next(1, 3), sourceChars.Substring(random.Next(sourceChars.Length), 1))
				+ newString + OneAndZero(random.Next(3), oneChar) + OneAndZero(random.Next(3), zeroChar)
				+ OneAndZero(random.Next(1, 3), sourceChars.Substring(random.Next(sourceChars.Length), 1));
		}

		// This method called a few times to enter random amount of characters
		private string OneAndZero(int Rept, string sOZ) {
			int ii;
			for (ii = 0; ii < Rept; ii++) {
				sOZ += sOZ.Substring(0, 1);
			}
			return sOZ;
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