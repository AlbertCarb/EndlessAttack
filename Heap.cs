using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heap<T> where T : IHeapItem<T>
{
    T[] m_items; // array of type template which will move nodes around
    int m_currentItemCount; // current count of items in heap

/**/
    /*
    Heap::Heap() Heap::Heap()

    NAME
        Heap::Heap - initializes the Heap class objects

    SYNOPSIS
        public Heap::Heap(int a_maxHeapSize); 
            a_maxHeapSize -> the maximum size of the heap
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the Heap
        class 

    RETURNS
        Heap class object

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public Heap(int a_maxHeapSize)
    {
        // creating a new array of size a_maxHeapSize in memory
        m_items = new T[a_maxHeapSize];
    }
/* public Heap::Heap(int a_maxHeapSize); */

/**/
    /*
    Heap::Add() Heap::Add()

    NAME
        Heap::Add - adds an item to the heap

    SYNOPSIS
        public void Heap::Add(T a_item); 
            a_item -> item or node to be added to the heap
       
    DESCRIPTION
        This function is responsible for adding a new item to the heap of type 
        template. In this case we will be adding our path nodes to the heap

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public void Add(T a_item)
    {
        // the heap index of the item is set to the current item count 
        a_item.HeapIndex = m_currentItemCount;
        // item is placed in the array
        m_items[m_currentItemCount] = a_item;
        // item is sorted up accordingly
        SortUp(a_item);
        m_currentItemCount++;
    }
/* public void Heap::Add(T a_item); */

/**/
    /*
    Heap::RemoveFirst() Heap::RemoveFirst()

    NAME
        Heap::RemoveFirst - removes first item off the heap

    SYNOPSIS
        public T Heap::RemoveFirst(); 
       
    DESCRIPTION
        This function is responsible for finding the first item in the 
        heap and removing it from the heap.

    RETURNS
        Template item

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public T RemoveFirst()
    {
        T firstItem = m_items[0];
        m_currentItemCount--;
        m_items[0] = m_items[m_currentItemCount];
        m_items[0].HeapIndex = 0;

        // re-sorts the heap downards after the first item is 
        SortDown(m_items[0]);
        return firstItem;
    }
/* public T Heap::RemoveFirst(); */

/**/
    /*
    Heap::UpdateItem() Heap::UpdateItem()

    NAME
        Heap::UpdateItem - updates an item

    SYNOPSIS
        public void Heap::UpdateItem(); 
            a_item -> the item to be updated
       
    DESCRIPTION
        This function is responsible for updating an item in the 
        heap

    RETURNS
        ((void))
    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public void UpdateItem(T a_item)
    {
        SortUp(a_item);
    }
/* public T Heap::UpdateItem(T a_item); */

/**/
    /*
    Heap::Count Heap::Count

    NAME
        Heap::Count - gets the int value of Count

    SYNOPSIS
        public int Heap::Count; 
        
    DESCRIPTION
        This accessor function is repsonsible for getting the current value of 
        m_currentItemCount

    RETURNS
        int value of m_currentItemCount

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public int Count
    {
        get
        {
            return m_currentItemCount;
        }
    }
/* public int Heap::Count; */

/**/
    /*
    Heap::Contains() Heap::Contains()

    NAME
        Heap::Contains - checks to see if an item is contained in the heap

    SYNOPSIS
        public bool Heap::Contains(T a_item); 
            a_item -> the item to be cross-checked
       
    DESCRIPTION
        This function is responsible for return true or false 
        if the item parameter is contained in the array at a
        particular index.

    RETURNS
        bool value for if an item is contained at a particular 
        index in the array

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public bool Contains(T a_item)
    {
        return Equals(m_items[a_item.HeapIndex], a_item);
    }
/* public bool Heap::Contains(T a_item); */

/**/
    /*
    Heap::SortDown() Heap::SortDown()

    NAME
        Heap::SortDown - sorts the array down 

    SYNOPSIS
        void Heap::SortDown(T a_item); 
            a_item -> the item to be sorted down
       
    DESCRIPTION
        This function is responsible for sorting the array from the
        specified item, downwards. This is to maintain the structure of 
        the heap.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    void SortDown(T a_item)
    {
        while (true)
        {
            int childIndexLeft = a_item.HeapIndex * 2 + 1;
            int childIndexRight = a_item.HeapIndex * 2 + 2;
            int swapIndex = 0;

            if (childIndexLeft < m_currentItemCount)
            {
                swapIndex = childIndexLeft;

                if (childIndexRight < m_currentItemCount)
                {
                    if (m_items[childIndexLeft].CompareTo(m_items[childIndexRight]) < 0)
                    {
                        swapIndex = childIndexRight;
                    }
                }

                if (a_item.CompareTo(m_items[swapIndex]) < 0)
                {
                    Swap(a_item, m_items[swapIndex]);
                }
                else 
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
/* void Heap::SortDown(T a_item); */

/**/
    /*
    Heap::SortUp() Heap::SortUp()

    NAME
        Heap::SortUp - sorts the array up 

    SYNOPSIS
        void Heap::SortUp(T a_item); 
            a_item -> the item to be sorted up
       
    DESCRIPTION
        This function is responsible for sorting the array from the
        specified item, upwards. This is to maintain the structure of 
        the heap.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    void SortUp(T a_item)
    {
        int parentIndex = (a_item.HeapIndex - 1) / 2;

        while (true)
        {
            T parentItem = m_items[parentIndex];
            if (a_item.CompareTo(parentItem) > 0)
            {
                Swap(a_item, parentItem);
            }
            else
            {
                break;
            }

            parentIndex = (a_item.HeapIndex - 1) / 2;
        }
    }
/* void Heap::SortUp(T a_item); */

/**/
    /*
    Heap::Swap() Heap::Swap()

    NAME
        Heap::Swap - swaps two items

    SYNOPSIS
        void Heap::Swap(T a_itemA, T a_itemB); 
            a_itemA -> the first item to be swapped 
            a_itemB -> the second item to be swapped
       
    DESCRIPTION
        This function is responsible for swapping the position of two
        items in the heap.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    void Swap(T a_itemA, T a_itemB)
    {
        m_items[a_itemA.HeapIndex] = a_itemB;
        m_items[a_itemB.HeapIndex] = a_itemA;

        int itemAIndex = a_itemA.HeapIndex;

        a_itemA.HeapIndex = a_itemB.HeapIndex;
        a_itemB.HeapIndex = itemAIndex;
    }
/* void Heap::Swap(T a_itemA, T a_itemB); */
}
