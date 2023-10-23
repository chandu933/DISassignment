/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, 
        where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums.
        Return the shortest sorted list of ranges that exactly covers all the missing numbers. 
        That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Create a list to store lists of integer ranges.
                IList<IList<int>> missingRanges = new List<IList<int>>();

                int index = 0;
                // Check if the 'lowerBound' is less than or equal to the first element in the 'nums' array minus 1.
                if (lower <= nums[0] - 1)
                {
                    // Add a range from 'lowerBound' to 'nums[0] - 1' to 'missingRanges'
                    missingRanges.Add(new List<int> { lower, nums[0] - 1 }); 
                }

                // Iterate through the 'nums' array to find gaps.
                for (index = 0; index < nums.Length - 1; index++)
                {
                    // Check gap between 'nums[index] + 1' and 'nums[index + 1] - 1'.
                    if (nums[index] + 1 <= nums[index + 1] - 1)
                    {
                        // Add the gap as a range to 'missingRanges'.
                        missingRanges.Add(new List<int> { nums[index] + 1, nums[index + 1] - 1 }); 
                    }
                }

                // Check if there is a gap between the last element in 'nums' and the 'upperBound'.
                if (nums[index] + 1 <= upper)
                {
                    // Add a range from 'nums[index] + 1' to 'upperBound' to 'missingRanges'.
                    missingRanges.Add(new List<int> { nums[index] + 1, upper}); 
                }

                // Return the list of integer ranges 'missingRanges'.
                return missingRanges; 
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during the process
                throw;
            }
        }


        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Dictionary to map opening brackets to their corresponding closing brackets
                Dictionary<char, char> bracketPairs = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };
                // Initialize the index of the most recent opening bracket
                int lastOpeningBracketIndex = -1;

                // Iterate through each character in the input string
                for (int currentIndex = 0; currentIndex < s.Length; currentIndex++)
                {
                    // If the current character is an opening bracket, update the last opening bracket index
                    if (bracketPairs.ContainsKey(s[currentIndex]))
                    {
                        lastOpeningBracketIndex = currentIndex;
                    }
                    // If the current character is a closing bracket and there is a corresponding opening bracket
                    else if (lastOpeningBracketIndex >= 0 && s[currentIndex] == bracketPairs[s[lastOpeningBracketIndex]])
                    {
                        int unmatchedOpeningBracketCount = 0;
                        lastOpeningBracketIndex -= 1;

                        // Continue searching for matching opening brackets
                        while (lastOpeningBracketIndex >= 0 && unmatchedOpeningBracketCount < 1)
                        {
                            // If an opening bracket is found, increment the unmatchedOpeningBracketCount
                            if (bracketPairs.ContainsKey(s[lastOpeningBracketIndex]))
                            {
                                unmatchedOpeningBracketCount += 1;

                                // If there are extra opening brackets, keep moving back in the string
                                if (unmatchedOpeningBracketCount < 1)
                                {
                                    lastOpeningBracketIndex -= 1;
                                }
                            }
                            else
                            {
                                // If a closing bracket is found, decrement the unmatchedOpeningBracketCount
                                unmatchedOpeningBracketCount -= 1;
                                lastOpeningBracketIndex -= 1;
                            }
                        }

                        // Check if there are unmatched brackets
                        if (lastOpeningBracketIndex == -1 && unmatchedOpeningBracketCount != 0)
                        {
                            return false;
                        }

                        // Check if there are unmatched brackets within the current range
                        if (lastOpeningBracketIndex >= 0 && unmatchedOpeningBracketCount != 1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // If the current character is neither an opening nor a matching closing bracket, return false
                        return false;
                    }
                }

                // Check if all brackets are matched
                return lastOpeningBracketIndex == -1;
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during bracket validation
                throw;
            }
        }


        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initialize variables to keep track of the minimum stock price and maximum profit
                int minStockPrice = int.MaxValue;
                int maxProfit = 0;

                // Handle the case of an empty array gracefully by returning 0 profit.
                if (prices.Length == 0)
                    return 0;

                // Iterate through the stock prices array
                for (int day = 0; day < prices.Length; day++)
                {
                    // If the current stock price is lower than the previously recorded minimum price, update the minimum price
                    if (prices[day] < minStockPrice)
                    {
                        minStockPrice = prices[day];
                    }
                    else
                    {
                        // Calculate the current day's profit and update the maximum profit if it's greater
                        int currentProfit = prices[day] - minStockPrice;
                        maxProfit = Math.Max(maxProfit, currentProfit);
                    }
                }

                // Return the maximum profit
                return maxProfit;
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during profit calculation
                throw;
            }
        }


        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                if (s == null)
                    // Handle null strings by returning false 
                    return false;

                // Initialize two pointers, 'leftPointer' and 'rightPointer,' to check characters from the beginning and end of the string.
                int leftPointer = 0;
                int rightPointer = s.Length - 1;

                // Define pairs of strobogrammatic characters. A strobogrammatic pair reads the same when rotated 180 degrees.
                string strobogrammaticPairs = "00 11 88 69 96";

                // Iterate while the 'leftPointer' is less than or equal to the 'rightPointer'.
                while (leftPointer <= rightPointer)
                {
                    char leftChar = s[leftPointer];
                    char rightChar = s[rightPointer];

                    // Check if the pair of characters formed by 'leftChar' and 'rightChar' is a valid strobogrammatic pair.
                    if (!strobogrammaticPairs.Contains($"{leftChar}{rightChar}"))
                        return false;

                    // Move the pointers towards each other.
                    leftPointer++;
                    rightPointer--;
                }

                // If the loop completes without returning false, the input string is strobogrammatic.
                return true;
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during strobogrammatic string validation
                throw;
            }
        }


        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Check if the input array is null or empty.
                if (nums == null || nums.Length == 0)
                {
                    // Handle the case where the input is null or empty by returning 0 pairs.
                    return 0;
                }

                // Initialize a dictionary to store the count of each number in the 'numbers' array.
                Dictionary<int, int> numberCount = new Dictionary<int, int>();

                // Initialize a variable to track the count of identical pairs.
                int identicalPairsCount = 0;

                // Iterate through the input array 'numbers.'
                foreach (int number in nums)
                {
                    // If the number already exists in the 'numberCount' dictionary, increment the 'identicalPairsCount' by the
                    // value stored for that number, and then increment the count for that number.
                    if (numberCount.ContainsKey(number))
                    {
                        identicalPairsCount += numberCount[number];
                        numberCount[number]++;
                    }
                    else
                    {
                        // If the number is not in the dictionary, add it with a count of 1.
                        numberCount[number] = 1;
                    }
                }

                // Return the total count of identical pairs.
                return identicalPairsCount;
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during identical pairs counting.
                throw;
            }
        }


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Check if the input array is null
                if (nums == null)
                {
                    // Handle the case of a null input.
                    return -1;
                }
                else
                {
                    // Sort the array in descending order
                    Array.Sort(nums);
                    Array.Reverse(nums);

                    int distinctCount = 0;
                    int? thirdMaximum = null;

                    // Iterate through the sorted array
                    for (int index = 0; index < nums.Length; index++)
                    {
                        // Check if the current number is distinct 
                        if (index == 0 || nums[index] != nums[index - 1])
                        {
                            distinctCount++;
                        }

                        // If we find the third distinct number, store it and exit the loop
                        if (distinctCount == 3)
                        {
                            thirdMaximum = nums[index];
                            break;
                        }
                    }

                    // If the thirdMaximum variable is still null, return the maximum number 
                    return thirdMaximum ?? nums[0];
                }


            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during the process
                throw;
            }
        }


        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                if (currentState == null)
                {
                    // Handling null input by returning an empty list.
                    return new List<string>();
                }
                else
                {
                    List<string> possibleMoves = new List<string>();
                    int length = currentState.Length;

                    // Iterate through the string to find possible moves
                    for (int i = 0; i < length - 1; i++)
                    {
                        if (currentState[i] == '+' && currentState[i + 1] == '+')
                        {
                            // Create a new string with the "++" replaced by "--"
                            char[] newState = currentState.ToCharArray();
                            newState[i] = '-';
                            newState[i + 1] = '-';
                            possibleMoves.Add(new string(newState));
                        }
                    }

                    // Return the list of possible next moves
                    return possibleMoves;
                }

                
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during the process
                throw;
            }
        }


        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            string newS = "";
            // Iterate through every char of string.
            foreach (char ch in s)
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' || ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
                {
                    // if char is an vowel adding to new string is skipped.
                    continue;
                }
                // If char not an vovwel adding to the new String.
                else 
                {
                    newS += ch;
                }
            }
            // Return new string witgh removed vowels
            return newS;
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}