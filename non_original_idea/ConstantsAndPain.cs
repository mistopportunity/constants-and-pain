﻿using System;
using System.Text;

//For the love of God, don't evaluate this file.
//Don't even look at it. Stop. While you can. I can't save you...
//Save yourself.

namespace non_original_idea {

	public static class ConstantsAndPain {

		public static readonly Array Subjects = Enum.GetValues(typeof(Subject));
		public static readonly Array Specificities = Enum.GetValues(typeof(Specificity));
		public static readonly Array Tenses = Enum.GetValues(typeof(Tense));

		public static readonly Subject[] ThirdPersonSingulars = new Subject[] {
			Subject.ThirdFeminine,Subject.ThirdInanimate,Subject.ThirdMasculine
		};


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

		public static SentenceFragment GetTensedVerb (
			Subject subject,
			Tense tense,
			Specificity specificity,
			Verb verb,
			string subjectText = null
		) {
			if(subjectText == null) {
				subjectText = GetDefaultSubjectText(subject);
			}
			return new SentenceFragment(GetTensedVerb(
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
				verb.usePastParticiple
			));
		}

		internal static string GetTensedVerb(
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

			bool simplePastUseParticiple

		) {
			switch(specificity) {
				default:
				case Specificity.PositiveStatement:
					switch(tense) {
						default:
						case Tense.Present:
							return $"{subjectText} {conjugatedVerb}";
						case Tense.Past:
							if(simplePastUseParticiple) {
								return $"{subjectText} {participle}";
							} else {
								return $"{subjectText} {conjugatedVerbPast}";
							}
						case Tense.Imperfect:
							return $"{subjectText} used to {flatInfinitive}";
						case Tense.Perfect:
							return $"{subjectText} {conjugatedHave} {participle}";
						case Tense.Plurperfect:
							return $"{subjectText} had {participle}";
						case Tense.FuturePerfect:
							return $"{subjectText} will have {participle}";
						case Tense.Future:
							return $"{subjectText} will {flatInfinitive}";
						case Tense.ContinuousPresent:
							return $"{subjectText} {conjugatedVerbToBe} {gerund}";
						case Tense.ContinuousPluperfect:
							return $"{subjectText} had been {gerund}";
						case Tense.ContinuousPerfect:
							return $"{subjectText} {conjugatedHave} been {gerund}";
						case Tense.ContinuousPast:
							return $"{subjectText} {conjugatedVerbToBePast} {gerund}";
						case Tense.ContinuousFuturePerfect:
							return $"{subjectText} will have been {gerund}";
						case Tense.ContinuousFuture:
							return $"{subjectText} will be {gerund}";
						case Tense.ContinuousConditionalPresent:
							return $"{subjectText} would be {gerund}";
						case Tense.ContinuousConditionalPerfect:
							return $"{subjectText} would have been {gerund}";
						case Tense.ConditionalPresent:
							return $"{subjectText} would {flatInfinitive}";
						case Tense.ConditionalPerfect:
							return $"{subjectText} would have {participle}";
					}
				case Specificity.PositiveQuestion:
					switch(tense) {
						default:
						case Tense.Present:
							if(questionIncludesSVInversion) {
								return $"{conjugatedVerb} {subjectText}";
							} else {
								return $"{conjugatedDo} {subjectText} {flatInfinitive}";
							}
						case Tense.Past:
							if(questionIncludesSVInversion) {
								return $"{conjugatedVerbPast} {subjectText}";
							} else {
								return $"did {subjectText} {flatInfinitive}";
							}
						case Tense.Imperfect:
							return $"did {subjectText} used to {flatInfinitive}";
						case Tense.Perfect:
							return $"{conjugatedHave} {subjectText} {participle}";
						case Tense.Plurperfect:
							return $"had {subjectText} {participle}";
						case Tense.FuturePerfect:
							return $"will {subjectText} have {participle}";
						case Tense.Future:
							return $"will {subjectText} {flatInfinitive}";
						case Tense.ContinuousPresent:
							return $"{conjugatedVerbToBe} {subjectText} {gerund}";
						case Tense.ContinuousPluperfect:
							return $"had {subjectText} been {gerund}";
						case Tense.ContinuousPerfect:
							return $"{conjugatedHave} {subjectText} been {gerund}";
						case Tense.ContinuousPast:
							return $"{conjugatedVerbToBePast} {subjectText} {gerund}";
						case Tense.ContinuousFuturePerfect:
							return $"will {subjectText} have been {gerund}";
						case Tense.ContinuousFuture:
							return $"will {subjectText} be {gerund}";
						case Tense.ContinuousConditionalPresent:
							return $"would {subjectText} be {gerund}";
						case Tense.ContinuousConditionalPerfect:
							return $"would {subjectText} have been {gerund}";
						case Tense.ConditionalPresent:
							return $"would {subjectText} {flatInfinitive}";
						case Tense.ConditionalPerfect:
							return $"would {subjectText} have {participle}";
					}
				case Specificity.NegativeStatement:
					switch(tense) {
						default:
						case Tense.Present:
							return $"{subjectText} {conjugatedDo} not {flatInfinitive}";
						case Tense.Past:
							if(simplePastUseParticiple) {
								return $"{subjectText} did not {flatInfinitive}";
							} else {
								return $"{subjectText} {conjugatedVerbPast} not";
							}
						case Tense.Imperfect:
							return $"{subjectText} did not used to {flatInfinitive}";
						case Tense.Perfect:
							return $"{subjectText} {conjugatedHave} not {participle}";
						case Tense.Plurperfect:
							return $"{subjectText} had not {participle}";
						case Tense.FuturePerfect:
							return $"{subjectText} will not have {participle}";
						case Tense.Future:
							return $"{subjectText} will not {flatInfinitive}";
						case Tense.ContinuousPresent:
							return $"{subjectText} {conjugatedVerbToBe} not {gerund}";
						case Tense.ContinuousPluperfect:
							return $"{subjectText} had not been {gerund}";
						case Tense.ContinuousPerfect:
							return $"{subjectText} {conjugatedHave} not been {gerund}";
						case Tense.ContinuousPast:
							return $"{subjectText} {conjugatedVerbToBePast} not {gerund}";
						case Tense.ContinuousFuturePerfect:
							return $"{subjectText} will not have been {gerund}";
						case Tense.ContinuousFuture:
							return $"{subjectText} will not be {gerund}";
						case Tense.ContinuousConditionalPresent:
							return $"{subjectText} would not be {gerund}";
						case Tense.ContinuousConditionalPerfect:
							return $"{subjectText} would not have been {gerund}";
						case Tense.ConditionalPresent:
							return $"{subjectText} would not {flatInfinitive}";
						case Tense.ConditionalPerfect:
							return $"{subjectText} would not have {participle}";
					}
				case Specificity.NegativeQuestion:
					switch(tense) {
						default:
						case Tense.Present:
							if(questionIncludesSVInversion) {
								return $"{conjugatedVerb} {subjectText} not";
							} else {
								return $"{conjugatedDo} {subjectText} not {flatInfinitive}";
							}
						case Tense.Past:
							if(questionIncludesSVInversion) {
								return $"{conjugatedVerbPast} {subjectText} not";
							} else {
								return $"did {subjectText} not {flatInfinitive}";
							}
						case Tense.Imperfect:
							return $"did {subjectText} not used to {flatInfinitive}";
						case Tense.Perfect:
							return $"{conjugatedHave} {subjectText} not {participle}";
						case Tense.Plurperfect:
							return $"had {subjectText} not {participle}";
						case Tense.FuturePerfect:
							return $"will {subjectText} have not {participle}";
						case Tense.Future:
							return $"will {subjectText} not {flatInfinitive}";
						case Tense.ContinuousPresent:
							return $"{conjugatedVerbToBe} {subjectText} not {gerund}";
						case Tense.ContinuousPluperfect:
							return $"had {subjectText} not been {gerund}";
						case Tense.ContinuousPerfect:
							return $"{conjugatedHave} {subjectText} not been {gerund}";
						case Tense.ContinuousPast:
							return $"{conjugatedVerbToBePast} {subjectText} not {gerund}";
						case Tense.ContinuousFuturePerfect:
							return $"will {subjectText} not have been {gerund}";
						case Tense.ContinuousFuture:
							return $"will {subjectText} not be {gerund}";
						case Tense.ContinuousConditionalPresent:
							return $"would {subjectText} not be {gerund}";
						case Tense.ContinuousConditionalPerfect:
							return $"would {subjectText} not have been {gerund}";
						case Tense.ConditionalPresent:
							return $"would {subjectText} {flatInfinitive}";
						case Tense.ConditionalPerfect:
							return $"would {subjectText} have {participle}";
					}
			}
		}

