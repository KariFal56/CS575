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
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App)App.Current).ResumeAtDefectReportId = -1;
            DefectList.ItemsSource = await App.Database.GetItemsAsync();
        }


        public void onItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var defectItem = e.SelectedItem as DefectReportItem;
            
            if (defectItem == null)
            {
                return;
            }

            ContentPage page = null;

            page = new DefectEntryPage();

            page.BindingContext = defectItem;
            Navigation.PushAsync(page);

        }
    }
}