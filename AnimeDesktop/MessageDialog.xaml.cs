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
using System.Windows.Shapes;

namespace AnimeDesktop
{
	/// <summary>
	/// Interaction logic for MessageDialog.xaml
	/// </summary>
	public partial class MessageDialog : Window
	{
		private static MessageDialog _instance;

		public static MessageDialog Instance
		{
			get { return _instance ?? (_instance = new MessageDialog()); }
			set { _instance = value; }
		}

		public MessageDialog()
		{
			InitializeComponent();
			Closing += MessageDialog_Closing;
		}

		private void MessageDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Application.Current.Shutdown();
		}

		public void SetMessage(string title, string message)
		{
			Title = title;
			Message.Text = message;
			Visibility = Visibility.Visible;
		}

		public static void ShowMessage(string title, string message)
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				Instance.SetMessage(title, message);
			});
		}

		public static void CloseDialog()
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				if (_instance != null && _instance.Visibility == Visibility.Visible)
				{
					_instance.Visibility = Visibility.Collapsed;
				}
			});
		}
	}
}
