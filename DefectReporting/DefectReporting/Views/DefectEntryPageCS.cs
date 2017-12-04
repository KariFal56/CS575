using Xamarin.Forms;

namespace DefectReporting.Views
{
    public class DefectEntryPageCS : ContentPage
    {
        public DefectEntryPageCS()
        {
            Title = "Defect Item";

            var countEntry = new Entry();
            countEntry.SetBinding(Entry.TextProperty, "count");

            var defectEntry = new Entry();
            defectEntry.SetBinding(Entry.TextProperty, "defect");

            var dispositionEntry = new Entry();
            dispositionEntry.SetBinding(Entry.TextProperty, "disposition");

            var useDefectSwitch = new Switch();
            useDefectSwitch.SetBinding(Switch.IsToggledProperty, "useDefect");

            var dateLabel = new Label();
            dateLabel.SetBinding(Label.TextProperty, "date");

            var workOrderLabel = new Label();
            workOrderLabel.SetBinding(Label.TextProperty, "workOrderNumber");

            var idLabel = new Label();
            idLabel.SetBinding(Label.TextProperty, "id");

            var updateButton = new Button { Text = "Update" };
            updateButton.Clicked += async (sender, e) =>
            {
                var defectReportItem = (DefectReportItem)BindingContext;
                await App.Database.SaveItemAsync(defectReportItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var defectReportItem = (DefectReportItem)BindingContext;
                await App.Database.DeleteItemAsync(defectReportItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Work Order" },
                    workOrderLabel,
                    new Label { Text = "Defective Count" },
                    countEntry,
                    new Label { Text = "Defect" },
                    defectEntry,
                    new Label { Text = "Disposition" },
                    dispositionEntry,
                    new Label { Text = "Date" },
                    dateLabel,
                    new Label { Text = "Use Defect Again?" },
                    useDefectSwitch,
                    updateButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
