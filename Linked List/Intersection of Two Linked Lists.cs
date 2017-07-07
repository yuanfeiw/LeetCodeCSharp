﻿/*
160	Intersection of Two Linked Lists
easy, linked list
Write a program to find the node at which the intersection of two singly linked lists begins.


For example, the following two linked lists:

A:          a1 → a2
                   ↘
                     c1 → c2 → c3
                   ↗            
B:     b1 → b2 → b3
begin to intersect at node c1.


Notes:

If the two linked lists have no intersection at all, return null.
The linked lists must retain their original structure after the function returns.
You may assume there are no cycles anywhere in the entire linked structure.
Your code should preferably run in O(n) time and use only O(1) memory.
*/


namespace Demo
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public partial class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }

            ListNode a = headA, b = headB;
            while (a != b)
            {
                a = (a != null) ? a.next : headB;
                b = (b != null) ? b.next : headA;
            }
            return a;
        }

        public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            ListNode p1 = headA;
            ListNode p2 = headB;

            if (p1 == null || p2 == null)
            {
                return null;
            }

            while (p1 != null && p2 != null && p1 != p2)
            {
                p1 = p1.next;
                p2 = p2.next;

                //
                // Any time they collide or reach end together without colliding 
                // then return any one of the pointers.
                //
                if (p1 == p2) return p1;

                //
                // If one of them reaches the end earlier then reuse it 
                // by moving it to the beginning of other list.
                // Once both of them go through reassigning, 
                // they will be equidistant from the collision point.
                //
                if (p1 == null) p1 = headB;
                if (p2 == null) p2 = headA;
            }

            return p1;
        }
    }
}
