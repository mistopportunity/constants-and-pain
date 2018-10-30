using System;
using System.Text;

//For the love of God, don't evaluate this file.
//Don't even look at it. Stop. While you can. I can't save you...
//Save yourself.

namespace non_original_idea {

	public static class ConstantsAndPain {

		public static readonly Array Subjects = Enum.GetValues(typeof(Subject));
		public static readonly Array Specificities = Enum.GetValues(typeof(Specificity));
		public static readonly Array Tenses = Enum.GetValues(typeof(Tense));

		private const string NegativeAbleVerbChain = "would|will|did|does|do|could|had|is|must|was|have|are|were";

		private const string BasicPronounsChain = "they|I|it|you|they|he|she";

		private const string NegativeContractionLookAhead = "(?:(?!'ve|'nt|n't))"; //In case you forget, ?: denotes a non-capturing group

		public static readonly Contraction[] BasicContractions = {
			//The top down order is the priority
			new Contraction("{0}n't",$"({NegativeAbleVerbChain}) not"),
			new Contraction("{0}'ve",$"(I|you|we|could|would|should|might|must) have{NegativeContractionLookAhead}"),
			new Contraction("{0}n't {1}",$@"({NegativeAbleVerbChain}) (\S*) not"),

			new Contraction("{0}'ll",$"({BasicPronounsChain}) will{NegativeContractionLookAhead}"),
			new Contraction("won't","willn't",isFormatter: false), //Thanks, English

			new Contraction("{0}'d",$"({BasicPronounsChain}) would{NegativeContractionLookAhead}"),

			new Contraction("{0}'re",$"(they|we|you) are{NegativeContractionLookAhead}"),
			new Contraction("{0}'s",$"(it|she|he|how) is{NegativeContractionLookAhead}"),
			new Contraction("{0}'d",$"(why|how) did{NegativeContractionLookAhead}"),

			new Contraction("I'm","I am",isFormatter: false),
			new Contraction("let's","let us",isFormatter: false),

			new Contraction("can't","cannot",isFormatter: false)
		};

		public static readonly Subject[] ThirdPersonSingulars = {
			Subject.ThirdFeminine,Subject.ThirdInanimate,Subject.ThirdMasculine
		};

		public static char GetPunctuation(Specificity specificity) {
			switch(specificity) {
				default:
				case Specificity.PositiveStatement:
				case Specificity.NegativeStatement:
					return '.';
				case Specificity.PositiveQuestion:
				case Specificity.NegativeQuestion:
					return '?';
			}
		}

		internal static string GetConjugatedHave(Subject subject) {
			switch(subject) {
				case Subject.ThirdMasculine:
				case Subject.ThirdInanimate:
				case Subject.ThirdFeminine:
					return "has";
				default:
					return "have";
			}
		}

		//Doesn't include the past tense because it's always the same thing: did
		internal static string GetConjugatedDo(Subject subject) {
			switch(subject) {
				case Subject.ThirdMasculine:
				case Subject.ThirdInanimate:
				case Subject.ThirdFeminine:
					return "does";
				default:
					return "do";
			}
		}

		internal static string GetDefaultSubjectText(Subject subject) {
			switch(subject) {
				case Subject.FirstSingular:
					return "I";
				case Subject.FirstPlural:
					return "we";
				case Subject.SecondPlural:
				case Subject.SecondSingular:
					return "you";
				case Subject.ThirdFeminine:
					return "she";
				default:
				case Subject.ThirdInanimate:
					return "it";
				case Subject.ThirdMasculine:
					return "he";
				case Subject.ThirdNeutral:
				case Subject.ThirdPlural:
					return "they";
			}
		}

		internal static string GetVerbToBeFlat(Subject subject) {
			switch(subject) {
				case Subject.FirstSingular:
					return "am";
				case Subject.FirstPlural:
				case Subject.SecondPlural:
				case Subject.SecondSingular:
				case Subject.ThirdNeutral:
				case Subject.ThirdPlural:
					return "are";
				default:
				case Subject.ThirdFeminine:
				case Subject.ThirdInanimate:
				case Subject.ThirdMasculine:
					return "is";
			}
		}

		internal static string GetVerbToBeFlatPast(Subject subject) {
			switch(subject) {
				case Subject.FirstPlural:
				case Subject.SecondPlural:
				case Subject.SecondSingular:
				case Subject.ThirdNeutral:
				case Subject.ThirdPlural:
					return "were";
				default:
				case Subject.FirstSingular:
				case Subject.ThirdFeminine:
				case Subject.ThirdInanimate:
				case Subject.ThirdMasculine:
					return "was";
			}
		}

