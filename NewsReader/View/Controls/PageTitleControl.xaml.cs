using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NewsReader.View.Controls
{
    public partial class PageTitleControl : UserControl
    {
        private DispatcherTimer _timer;
        private DateTime _currentTime;

        public PageTitleControl()
        {
            InitializeComponent();
            SetupTime();
        }

        private void SetupTime()
        {
            _minuteCount = 0;
            _currentTime = DateTime.Now;
            Time.Text = FormatTime(_currentTime);
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(60 - _currentTime.Second) };
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private int _minuteCount;
        private void _timer_Tick(object sender, EventArgs e)
        {
            _currentTime += _timer.Interval;
            Time.Text = FormatTime(_currentTime);
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

        public string FormatTime(DateTime time)
        {
            if (time.Minute<10)
            {
                return string.Format("{0}:{1}", time.Hour.ToString(), "0" + time.Minute.ToString());
            }
            return string.Format("{0}:{1}", time.Hour.ToString(), time.Minute.ToString());
        }
    }
}
