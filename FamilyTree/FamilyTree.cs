using System;
using System.Collections.Generic;
using System.Linq;

namespace Family
{
    internal class FamilyInfo
    {
        public int Id { get; set; }
        public List<int> ParentIds { get; set; }
        public string Name { get; set; }

        public FamilyInfo(int id, List<int> parentIds, string name)
        {
            Id = id;
            Name = name;
            ParentIds = new List<int>();
            ParentIds = parentIds;
        }
    }

    internal class FamilyTree
    {
        static void Main(string[] args)
        {
            var items = new List<FamilyInfo>() {
                new FamilyInfo(1, new List<int> {0}, "pat_grandpa"),
                new FamilyInfo(2, new List<int> {0}, "pat_grandma"),
                new FamilyInfo(3, new List<int> {0}, "mat_grandpa"),
                new FamilyInfo(4, new List<int> {0}, "mat_grandma"),
                new FamilyInfo(5, new List<int> {1,2}, "Dad"),
                new FamilyInfo(6, new List<int> {3,4}, "Mom"),
                new FamilyInfo(7, new List<int> {5,6}, "me"),
                new FamilyInfo(8, new List<int> {0}, "inlaw_dad"),
                new FamilyInfo(9, new List<int> {0}, "inlaw_mom"),
                new FamilyInfo(10, new List<int> {8,9}, "wife"),
                new FamilyInfo(11, new List<int> {7,10}, "mykid"),                
             };

            items.ForEach(item => Console.WriteLine(item.Id + ":"  +  item.Name + GetParentsString(items, item) + Environment.NewLine));
          
            Console.ReadLine();
        }

        private static string GetParentsString(List<FamilyInfo> all, FamilyInfo current)
        {
            string path = string.Empty;

            Action<List<FamilyInfo>, FamilyInfo, int> GetPath = null;

            GetPath = (List<FamilyInfo> ps, FamilyInfo p, int indent) => {

                var indentLines = new string(' ', indent);
                var parents = all.Where(x => p.ParentIds.Any(y => y == x.Id));
                
                foreach (var parent in parents)
                {
                    path += Environment.NewLine + indentLines +  parent.Name;                  
                    GetPath(ps, parent, indent +2);
                }                
            };

            GetPath(all, current, 2);
           
            return path;
        }
    }
} 
