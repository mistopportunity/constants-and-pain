using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public static class VerbGenerator {

		public static Verb ConjugateUnsafelyAndRegularly(string flatInfinitive) {


			var presentConjugations = new Dictionary<Subject,string>();
			var pastConjugations = new Dictionary<Subject,string>();


			string gerund;
			string participle;

			string thirdPersonSingular = flatInfinitive + "s";

			var lastLetter = flatInfinitive.Substring(flatInfinitive.Length-1,1);

			switch(lastLetter) {
				case "e":
					gerund = flatInfinitive.Substring(0,flatInfinitive.Length-1) + "ing";
					participle = flatInfinitive + "d";
					break;
				default:
					var stem = flatInfinitive + lastLetter;
					gerund = stem + "ing";
					participle = stem + "ed";
					break;
			}


			foreach(Subject subject in ConstantsAndPain.Subjects) {
				pastConjugations.Add(subject,participle);
				presentConjugations.Add(subject,flatInfinitive);
			}

			foreach(Subject subject in ConstantsAndPain.ThirdPersonSingulars) {
				presentConjugations[subject] = thirdPersonSingular;
			}

			return new Verb(flatInfinitive,gerund,participle,false,true,presentConjugations,pastConjugations);

		}


	}
}
