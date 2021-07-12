using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP.vm
{
    class ViewModel : AbstractViewModelTable
    {
        public ViewModel(string SelectedCommandText, string tablename) : base(SelectedCommandText, tablename)
        {
        }
    }
}
