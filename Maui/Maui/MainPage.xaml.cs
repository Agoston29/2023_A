using Maui.Mountain;

namespace Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MountainViewModel(); // összeköti a MainPage-t a MountainViewModel-el DAGADT
        }
    }
}
