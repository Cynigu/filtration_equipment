using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP.server
{
    interface IDB
    {
        void AddCommandTable(string SelectText);
        void AddCommandSelectTable(string SelectText);
        Task FillTableAsync();
        Task UpdateBDAsync();
        void UpdateBD();
        void FillTable();
        MySqlConnection GetConnect();
    }
}
