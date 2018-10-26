using System;
using System.Collections.Generic;
using System.Text;

namespace non_original_idea {
	public sealed class SentenceFragment {

		public SentenceFragment(string text,FragmentFlags flags = FragmentFlags.None) {
			this.text = text;
			this.flags = flags;
		}

		private readonly string text;
		private readonly FragmentFlags flags;

		public string Text {
			get {
				return text;
			}
		}

		public FragmentFlags Flags {
			get {
				return flags;
			}
		}

	}
}
