using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public ViewModelBase CurrentModelViewModel { get; set; }
        public bool IsOpen { get; set; }
    }
}
