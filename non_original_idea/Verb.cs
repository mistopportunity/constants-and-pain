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
	}
}
