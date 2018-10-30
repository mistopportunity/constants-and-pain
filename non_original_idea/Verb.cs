using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public sealed class Verb {
		public Verb (
			string flatInfinitive,
			string gerund,string participle,
			bool subjectVerbInversion,
			bool usePastParticiple,
			Dictionary<Subject,string> conjugations,
			Dictionary<Subject,string> pastConjugations
		) {
			this.flatInfinitive = flatInfinitive;
			this.gerund = gerund;
			this.participle = participle;
			this.subjectVerbInversion = subjectVerbInversion;
			this.usePastParticiple = usePastParticiple;
			this.conjugations = conjugations;
			this.pastConjugations = pastConjugations;
		}
		internal readonly string flatInfinitive;
		internal readonly string gerund;
		internal readonly string participle;
		internal readonly bool subjectVerbInversion;
		internal readonly bool usePastParticiple;
		internal readonly Dictionary<Subject,string> conjugations;
		internal readonly Dictionary<Subject,string> pastConjugations;
		//We don't really need to add get accessors. The creator already has these values.

		public static Verb GenerateUnsafelyAndRegularly(string flatInfinitive) {
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
