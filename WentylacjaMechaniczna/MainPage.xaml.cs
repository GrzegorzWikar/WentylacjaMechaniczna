using Microsoft.Maui.Controls.Shapes;
using GradientStop = Microsoft.Maui.Controls.GradientStop;

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
            HorizontalStackLayout menagmentBar = new HorizontalStackLayout();

            foreach (string column in TableHeaders)
            {
                columns.Add(new ColumnDefinition());
            }

            RowDefinition row = new RowDefinition();
            rows.Add(row);

            columns[0].Width = 60;
            VerticalStackLayout mainVertical = new VerticalStackLayout();
            mainVertical.VerticalOptions = LayoutOptions.Start;
            Grid mainGrid = new Grid()
            {
                ColumnDefinitions = columns,
                RowDefinitions = rows,
            };

            mainGrid.Margin = 5;
            mainVertical.Add(menagmentBar);

            mainVertical.Add(mainGrid);

            
            Button button = new Button();
            button.Text = "Kliknij mnie chuju";
            button.Clicked += (s, e) =>  NewRow();

            menagmentBar.Add(button);


            void NewRow()
            {
                HorizontalStackLayout row = [];
                int rowCount = mainGrid.RowDefinitions.Count;
                foreach (string header in TableHeaders)
                {
                    int columnId = Array.IndexOf(TableHeaders, header);

                    Border cellBorder = newBorder();

                    cellBorder.Content = new Entry();

                    row.Add(cellBorder);

                    mainGrid.Add(row, columnId, rowCount);
                }
            }

            HorizontalStackLayout tableHeaders = [];
            tableHeaders.VerticalOptions = LayoutOptions.Start;
            tableHeaders.HorizontalOptions = LayoutOptions.Fill;
            RowDefinition rowTableHeaders = new RowDefinition();
            rows.Add(rowTableHeaders);

            mainGrid.Add(tableHeaders, 0, 1);
            
            //Naglowki
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

            Content = mainVertical;
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
