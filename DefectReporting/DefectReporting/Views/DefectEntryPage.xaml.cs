using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefectReporting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefectEntryPage : ContentPage
	{
		public DefectEntryPage ()
		{
            InitializeComponent();
        }

        public DefectEntryPage(DefectReportItem passedDefect)
        {
            InitializeComponent();
        }

        async void OnUpdate(object sender, EventArgs e)
        {
            var defectReportItem = (DefectReportItem)BindingContext;
            await App.Database.SaveItemAsync(defectReportItem);
            await Navigation.PopAsync();
        }

        async void OnDelete(object sender, EventArgs e)
        {
            var defectReportItem = (DefectReportItem)BindingContext;
            await App.Database.DeleteItemAsync(defectReportItem);
            await Navigation.PopAsync();
        }

        async void OnCancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            //await Navigation.PushAsync(new MainPage());
        }
    }
}