﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.CoreBusiness.Extensions
{
    static public class Extensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
             (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
