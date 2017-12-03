using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        async void OnSubmit(object sender, EventArgs e)
        {
            var defectReportItem = (DefectReportItem)BindingContext;
            await App.Database.SaveItemAsync(defectReportItem);
            await Navigation.PopAsync();
        }

        async void OnUpdate(object sender, EventArgs e)
        {
            var defectReportItem = (DefectReportItem)BindingContext;
            await App.Database.UpdateItemAsync(defectReportItem);
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