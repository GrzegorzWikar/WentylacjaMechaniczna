using Microsoft.Maui.Controls.Shapes;
using GradientStop = Microsoft.Maui.Controls.GradientStop;
using System.Windows;

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
                    FontFamily = "Calibri",
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
                HorizontalOptions = LayoutOptions.Center,
            };

            return mainBorder;
        }
    }
}
