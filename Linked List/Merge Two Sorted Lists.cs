﻿/*
21	Merge Two Sorted Lists
easy, linked list
Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode header = new ListNode(0);
            var p = header;
            while (l1 != null && l2 !=null)
            {
                if (l1.val <= l2.val)
                {
                    p.next = l1;
                    p = p.next;
                    l1 = l1.next;
                }
                else
                {
                    p.next = l2;
                    p = p.next;
                    l2 = l2.next;
                }
            }

            if (l1 != null)
            {
                p.next = l1;
            }

            if (l2 != null)
            {
                p.next = l2;
            }

            return header.next;
        }
    }
}
