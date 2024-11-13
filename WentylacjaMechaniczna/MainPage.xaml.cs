using Microsoft.Maui.Controls.Shapes;
using GradientStop = Microsoft.Maui.Controls.GradientStop;

namespace WentylacjaMechaniczna
{
    public partial class MainPage : ContentPage
    {
        string[] TableHeaders = ["L.P", "Nazwa Pomieszczenia", "Powierzchnia [m2]", "Wysokosc pomieszczenia", "Kubatura [m3]", "Krotnosc Wymian [1/h]", "Obliczeniowy strumien powietrza nawiewanego [m3/h]", "Obliczeniowy strumien powietrza wywiewanego [m3/h]", "Przyjety strumien powietrza nawiewanego [m3/h]", "Przyjety strumien powietrza wywiewanego [m3/h]"];

        public VerticalStackLayout MainVeiw = [];
        public HorizontalStackLayout OperationBar = [];
        public Grid Table = [];
        
        public MainPage()
        {
            InitializeComponent();

            Content = MainVeiw;
            MainVeiw.Add(OperationBar);
            MainVeiw.Add(Table);
            addTableHeaders();
            Table.Margin = 5;

            
            Button button = new Button();
            button.Text = "AddRoom";
            button.Clicked += NewRoom_Clicked;

            OperationBar.Add(button);
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

                Table.SetRow(cellBorder, rowCount);
                Table.SetColumn(cellBorder, Array.IndexOf(TableHeaders, header));

                int rowTest = Table.RowDefinitions.Count;
            }
        }

        private void addTableHeaders()
        {
            RowDefinitionCollection rows= new RowDefinitionCollection();
            RowDefinition row = new RowDefinition();
            ColumnDefinitionCollection columns = new ColumnDefinitionCollection();
            ColumnDefinition columnDefinition = new ColumnDefinition();
            rows.Add(row);

            foreach (string header in TableHeaders)
            {

                columns.Add(columnDefinition);
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

                Table.Add(headerBorder, Array.IndexOf(TableHeaders, header), 0);
            }

            Table.ColumnDefinitions[0].Width = 60;
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
