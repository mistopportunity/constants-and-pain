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

		public static readonly Tense[] ConditionalTenses = new Tense[]{
			Tense.ConditionalPerfect,
			Tense.ConditionalPresent,
			Tense.ContinuousConditionalPerfect,
			Tense.ContinuousConditionalPresent
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

		public static Tense GetRandomConditionalTense(Random random) {
			switch(random.Next(0,4)) {
				default:
				case 0:
					return Tense.ConditionalPresent;
				case 1:
					return Tense.ConditionalPerfect;
				case 2:
					return Tense.ContinuousConditionalPresent;
				case 3:
					return Tense.ContinuousConditionalPerfect;
			}
		}

		public static Tense GetRandomNonConditionalTense(Random random) {
			switch(random.Next(0,12)) {
				case 0:
					return Tense.ContinuousFuture;
				case 1:
					return Tense.ContinuousFuturePerfect;
				case 2:
					return Tense.ContinuousPast;
				case 3:
					return Tense.ContinuousPerfect;
				case 4:
					return Tense.ContinuousPluperfect;
				case 5:
					return Tense.ContinuousPresent;
				case 6:
					return Tense.Future;
				case 7:
					return Tense.FuturePerfect;
				case 8:
					return Tense.Past;
				case 9:
					return Tense.Perfect;
				case 10:
					return Tense.Plurperfect;
				default:
				case 11:
					return Tense.Present;
					
			}
		}

		public static string ConjugateDo(Subject subject) {
			switch(subject) {
				case Subject.ThirdMasculine:
				case Subject.ThirdInanimate:
				case Subject.ThirdFeminine:
					return "does";
				default:
					return "do";
			}
		}

		internal static string TensifyVerb(

			Tense tense,
			Specificity specificity,

			string conjugatedVerb,
			string conjugatedVerbPast,

			string imperfectVerb,
			string participle,
			string flatInfinitive,
			string gerund,
			string subjectText,

			bool questionIncludesSVInversion = true,

			string conjugatedDo = null


		) {
			string result = null;
			switch(specificity) {
				case Specificity.PositiveStatement:
					switch(tense) {
						case Tense.Present:
							result = $"{subjectText} {conjugatedVerb}";
							break;
						case Tense.Past:
							result = $"{subjectText} {conjugatedVerbPast}";
							break;
						case Tense.Imperfect:
							result = $"{subjectText} {imperfectVerb}";
							break;
						case Tense.Perfect:
							result = $"{subjectText} have {participle}";
							break;
						case Tense.Plurperfect:
							result = $"{subjectText} had {participle}";
							break;
						case Tense.FuturePerfect:
							result = $"{subjectText} will have {participle}";
							break;
						case Tense.Future:
							result = $"{subjectText} will {flatInfinitive}";
							break;
						case Tense.ContinuousPresent:
							result = $"{subjectText} {conjugatedVerb} {gerund}";
							break;
						case Tense.ContinuousPluperfect:
							result = $"{subjectText} had been {gerund}";
							break;
						case Tense.ContinuousPerfect:
							result = $"{subjectText} have been {gerund}";
							break;
						case Tense.ContinuousPast:
							result = $"{subjectText} {conjugatedVerbPast} {gerund}";
							break;
						case Tense.ContinuousFuturePerfect:
							result = $"{subjectText} will have been {gerund}";
							break;
						case Tense.ContinuousFuture:
							result = $"{subjectText} will be {gerund}";
							break;
						case Tense.ContinuousConditionalPresent:
							result = $"{subjectText} would be {gerund}";
							break;
						case Tense.ContinuousConditionalPerfect:
							result = $"{subjectText} would have been {gerund}";
							break;
						case Tense.ConditionalPresent:
							result = $"{subjectText} would {flatInfinitive}";
							break;
						case Tense.ConditionalPerfect:
							result = $"{subjectText} would have {participle}";
							break;
					}
					break;
				case Specificity.PositiveQuestion:
					switch(tense) {
						case Tense.Present:
							if(questionIncludesSVInversion) {
								result = $"{conjugatedVerb} {subjectText}";
							} else {
								result = $"{conjugatedDo} {subjectText} {flatInfinitive}";
							}
							break;
						case Tense.Past:
							if(questionIncludesSVInversion) {
								result = $"{conjugatedVerbPast} {subjectText}";
							} else {
								result = $"did {subjectText} {flatInfinitive}";
							}
							break;
						case Tense.Imperfect:
							if(questionIncludesSVInversion) {
								result = $"{imperfectVerb} {subjectText}";
							} else {
								result = $"didded {subjectText} {imperfectVerb}";
							}
							break;
						case Tense.Perfect:
							result = $"have {subjectText} {participle}";
							break;
						case Tense.Plurperfect:
							result = $"had {subjectText} {participle}";
							break;
						case Tense.FuturePerfect:
							result = $"will {subjectText} have {participle}";
							break;
						case Tense.Future:
							result = $"will {subjectText} {flatInfinitive}";
							break;
						case Tense.ContinuousPresent:
							result = $"{conjugatedVerb} {subjectText} {gerund}";
							break;
						case Tense.ContinuousPluperfect:
							result = $"had {subjectText} been {gerund}";
							break;
						case Tense.ContinuousPerfect:
							result = $"have {subjectText} been {gerund}";
							break;
						case Tense.ContinuousPast:
							result = $"{conjugatedVerbPast} {subjectText} {gerund}";
							break;
						case Tense.ContinuousFuturePerfect:
							result = $"will {subjectText} have been {gerund}";
							break;
						case Tense.ContinuousFuture:
							result = $"will {subjectText} be {gerund}";
							break;
						case Tense.ContinuousConditionalPresent:
							result = $"would {subjectText} be {gerund}";
							break;
						case Tense.ContinuousConditionalPerfect:
							result = $"would {subjectText} have been {gerund}";
							break;
						case Tense.ConditionalPresent:
							result = $"would {subjectText} {flatInfinitive}";
							break;
						case Tense.ConditionalPerfect:
							result = $"would {subjectText} have {participle}";
							break;
					}
					break;
				case Specificity.NegativeStatement:
					switch(tense) {
						case Tense.Present:
							result = $"{subjectText} {conjugatedVerb} not";
							break;
						case Tense.Past:
							result = $"{subjectText} {conjugatedVerbPast} not";
							break;
						case Tense.Imperfect:
							result = $"{subjectText} {imperfectVerb} not";
							break;
						case Tense.Perfect:
							result = $"{subjectText} have not {participle}";
							break;
						case Tense.Plurperfect:
							result = $"{subjectText} had not {participle}";
							break;
						case Tense.FuturePerfect:
							result = $"{subjectText} will not have {participle}";
							break;
						case Tense.Future:
							result = $"{subjectText} will not {flatInfinitive}";
							break;
						case Tense.ContinuousPresent:
							result = $"{subjectText} {conjugatedVerb} not {gerund}";
							break;
						case Tense.ContinuousPluperfect:
							result = $"{subjectText} had not been {gerund}";
							break;
						case Tense.ContinuousPerfect:
							result = $"{subjectText} have not been {gerund}";
							break;
						case Tense.ContinuousPast:
							result = $"{subjectText} {conjugatedVerbPast} not {gerund}";
							break;
						case Tense.ContinuousFuturePerfect:
							result = $"{subjectText} will not have been {gerund}";
							break;
						case Tense.ContinuousFuture:
							result = $"{subjectText} will not be {gerund}";
							break;
						case Tense.ContinuousConditionalPresent:
							result = $"{subjectText} would not be {gerund}";
							break;
						case Tense.ContinuousConditionalPerfect:
							result = $"{subjectText} would not have been {gerund}";
							break;
						case Tense.ConditionalPresent:
							result = $"{subjectText} would not {flatInfinitive}";
							break;
						case Tense.ConditionalPerfect:
							result = $"{subjectText} would not have {participle}";
							break;
					}
					break;
				case Specificity.NegativeQuestion:
					switch(tense) {
						case Tense.Present:
							if(questionIncludesSVInversion) {
								result = $"{conjugatedVerb} {subjectText} not";
							} else {
								result = $"{conjugatedDo} {subjectText} not {flatInfinitive}";
							}
							break;
						case Tense.Past:
							if(questionIncludesSVInversion) {
								result = $"{conjugatedVerbPast} {subjectText} not";
							} else {
								result = $"did {subjectText} not {flatInfinitive}";
							}
							break;
						case Tense.Imperfect:
							if(questionIncludesSVInversion) {
								result = $"{imperfectVerb} {subjectText} not";
							} else {
								result = $"didded {subjectText} not {imperfectVerb}";
							}
							break;
						case Tense.Perfect:
							result = $"have {subjectText} not {participle}";
							break;
						case Tense.Plurperfect:
							result = $"had {subjectText} not {participle}";
							break;
						case Tense.FuturePerfect:
							result = $"will {subjectText} have not {participle}";
							break;
						case Tense.Future:
							result = $"will {subjectText} not {flatInfinitive}";
							break;
						case Tense.ContinuousPresent:
							result = $"{conjugatedVerb} {subjectText} not {gerund}";
							break;
						case Tense.ContinuousPluperfect:
							result = $"had {subjectText} not been {gerund}";
							break;
						case Tense.ContinuousPerfect:
							result = $"have {subjectText} not been {gerund}";
							break;
						case Tense.ContinuousPast:
							result = $"{conjugatedVerbPast} {subjectText} not {gerund}";
							break;
						case Tense.ContinuousFuturePerfect:
							result = $"will {subjectText} not have been {gerund}";
							break;
						case Tense.ContinuousFuture:
							result = $"will {subjectText} not be {gerund}";
							break;
						case Tense.ContinuousConditionalPresent:
							result = $"would {subjectText} not be {gerund}";
							break;
						case Tense.ContinuousConditionalPerfect:
							result = $"would {subjectText} not have been {gerund}";
							break;
						case Tense.ConditionalPresent:
							result = $"would {subjectText} {flatInfinitive}";
							break;
						case Tense.ConditionalPerfect:
							result = $"would {subjectText} have {participle}";
							break;
					}
					break;
			}
			return result;
		}

		public static SentenceFragment GetVerbToBePredicate (
			Subject subject,
			Tense tense = Tense.Present,
			Specificity specificity = Specificity.PositiveStatement,
			string subjectText = null
		) {
			string result = null;
			switch(subject) {
				case Subject.FirstSingular:
					subjectText = subjectText != null ? subjectText : "I";
					result = TensifyVerb(tense,specificity,"am","was","were","been","be","being",subjectText);
					break;
				case Subject.FirstPlural:
					subjectText = subjectText != null ? subjectText : "we";
					result = TensifyVerb(tense,specificity,"are","were","were","been","be","being",subjectText);
					break;
				case Subject.SecondSingular:
				case Subject.SecondPlural:
					subjectText = subjectText != null ? subjectText : "you";
					result = TensifyVerb(tense,specificity,"are","were","were","been","be","being",subjectText);
					break;

				case Subject.ThirdMasculine:
					subjectText = subjectText != null ? subjectText : "he";
					result = TensifyVerb(tense,specificity,"is","was","were","been","be","being",subjectText);
					break;
				case Subject.ThirdFeminine:
					subjectText = subjectText != null ? subjectText : "she";
					result = TensifyVerb(tense,specificity,"is","was","were","been","be","being",subjectText);
					break;
				case Subject.ThirdInanimate:
					subjectText = subjectText != null ? subjectText : "it";
					result = TensifyVerb(tense,specificity,"is","was","were","been","be","being",subjectText);
					break;

				case Subject.ThirdNeutral:
				case Subject.ThirdPlural:
					subjectText = subjectText != null ? subjectText : "they";
					result = TensifyVerb(tense,specificity,"are","were","were","been","be","being",subjectText);
					break;
			}
			var flags = FragmentFlags.Predicate;
			switch(tense) {
				case Tense.ConditionalPresent:
				case Tense.ConditionalPerfect:
				case Tense.ContinuousConditionalPresent:
				case Tense.ContinuousConditionalPerfect:
					flags = flags | FragmentFlags.Conditional;
					break;
			}
			switch(tense) {
				case Tense.ContinuousConditionalPresent:
				case Tense.ContinuousConditionalPerfect:
				case Tense.ContinuousPresent:
				case Tense.ContinuousPast:
				case Tense.ContinuousFuture:
				case Tense.ContinuousFuturePerfect:
				case Tense.ContinuousPluperfect:
				case Tense.ContinuousPerfect:
					flags = flags | FragmentFlags.Continuous;
					break;
			}
			return new SentenceFragment(result,FragmentFlags.Predicate);
		}
	}
}
