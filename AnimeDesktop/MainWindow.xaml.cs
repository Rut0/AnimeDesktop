using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Visibility = Visibility.Hidden;
			MessageDialog.ShowMessage("Starting", "Initializing...");
			Cache.AnimeMobile = new AnimeMobile();
			new Thread(() =>
			{
				Cache.AnimeMobile.Initialize();
				MessageDialog.ShowMessage("Starting", "Parsing " + Cache.AnimeMobile.Animes.Count + " Animes");
				InvokeUi(() =>
				{
					foreach (var anim in Cache.AnimeMobile.Animes)
						AnimeListBox.Items.Add(anim.Title);
					MessageDialog.ShowMessage("Starting", "Done!");
					Thread.Sleep(1500);
					MessageDialog.CloseDialog();
					Visibility = Visibility.Visible;
					ShowInTaskbar = true;
					Activate();
				});
			}).Start();
		}

		public void InvokeUi(Action action)
		{
			Application.Current.Dispatcher.Invoke(action);
		}

		private void SearchOnClick(object sender, RoutedEventArgs e)
		{
			var window = new SearchForm(this);
			if (ContentWindow.Children.Count > 0)
				ContentWindow.Children.Clear();
			ContentWindow.Children.Add(window);
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Application.Current.Shutdown();
		}

		public void ShowAnime(Anime anime)
		{
			var info = Cache.AnimeMobile.GetAnimeData(anime);
			if (ContentWindow.Children.Count > 0)
				ContentWindow.Children.Clear();
			var view = new AnimeView(info, this);
			ContentWindow.Children.Add(view);
		}

		public void PlayEpisode(string url)
		{
			if (ContentWindow.Children.Count > 0)
				ContentWindow.Children.Clear();
			var form = new StreamForm(url);
			ContentWindow.Children.Add(form);
			form.Play();
		}
	}
}