		public static string GetTensedVerb (
			Subject subject,
			Tense tense,
			Specificity specificity,
			Verb verb,
			string subjectText = null,
			string adverb = null
		) {
			if(subjectText == null) {
				subjectText = GetDefaultSubjectText(subject);
			}
			return GetTensedVerb(
				tense,
				specificity,
				verb.conjugations[subject],
				verb.pastConjugations[subject],
				verb.participle,
				verb.flatInfinitive,
				verb.gerund,
				subjectText,
				verb.subjectVerbInversion,
				(verb.subjectVerbInversion ? null : GetConjugatedDo(subject)),
				GetConjugatedHave(subject),
				GetVerbToBeFlat(subject),
				GetVerbToBeFlatPast(subject),
				verb.usePastParticiple,
				adverb
			);
		}

		internal static string GetTensedVerb (
			Tense tense,
			Specificity specificity,

			string conjugatedVerb,
			string conjugatedVerbPast,

			string participle,
			string flatInfinitive,
			string gerund,

			string subjectText,

			bool questionIncludesSVInversion,

			string conjugatedDo,
			string conjugatedHave,

			string conjugatedVerbToBe,
			string conjugatedVerbToBePast,

			bool flatInfinitiveIsRegular,

			string adverb

		) {
			string sfa = string.Empty; //Space followed adverb
			string sta = string.Empty; //Space trailed adverb
			if(adverb != null) {
				sfa = $" {adverb}";
				sta = $"{adverb} ";
			}

			bool isQuestion = specificity == Specificity.PositiveQuestion || specificity == Specificity.NegativeQuestion;
			string not = specificity == Specificity.NegativeStatement || specificity == Specificity.NegativeQuestion ? " not" : string.Empty;

			switch(isQuestion) {
				default:
				case false:
					switch(tense) {
						default:
						case Tense.Present:
							if(flatInfinitiveIsRegular) {
								return $"{subjectText} {conjugatedDo}{not} {sta}{flatInfinitive}";
							} else {
								return $"{subjectText} {conjugatedVerb}{not}{sfa}";
							}
						case Tense.Past:
							if(flatInfinitiveIsRegular) {
								return $"{subjectText} did{not} {sta}{flatInfinitive}";
							} else {
								return $"{subjectText} {conjugatedVerbPast}{not}{sfa}";
							}
						case Tense.Imperfect:
							return $"{subjectText} did{not} used to {sta}{flatInfinitive}";
						case Tense.Perfect:
							return $"{subjectText} {conjugatedHave}{not} {sta}{participle}";
						case Tense.Pluperfect:
							return $"{subjectText} had{not} {sta}{participle}";
						case Tense.FuturePerfect:
							return $"{subjectText} will{not} have {sta}{participle}";
						case Tense.Future:
							return $"{subjectText} will{not} {sta}{flatInfinitive}";
						case Tense.FutureInformal:
							return $"{subjectText} will{not} be{sfa} going to {flatInfinitive}";
						case Tense.ProgressivePresent:
							return $"{subjectText} {conjugatedVerbToBe}{not} {sta}{gerund}";
						case Tense.ProgressivePluperfect:
							return $"{subjectText} had{not} been {sta}{gerund}";
						case Tense.ProgressivePerfect:
							return $"{subjectText} {conjugatedHave}{not} been {sta}{gerund}";
						case Tense.ProgressivePast:
							return $"{subjectText} {conjugatedVerbToBePast}{not} {sta}{gerund}";
						case Tense.ProgressiveFuturePerfect:
							return $"{subjectText} will{not} have been {sta}{gerund}";
						case Tense.ProgressiveFuture:
							return $"{subjectText} will{not} be {sta}{gerund}";
						case Tense.ProgressiveConditionalPresent:
							return $"{subjectText} would{not} be {sta}{gerund}";
						case Tense.ProgressiveConditionalPerfect:
							return $"{subjectText} would{not} have been {sta}{gerund}";
						case Tense.ConditionalPresent:
							return $"{subjectText} would{not} {sta}{flatInfinitive}";
						case Tense.ConditionalPerfect:
							return $"{subjectText} would{not} have {sta}{participle}";
						case Tense.PossiblePresent:
							return $"{subjectText} cannot {sta}{flatInfinitive}";
						case Tense.PossiblePast:
							return $"{subjectText} could{not} {sta}{flatInfinitive}";
						case Tense.PossibleFuture:
							return $"{subjectText} might{not} {sta}{flatInfinitive}";
						case Tense.PossiblePerfect:
							return $"{subjectText} could{not} have {sta}{participle}";
						case Tense.PossibleImperfect:
							return $"{subjectText} used to{not} be able to {sta}{flatInfinitive}";
						case Tense.PossibleFutureImformal:
							return $"{subjectText} cannot go {sta}{flatInfinitive}";
						case Tense.ProgressivePossiblePresent:
							return $"{subjectText} could{not} be {sta}{gerund}";
						case Tense.ProgressivePossiblePerfect:
							return $"{subjectText} could{not} have been {sta}{gerund}";
						case Tense.AdvisoryPresent:
							return $"{subjectText} should{not} {sta}{flatInfinitive}";
						case Tense.AdvisoryPerfect:
							return $"{subjectText} should{not} have {sta}{participle}";
						case Tense.ProgressiveAdvisoryPresent:
							return $"{subjectText} should{not} be {sta}{gerund}";
						case Tense.ProgressiveAdvisoryPerfect:
							return $"{subjectText} should{not} have been {sta}{gerund}";
						case Tense.PermissivePresent:
							return $"{subjectText} may{not} {sta}{flatInfinitive}";
						case Tense.PermissivePerfect:
							return $"{subjectText} may{not} have {sta}{participle}";
						case Tense.ProgressivePermissivePresent:
							return $"{subjectText} may{not} be {sta}{gerund}";
						case Tense.ProgressivePermissivePerfect:
							return $"{subjectText} may{not} have been {sta}{gerund}";
						case Tense.ObligatePresent:
							return $"{subjectText} must{not} {sta}{flatInfinitive}";
						case Tense.ObligatePast:
							return $"{subjectText} had to{not} {sta}{flatInfinitive}";
						case Tense.ObligatePerfect:
							return $"{subjectText} must{not} have {sta}{participle}";
						case Tense.ProgressiveObligatePresent:
							return $"{subjectText} must{not} be {sta}{gerund}";
						case Tense.ProgressiveObligatePerfect:
							return $"{subjectText} must{not} have been {sta}{gerund}";
						case Tense.ObligateImperfect:
							return $"{subjectText} used to{not} have to {sta}{flatInfinitive}";
						case Tense.ObligatePresentInformal:
							return $"{subjectText} {conjugatedHave} to{not} {sta}{flatInfinitive}";
						case Tense.ObligateFuture:
							return $"{subjectText} {conjugatedVerbToBe} going to have to{not} {sta}{flatInfinitive}";
					}
				case true:
					switch(tense) {
						default:
						case Tense.Present:
							if(questionIncludesSVInversion) {
								return $"{conjugatedVerb} {subjectText}{not}{sfa}";
							} else {
								return $"{conjugatedDo} {subjectText}{not} {sta}{flatInfinitive}";
							}
						case Tense.Past:
							if(questionIncludesSVInversion) {
								return $"{conjugatedVerbPast} {subjectText}{not}{sfa}";
							} else {
								return $"did {subjectText}{not} {sta}{flatInfinitive}";
							}
						case Tense.Imperfect:
							return $"did {subjectText}{not} used to {sta}{flatInfinitive}";
						case Tense.Perfect:
							return $"{conjugatedHave} {subjectText}{not} {sta}{participle}";
						case Tense.Pluperfect:
							return $"had {subjectText}{not} {sta}{participle}";
						case Tense.FuturePerfect:
							return $"will {subjectText}{not} have {sta}{participle}";
						case Tense.Future:
							return $"will {subjectText}{not} {sta}{flatInfinitive}";
						case Tense.FutureInformal:
							return $"will {subjectText}{not} be{sfa} going to {flatInfinitive}";
						case Tense.ProgressivePresent:
							return $"{conjugatedVerbToBe} {subjectText}{not} {sta}{gerund}";
						case Tense.ProgressivePluperfect:
							return $"had {subjectText}{not} been {sta}{gerund}";
						case Tense.ProgressivePerfect:
							return $"{conjugatedHave} {subjectText}{not} been {sta}{gerund}";
						case Tense.ProgressivePast:
							return $"{conjugatedVerbToBePast} {subjectText}{not} {sta}{gerund}";
						case Tense.ProgressiveFuturePerfect:
							return $"will {subjectText}{not} have been {sta}{gerund}";
						case Tense.ProgressiveFuture:
							return $"will {subjectText}{not} be {sta}{gerund}";
						case Tense.ProgressiveConditionalPresent:
							return $"would {subjectText}{not} be {sta}{gerund}";
						case Tense.ProgressiveConditionalPerfect:
							return $"would {subjectText}{not} have been {sta}{gerund}";
						case Tense.ConditionalPresent:
							return $"would {subjectText} {sta}{flatInfinitive}";
						case Tense.ConditionalPerfect:
							return $"would {subjectText} have {sta}{participle}";
						case Tense.PossiblePresent:
							return $"can {subjectText}{not} {sta}{flatInfinitive}";
						case Tense.PossiblePast:
							return $"could {subjectText}{not} {sta}{flatInfinitive}";
						case Tense.PossibleFuture:
							return $"might {subjectText}{not} {sta}{flatInfinitive}";
						case Tense.PossiblePerfect:
							return $"could {subjectText}{not} have {sta}{participle}";
						case Tense.PossibleImperfect:
							return $"did {subjectText}{not} used to be able to {sta}{flatInfinitive}";
						case Tense.PossibleFutureImformal:
							return $"can {subjectText}{not} go {sta}{flatInfinitive}";
						case Tense.ProgressivePossiblePresent:
							return $"can {subjectText}{not} be {sta}{gerund}";
						case Tense.ProgressivePossiblePerfect:
							return $"could {subjectText}{not} have been {sta}{gerund}";
						case Tense.AdvisoryPresent:
							return $"should {subjectText}{not} {sta}{flatInfinitive}";
						case Tense.AdvisoryPerfect:
							return $"should {subjectText}{not} have {sta}{participle}";
						case Tense.ProgressiveAdvisoryPresent:
							return $"should {subjectText}{not} be {sta}{gerund}";
						case Tense.ProgressiveAdvisoryPerfect:
							return $"should {subjectText}{not} have been {sta}{gerund}";
						case Tense.PermissivePresent:
							return $"may {subjectText}{not} {sta}{flatInfinitive}";
						case Tense.PermissivePerfect:
							return $"may {subjectText}{not} have {sta}{participle}";
						case Tense.ProgressivePermissivePresent:
							return $"may {subjectText}{not} be {sta}{gerund}";
						case Tense.ProgressivePermissivePerfect:
							return $"may {subjectText}{not} have been {sta}{gerund}";
						case Tense.ObligatePresent:
							return $"must {subjectText}{not} have to {sta}{flatInfinitive}";
						case Tense.ObligatePast:
							return $"must {subjectText}{not} have had to {sta}{flatInfinitive}";
						case Tense.ObligatePerfect:
							return $"must {subjectText}{not} have to have {sta}{participle}";
						case Tense.ProgressiveObligatePresent:
							return $"must {subjectText}{not} be {sta}{gerund}";
						case Tense.ProgressiveObligatePerfect:
							return $"must {subjectText}{not} have been {sta}{gerund}";
						case Tense.ObligateImperfect:
							return $"did {subjectText}{not} used to have to {sta}{flatInfinitive}";
						case Tense.ObligatePresentInformal:
							return $"{conjugatedDo} {subjectText}{not} have to {sta}{flatInfinitive}";
						case Tense.ObligateFuture:
							return $"{conjugatedVerbToBe} {subjectText}{not} going to have to {sta}{flatInfinitive}";
					}
			}
		}

