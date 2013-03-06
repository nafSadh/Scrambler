using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Scrambler {
	public class Scrambler {
		private const string RUSSIAN_CHARACTERS = "ёйцукенгшщзхъэждлорпавыфячсмитьбюЁЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮ";
		private const string ENGLISH_CHARACTERS = "abcdefghiklmnopqrstuvwxyzABCDEFGHIKLMNOPQRSTUVWXYZ";
		private const string OTHER_CHARACTERS = "><!@#$%&*1234567890";
		private const int BINARY_LENGTH = 16;

		public string BinaryString(string MainString) {
			return BinaryWork(MainString);
		}

		public string ScrambledString(string MainString) {
			return ScrambstrBinaryext(BinaryWork(MainString));
		}

		public string MainString(string passingString, DecodeType decodeType) {
			switch (decodeType) {
				case DecodeType.Binary:
					return DecodeBinary(passingString);
				case DecodeType.UnScramble:
					return DecodeBinary((UnScrambstrBinaryext(passingString)));
			}
			throw new Exception("DecodeType Error");
		}

		private string BinaryWork(string WhatToWorkOn) {
			string BinaryResults = "";
			foreach (char GetChr in WhatToWorkOn) {
				BinaryResults += GetBinary(GetChr);
			}
			return BinaryResults;
		}

		private string DecodeBinary(string PassingString) {
			int ii;
			string CharResult = "";

			for (ii = 0; ii < PassingString.Length; ii += BINARY_LENGTH) {
				try {
					CharResult += GetCharacter(PassingString.Substring(ii, BINARY_LENGTH));
				} catch (OverflowException) { }
			}
			return CharResult;
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

		private string ScrambstrBinaryext(string ScrString) {
			int rndRep;
			Random intRan = new Random();
			string newString = "";
			string ScrChrs = OTHER_CHARACTERS;
			string chrOne = ScrChrs.Substring(intRan.Next(ScrChrs.Length), 1);
			ScrChrs = ScrChrs.Replace(chrOne, "");
			string chrZero = ScrChrs.Substring(intRan.Next(ScrChrs.Length), 1);
			ScrChrs = ScrChrs.Replace(chrZero, "");

			int IntStrLength = ScrString.Length;
			foreach (char OZchr in ScrString) {
				rndRep = intRan.Next(3);

				switch (OZchr) {
					case '1': // I wrote a method to make things simpler.
						newString += OneAndZero(rndRep, chrOne) + OneAndZero(rndRep, ";");
						break;
					case '0':
						newString += OneAndZero(rndRep, chrZero) + OneAndZero(rndRep, ":");
						break;
				}

				newString += OneAndZero(intRan.Next(1, 3), ScrChrs.Substring(intRan.Next(ScrChrs.Length), 1));
			}

			// When return, the first and the last character is random to confuse people. Before that two characters are our guys
			return OneAndZero(intRan.Next(1, 3), ScrChrs.Substring(intRan.Next(ScrChrs.Length), 1))
				+ newString + OneAndZero(intRan.Next(3), chrOne) + OneAndZero(intRan.Next(3), chrZero)
				+ OneAndZero(intRan.Next(1, 3), ScrChrs.Substring(intRan.Next(ScrChrs.Length), 1));
		}

		// This method called a few times to enter random amount of characters
		private string OneAndZero(int Rept, string sOZ) {
			int ii;
			for (ii = 0; ii < Rept; ii++) {
				sOZ += sOZ.Substring(0, 1);
			}
			return sOZ;
		}

		//private string GetCharacter(string strBinary){

		//    return GetCharacter(strBinary).ToString();
		//}

		private char GetCharacter(string strBinary) {
			return (char)Convert.ToInt32(strBinary, 2);
		}

		private string GetBinary(char strChr) {
			return Convert.ToString(strChr, 2).PadLeft(BINARY_LENGTH, '0');
		}
	}
}