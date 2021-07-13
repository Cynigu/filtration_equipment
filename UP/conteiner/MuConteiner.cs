using Autofac;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UP.command;
using UP.server;

namespace UP.conteiner
{
    class MuConteiner
    {
        public static ContainerBuilder ContainerMain()
        {
            var builderBase = new ContainerBuilder();
            //builderBase.RegisterType<DataTable>().AsSelf();
            //builderBase.RegisterType<DB>().As<IDB>().UsingConstructor(typeof(DataTable));
            builderBase.RegisterType<ExportDataTableToWordService>().AsSelf().As<IExportDataTable>();
            builderBase.RegisterType<DefaultDialogService>().AsSelf().As<IDialogService>();

            builderBase.Register((c, p) => new DB(p.Named<DataTable>("p1"), p.Named<string>("p2"))).AsSelf().As<IDB>();
            builderBase.Register((c, p) => new DB(p.Named<DataTable>("p1"))).AsSelf().As<IDB>();

            builderBase.Register((c, p) =>new AsyncCommand(p.Named<Func<Task>>("p1"))).AsSelf().As<IAsyncCommand>();
            builderBase.Register((c, p) => new RelayCommand(p.Named<Action<object>>("p1"))).AsSelf().As<ICommand>();
            //builderBase.Register((c, p) => new RelayCommand(p.Named<Action<object>>("p1"), p.Named<Func<object, bool>>("p2"))).AsSelf().As<ICommand>();

            return builderBase;
        }
    }
}
