using Asp.EFCore.Data;
using AspEFCore.Domain;
using EFCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspEFCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;
        private readonly MyContext _context1;
        public HomeController(MyContext myContext, MyContext myContext1)
        {
            _context = myContext;
            _context1 = myContext1;
        }

        public IActionResult Index()
        {
            //Add

            #region 添加单条数据
            //var province = new Province
            //{
            //    /*Id会自动生成，如果Model中有Id属性并且是int类型的，
            //    那么EF会自动把它当成Id，并且在插入的时候自增，不需要赋值*/
            //    Name = "北京",
            //    Population = 3_00_000
            //};
            //_context.Provinces.Add(province);
            //_context.Add(province);

            //_context.SaveChanges();
            ///*插入完成之后会查出来自动生成的Id返回给EFCore，就是_context,
            //_context会把id赋值给上面创建的province对象*/
            #endregion

            #region 添加多条数据
            //var province = new Province
            //{
            //    Name = "北京",
            //    Population = 3_00_000
            //};
            //var province1 = new Province
            //{
            //    Name = "上海",
            //    Population = 2_00_000
            //};
            //var province2 = new Province
            //{
            //    Name = "广东",
            //    Population = 1_00_000
            //};

            //_context.Provinces.Add(province);
            //_context.Provinces.Add(province1);
            //_context.Provinces.Add(province2);
            //_context.SaveChanges();

            ////_context.Provinces.AddRange(province,province1,province2);
            ////_context.Provinces.AddRange(new List<Province> {
            ////    province,
            ////    province1,
            ////    province2
            ////} );

            ////_context.SaveChanges(); 
            #endregion

            #region 添加两个没有关联的数据
            //var province = new Province
            //{
            //    Name = "甘肃",
            //    Population = 2_00_000
            //};

            //var company = new Company
            //{
            //    Name = "Microsoft",
            //    EstablishDate = new DateTime(1980, 1, 1),
            //    LegaPerson = "Bill Gates"
            //};

            ///*
            // 插入两个没有关联不同的对象
            // 这时候就不能用_context.DbSet<T>属性.AddRang()方法了
            // 直接时候 _context.AddRange
            //*/
            //_context.AddRange(province, company);
            //_context.SaveChanges();
            #endregion

            #region 添加关联数据
            //添加新的数据以及关联数据--追踪状态下
            //var province = new Province
            //{
            //    Name = "陕西",
            //    Population=4_00_000,
            //    Cities=new List<City>
            //    {
            //        new City{ AreaCode="063",Name="西安"},
            //        new City{ AreaCode="064",Name="延安"}
            //    }

            //};

            //_context.Add(province);
            //_context.SaveChanges();

            //现有的数据上添加新的关联数据

            //var province = _context.Provinces.Single(x => x.Name == "陕西");

            //province.Cities.Add(new City
            //{
            //    AreaCode="065",
            //    Name="宝鸡"
            //});

            //_context.SaveChanges();


            //离线状态下添加关联的数据，要使用外键

            //var city = new City
            //{
            //    ProvinceId=4,
            //    AreaCode="067",
            //    Name= "榆林"
            //};

            //_context.Cities.Add(city);
            //_context.SaveChanges(); 
            #endregion

            //Query Filter

            #region 查询语法介绍
            //内部是LINQ，只是在组表达式，组SQL语句，只有.ToList()方法的时候才会查询，才会执行查询数据库
            //var provinces = _context.Provinces
            //    .Where(x => x.Name == "北京")
            //    .ToList();


            ////LINQ查询语法，也是在组表达式，只有.ToList()方法的时候才会查询，才会执行查询数据库
            //var provinces2 = (from p in _context.Provinces
            //                  where p.Name == "北京"
            //                  select p).ToList();


            ////没有ToList执行的是IQueryable<T>的集合，不会立即查询，只有在使用数据的时候才会查询数据库
            //var provinces3 = _context.Provinces
            //  .Where(x => x.Name == "北京").ToList();

            ////使用foreach遍历的时候会执行查询数据库
            ////这样遍历有危险，因为数据连接一直是打开着的，只有遍历完才会关闭连接
            ////如果有其他人在操作这张表，结果会乱掉
            ////最好是ToList()之后在让数据在内存，再遍历就不会有问题
            //foreach (var p in provinces3)
            //{
            //    //Console.WriteLine(p.Name);
            //} 
            #endregion

            #region Linq查询方法和非Linq查询方法
            ////查询，过滤
            ////Linq查询方法

            ////ToList() 会立即查询，放到集合（内存）里
            //var provinces_01 = _context.Provinces.ToList();


            ////First() 如果有一笔数据，就返回一笔，如果有两笔就返回第一笔，如果没有就抛异常
            //var provinces_02 = _context.Provinces.First();


            ////FirstOrDefault()按照查询条件，有就返回，没有就返回Null，不抛异常
            //var provinces_1 = _context.Provinces.FirstOrDefault();


            ////Single()期待查询结果只有一笔数据，如果多于一笔数据或者没有数据都会抛出异常
            //var provinces_2 = _context.Provinces.Single();


            ////SingleOrDefault() 如果有一笔数据就返回一笔，如果多与一笔就抛出异常，如果没有就返回Null
            //var provinces_3 = _context.Provinces.SingleOrDefault();


            ////先排序，返回的是最后一笔数据，和上面类似，要
            //var provinces_4 = _context.Provinces.OrderBy(x => x.Name).Last();
            //var provinces_5 = _context.Provinces.OrderBy(x => x.Name).LastOrDefault();


            ////效果是一样的
            //var provinces_10 = _context.Provinces.Where(x => x.Id == 3).ToList();
            //var provinces_11 = _context.Provinces.FirstOrDefault(x => x.Id == 3);


            ////Find()方法是非Linq查询方法，Find（）方法是DbSet的方法，
            ////如果查询的对象已经在内存中并且被EFCore追踪，那么EFCore就不会去数据库查询了，直接从内存中返回数据
            //var provinces_12 = _context.Provinces.Find(3);


            ////EF Core2.0中的EF.Functions.Like方法
            ////就相当于Name like '%北%'
            //var pars = "%北%";
            //var provinces_13 = _context.Provinces
            //    .Where(x =>
            //    EF.Functions.Like(x.Name, pars)
            //    ).ToList(); 
            #endregion

            #region 查询数据-预加载
            ////查询关联数据--预加载
            //var provinces = _context.Provinces
            //    .Include(x => x.Cities)
            //    .ToList();

            //var provinces2 = _context.Cities
            //    .Include(x => x.Province)
            //    .Include(x => x.CityCompanies)
            //    .Include(x => x.Mayor)
            //    .ToList();

            //var provinces1 = _context.Provinces
            //    .Include(x => x.Cities)
            //    .ThenInclude(x => x.CityCompanies)
            //    .ThenInclude(x => x.Company)
            //    .ToList(); 
            #endregion

            #region 修改
            ////修改属性
            //var province = _context.Provinces.FirstOrDefault();
            //if (province != null)
            //{
            //    //只更改了Population属性
            //    province.Population += 100;
            //    _context.SaveChanges();
            //}

            ////修改和添加同时
            //var province = _context.Provinces.FirstOrDefault();
            //if (province != null)
            //{
            //    province.Population += 100;
            //    _context.Provinces.Add(new Province
            //    {
            //        Name = "江苏",
            //        Population = 5_00_000
            //    });
            //    _context.SaveChanges();
            //}


            ////离线修改
            //var province = _context.Provinces.FirstOrDefault();
            //_context1.Provinces.Update(province);
            //_context1.SaveChanges(); 
            #endregion

            #region 查询数据 过滤

            //查询返回单个属性
            var province = _context.Provinces
                .Select(x => x.Name)
                .ToList();

            //查询多个属性，使用匿名对象构建自己想要的属性
            var provinceInfo = _context.Provinces
                .Select(x => new
                {
                    x.Id,
                    x.Name
                }).ToList();


            //使用动态类型，查询多个属性值在其他方法中使用
            var provincesInfo = Query();

            //查询多个自己需要的属性，属性中带有关联属性的
            var provincesINfo1 = _context.Provinces
                .Select(x => new
                {
                    x.Name,
                    x.Id,
                    Cities = x.Cities.Where(y => y.Name == "西安").ToList()
                }).ToList();


            //使用Any方法
            //表示关联属性Cities中Name为西安的会返回，返回的是province
            //带出查询条件符合的关联属性而不带出所有的关联属性
            var provinces = _context.Provinces
                .Where(x => x.Cities.Any(y => y.Name == "西安"))
                .ToList();



            //修改关联属性--一个上下文跟踪下
            var provincesInfo2 = _context.Provinces
                .Include(x => x.Cities)
                .First(x => x.Cities.Any());//查询有Cities的Province

            var city = provincesInfo2.Cities[0];
            city.Name += "Updated";
            _context.Cities.Update(city);

            //删除挂关联属性--上下文跟踪状态下
            var provincesInfo3 = _context.Provinces
                .Include(x => x.Cities)
                .First(x => x.Cities.Any());

            var city1 = provincesInfo3.Cities[0];

            _context.Cities.Remove(city1);



            //离线修改关联属性--没有被上下文跟踪
            //查询使用的是_context
            //Update使用的是_context1
            var provincesInfo4 = _context.Provinces
                .Include(x => x.Cities)
                .First(x => x.Cities.Any());//查询有Cities的Province

            var city2 = provincesInfo2.Cities[0];
            city2.Name += "Updated";
            //不合理的做法
            //使用_context1 更新_context查出来的province的City，就是相当于离线没有被同一个上下文实例跟踪，
            //这样provincesInfo4的关联属性City的所有name 都会被更新
            _context1.Cities.Update(city2);
            _context1.SaveChanges();

            //正确的做法
            //这样就会只修改当前更改的一个City的Name
            _context1.Entry(city2).State = EntityState.Modified;
            _context1.SaveChanges();



            #endregion
            return View();
        }

        private List<dynamic> Query()
        {
            var provincesInfo = _context.Provinces
                .Select(x => new
                {
                    x.Name,
                    x.Id
                })
                .ToList<dynamic>();
            return provincesInfo;
        }

    }
}
