using System;
using non_original_idea;

namespace non_original_idea_tester.cs {
	class Program {
		static void Main() {

			foreach(Subject subject in ConstantsAndPain.Subjects) {

				foreach(Specificity specificity in ConstantsAndPain.Specificities) {

					foreach(Tense tense in ConstantsAndPain.Tenses) {

						var fragment = ConstantsAndPain.GetVerbToBePredicate(
							subject,
							tense,
							specificity
						);

						var adjective = new SentenceFragment("complicated");

						char punctuation;

						if(specificity == Specificity.NegativeStatement || specificity == Specificity.PositiveStatement) {
							punctuation = '.';
						} else {
							punctuation = '?';
						}

						var sentence = SentenceBuilder.Build(
							punctuation,
							fragment,
							adjective
						);

						Console.WriteLine(sentence);

					}
				}

			}

			Console.ReadKey(true);

		}
	}
}
