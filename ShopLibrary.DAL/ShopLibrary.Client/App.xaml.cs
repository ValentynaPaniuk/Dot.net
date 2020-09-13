using Autofac;
using AutoMapper;
using ShopLibrary.BLL.Services;
using ShopLibrary.BLL.Utils;
using ShopLibrary.DAL;
using ShopLibrary.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShopLibrary.Client
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
   
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<ShopService>().As<IShopService>();
            builder.RegisterType<MainWindow>().AsSelf();

            var config = new MapperConfiguration(cgf => cgf.AddProfile(new MapperConfig()));
                builder.RegisterInstance(config.CreateMapper());

            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.ShowDialog();
            }
        }
    }
}
