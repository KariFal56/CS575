using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace DefectReporting
{
    public partial class MainPage : ContentPage
    {
        private ZXingScannerPage scanPage;

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnGo(object sender, EventArgs e)
        {
            string workOrderNumber = workOrderText.Text;

            if (!string.IsNullOrWhiteSpace(workOrderNumber) && workOrderNumber.Length < 40)
            {
                userMessage.Text = "";
                await Navigation.PushAsync(new DefectEntryPage());
            }
            else
            {
                userMessage.Text = "Work Order should be < 40 characters and cannot be blank";
            }
        }

        async void OnGoHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }

        //Scanner button
       async void OnScan(object sender, EventArgs e)
        //scanButton.Clicked(sender,args)=>
        {
            string scanResult = "";
            scanPage = new ZXingScannerPage();
            scanPage.Title = "Scan Work Order Number";

            scanPage.Disappearing += (sender2, args2) =>
             {
                 scanPage.IsScanning = false;
             };

            scanPage.OnScanResult += (result) =>
              {
                  scanPage.IsScanning = false;
                  Navigation.PopAsync();
                  scanResult = result.Text;
              };

            await Navigation.PushAsync(scanPage);

        }
    }
}