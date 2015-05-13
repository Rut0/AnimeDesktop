using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDesktop
{
	class Anime
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Seo { get; set; }
		public string Letter { get; set; }
		public int Language { get; set; }
		public int Status { get; set; }
		public string[] Alternatives { get; set; }
		public string[] Categories { get; set; }

	}

}
