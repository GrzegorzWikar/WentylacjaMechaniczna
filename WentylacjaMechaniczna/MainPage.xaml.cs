using Microsoft.Maui.Controls.Shapes;

namespace WentylacjaMechaniczna
{
    public partial class MainPage : ContentPage
    {
        string[] TableHeaders = ["L.P", "Nazwa Pomieszczenia", "Powierzchnia [m2]", "Wysokosc pomieszczenia", "Kubatura [m3]", "Krotnosc Wymian [1/h]", "Obliczeniowy strumien powietrza nawiewanego [m3/h]", "Obliczeniowy strumien powietrza wywiewanego [m3/h]", "Przyjety strumien powietrza nawiewanego [m3/h]", "Przyjety strumien powietrza wywiewanego [m3/h]"];

        public MainPage()
        {
            InitializeComponent();

            ColumnDefinitionCollection columns = new ColumnDefinitionCollection();
            RowDefinitionCollection rows = new RowDefinitionCollection();
            foreach (string column in TableHeaders)
            {
                columns.Add(new ColumnDefinition());
                rows.Add(new RowDefinition());
            }

            rows[0].Height = 100;
            columns[0].Width = 60;

            Grid mainGrid = new Grid()
            {
                ColumnDefinitions = columns,
                RowDefinitions = rows,
            };

            mainGrid.Margin = 5;

            HorizontalStackLayout tableHeaders = [];
            tableHeaders.VerticalOptions = LayoutOptions.Start;
            HorizontalStackLayout tableRow = [];


            mainGrid.Add(tableHeaders);
            mainGrid.Add(tableRow);
           

            foreach (string header in TableHeaders)
            {
                
                Border headerBorder = newBorder();

                Label label = new() {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = header,
                    TextColor = Colors.White,
                };

                headerBorder.Content = label;
            
                mainGrid.Add(headerBorder, Array.IndexOf(TableHeaders,header), 0);

            }

            Content = mainGrid;
        }

        private Border newBorder()
        {
            Border mainBorder = new Border()
            {
                Stroke = Colors.DarkGoldenrod,
                BackgroundColor = Colors.DarkBlue,
                StrokeThickness = 4,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(40, 0, 0, 40)
                }
              ,
                Padding = new Thickness(16, 8),
                HorizontalOptions = LayoutOptions.Center,
            };

            return mainBorder;
        }
    }
}
