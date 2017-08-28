using System.Collections.Generic;

namespace USDA.NET.Food
{
	public class SearchList
	{
		public string Q { get; set; }
		public string Sr { get; set; }
		public string Ds { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
		public int Total { get; set; }
		public string Group { get; set; }
		public string Sort { get; set; }

		public IEnumerable<SearchItem> Item { get; set; }
	}
}