using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_2_AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Solution s1 = new Solution();
            int[] a = { 1,8 };
            int[] b = { 0 };
            ListNode alist = s1.CreateListNode(a);
            ListNode blist = s1.CreateListNode(b);
            s1.DisplayNode(alist);
            s1.DisplayNode(blist);
            var name = Console.ReadLine();
            //Console.WriteLine(s1.GetValue(alist));
            //Console.WriteLine(s1.GetValue(blist));
            s1.DisplayNode(s1.AddTwoNumbers(alist, blist));
            //s1.DisplayNode(s1.GetListNode(807));
            name = Console.ReadLine();
        }
    }
    public class ListNode
    {
       public int val;
       public ListNode next;
       public ListNode(int x) { val = x; }
   }
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry = 0)
        {
            int result;
            ListNode NextL1 = null;
            ListNode NextL2 = null;
            if (l1 == null & l2 == null)
                if (carry == 0)
                    return null;
                else
                    return new ListNode(carry);
            else if (l1 == null)
            {
                result = l2.val + carry;
                NextL2 = l2.next;
            }
            else if (l2 == null)
            {
                result = l1.val + carry;
                NextL1 = l1.next;
            }
            else
            {
                result = l1.val + l2.val + carry;
                NextL1 = l1.next;
                NextL2 = l2.next;
            }
            ListNode resultList = new ListNode(result%10)
            {
                next = AddTwoNumbers(NextL1, NextL2, result/10)
            };
            return resultList;
        }
        public int GetValue(ListNode L)
        {
            if (L.next != null)
                return L.val + 10 * GetValue(L.next);
            else
                return L.val;
        }
        public ListNode GetListNode(int value)
        {
            if (value < 10)
                return new ListNode(value);
            else
            {
                ListNode result = new ListNode(value % 10);
                result.next = GetListNode(value / 10);
                return result;
            }
        }
        public void DisplayNode(ListNode L)
        {
            Console.Write(L.val);
            if (L.next != null)
            {
                Console.Write("->");
                DisplayNode(L.next);
            }
            else
                Console.WriteLine();

        }
        public ListNode CreateListNode(int[] nums, int idx = 0)
        {
            if (idx == nums.Length - 1)
            {
                return new ListNode(nums[idx]);
            }
            else
            {
                ListNode result = new ListNode(nums[idx])
                {
                    next = CreateListNode(nums, idx + 1)
                };
                return result;

            }
        }
    }
}
