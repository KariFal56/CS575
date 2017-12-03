using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DefectReporting
{
    public partial class MainPage : ContentPage
    {
        string workOrderNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnGo(object sender, EventArgs e)
        {
            workOrderNumber = workOrderText.Text;
            if (!string.IsNullOrWhiteSpace(workOrderNumber) && workOrderNumber.Length < 40)
            {
                //UserMessage = "";
                await Navigation.PushAsync(new DefectEntryPage());
            }
            else
            {
                //UserMessage = "Work Order should be < 40 characters and cannot be blank";
            }
        }

        async void OnGoHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
    }
}