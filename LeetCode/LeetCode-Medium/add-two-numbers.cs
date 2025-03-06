namespace add_two_numbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class Program
    {

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l3 = new ListNode(0);
            ListNode iter1 = l1;
            ListNode iter2 = l2;
            ListNode iter3 = l3;

            int remaining = 0;
            while (true)
            {
                if (iter1 != null && iter2 != null)
                {
                    var sum = iter1.val + iter2.val + remaining;
                    remaining = sum >= 10 ? 1 : 0;
                    iter3.val = sum % 10;
                    iter1 = iter1.next;
                    iter2 = iter2.next;
                }
                else if (iter2 != null)
                {
                    var sum = iter2.val + remaining;
                    remaining = sum >= 10 ? 1 : 0;
                    iter3.val = sum % 10;
                    iter2 = iter2.next;
                }
                else if (iter1 != null)
                {
                    var sum = iter1.val + remaining;
                    remaining = sum >= 10 ? 1 : 0;
                    iter3.val = sum % 10;
                    iter1 = iter1.next;
                }
                else if(remaining == 1)
                {
                    iter3.val = 1;
                    remaining = 0;
                }
                else break;

                if (iter1 != null || iter2 != null || remaining == 1)
                {
                    iter3.next = new ListNode(0);
                    iter3 = iter3.next;
                }
            }
            
            return l3;
        }


        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))));
            ListNode l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            var l3 = AddTwoNumbers( l1, l2);
            var current = l3;
            while (current != null) 
            {
                Console.WriteLine(current.val); 
                current = current.next; 
            }
        }
    }
}
