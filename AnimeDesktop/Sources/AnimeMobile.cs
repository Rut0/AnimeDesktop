using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Application = System.Windows.Application;

namespace AnimeDesktop.Sources
{
	public class AnimeMobile : AnimeSource
	{
		public override void Initialize()
		{
			Animes = GetAnimes().ToList();
		}

		public override IEnumerable<Anime> GetAnimes()
		{
			const string link = "http://www.animemobile.com/service/mobile2.php?&all_list=true";
			var data = new WebClient().DownloadString(link);
			var json = JsonConvert.DeserializeObject<JObject>(data)["list"];
			return from members in json.Children() from values in members.Children() from anime in values select new Anime
			{
				Id = int.Parse(anime["ID"].ToString()),
				Title = anime["Title"].ToString(),
				Seo = anime["Seo"].ToString(),
				Letter = anime["Letter"].ToString(),
				Language = int.Parse(anime["Language"].ToString()),
				Status = int.Parse(anime["Status"].ToString()),
				Alternatives = anime["Alternatives"].ToString().Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries).ToList(),
				Categories = anime["Categories"].ToString().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList()
			};
		}

		public override IEnumerable<Anime> SearchAnime(string term)
		{
			var returned = new List<string>();
			foreach (var anime in Cache.AnimeMobile.Animes)
			{
				if ((anime.Title.ToLower().Contains(term.ToLower()) ||
				    anime.Alternatives.FirstOrDefault(alt => alt.ToLower().Contains(term.ToLower())) != null) && !returned.Contains(anime.Title))
				{
					returned.Add(anime.Title);
					yield return anime;
				}
			}
		} 

		public override AnimeInfo GetAnimeData(Anime anime)
		{
			var link = "http://www.animemobile.com/service/mobile2.php?&anime_id=" + anime.Id;
			var data = new WebClient().DownloadString(link);
			return JsonConvert.DeserializeObject<AnimeInfo>(data);
		}

		public override string[] GetEpisodeLinks(int episodeId)
		{
			throw new NotImplementedException();
		}
	}
}
