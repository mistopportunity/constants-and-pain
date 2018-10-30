using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace non_original_idea {
	public static class SentenceBuilder {

		internal static string ContractContractables (
			string sentence,
			IEnumerable<Contraction> contractions
		) {

			foreach(Contraction contraction in contractions) {

				if(contraction.isFormatter) {

					var matches = Regex.Matches(sentence,contraction.longway);

					foreach(Match match in matches) {

						var group1 = match.Groups[1].Value;
						var group2 = match.Groups[2].Value;

						string formattedShorthand = null;

						switch(match.Groups.Count) {
							case 2:
								formattedShorthand = string.Format(
									contraction.shorthand,group1
								);
								break;
							case 3:
								formattedShorthand = string.Format(
									contraction.shorthand,group1,group2
								);
								break;
						}
						if(formattedShorthand != null) {

						} else {
							throw new Exception($"({contraction.longway}) is an invalid formatter. Do you have an extra Regex group?");
						}

						sentence = sentence.Replace(
							match.Value,
							formattedShorthand
						);
					}

				} else {

					sentence = sentence.Replace(
						contraction.longway,
						contraction.shorthand
					);

				}


			}

			return sentence;


		}
		public static string Build(this IEnumerable<string> sentenceFragments,char punctuation) {
			return Build(sentenceFragments,punctuation,true,ConstantsAndPain.BasicContractions);
		}

		public static string Build(
			this IEnumerable<string> sentenceFragments,
			char punctuation,
			bool startCapital,
			IEnumerable<Contraction> contractions
		) {
			StringBuilder stringBuilder = new StringBuilder();
			foreach(var sentenceFragment in sentenceFragments) {
				stringBuilder.Append(sentenceFragment);
				stringBuilder.Append(' ');
			}
			string sentence = stringBuilder.ToString();

			if(contractions != null) {
				sentence = ContractContractables(sentence,contractions);
			}

			string startCharacter = startCapital ?
				sentence.Substring(0,1).ToUpper():
				sentence.Substring(0,1);
			return
				$"{startCharacter}" +
				$"{sentence.Substring(1,sentence.Length-2)}" +
				$"{punctuation}";
		}
	}
}
