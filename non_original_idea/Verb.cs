using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public sealed class Verb {
		public Verb (
			string flatInfinitive,
			string gerund,string participle,
			string imperfect,
			bool subjectVerbInversion,
			Dictionary<Subject,string> conjugations,
			Dictionary<Subject,string> pastConjugations
		) {
			this.flatInfinitive = flatInfinitive;
			this.gerund = gerund;
			this.participle = participle;
			this.imperfect = imperfect;
			this.subjectVerbInversion = subjectVerbInversion;
			this.conjugations = conjugations;
			this.pastConjugations = pastConjugations;
		}
		internal readonly string flatInfinitive;
		internal readonly string gerund;
		internal readonly string participle;
		internal readonly string imperfect;
		internal readonly bool subjectVerbInversion;
		internal readonly Dictionary<Subject,string> conjugations;
		internal readonly Dictionary<Subject,string> pastConjugations;

		//We don't really need to add get accessors. The creator already has these values.
	}
}
