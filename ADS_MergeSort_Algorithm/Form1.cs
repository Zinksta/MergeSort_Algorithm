using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADS_MergeSort_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /*--------------MergeSort Algorithm-----------------------
        The steps of the MergeSort algorithm can be listed as follows:
        1. Divide the unsorted array into two sub arrays
        2. Recursively sort each sub array
        3. Merge the two sub arrays by comparing values
        */
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // declare an array
            int[] numbers = new int[] { 3, 6, 1, 4, 5 };

            // add text to output
            txtOutput.Text = "Unsorted array:\r\n";

            // loop through array and print each value
            foreach (int value in numbers)
                txtOutput.Text += value + "\t";

            // add text to output
            txtOutput.Text += "\r\nSorted array:\r\n";

            //call mergeSort method
            mergeSort(numbers, 0, numbers.Length - 1);

            // loop through array after it has been sorted and print each value
            foreach (int value in numbers)
                txtOutput.Text += value + "\t";
        }
        /* MergerSort Algorithm will divide the array
            1st parameter is the array to sort, 2nd is the starting index(usually 0),
            the 3rd is the upperbound of the array(which is usually the last index)
            example:- a numbers array with 5 indexs would be mergeSort(numbers, 0, numbers.Length - 1)
            *******THIS METHOD WILL NOT WORK WITHOUT THE MERGE METHOD********
        */
        public void mergeSort(int[] sortArray, int lower, int upper)
        {
            int middle;
            if (upper == lower)
                return;
            else
            {
                middle = (lower + upper) / 2;
                mergeSort(sortArray, lower, middle);
                mergeSort(sortArray, middle + 1, upper);
                Merge(sortArray, lower, middle + 1, upper);
            }
        }
        // Merge method will merge subarrays together incrementally
        // ******THIS METHOD WILL NOT WORK WITHOUT THE MERGESORT METHOD********
        public void Merge(int[] sortArray, int lower, int middle, int upper)
        {
            int[] temp = new int[sortArray.Length];
            int lowEnd = middle - 1;
            int low = lower;
            int n = upper - lower + 1;

            while ((lower <= lowEnd) && (middle <= upper))
            {
                if (sortArray[lower] <= sortArray[middle])
                {
                    temp[low] = sortArray[lower];
                    low++;
                    lower++;
                }
                else
                {
                    temp[low] = sortArray[middle];
                    low++;
                    middle++;
                }
            }
            while (lower <= lowEnd)
            {
                temp[low] = sortArray[lower];
                low++;
                lower++;
            }
            while (middle <= upper)
            {
                temp[low] = sortArray[middle];
                low++;
                middle++;
            }
            for (int i = 0; i < n; i++)
            {
                sortArray[upper] = temp[upper];
                upper--;
            }
        }
    }
}
