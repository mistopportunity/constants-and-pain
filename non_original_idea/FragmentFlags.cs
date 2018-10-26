using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	[Flags]
	public enum FragmentFlags {
		None = 0,
		Predicate = 1,
		Conditional = 2,
		Continuous = 4,
	}
}
