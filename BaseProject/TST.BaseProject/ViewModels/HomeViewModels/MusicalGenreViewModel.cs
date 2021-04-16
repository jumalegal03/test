using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TST.BaseProject.ViewModels.HomeViewModels
{
    public class MusicalGenreViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
