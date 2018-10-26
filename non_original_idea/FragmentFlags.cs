using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	//This will probably go away because it's not useful in the way we do things now
	[Flags]
	public enum FragmentFlags {
		None = 0,
		Conditional = 1,
		Continuous = 2,
	}
}
