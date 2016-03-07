using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimeDesktop
{
	/// <summary>
	/// Interaction logic for AnimeView.xaml
	/// </summary>
	public partial class AnimeView : UserControl
	{
		public BitmapImage UriSource { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int EpisodeCount { get; set; }
		public string Status { get; set; }
		public string Genre { get; set; }
		public string AgeRating { get; set; }
		public string Language { get; set; }

		private readonly AnimeInfo _anime;
		private readonly MainWindow _parent;
		public AnimeView(AnimeInfo anime, MainWindow parent)
		{
			_anime = anime;
			_parent = parent;
			UriSource = new BitmapImage(new Uri("http://img.animemobile.com/content/" + anime.Seo + "/" + anime.Image));
			Title = anime.Title;
			Description = anime.Description;
			EpisodeCount = anime.Episodes.Count;
			Status = anime.Status;
			Genre = anime.Categories.ToString();
			AgeRating = anime.AgeRating;
			Language = anime.Language;
			DataContext = this;
			InitializeComponent();
		}

		private void EpisodeDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var item = ItemsControl.ContainerFromElement(EpisodeBox, e.OriginalSource as DependencyObject) as ListBoxItem;
			if (item == null) return;
			var anime = item.Tag as Episode;
			var episode = Cache.AnimeMobile.GetEpisodeLink(anime.Episode_ID);
			_parent.PlayEpisode(episode);
		}

		private void UserControl_Initialized(object sender, EventArgs e)
		{
			foreach (var ep in _anime.Episodes)
			{
				var lst = new ListBoxItem();
				lst.Content = ep.Title;
				lst.Tag = ep;
				EpisodeBox.Items.Add(lst);
			}
		}
	}
}
