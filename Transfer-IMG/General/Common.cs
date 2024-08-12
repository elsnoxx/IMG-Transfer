using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transfer_IMG.General
{
    public class Common
    {
        /// <summary>
        /// Asynchronously simulates loading by incrementing the progress bar value.
        /// </summary>
        /// <param name="length">The number of steps to simulate.</param>
        /// <param name="progressBar">The ProgressBar control to update.</param>
        public async Task ProgressBarLoading(int length, ProgressBar progressBar)
        {
            // Ensure the ProgressBar value is within the valid range
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            
            for (int i = 0; i < length; i++)
            {
                // If the ProgressBar is already at the maximum value, exit the loop
                if (progressBar.Value >= progressBar.Maximum)
                {
                    break;
                }

                // Increment the value of the ProgressBar
                progressBar.Value += 1;

                // Introduce a small delay to simulate work being done
                await Task.Delay(10); // Use Task.Delay for asynchronous waiting
            }
        }
    }
}
