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
	/// Interaction logic for StreamForm.xaml
	/// </summary>
	public partial class StreamForm : UserControl
	{
		private readonly string _url;
		public StreamForm(string url)
		{
			_url = url;
			InitializeComponent();
		}

		public void Stop()
		{
			try
			{
				MediaPlayer.Pause();
			}
			catch
			{
			}
		}

		public void Play()
		{
			try
			{
				MediaPlayer.Play();
			}
			catch
			{

			}
		}
	}
}
