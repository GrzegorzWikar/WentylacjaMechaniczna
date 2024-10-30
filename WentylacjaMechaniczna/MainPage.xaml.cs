namespace WentylacjaMechaniczna
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var rooms = new List<Room> 
            {
                new Room("Kuchnia", 20.5M, 2.5M )
            };

           //homeView.ItemsSource = rooms;

        }
    }
}
