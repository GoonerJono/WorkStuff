using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFunction
{
    class Program
    {
        private static List<Area> areaList = new List<Area>();
        static void Main(string[] args)
        {
            
            areaList.Add(new Area {Id = 1,Description="Continent",ParentId = 0});
            areaList.Add(new Area {Id = 2,Description="Country",ParentId = 1});
            areaList.Add(new Area {Id = 3,Description="Province",ParentId = 2});
            areaList.Add(new Area {Id = 4,Description="City1",ParentId = 3});
            areaList.Add(new Area {Id = 5,Description="Suburb1",ParentId = 6});
            areaList.Add(new Area {Id = 6,Description="City2",ParentId = 3});
            areaList.Add(new Area {Id = 7,Description= "Suburb2", ParentId = 6});
            areaList.Add(new Area {Id = 8,Description= "Suburb3", ParentId = 6});
            areaList.Add(new Area {Id = 9,Description= "Suburb4", ParentId = 4});
            areaList.Add(new Area {Id = 10,Description="House1",ParentId = 7});
            areaList.Add(new Area {Id = 11,Description= "House3", ParentId = 9});
            areaList.Add(new Area {Id = 12,Description= "House4", ParentId = 8});
            areaList.Add(new Area {Id = 13,Description= "House5", ParentId = 8});
            areaList.Add(new Area {Id = 14,Description="House6",ParentId = 7});
            var startIndent = areaList.Find((x) => x.ParentId == 0);
            UpdateIndent(startIndent, startIndent.ParentId + 1);
            Console.ReadLine();
        }

        public static void UpdateIndent(Area area, int level)
        {
            Console.WriteLine(new string('-', level) + area.Description);
            foreach (var child in areaList.FindAll((x) => x.ParentId == area.Id).OrderBy(x => x.Id))
            {
                UpdateIndent(child, level + 1);
            }
        }
    }
}