		public static string GetVerbToBe (
			Subject subject,
			Tense tense = Tense.Present,
			Specificity specificity = Specificity.PositiveStatement,
			string subjectText = null,
			string adverb = null,
			string gerundVerb = null
		) {

			var adverbArgument = gerundVerb != null ? null : adverb;

			string result = null;
			switch(subject) {
				case Subject.FirstSingular:
					subjectText = subjectText != null ? subjectText : "I";
					result = GetTensedVerb(tense,specificity,"am","was","been","be","being",subjectText,true,"do","have","am","was",false,adverbArgument);
					break;
				case Subject.FirstPlural:
					subjectText = subjectText != null ? subjectText : "we";
					result = GetTensedVerb(tense,specificity,"are","were","been","be","being",subjectText,true,"do","have","are","were",false,adverbArgument);
					break;
				case Subject.SecondSingular:
				case Subject.SecondPlural:
					subjectText = subjectText != null ? subjectText : "you";
					result = GetTensedVerb(tense,specificity,"are","were","been","be","being",subjectText,true,"do","have","are","were",false,adverbArgument);
					break;

				case Subject.ThirdMasculine:
					subjectText = subjectText != null ? subjectText : "he";
					goto default;
				case Subject.ThirdFeminine:
					subjectText = subjectText != null ? subjectText : "she";
					goto default;
				case Subject.ThirdInanimate:
					subjectText = subjectText != null ? subjectText : "it";
					goto default;

				default:
					result = GetTensedVerb(tense,specificity,"is","was","been","be","being",subjectText,true,"do","has","is","was",false,adverbArgument);
					break;

				case Subject.ThirdNeutral:
				case Subject.ThirdPlural:
					subjectText = subjectText != null ? subjectText : "they";
					result = GetTensedVerb(tense,specificity,"are","were","been","be","being",subjectText,true,"do","have","are","were",false,adverbArgument);
					break;
			}

			if(gerundVerb != null) {
				result += $" {(adverb != null ? $"{adverb} " : "")}{gerundVerb}";
			}

			return result;
		}

	}
}
