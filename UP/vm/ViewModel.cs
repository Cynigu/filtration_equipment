using Autofac;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using UP.model;
using UP.server;

namespace UP.vm
{
    class ViewModel : AbstractViewModelTable
    {
        //private IContainer _con;
        IDialogService _dialogservice;
        public ViewModel(string SelectedCommandText, string tablename) : base(SelectedCommandText, tablename)
        {
            //ContainerBuilder _myconteiner = MuConteiner.ContainerMain();
            //_con = _myconteiner.Build();
            _dialogservice = _con.Resolve<IDialogService>();
        }
        #region fields

        private bool checkbox10;
        private bool checkbox11;

        private bool checkbox20;
        private bool checkbox21;

        private bool checkbox30;
        private bool checkbox31;

        private bool checkbox40;
        private bool checkbox41;
        private bool checkbox42;

        private bool checkbox50;
        private bool checkbox51;
        private bool checkbox52;
        private bool checkbox53;

        private bool checkbox60;
        private bool checkbox61;
        private bool checkbox62;
        private bool checkbox63;
        private bool checkbox64;
        private bool checkbox65;
        private bool checkbox66;
        private bool checkbox67;
        private bool checkbox68;

        private bool checkbox70;
        private bool checkbox71;
        private bool checkbox72;
        private bool checkbox73;
        private bool checkbox74;
        private bool checkbox75;
        private bool checkbox76;
        #endregion
        #region properties
        #region f1
        // filter 1
        public bool Checkbox10
        {
            get { return checkbox10; }
            set { this.RaiseAndSetIfChanged(ref checkbox10, value); }
        }
        public bool Checkbox11
        {
            get { return checkbox11; }
            set { this.RaiseAndSetIfChanged(ref checkbox11, value); }
        }
        #endregion
        #region f2
        // filter 2
        public bool Checkbox20
        {
            get { return checkbox20; }
            set { this.RaiseAndSetIfChanged(ref checkbox20, value); }
        }
        public bool Checkbox21
        {
            get { return checkbox21; }
            set { this.RaiseAndSetIfChanged(ref checkbox21, value); }
        }
        #endregion

        #region f3
        // filter 3
        public bool Checkbox30
        {
            get { return checkbox30; }
            set { this.RaiseAndSetIfChanged(ref checkbox30, value); }
        }
        public bool Checkbox31
        {
            get { return checkbox31; }
            set { this.RaiseAndSetIfChanged(ref checkbox31, value); }
        }
        #endregion

        #region f4
        // filter 4
        public bool Checkbox40
        {
            get { return checkbox40; }
            set { this.RaiseAndSetIfChanged(ref checkbox40, value); }
        }
        public bool Checkbox41
        {
            get { return checkbox41; }
            set { this.RaiseAndSetIfChanged(ref checkbox41, value); }
        }
        public bool Checkbox42
        {
            get { return checkbox42; }
            set { this.RaiseAndSetIfChanged(ref checkbox42, value); }
        }
        #endregion

        #region f5
        // filter 5
        public bool Checkbox50
        {
            get { return checkbox50; }
            set { this.RaiseAndSetIfChanged(ref checkbox50, value); }
        }
        public bool Checkbox51
        {
            get { return checkbox51; }
            set { this.RaiseAndSetIfChanged(ref checkbox51, value); }
        }
        public bool Checkbox52
        {
            get { return checkbox52; }
            set { this.RaiseAndSetIfChanged(ref checkbox52, value); }
        }
        public bool Checkbox53
        {
            get { return checkbox53; }
            set { this.RaiseAndSetIfChanged(ref checkbox53, value); }
        }
        #endregion
        #region f6
        // filter 6
        public bool Checkbox60
        {
            get { return checkbox60; }
            set { this.RaiseAndSetIfChanged(ref checkbox60, value); }
        }
        public bool Checkbox61
        {
            get { return checkbox61; }
            set { this.RaiseAndSetIfChanged(ref checkbox61, value); }
        }
        public bool Checkbox62
        {
            get { return checkbox62; }
            set { this.RaiseAndSetIfChanged(ref checkbox62, value); }
        }
        public bool Checkbox63
        {
            get { return checkbox63; }
            set { this.RaiseAndSetIfChanged(ref checkbox63, value); }
        }
        public bool Checkbox64
        {
            get { return checkbox64; }
            set { this.RaiseAndSetIfChanged(ref checkbox64, value); }
        }
        public bool Checkbox65
        {
            get { return checkbox65; }
            set { this.RaiseAndSetIfChanged(ref checkbox65, value); }
        }
        public bool Checkbox66
        {
            get { return checkbox66; }
            set { this.RaiseAndSetIfChanged(ref checkbox66, value); }
        }
        public bool Checkbox67
        {
            get { return checkbox67; }
            set { this.RaiseAndSetIfChanged(ref checkbox67, value); }
        }
        public bool Checkbox68
        {
            get { return checkbox68; }
            set { this.RaiseAndSetIfChanged(ref checkbox68, value); }
        }
        #endregion


        #region f7
        // filter 6
        public bool Checkbox70
        {
            get { return checkbox70; }
            set { this.RaiseAndSetIfChanged(ref checkbox70, value); }
        }
        public bool Checkbox71
        {
            get { return checkbox71; }
            set { this.RaiseAndSetIfChanged(ref checkbox71, value); }
        }
        public bool Checkbox72
        {
            get { return checkbox72; }
            set { this.RaiseAndSetIfChanged(ref checkbox72, value); }
        }
        public bool Checkbox73
        {
            get { return checkbox73; }
            set { this.RaiseAndSetIfChanged(ref checkbox73, value); }
        }
        public bool Checkbox74
        {
            get { return checkbox74; }
            set { this.RaiseAndSetIfChanged(ref checkbox74, value); }
        }
        public bool Checkbox75
        {
            get { return checkbox75; }
            set { this.RaiseAndSetIfChanged(ref checkbox75, value); }
        }
        public bool Checkbox76
        {
            get { return checkbox76; }
            set { this.RaiseAndSetIfChanged(ref checkbox76, value); }
        }
        #endregion

