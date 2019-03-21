using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Mythigine
{
    internal class RandomTimer : IDisposable
    {
        Timer mTimer;
        decimal cutOff;
        decimal total;

        public delegate void StatusCheck(bool value);
        public event StatusCheck StatusChecked;

        public RandomTimer(decimal cutOff, decimal total)
        {
            this.cutOff = cutOff;
            this.total = total;

            mTimer = new Timer(100);
            mTimer.Elapsed += new ElapsedEventHandler(Scan);
        }

        public void Start()
        {
            mTimer.Enabled = true;
        }

        private void Scan(object source, ElapsedEventArgs e)
        {
            bool result = StaticRandom.Instance.Next(1, Convert.ToInt32(total)) < cutOff;

            StatusChecked?.Invoke(result);
        }

        public void Dispose()
        {
            ((IDisposable)mTimer).Dispose();
        }
    }
}
