//https://www.geeksforgeeks.org/find-a-peak-in-a-given-array/ --------> GeekforGeek referance.

// what is a peak element ? 
// An array element is a peak if it is NOT smaller than its neighbours



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarysearch_finding_peak_element_cs
{
    class Program
    {
        public static int findPeak(int[] nums)
        {
            // O(n) solution 

           
            int peak_element_index  = -1;

            // peak element 
            if (nums.Length == 0 )
            {
                peak_element_index = -1; 
            }
            else if(nums.Length == 1)
            {
                peak_element_index = 0;
            }
            else if (nums[0] >= nums[1])
            {
                // corner case : to handle  1: \ or 2: ---\/ or 3: ------
                peak_element_index =  0;
            }

            else if (nums[nums.GetUpperBound(0)]  >= nums[nums.GetUpperBound(0) - 1])
            {
                // corner case to handle : 1: / or 2: /--
                peak_element_index = nums.GetUpperBound(0);
            }
            else
            {
                for (int i = 1; i <= nums.GetUpperBound(0) - 1; i++ )
                {
                    if (nums[i] >= nums[i-1] && nums[i] >= nums[i + 1])
                    {
                        // element[i] is the peak_element.
                        peak_element_index =  i;
                        break;

                    }
                }
            }

            return peak_element_index;
        }


        public static int findPeak_using_binarysearch(int[] elements , int start_index , int end_index)
        {

            int middle_index = start_index + (end_index - start_index) / 2;
            // set the middle_index_value.

            if ((middle_index == 0 || elements[middle_index] >= elements[middle_index - 1]) && (middle_index == elements.Length - 1 || elements[middle_index] >= elements[middle_index + 1]))
            {
                return middle_index;
            }
           else if (middle_index < elements.Length - 1 && elements[middle_index] < elements[middle_index + 1 ] )
            {
                // search for the peak element in the right half .
                return findPeak_using_binarysearch(elements, middle_index + 1, end_index);

            }
            else
            {
                // search for the peak element in the left half of the middle_index.
                return findPeak_using_binarysearch(elements, start_index , middle_index - 1);
            }
        }
        static void Main(string[] args)
        {
            int[] elements  = { 1,2 };
            // passing the list to the findPeak function . 

            // int peak_element_index  = findPeak(elements);
            // catch the peak_element  present in the list .

            int peak_element_index = findPeak_using_binarysearch(elements, 0, elements.GetUpperBound(0));

            Console.WriteLine("the peak element is : " + elements[peak_element_index]);

            Console.ReadLine();
        }
    }
}