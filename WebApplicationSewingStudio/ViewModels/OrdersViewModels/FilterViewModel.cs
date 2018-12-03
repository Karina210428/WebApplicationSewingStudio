using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSewingStudio.ViewModels.OrdersViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(int id)
        {
            SelectedId = id;
        }
        public int SelectedId { get; private set; }
    }
}
