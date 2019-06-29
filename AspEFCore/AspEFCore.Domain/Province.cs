using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Model
{
    public class Province
    {
        public Province()
        {
            Cities = new List<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        /// <summary>
        /// 导航属性，一个省份对应多个城市
        /// </summary>
        public List<City> Cities { get; set; }
    }
}
