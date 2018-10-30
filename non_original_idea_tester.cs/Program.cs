using System;
using System.Collections.Generic;
using non_original_idea;

namespace non_original_idea_tester.cs {

	using static ConstantsAndPain;

	class Program {

		static void Main() {


			LaughableAutoConjugator();

			BruteForceTest();



			Console.ReadKey(true);
		}


		static void TestContractions() {

			var tests = new List<Tuple<Subject,Tense,Specificity>>();

			tests.Add(new Tuple<Subject,Tense,Specificity>(
				Subject.FirstPlural,Tense.Perfect,Specificity.NegativeStatement
			));

			foreach(var test in tests) {

				var bob = new List<string>();

				bob.Add(GetVerbToBe(test.Item1,test.Item2,test.Item3));

				var sentence = bob.Build('.',true,BasicContractions);

				Console.WriteLine(sentence);
			}

		}


		static void LaughableAutoConjugator() {

			var create = Verb.GenerateUnsafelyAndRegularly("create");
			var shit = Verb.GenerateUnsafelyAndRegularly("shit");
			var hate = Verb.GenerateUnsafelyAndRegularly("hate");

			foreach(Subject subject in Subjects) {

				foreach(Tense tense in Tenses) {

					foreach(Specificity specificity in Specificities) {


						Console.WriteLine(string.Join(',',subject,tense,specificity));

						var bob = new List<string>();

						bob.Add(GetTensedVerb(subject,tense,specificity,hate,null,"happily"));

						bob.Add("zebras");

						bob.Add("because");

						bob.Add(GetTensedVerb(Subject.SecondSingular,Tense.Present,Specificity.PositiveStatement,shit));

						bob.Add("on my cat");

						


						Console.WriteLine(bob.Build(
							startCapital: true,
							punctuation: GetPunctuation(specificity),
							contractions: BasicContractions)
						);

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

						Console.WriteLine(tensified);

						Console.WriteLine();

					}

				}
			}

		}

		static void BruteForceTest() {

			var subject = Subject.FirstSingular;

			var specificity = Specificity.NegativeQuestion;


			//foreach(Subject subject in Subjects) {

			//	foreach(Specificity specificity in Specificities) {

					foreach(Tense tense in Tenses) {

						var bob = new List<string>();

						bob.Add(GetVerbToBe(
							subject,
							tense,
							specificity,
							subjectText: null,
							adverb: "happily"
						));

						bob.Add("dogs");

						char punctuation = GetPunctuation(specificity);

						var sentence1 = bob.Build(punctuation,true,null);

						var sentence2 = bob.Build(punctuation,true,BasicContractions);

						//Console.WriteLine(string.Join("-",subject,specificity,tense));
						Console.WriteLine(sentence1);
						Console.WriteLine(sentence2);
						Console.WriteLine();
					}
			//	}
			//}
		}

		static void BasicConditionalSentenceTest() {

			var fragments = new List<string>();

			fragments.Add("if");

			fragments.Add(GetVerbToBe(
				Subject.FirstSingular,
				Tense.ProgressivePast,
				Specificity.NegativeStatement
			));

			fragments.Add("so mean,");

			fragments.Add(GetVerbToBe(
				Subject.FirstSingular,
				Tense.ConditionalPerfect,
				Specificity.PositiveQuestion
			));

			fragments.Add("nicer");

			var sentence = fragments.Build('?');

			Console.WriteLine(sentence);

		}

	}
}
