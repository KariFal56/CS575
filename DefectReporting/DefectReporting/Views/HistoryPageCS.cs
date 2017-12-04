using Xamarin.Forms;

namespace DefectReporting
{
    public class HistoryPageCS : ContentPage
    {
        public ListView DefectList;

        public HistoryPageCS()
        {

            Title = "History";

            //Label header = new Label
            //{
            //   Text = "History",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center
            //};

            var toolbarItem = new ToolbarItem
            {
                Text = "+",
                Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Views.DefectEntryPageCS
                {
                    BindingContext = new DefectReportItem()
                });
            };
            ToolbarItems.Add(toolbarItem);

            // Define some data.
            //List<DefectReportItem> defects = App.Database.GetItemsAsync();
            //List<DefectReportItem> defects = new List<DefectReportItem>
            //{
            //await App.Database.GetItemsAsync();
            //};

            // Create the ListView.
            DefectList = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    label.SetBinding(Label.TextProperty, "Defect");  //was Name

                    var tick = new Image
                    {
                        Source = ImageSource.FromFile("check.png"),
                        HorizontalOptions = LayoutOptions.End
                    };
                    tick.SetBinding(VisualElement.IsVisibleProperty, "useDefect");

                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(20, 0, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label, tick }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            DefectList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new Views.DefectEntryPageCS
                    {
                        BindingContext = e.SelectedItem as DefectReportItem
                    });
                }
            };

            Content = DefectList;
        }
    }
}
