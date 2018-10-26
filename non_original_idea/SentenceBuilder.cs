using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public static class SentenceBuilder {

		public static string Build(
			bool startCapital,
			char endPuncuation,
			params SentenceFragment[] sentenceFragments
		) {
			return Build(sentenceFragments,startCapital,endPuncuation);
		}

		public static string Build(
			char endPuncuation,
			params SentenceFragment[] sentenceFragments
		) {
			return Build(sentenceFragments,startCapital: true,endPuncuation: endPuncuation);
		}

		public static string Build (
			params SentenceFragment[] sentenceFragments
		) {
			return Build(sentenceFragments);
		}

		public static string Build (
			IEnumerable<SentenceFragment> sentenceFragments,
			bool startCapital = true,
			char endPuncuation = '.'
		) {
			StringBuilder stringBuilder = new StringBuilder();

			foreach(var sentenceFragment in sentenceFragments) {
				stringBuilder.Append(sentenceFragment.Text);
				stringBuilder.Append(' ');
			}
			string sentence = stringBuilder.ToString();

			string startCharacter = startCapital ?
				sentence.Substring(0,1).ToUpper():
				sentence.Substring(0,1);
			return
				$"{startCharacter}" +
				$"{sentence.Substring(1,sentence.Length-2)}" +
				$"{endPuncuation}";
		}
	}
}
