using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Feature.Teams.ViewModels
{
    public class PreviousWinnerYearViewModel
    {
        public string Year { get; set; }

        public List<YearRowViewModel> Details { get; set; }
    }
}
