using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RaycastComparer : Comparer<RaycastHit>
{
    override public int Compare(RaycastHit x, RaycastHit y)
    {
        return x.distance.CompareTo(y.distance);
    }
}
