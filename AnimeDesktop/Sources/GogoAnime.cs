using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDesktop.Sources
{
    class GogoAnime : AnimeSource
    {
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Anime> GetAnimes()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Anime> SearchAnime(string term)
        {
            string url = "http://gogoanime.io/site/loadSearch";
            //post data
            //{"keyword":"", "id":-1}
            return null;
        }

        public override AnimeInfo GetAnimeData(Anime anime)
        {
            throw new NotImplementedException();
        }

        public override string GetEpisodeLink(int episodeId)
        {
            throw new NotImplementedException();
        }
    }
}
