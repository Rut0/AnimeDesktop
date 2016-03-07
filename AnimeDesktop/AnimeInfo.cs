using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDesktop
{
	public class AnimeInfo
	{
		public string Title { get; set; }
		public string Letter { get; set; }
		public string Seo { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public string AgeRating { get; set; }
		public string Language { get; set; }
		public string Status { get; set; }
		public string Manga { get; set; }
		public string MangaLink { get; set; }
		public string Prequel { get; set; }
		public int New { get; set; }
		public int Hot { get; set; }
		public int Private { get; set; }
		public string Banner { get; set; }
		public string Sequel { get; set; }
		public string User_ID { get; set; }
		public string Date { get; set; }
		public Categories Categories { get; set; }
		public List<string> Titles { get; set; }
		public object SideStories { get; set; }
		public object ContentAlternatives { get; set; }
		public string Image { get; set; }
		public int Content_ID { get; set; }
		public List<Episode> Episodes { get; set; }

	}

	public class Categories
	{
		public string gjwk { get; set; }
		public string prrp { get; set; }
		public string qroi { get; set; }
		public string rayd { get; set; }
		public string uvdy { get; set; }
		public string vgno { get; set; }
		public string fhnm { get; set; }
		public string dbvs { get; set; }
		public string svqb { get; set; }
		public string umed { get; set; }

	}

	public class SideStories
	{
		public string __invalid_name__3 { get; set; }
	}

	public class Episode
	{
		public string Title { get; set; }
		public string Seo { get; set; }
		public int Image { get; set; }
		public string Timestamp { get; set; }
		public int Episode_ID { get; set; }

	}
}
