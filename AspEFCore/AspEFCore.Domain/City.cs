using AspEFCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Model
{
    public class City
    {
        public City()
        {
            CityCompanies = new List<CityCompany>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string AreaCode { get; set; }
       public int ProvinceId { get; set; }
        /// <summary>
        /// 导航属性，一个城市对应一个省份
        /// </summary>
        public Province Province { get; set; }
        public List<CityCompany> CityCompanies { get; set; }
        //  一个城市对应一个市长 
        public Mayor Mayor { get; set; }
    }
}
