using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public sealed class Contraction {
		public Contraction(string shorthand,string longway,bool isFormatter = true) {
			if(isFormatter) {
				this.shorthand = shorthand;
				this.longway = longway;
				this.isFormatter = true;
			} else {
				//We add spaces so that words can't be double contracted nor can sentences end in contractions. It's just easier this way.
				this.shorthand = shorthand + " ";
				this.longway = longway + " ";
				this.isFormatter = false;
			}
		}
		internal readonly string shorthand;
		internal readonly string longway;
		internal readonly bool isFormatter;
	}
}
