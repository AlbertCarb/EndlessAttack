using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// This is the interface to access and manipulate the heap's index value

public interface IHeapItem<T> : IComparable<T>
{
    int HeapIndex
    {
        get;
        set;
    }
}
