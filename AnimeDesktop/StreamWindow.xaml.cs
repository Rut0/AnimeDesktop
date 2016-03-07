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
    /// Interaction logic for StreamWindow.xaml
    /// </summary>
    public partial class StreamWindow : Window
    {

        private enum VideoState
        {
            Playing,
            Paused,
            Stopped
        }

        private VideoState _state;

        private readonly string _url;
        public StreamWindow(string url)
        {
            _url = url;
            InitializeComponent();
            MediaPlayer.EncounteredError += MediaPlayerOnEncounteredError;
            MediaPlayer.Opened += MediaPlayer_Opened;
            MediaPlayer.PositionChanged += MediaPlayer_PositionChanged;
            SliderBar.ValueChanged += SliderBar_ValueChanged;
            //MediaPlayer. = MediaState.Manual;
        }

        private void SliderBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer.Position = TimeSpan.FromSeconds(SliderBar.Value);
        }

        private void MediaPlayer_PositionChanged(object sender, RoutedEventArgs e)
        {
            SliderBar.Value = MediaPlayer.Position.Value.TotalSeconds;
        }

        private void MediaPlayer_Opened(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer.Length != null) SliderBar.Maximum = MediaPlayer.Length.Value.TotalSeconds;
        }

        private void MediaPlayerOnEncounteredError(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Failed to load anime\n" + e.RoutedEvent);
            _state = VideoState.Stopped; ;
        }

        private void MediaPlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Failed to load anime\n" + e.ErrorException);
            _state = VideoState.Stopped; ;
        }

        public void Pause()
        {
            try
            {
                MediaPlayer.Pause();
                _state = VideoState.Paused;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public void Resume()
        {
            try
            {
                MediaPlayer.Play();
                _state = VideoState.Playing;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public void Start()
        {
            MediaPlayer.Source = new Uri(_url);
            Resume();
            _state = VideoState.Playing;
        }

        private void MediaPlayer_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_state == VideoState.Playing)
                Pause();
            else if (_state == VideoState.Paused)
                Resume();

        }
    }
}
