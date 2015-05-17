using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDesktop
{
	public abstract class AnimeSource
	{
		public List<Anime> Animes;
		public abstract void Initialize();

		public abstract IEnumerable<Anime> GetAnimes();
		public abstract IEnumerable<Anime> SearchAnime(string term);
		public abstract AnimeInfo GetAnimeData(Anime anime);

		public abstract string GetEpisodeLink(int episodeId);
	}
}
