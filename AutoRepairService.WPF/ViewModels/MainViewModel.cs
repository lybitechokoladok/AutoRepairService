using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableObject CurrentViewModel { get; set; }
        public ObservableObject CurrentModelViewModel { get; set; }
        public bool IsOpen { get; set; }
    }
}
