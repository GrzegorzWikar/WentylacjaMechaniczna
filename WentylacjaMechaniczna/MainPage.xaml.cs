using Microsoft.Maui.Controls.Shapes;
using GradientStop = Microsoft.Maui.Controls.GradientStop;
using WentylacjaMechaniczna.Models;
using System.Data.Common;

namespace WentylacjaMechaniczna
{
    public partial class MainPage : ContentPage
    {
        string[] TableHeaders = ["L.P", "Nazwa Pomieszczenia", "Powierzchnia [m2]", "Wysokosc pomieszczenia", "Kubatura [m3]", "Krotnosc Wymian [1/h]", "Obliczeniowy strumien powietrza nawiewanego [m3/h]", "Obliczeniowy strumien powietrza wywiewanego [m3/h]", "Przyjety strumien powietrza nawiewanego [m3/h]", "Przyjety strumien powietrza wywiewanego [m3/h]"];

        public VerticalStackLayout MainVeiw = [];
        public HorizontalStackLayout OperationBar = [];
        public ListView Table = new ();
        public List<Floor> Floors = new List<Floor> ();
        public MainPage()
        {
            InitializeComponent();
            Content = MainVeiw;

            Table.SetBinding(ItemsView.ItemsSourceProperty, "Floor");
            DataTemplate dataTemplate = new DataTemplate();
            ViewCell cell = new ViewCell();
            Table.ItemTemplate = dataTemplate;
            HorizontalStackLayout views = new HorizontalStackLayout();
            cell.AddLogicalChild(views);

           
            addTableHeaders();

            Table.Margin = 5;

            Button addRoom = new Button();
            addRoom.Text = "Add Room";
            addRoom.Clicked += NewRoom_Clicked;

            OperationBar.Add(addRoom);

            Button addFloor = new Button();
            addFloor.Text = "Add Floor";
            addFloor.Clicked += AddFloor_Clicked;

        }

        private void AddFloor_Clicked(object? sender, EventArgs e)
        {
            VerticalStackLayout newFloor = new VerticalStackLayout();
            Table.Add(newFloor);
            Table.

            Entry floorName = new Entry();
            floorName.Text = "Nazwa Kondgnacji";
            floorName.IsEnabled = true;


        }

        private void NewRoom_Clicked(object? sender, EventArgs e)
        {
            int rowCount = Table.RowDefinitions.Count + 1;

            foreach (string header in TableHeaders)
            {
                Border cellBorder = newBorder();

                switch (header)
                {
                    case "L.P":

                        Label label = new Label() 
                        {
                            Text = rowCount.ToString()
                        };

                        cellBorder.Content = label;

                        break;
                }

                Table.Add(cellBorder, Array.IndexOf(TableHeaders,header), rowCount);
            };
        }

        private void addTableHeaders()
        { 
            foreach (string header in TableHeaders)
            {
                Border headerBorder = newBorder();

                Label label = new()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontFamily = "Calibri",
                    Text = header,
                    TextColor = Colors.White,
                };

                headerBorder.Content = label;

                TableHeader.Add(headerBorder, Array.IndexOf(TableHeaders, header), 0);
            }

            TableHeader.ColumnDefinitions[0].Width = 60;
        }

        private Border newBorder()
        {
            Border mainBorder = new Border()
            {
                Stroke = new LinearGradientBrush
                {
                    EndPoint = new Point(0, 1),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop { Color = Color.FromArgb("#F0B651"), Offset = 0.1f },
                        new GradientStop { Color = Color.FromArgb("#F051CB"), Offset = 1.0f }
                    }
                },
                BackgroundColor = Color.FromArgb("#519EF0"),
                StrokeThickness = 4,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(20)
                }
              ,
                Padding = new Thickness(16, 8),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions= LayoutOptions.Fill,
                MaximumHeightRequest = 100,
            };

            return mainBorder;
        }
    }
}
