using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.ViewModels.EmployeesViewModels
{
    public class EmployeeSortViewModel
    {
        public SortState EmployeeIdSort { get; private set; }
        public SortState EmployeeNameSort { get; private set; }
        public SortState EmployeeSurnameSort { get; private set; }
        public SortState EmployeePatronymicSort { get; private set; }
        public SortState EmployeeExecutionStartDateSort { get; private set; }
        public SortState EmployeeDateOfDeliverySort { get; private set; }
        public SortState Current { get; private set; }

        public EmployeeSortViewModel(SortState sortOrder)
        {
            EmployeeIdSort = sortOrder == SortState.EmployeeIdAsc ? SortState.EmployeeIdDec : SortState.EmployeeIdAsc;
            EmployeeNameSort = sortOrder == SortState.EmployeeNameAsc ? SortState.EmployeeNameDec : SortState.EmployeeNameAsc;
            EmployeeSurnameSort = sortOrder == SortState.EmployeeSurnameAsc ? SortState.EmployeeSurnameDec : SortState.EmployeeSurnameAsc;
            EmployeePatronymicSort = sortOrder == SortState.EmployeePatronymicAsc ? SortState.EmployeePatronymicDec : SortState.EmployeePatronymicAsc;
            EmployeeExecutionStartDateSort = sortOrder == SortState.EmployeeExecutionStartDateAsc ? SortState.EmployeeExecutionStartDateDec : SortState.EmployeeExecutionStartDateAsc;
            EmployeeDateOfDeliverySort = sortOrder == SortState.EmployeeDateOfDeliveryAsc ? SortState.EmployeeDateOfDeliveryDec : SortState.EmployeeDateOfDeliveryAsc;
            Current = sortOrder;
        }
    }
}
