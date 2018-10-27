using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace non_original_idea {
	public sealed class SentenceBuilder {

		public readonly List<SentenceFragment> Fragments;

		public SentenceBuilder() {
			Fragments = new List<SentenceFragment>();
		}

		public void Add(SentenceFragment sentenceFragment) {
			Fragments.Add(sentenceFragment);
		}
		public void Add(string sentenceFragment) {
			Fragments.Add(new SentenceFragment(sentenceFragment));
		}

		public string Build (
			char punctuation = '.',
			bool startCapital = true,
			IEnumerable<Contraction> contractions = null
		) {
			return Build(Fragments,startCapital,punctuation,contractions);
		}


		internal static string ContractContractables (
			string sentence,
			IEnumerable<Contraction> contractions
		) {

			foreach(Contraction contraction in contractions) {



				if(contraction.isFormatter) {

					var matches = Regex.Matches(sentence,contraction.longway);

					foreach(Match match in matches) {

						var verb = match.Groups[1].Value;
						var subject = match.Groups[2].Value;

						sentence = sentence.Replace(
							match.Value,contraction.shorthand.Replace("{}",subject),
							StringComparison.CurrentCultureIgnoreCase
						);

					}

				} else {

					sentence = sentence.Replace(contraction.longway,contraction.shorthand);

				}


			}

			return sentence;


		}

		internal static string Build(
			IEnumerable<SentenceFragment> sentenceFragments,
			bool startCapital,
			char punctuation,
			IEnumerable<Contraction> contractions
		) {
			StringBuilder stringBuilder = new StringBuilder();
			foreach(var sentenceFragment in sentenceFragments) {
				var fragmentText = sentenceFragment.Text;
				stringBuilder.Append(fragmentText);
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
