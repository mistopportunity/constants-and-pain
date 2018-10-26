using System;
using System.Collections.Generic;
using non_original_idea;

namespace non_original_idea_tester.cs {

	using static ConstantsAndPain;

	class Program {

		static void Main() {


			BruteForceTest();



			Console.ReadKey(true);
		}


		static void LaughableAutoConjugator() {

			var create = VerbGenerator.ConjugateUnsafelyAndRegularly("create");
			var shit = VerbGenerator.ConjugateUnsafelyAndRegularly("shit");
			var hate = VerbGenerator.ConjugateUnsafelyAndRegularly("hate");


			foreach(Subject subject in Subjects) {

				foreach(Tense tense in Tenses) {

					foreach(Specificity specificity in Specificities) {


						Console.WriteLine(string.Join(',',subject,tense,specificity));

						var bob = new SentenceBuilder();

						bob.Add(GetTensedVerb(subject,tense,specificity,hate));

						bob.Add("zebras");

						bob.Add("because");

						bob.Add(GetTensedVerb(Subject.SecondSingular,Tense.Present,Specificity.PositiveStatement,shit));

						bob.Add("on my cat");


						Console.WriteLine(bob.Build(true,GetPunctuation(specificity)));

						Console.WriteLine();

					}


				}


			}


		}


		static void CustomVerbsTest() {


			var presentConjugations = new Dictionary<Subject,string>();
			var pastConjugations = new Dictionary<Subject,string>();

			//Applying the base
			foreach(Subject subject in Subjects) {
				pastConjugations.Add(subject,"created");
				presentConjugations.Add(subject,"create");
			}
			//Applying irregulars
			foreach(Subject subject in ThirdPersonSingulars) {
				presentConjugations[subject] = "creates";
			}


			var createVerb = new Verb("create","creating","created",false,true,presentConjugations,pastConjugations);

			foreach(Tense tense in Tenses) {
				foreach(Specificity specificity in Specificities) {

					foreach(Subject subject in Subjects) {

						var tensified = GetTensedVerb(
							subject,tense,specificity,createVerb
						);

						Console.WriteLine(string.Join(',',tense,specificity,subject));

						Console.WriteLine(tensified.Text);

						Console.WriteLine();

					}

				}
			}


		}

		static void BruteForceTest() {

			foreach(Subject subject in Subjects) {

				foreach(Specificity specificity in Specificities) {

					foreach(Tense tense in Tenses) {

						var fragment = GetVerbToBe(
							subject,
							tense,
							specificity
						);

						var adjective = new SentenceFragment("constipated");

						char punctuation = GetPunctuation(specificity);

						var sentence = SentenceBuilder.Build(
							punctuation,
							fragment,
							adjective
						);
						Console.WriteLine(sentence);
					}
				}
			}
		}

		static void BasicConditionalSentenceTest() {

			List<SentenceFragment> fragments = new List<SentenceFragment>();

			fragments.Add(new SentenceFragment("if"));

			fragments.Add(GetVerbToBe(
				Subject.FirstSingular,
				Tense.ContinuousPast,
				Specificity.NegativeStatement
			));

			fragments.Add(new SentenceFragment("so mean,"));

			fragments.Add(GetVerbToBe(
				Subject.FirstSingular,
				Tense.ConditionalPerfect,
				Specificity.PositiveQuestion
			));

			fragments.Add(new SentenceFragment("nicer"));

			var sentence = SentenceBuilder.Build(fragments,true,'?');

			Console.WriteLine(sentence);

		}

		static void ConditionalBlendTest() {

			var random = new Random();

			foreach(Specificity specificity in Specificities) {

				foreach(Tense tense in ConditionalTenses) {

					List<SentenceFragment> fragments = new List<SentenceFragment>();

					fragments.Add(GetVerbToBe(
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

					fragments.Add(GetVerbToBe(
						Subject.ThirdMasculine,
						ifClauseTense,
						Specificity.NegativeStatement,
						"Sam"
					));

					fragments.Add(new SentenceFragment("so gay"));


					char punctuation = GetPunctuation(specificity);
					var sentence = SentenceBuilder.Build(fragments,true,punctuation);

					Console.WriteLine(sentence);


				}

			}

		}
	}
}
