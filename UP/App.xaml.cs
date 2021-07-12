using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UP.vm;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //logger.Info("Запуск приложения...");
            var builderBase = new ContainerBuilder();
            //builderBase.RegisterType<DB>().As<IDB>();
            string select = "select * from аппарат left join характеристика on характеристика.аппарат = аппарат.id;";
            builderBase.Register(c => new ViewModel(select , "Оборудование")).AsSelf();
            var containerBase = builderBase.Build();
            var viewmodelBase = containerBase.Resolve<ViewModel>();
            var viewBase = new MainWindow { DataContext = viewmodelBase };
            viewBase.Show();
        }
    }
}
