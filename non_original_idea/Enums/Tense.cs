using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public enum Tense {

		//The defacto conjugations
		Present,//I run
		Past,//I ran
		Future,//I will run
		Pluperfect,//I had ran
		Perfect,//I have ran
		FuturePerfect,//I will have ran

		//These aren't technically real tenses:
		Imperfect,//I used to
		FutureInformal,//I am going to

		//Standard continuous cases, made with the verb to be
		ProgressivePresent,//I am running
		ProgressivePerfect,//I have been running
		ProgressivePast,//I was running
		ProgressivePluperfect,//I had been running
		ProgressiveFuture,//I will be running
		ProgressiveFuturePerfect,//I will have been running

		ConditionalPresent,//I would run
		ConditionalPerfect,//I would have ran
		ProgressiveConditionalPresent,//I would be running
		ProgressiveConditionalPerfect,//I would have been running

		PossiblePresent,//I can run
		PossiblePast,//I could run
		PossibleFuture,//I might run
		PossiblePerfect,//I could have ran
			//PossiblePluperfect is invalid
			//PossibleFuturePerfect is invalid
		PossibleImperfect,//I used to be able to run
		PossibleFutureImformal,//I can go run

		ProgressivePossiblePresent,//I could be running
		ProgressivePossiblePerfect,//I could have been running
			//PossibleProgressivePast is invalid
			//PossibleProgressivePluperfect is invalid
			//ProgressivePossibleFuture is invalid
			//ProgressivePossibleFuturePerfect is invalid

		AdvisoryPresent,//I should run
		AdvisoryPerfect,//I should have ran
		ProgressiveAdvisoryPresent,//I should be running
		ProgressiveAdvisoryPerfect,//I should have been running

		PermissivePresent,//I may run
		PermissivePerfect,//I may have ran
		ProgressivePermissivePresent,//I may be running
		ProgressivePermissivePerfect,//I may have been running


		ObligatePresent,//I must run
		ObligatePast,//I had to run
		ObligatePerfect,//I must have ran
		ProgressiveObligatePresent,//I must be running
		ProgressiveObligatePerfect,//I must have been runnin
		ObligateImperfect,//I used to have to run
		ObligatePresentInformal,//I have to run - doubles as imperative case
		ObligateFuture,//I am going to have to run

	}
}
