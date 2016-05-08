using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseShiftCareerEditor
{
	public static class IniFileReader
	{
		public static List<KeyValuePair<string, string>> ReadFile(string fileName) {
			if (!File.Exists(fileName)) {
				return null;
			}

			List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();

			var lines = File.ReadAllLines(fileName);
			foreach (var l in lines)
			{
				var fI = l.IndexOf('"'); //KVP
				var lI = l.LastIndexOf('"'); //KVP
				var eI = l.IndexOf('='); //KVP
				//var semiI = l.IndexOf(';'); //comment
				//var lBI = l.IndexOf('['); //section
				//var rBI = l.LastIndexOf(']'); //section
				if (eI < fI && fI >= 0 && lI >= 0 && fI != lI)
				{
					var key = l.Substring(0, eI).Trim().ToLower();
					var value = l.Substring(fI + 1, lI - fI - 1);
					ret.Add(new KeyValuePair<string, string>(key, value));
				}
				/*else if (l.Trim().StartsWith(";"))
				{
					ret.Add(new KeyValuePair<string, string>(";", (l + " ").Substring(semiI + 1).Trim()));
				}*/
				else {
					ret.Add(new KeyValuePair<string, string>(l, "")); //Let the user parse it.
				}
			}

			return ret;
		}

		public static void WriteFile(string fileName, List<KeyValuePair<string, string>> data) {
			string dataToWrite = "";
			foreach (var l in data) {
				if (!string.IsNullOrWhiteSpace(l.Value))
				{
					dataToWrite += l.Key + " = \"" + l.Value + "\"" + Environment.NewLine;
				}
				else {
					dataToWrite += l.Key + Environment.NewLine;
				}
			}

			File.WriteAllText(fileName, dataToWrite, Encoding.Unicode);
		}
	}
}
