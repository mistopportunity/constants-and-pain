using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public static class SentenceBuilder {

		public static string Build(
			bool startCapital,
			char punctuation,
			params SentenceFragment[] sentenceFragments
		) {
			return Build(sentenceFragments,startCapital,punctuation);
		}

		public static string Build(
			char punctuation,
			params SentenceFragment[] sentenceFragments
		) {
			return Build(sentenceFragments,startCapital: true,punctuation: punctuation);
		}

		public static string Build (
			params SentenceFragment[] sentenceFragments
		) {
			return Build(sentenceFragments);
		}

		public static string Build (
			IEnumerable<SentenceFragment> sentenceFragments,
			bool startCapital = true,
			char punctuation = '.'
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
				$"{punctuation}";
		}
	}
}
