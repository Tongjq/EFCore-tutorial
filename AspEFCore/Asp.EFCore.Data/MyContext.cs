using AspEFCore.Domain;
using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.EFCore.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 配置表关系
            // base.OnModelCreating(modelBuilder);
            //配置CityCompany的联合主键
            modelBuilder.Entity<CityCompany>().HasKey(x => new { x.CityId, x.CompanyId });
            //配置一个City对应多个Company
            modelBuilder.Entity<CityCompany>().HasOne(x => x.City).WithMany(x => x.CityCompanies).HasForeignKey(x => x.CityId);
            //配置一个Company多个City
            modelBuilder.Entity<CityCompany>().HasOne(x => x.Company).WithMany(x => x.CityCompanies).HasForeignKey(x => x.CompanyId);
            //配置一个Province对应多个City
            modelBuilder.Entity<City>().HasOne(x => x.Province).WithMany(x => x.Cities).HasForeignKey(x => x.ProvinceId);
            //配置一个City对应一个Mayor，一个city对应一个Mayjor
            modelBuilder.Entity<Mayor>().HasOne(x => x.City).WithOne(x => x.Mayor)
                .HasForeignKey<Mayor>(x => x.CityId);
            #endregion

            #region 添加种子数据
            modelBuilder.Entity<Province>().HasData(
                   new Province
                   {
                       Id = 1,
                    //Id = 10,
                    Name = "甘肃省",
                       Population = 20_000_000
                   },
                   new Province
                   {
                       Id = 2,
                    //没有ID迁移的时候会报错
                    Name = "陕西",
                       Population = 15_000_000
                   },
                   new Province
                   {
                       Id = 4,
                       Name = "山西",
                       Population = 17_000_000,
                   }
                   );

            modelBuilder.Entity<City>().HasData
                (
                     new { ProvinceId = 4, Id = 61, Name = "太原" },
                     new { ProvinceId = 4, Id = 62, Name = "大同" }
                );


            var studenId = new Guid("170e3505-f717-4201-8a9e-6a592ab358e4");
            modelBuilder.Entity<Student>().HasData
                (
                    // new Student { Id =  Guid.NewGuid(), Name = "刘备" }
                    new Student { Id = studenId, Name = "奥巴马" }
                ); 
            #endregion
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<CityCompany> CityCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Mayor> Mayor { get; set; }

    }
}
