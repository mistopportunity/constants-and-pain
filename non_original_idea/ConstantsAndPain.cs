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
					switch(tense) {
						case Tense.Present:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} am";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} am not";
									break;
								case Specificity.PositiveQuestion:
									result = $"am {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"am {subjectText} not";
									break;
							}
							break;
						case Tense.Perfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} have not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"have {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"have {subjectText} not been";
									break;
							}
							break;
						case Tense.Plurperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been";
									break;
							}
							break;
						case Tense.Past:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} was";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} was not";
									break;
								case Specificity.PositiveQuestion:
									result = $"was {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"was {subjectText} not";
									break;
							}
							break;
						case Tense.FuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been";
									break;
							}
							break;
						case Tense.Future:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be";
									break;
							}
							break;
						case Tense.ContinuousPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} am being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} am not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"am {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"am {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPluperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been being";
									break;
							}
							break;
						case Tense.ContinuousPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPast:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} am being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} am not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"am {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"am {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousFuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ContinuousFuture:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be";
									break;
							}
							break;
						case Tense.ConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been";
									break;
							}
							break;
					}
					break;
				case Subject.FirstPlural:
					subjectText = subjectText != null ? subjectText : "we";
					switch(tense) {
						case Tense.Present:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} are";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} are not";
									break;
								case Specificity.PositiveQuestion:
									result = $"are {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"are {subjectText} not";
									break;
							}
							break;
						case Tense.Perfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} have not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"have {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"have {subjectText} not been";
									break;
							}
							break;
						case Tense.Plurperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been";
									break;
							}
							break;
						case Tense.Past:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} were";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} were not";
									break;
								case Specificity.PositiveQuestion:
									result = $"were {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"were {subjectText} not";
									break;
							}
							break;
						case Tense.FuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been";
									break;
							}
							break;
						case Tense.Future:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be";
									break;
							}
							break;
						case Tense.ContinuousPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} are being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} are not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"are {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"are {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPluperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been being";
									break;
							}
							break;
						case Tense.ContinuousPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPast:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} were being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} were not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"were {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"were {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousFuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ContinuousFuture:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be";
									break;
							}
							break;
						case Tense.ConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been";
									break;
							}
							break;
					}
					break;
				case Subject.SecondSingular:
				case Subject.SecondPlural:
					subjectText = subjectText != null ? subjectText : "you";
					SecondSubjectCase:
					switch(tense) {
						case Tense.Present:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} are";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} are not";
									break;
								case Specificity.PositiveQuestion:
									result = $"are {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"are {subjectText} not";
									break;
							}
							break;
						case Tense.Perfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} have not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"have {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"have {subjectText} not been";
									break;
							}
							break;
						case Tense.Plurperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been";
									break;
							}
							break;
						case Tense.Past:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} were";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} were not";
									break;
								case Specificity.PositiveQuestion:
									result = $"were {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"were {subjectText} not";
									break;
							}
							break;
						case Tense.FuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been";
									break;
							}
							break;
						case Tense.Future:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be";
									break;
							}
							break;
						case Tense.ContinuousPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} are being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} are not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"are {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"are {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPluperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been being";
									break;
							}
							break;
						case Tense.ContinuousPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPast:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} were being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} were not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"were {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"were {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousFuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ContinuousFuture:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be";
									break;
							}
							break;
						case Tense.ConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been";
									break;
							}
							break;
					}
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
				case Subject.ThirdNeutral:
				case Subject.ThirdPlural:
					subjectText = subjectText != null ? subjectText : "they";
					goto SecondSubjectCase;
				default:
					switch(tense) {
						case Tense.Present:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} is";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} is not";
									break;
								case Specificity.PositiveQuestion:
									result = $"is {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"is {subjectText} not";
									break;
							}
							break;
						case Tense.Perfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} has been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} has not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"has {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"has {subjectText} not been";
									break;
							}
							break;
						case Tense.Plurperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been";
									break;
							}
							break;
						case Tense.Past:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} was";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} was not";
									break;
								case Specificity.PositiveQuestion:
									result = $"was {subjectText}";
									break;
								case Specificity.NegativeQuestion:
									result = $"was {subjectText} not";
									break;
							}
							break;
						case Tense.FuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been";
									break;
							}
							break;
						case Tense.Future:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be";
									break;
							}
							break;
						case Tense.ContinuousPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} is being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} is not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"is {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"is {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPluperfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} had been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} had not been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"had {subjectText} been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"had {subjectText} not been being";
									break;
							}
							break;
						case Tense.ContinuousPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousPast:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} was being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} was not being";
									break;
								case Specificity.PositiveQuestion:
									result = $"was {subjectText} being";
									break;
								case Specificity.NegativeQuestion:
									result = $"was {subjectText} not being";
									break;
							}
							break;
						case Tense.ContinuousFuturePerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ContinuousFuture:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} will be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} will not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"will {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"will {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be being";
									break;
							}
							break;
						case Tense.ContinuousConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been being";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been being";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been being";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been being";
									break;
							}
							break;
						case Tense.ConditionalPresent:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would be";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not be";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} be";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not be";
									break;
							}
							break;
						case Tense.ConditionalPerfect:
							switch(specificity) {
								case Specificity.PositiveStatement:
									result = $"{subjectText} would have been";
									break;
								case Specificity.NegativeStatement:
									result = $"{subjectText} would not have been";
									break;
								case Specificity.PositiveQuestion:
									result = $"would {subjectText} have been";
									break;
								case Specificity.NegativeQuestion:
									result = $"would {subjectText} not have been";
									break;
							}
							break;
					}
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
