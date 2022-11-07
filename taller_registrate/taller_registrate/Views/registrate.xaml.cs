using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taller_registrate.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taller_registrate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registrate : ContentPage
    {
        public registrate()
        {
            InitializeComponent();
            BindingContext = new RegistrateViewModel();
        }

    }
}