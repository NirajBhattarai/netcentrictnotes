using System;
using System.IO.Pipelines;

namespace EmployeeManagement.Models
{
    public class PieListViewModel
    {
        
         public IEnumerable<Pie> Pies { get; }
        public string? CurrentCategory { get; }

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }
    }
    
}

