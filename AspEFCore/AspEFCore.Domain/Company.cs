using System;
using System.Collections.Generic;
using System.Text;

namespace AspEFCore.Domain
{
    public class Company
    {
        public Company()
        {
            CityCompanies = new List<CityCompany>();
        }
        public int Id { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 公司成立时间
        /// </summary>
        public DateTime EstablishDate { get; set; }
        /// <summary>
        /// 公司法人
        /// </summary>
        public string LegaPerson { get; set; }
        /// <summary>
        /// 一个公司有多个城市
        /// </summary>
        public List<CityCompany> CityCompanies { get; set; }

    }
}
