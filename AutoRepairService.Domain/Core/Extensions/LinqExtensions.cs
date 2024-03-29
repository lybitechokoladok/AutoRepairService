﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Core.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts) 
        {
            int i = 0;
            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();

            return splits;
        }
    }
}
