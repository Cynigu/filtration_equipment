using Autofac;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP.command;
using UP.conteiner;
using UP.server;

namespace UP.vm
{
    class AbstractViewModelTable : ReactiveObject
    {

        #region Readonly
        protected readonly DB _dB;
        private readonly string _SelectedCommandText; // Для отображения таблицы 
        //private ContainerBuilder _myconteiner;
        protected IContainer _con;
        #endregion

        #region Constructors

        public AbstractViewModelTable(string SelectedCommandText, string tablename)
        {
            ContainerBuilder _myconteiner = MuConteiner.ContainerMain();
            _con = _myconteiner.Build();

            _SelectedCommandText = SelectedCommandText;
            TableName = tablename;

            DT = new DataTable();
            _dB = _con.Resolve<DB>(new NamedParameter("p1", DT));
            _dB.AddCommandSelectTable(_SelectedCommandText); // Подключаем таблицу, добавляем комманды
            _dB.FillTable(); // заполняем таблицу 
        }
        #endregion

        #region Fields
        private DataTable dt;
        private DataRowView selectedRow;
        private string tableName;
        private bool enavledButtonFroSelectedRow;
        #endregion
        #region Properties
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref tableName, value);
            }
        }
        public DataTable DT
        {
            get
            {
                return dt;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref dt, value);
            }
        }

        public bool EnavledButtonFroSelectedRow
        {
            get { return enavledButtonFroSelectedRow; }
            set { this.RaiseAndSetIfChanged(ref enavledButtonFroSelectedRow, value); }
        } // для блокировки возможностей (кнопок), которые не используется без выделенное строки 

        public DataRowView SelectedRow
        {
            get { return selectedRow; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedRow, value);
                if (SelectedRow != null) EnavledButtonFroSelectedRow = true;
                else EnavledButtonFroSelectedRow = false;
            }
        }

        #endregion

        #region Commands
        private IAsyncCommand fillCommand;
        public IAsyncCommand FillCommand
        {
            get
            {
                Func<Task> p1 = async () => { await FillAsync(); };
                return fillCommand ??
                    (fillCommand = _con.Resolve<IAsyncCommand>(new NamedParameter("p1", p1)));
            }
        }
        #endregion

        #region Methods
        public async Task FillAsync()
        {
            DT.Clear();
            await _dB.FillTableAsync();
        }
        public void Fill()
        {
            DT.Clear();
            _dB.FillTable();
        }
        #endregion
    }
}
