using AutoRepairService.Domain.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Core.Primitives
{
    public class PagedList<T>
        where T : class
    {
        public int TotalPageCount => Items.Count;
        public int CurrentPage { get; set; }
        public IEnumerable<T> CurrentItem { get; private set; }
        public Dictionary<int, IEnumerable<T>> Items { get; set; }

        public void Fill(IEnumerable<T> collection, int size)
        {
            var pageCount = collection.ToList().Count / size;

            var splits = collection.Split(pageCount);

            int pointer = 0;
            foreach (var item in splits)
            {
                Items.Add(pointer, item);
                pointer++;
            }

            CurrentItem = Items.First().Value;
            CurrentPage = Items.First().Key;
        }
        public void Next() 
        {
            CurrentPage++;
            CurrentItem = Items.First(x=> x.Key == CurrentPage).Value;
        }

        public void Previous() 
        {
            CurrentPage--;
            CurrentItem = Items.First(x => x.Key == CurrentPage).Value;
        }
    }
}
