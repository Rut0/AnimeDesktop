using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDesktop
{
	internal abstract class AnimeSource
	{
		public List<Anime> Animes;
		public abstract void Initialize();

		public abstract IEnumerable<Anime> GetAnimes();
		public abstract AnimeInfo GetAnimeData(Anime anime);

		public abstract string[] GetEpisodeLinks(int episodeId);
	}
}
