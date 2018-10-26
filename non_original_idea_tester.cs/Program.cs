using System;
using System.Collections.Generic;
using non_original_idea;

namespace non_original_idea_tester.cs {
	class Program {
		static void Main2() {

			foreach(Subject subject in ConstantsAndPain.Subjects) {

				foreach(Specificity specificity in ConstantsAndPain.Specificities) {

					foreach(Tense tense in ConstantsAndPain.Tenses) {

						var fragment = ConstantsAndPain.GetVerbToBe(
							subject,
							tense,
							specificity
						);

						var adjective = new SentenceFragment("complicated");

						char punctuation = ConstantsAndPain.GetPunctuation(specificity);

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

		static void Main() {

			List<SentenceFragment> fragments = new List<SentenceFragment>();

			fragments.Add(new SentenceFragment("if"));

			fragments.Add(ConstantsAndPain.GetVerbToBe(
				Subject.FirstSingular,
				Tense.ContinuousPast,
				Specificity.NegativeStatement
			));

			fragments.Add(new SentenceFragment("so mean,"));

			fragments.Add(ConstantsAndPain.GetVerbToBe(
				Subject.FirstSingular,
				Tense.ConditionalPerfect,
				Specificity.PositiveQuestion
			));

			fragments.Add(new SentenceFragment("nicer"));

			var sentence = SentenceBuilder.Build(fragments,true,'?');

			Console.WriteLine(sentence);

			Console.ReadKey(true);

		}

		static void Main3() {

			var random = new Random();

			foreach(Specificity specificity in ConstantsAndPain.Specificities) {

				foreach(Tense tense in ConstantsAndPain.ConditionalTenses) {

					List<SentenceFragment> fragments = new List<SentenceFragment>();

					fragments.Add(ConstantsAndPain.GetVerbToBe(
						Subject.ThirdFeminine,
						tense,
						specificity,
						"Kyndrajauna"
					));

					fragments.Add(new SentenceFragment("such a bitch"));
					fragments.Add(new SentenceFragment("if"));

					Tense ifClauseTense = tense;
					switch(tense) {
						case Tense.ConditionalPerfect:
							ifClauseTense = Tense.ConditionalPerfect;
							break;
						default:
						case Tense.ConditionalPresent:
							ifClauseTense = Tense.Plurperfect;
							break;
						case Tense.ContinuousConditionalPresent:
							ifClauseTense = Tense.Past;
							break;
						case Tense.ContinuousConditionalPerfect:
							ifClauseTense = Tense.Past;
							break;

					}

					fragments.Add(ConstantsAndPain.GetVerbToBe(
						Subject.ThirdMasculine,
						ifClauseTense,
						Specificity.NegativeStatement,
						"Sam"
					));

					fragments.Add(new SentenceFragment("so gay"));


					char punctuation = ConstantsAndPain.GetPunctuation(specificity);
					var sentence = SentenceBuilder.Build(fragments,true,punctuation);

					Console.WriteLine(sentence);


				}

			}

			Console.ReadKey(true);

		}
	}
}