        #endregion

        #region commands
        private ICommand apllyFilterCommand;
        public ICommand ApplyFilterCommand
        {
            get
            {
                Action<object> p1 = obj => { ApplyFilter(); };

                return apllyFilterCommand ??
                  (apllyFilterCommand = _con.Resolve<ICommand>(new NamedParameter("p1", p1)));
            }
        }
        private ICommand reportFilterCommand;
        public ICommand ReportFilterCommand
        {
            get
            {
                Action<object> p1 = obj => { Report(); };

                return reportFilterCommand ??
                  (reportFilterCommand = _con.Resolve<ICommand>(new NamedParameter("p1", p1)));
            }
        }
        private ICommand resetFilterCommand;
        public ICommand ResetFilterCommand
        {
            get
            {
                Action<object> p1 = obj => { ResetFilter(); };

                return resetFilterCommand ??
                  (resetFilterCommand = _con.Resolve<ICommand>(new NamedParameter("p1", p1)));
            }
        }
        #endregion

        #region methods
        private void ApplyFilter()
        {
            //string filter = "";
            List<string> filters = new List<string>();

            bool[] f1 = new bool[] { Checkbox10, Checkbox11};
            string ColumnName1 = "Принцип действия во времени";
            string[] enum1 = new string[] { "Периодический" , "Непрерывный" };
            filters.Add(Filter.GenerateFilterString(f1, ColumnName1, enum1));

            bool[] f2 = new bool[] { Checkbox20, Checkbox21 };
            string ColumnName2 = "Степень очистки";
            string[] enum2 = new string[] { "Грубая", "Тонкая" };
            filters.Add(Filter.GenerateFilterString(f2, ColumnName2, enum2));

            bool[] f3 = new bool[] { Checkbox30, Checkbox31 };
            string ColumnName3 = "Очищающие среды";
            string[] enum3 = new string[] { "Фильтры для суспензий", "Фильтры для аэрозолей" };
            filters.Add(Filter.GenerateFilterString(f3, ColumnName3, enum3));

            bool[] f4 = new bool[] { Checkbox40, Checkbox41, Checkbox42 };
            string ColumnName4 = "Направление движения фильтрата и действия силы тяжести";
            string[] enum4 = new string[] { "Противоположное", "Cовпадающее", "Перекрестное" };
            filters.Add(Filter.GenerateFilterString(f4, ColumnName4, enum4));

            bool[] f5 = new bool[] { Checkbox50, Checkbox51, Checkbox52, Checkbox53 };
            string ColumnName5 = "Способ создания движущей силы";
            string[] enum5 = new string[] { "Друк-фильтры", "Вакуумный", "Под наливом", "Комбинированный" };
            filters.Add(Filter.GenerateFilterString(f5, ColumnName5, enum5));

            bool[] f6 = new bool[] { Checkbox60, Checkbox61, Checkbox62, Checkbox63, Checkbox64, Checkbox65, Checkbox66, Checkbox67, Checkbox68 };
            string ColumnName6 = "Конструкция";
            string[] enum6 = new string[] { "Нутч-фильтры", "Фильтр – прессы", "Листовые", "Патронные",
                "Барабанные", "Дисковая", "Ленточная", "Карусельная" , "Рукавная"};
            filters.Add(Filter.GenerateFilterString(f6, ColumnName6, enum6));

            bool[] f7 = new bool[] { Checkbox70, Checkbox71, Checkbox72, Checkbox73, Checkbox74, Checkbox75, Checkbox76};
            string ColumnName7 = "Фильтрующий материал";
            string[] enum7 = new string[] { "Песок", "Картон", "Гравий", "Ткань",
                "Сетка", "Пористый полимерный материал", "Керамика"};
            filters.Add(Filter.GenerateFilterString(f7, ColumnName7, enum7));

            string filter = Filter.GenerateFullFilter(filters);

            DT.DefaultView.RowFilter = filter;
        }

        private void ResetFilter()
        {
            Checkbox10 = false;
            Checkbox11 = false;
            Checkbox20 = false;
            Checkbox21 = false;
            Checkbox30 = false;
            Checkbox31 = false;
            Checkbox40 = false;
            Checkbox41 = false;
            Checkbox42 = false;
            Checkbox50 = false;
            Checkbox51 = false;
            Checkbox52 = false;
            Checkbox53 = false;

            Checkbox60 = false;
            Checkbox61 = false;
            Checkbox62 = false;
            Checkbox63 = false;
            Checkbox64 = false;
            Checkbox65 = false;
            Checkbox66 = false;
            Checkbox67 = false;
            Checkbox68 = false;

            Checkbox70 = false;
            Checkbox71 = false;
            Checkbox72 = false;
            Checkbox73 = false;
            Checkbox74 = false;
            Checkbox75 = false;
            Checkbox76 = false;
            DT.DefaultView.RowFilter = "";
        }

        private void Report()
        {
            IExportDataTable export = _con.Resolve<IExportDataTable>();
            if (_dialogservice.SaveFileDialog() == true)
            {
                export.Save(_dialogservice.FilePath, DT);
                _dialogservice.ShowMessage("Файл сохранен");
            }
        }
        #endregion
    }
}
