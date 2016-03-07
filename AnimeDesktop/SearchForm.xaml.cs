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
using AnimeDesktop.Sources;

namespace AnimeDesktop
{
	/// <summary>
	/// Interaction logic for SearchForm.xaml
	/// </summary>
	public partial class SearchForm : UserControl
	{
		private MainWindow _parent;

		public string SearchTerm
		{
			get { return SearchBox.Text.Trim(); }
			set { SearchBox.Text = value; }
		}

		public SearchForm(MainWindow parent)
		{
			InitializeComponent();
			_parent = parent;
			DataContext = this;
		}

		private void ResultsBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var item = ItemsControl.ContainerFromElement(ResultsBox, e.OriginalSource as DependencyObject) as ListBoxItem;
			if (item == null) return;
			var anime = (item.Content as dynamic).Tag as Anime;
			_parent.ShowAnime(anime);
		}

		private void SearchBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				var results = Cache.AnimeMobile.SearchAnime(SearchTerm);
				foreach (var anime in results)
				{
					var data = Cache.AnimeMobile.GetAnimeData(anime);
					ResultsBox.Items.Add(new
					{
						UriSource = new BitmapImage(new Uri("http://img.animemobile.com/content/" + data.Seo + "/" + data.Image)),
						Title = data.Title,
						Description = data.Description,
						EpisodeCount = data.Episodes.Count,
						Tag = anime
					});
				}
			}
		}
	}
}
