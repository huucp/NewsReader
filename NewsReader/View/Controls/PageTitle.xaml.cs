using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NewsReader.View.Controls
{
    public partial class PageTitle : UserControl
    {
        private DispatcherTimer _timer;
        private DateTime _currentTime;

        public PageTitle()
        {
            InitializeComponent();
            SetupTime();
        }

        private void SetupTime()
        {
            _minuteCount = 0;
            _currentTime = DateTime.Now;
            Time.Text = string.Format(_currentTime.Hour.ToString() + ":" + _currentTime.Minute.ToString());
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(60 - _currentTime.Second) };
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private int _minuteCount;
        private void _timer_Tick(object sender, EventArgs e)
        {
            _currentTime += _timer.Interval;
            Time.Text = string.Format(_currentTime.Hour.ToString() + ":" + _currentTime.Minute.ToString());
            if (_timer.Interval != TimeSpan.FromMinutes(1.0))
            {
                _timer.Interval = TimeSpan.FromMinutes(1.0);
            }

            // Update the current time by using system clock
            if (_minuteCount == 30)
            {
                _minuteCount = 0;
                _currentTime = DateTime.Now;
                _timer.Interval = TimeSpan.FromSeconds(60 - _currentTime.Second);
            }
            _minuteCount++;
        }

        public void StopTimer()
        {
            _timer.Stop();
            _timer.Tick -= _timer_Tick;
        }
    }
}
