using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transfer_IMG.General
{
    public class Common
    {
        public void ProgressBarLoading(int length, ProgressBar progressBar)
        {
            for (int i = 0; i < length; i++)
            {
                if (progressBar.Value == 100)
                {
                    break;
                }
                progressBar.Value += 1;
                Thread.Sleep(10); // Pauza pro simulaci práce
            }
        }
    }
}
