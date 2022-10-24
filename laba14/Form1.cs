using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba14
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[100];
        int[] result;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                numbers[i] = random.Next(0, 1000);
                listBox1.Items.Add(numbers[i]);
            }
        }

        private static int [] QuickSort(ref int[] Array, int Left, int Right)
        {
            if (Left >= Right)
            {
                return Array;
            }
            int pivot_id = Left - 1;
            for (int i = Left; i <= Right; i++)
            {
                if (Array[i] < Array[Right])
                {
                    pivot_id++;
                    Swap(ref Array[pivot_id], ref Array[i]);
                }
            }
            pivot_id++;
            Swap(ref Array[pivot_id], ref Array[Right]);

            QuickSort(ref Array, Left, pivot_id - 1);
            QuickSort(ref Array, pivot_id + 1, Right);

            return Array;
        }

        private static void Swap(ref int left_item, ref int right_item)
        {
            int temp = left_item;
            left_item = right_item;
            right_item = temp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            result = QuickSort(ref numbers, 0, numbers.Length - 1);
            for (int i = 0; i < result.Length; i++)
            {
                listBox2.Items.Add(result[i]);
            }
        }
        private int BinarySearch(int elem, int[] array, int min, int max)
        {
            if (max < min) { return -1; }
            else
            { 
                int mid = (min + max) / 2;
                if (array[mid] < elem)
                {
                    return BinarySearch(elem, array, mid + 1, max);

                }
                else if (array[mid] > elem)
                {
                    return BinarySearch(elem, array, min, mid - 1);
                }
                else { return mid; }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int elem = Int32.Parse(textBox1.Text);
            textBox2.Text = (BinarySearch(elem, result, 0, result.Length - 1) + 1).ToString();
        }
    }
}
