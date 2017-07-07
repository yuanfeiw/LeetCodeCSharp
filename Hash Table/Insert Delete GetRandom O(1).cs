﻿/*
380. Insert Delete GetRandom O(1)
Design a data structure that supports all following operations in average O(1) time.

insert(val): Inserts an item val to the set if not already present.
remove(val): Removes an item val from the set if present.
getRandom: Returns a random element from current set of elements. Each element must have the same probability of being returned.

Example:

// Init an empty set.
RandomizedSet randomSet = new RandomizedSet();

// Inserts 1 to the set. Returns true as 1 was inserted successfully.
randomSet.insert(1);

// Returns false as 2 does not exist in the set.
randomSet.remove(2);

// Inserts 2 to the set, returns true. Set now contains [1,2].
randomSet.insert(2);

// getRandom should return either 1 or 2 randomly.
randomSet.getRandom();

// Removes 1 from the set, returns true. Set now contains [2].
randomSet.remove(1);

// 2 was already in the set, so return false.
randomSet.insert(2);

// Since 2 is the only number in the set, getRandom always return 2.
randomSet.getRandom();
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public class RandomizedSet
    {
        private readonly Dictionary<int, int> _valueToIndex = new Dictionary<int, int>(); 
        private readonly List<int> _nums = new List<int>();
        private readonly Random _random = new Random();
        /** Initialize your data structure here. */
        public RandomizedSet()
        {

        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (_valueToIndex.ContainsKey(val))
            {
                return false;
            }

            _nums.Add(val);
            _valueToIndex[val] = _nums.Count - 1;
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!_valueToIndex.ContainsKey(val))
            {
                return false;
            }

            int last = _nums[_nums.Count - 1];
            _valueToIndex[last] = _valueToIndex[val];
            _nums[_valueToIndex[val]] = last;
            _nums.RemoveAt(_nums.Count - 1);
            _valueToIndex.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return _nums[_random.Next(_nums.Count)];
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
