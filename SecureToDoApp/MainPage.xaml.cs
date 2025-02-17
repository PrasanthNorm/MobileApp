using SecureToDoApp.ViewModel;

namespace SecureToDoApp
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage(TodoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
       
    }

}
