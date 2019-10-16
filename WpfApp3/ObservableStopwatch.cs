using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApp3
{
    class ObservableStopwatch : INotifyPropertyChanged
    {
        private DispatcherTimer _ticker;

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTimeOffset? _startTime { get; set; }

        public bool IsRunning => _startTime.HasValue;

        public string Elapsed
        {
            get
            {
                if (IsRunning)
                    return (DateTimeOffset.Now - _startTime.Value).TotalSeconds.ToString();
                return string.Empty;
            }
        }

        public ObservableStopwatch()
        {
            _ticker = new DispatcherTimer(DispatcherPriority.Background);
            _ticker.Interval = TimeSpan.FromMilliseconds(10);
            _ticker.Tick += _ticker_Tick;
        }

        private void _ticker_Tick(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Elapsed));
        }

        public void Toggle()
        {
            if(IsRunning)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }

        private void Start()
        {
            _startTime = DateTime.Now;
            _ticker.Start();
        }

        private void Stop()
        {
            _startTime = null;
            _ticker.Stop();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