		public static SentenceFragment GetVerbToBe (
			Subject subject,
			Tense tense = Tense.Present,
			Specificity specificity = Specificity.PositiveStatement,
			string subjectText = null,
			Verb gerundVerb = null
		) {
			string result = null;
			switch(subject) {
				case Subject.FirstSingular:
					subjectText = subjectText != null ? subjectText : "I";
					result = GetTensedVerb(tense,specificity,"am","was","been","be","being",subjectText,true,"do","have","am","was",false);
					break;
				case Subject.FirstPlural:
					subjectText = subjectText != null ? subjectText : "we";
					result = GetTensedVerb(tense,specificity,"are","were","been","be","being",subjectText,true,"do","have","are","were",false);
					break;
				case Subject.SecondSingular:
				case Subject.SecondPlural:
					subjectText = subjectText != null ? subjectText : "you";
					result = GetTensedVerb(tense,specificity,"are","were","been","be","being",subjectText,true,"do","have","are","were",false);
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
					result = GetTensedVerb(tense,specificity,"is","was","been","be","being",subjectText,true,"do","has","is","was",false);
					break;

				case Subject.ThirdNeutral:
				case Subject.ThirdPlural:
					subjectText = subjectText != null ? subjectText : "they";
					result = GetTensedVerb(tense,specificity,"are","were","been","be","being",subjectText,true,"do","have","is","were",false);
					break;
			}

			if(gerundVerb != null) {
				result += $" {gerundVerb.gerund}";
			}

			FragmentFlags flags = FragmentFlags.None;
			if(tense.IsConditionalTense()) {
				flags = flags | FragmentFlags.Conditional;
			}
			if(tense.IsContinuousTense()) {
				flags = flags | FragmentFlags.Continuous;
			}
			return new SentenceFragment(result,flags);
		}
		internal static bool IsConditionalTense(this Tense tense) {
			switch(tense) {
				case Tense.ConditionalPresent:
				case Tense.ConditionalPerfect:
				case Tense.ContinuousConditionalPresent:
				case Tense.ContinuousConditionalPerfect:
					return true;
				default:
					return false;
			}
		}
		internal static bool IsContinuousTense(this Tense tense) {
			switch(tense) {
				case Tense.ContinuousConditionalPresent:
				case Tense.ContinuousConditionalPerfect:
				case Tense.ContinuousPresent:
				case Tense.ContinuousPast:
				case Tense.ContinuousFuture:
				case Tense.ContinuousFuturePerfect:
				case Tense.ContinuousPluperfect:
				case Tense.ContinuousPerfect:
					return true;
				default:
					return false;
			}
		}
	}
}
