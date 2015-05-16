using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDesktop
{
	public class Anime
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Seo { get; set; }
		public string Letter { get; set; }
		public int Language { get; set; }
		public int Status { get; set; }
		public List<string> Alternatives { get; set; }
		public List<string> Categories { get; set; }

		public override bool Equals(object obj)
		{
			return ((Anime) obj).Id == Id;
		}
	}

}
