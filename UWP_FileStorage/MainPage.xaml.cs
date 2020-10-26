using GalaSoft.MvvmLight.Views;
using Library_UWP.Helper;
using Library_UWP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;//++
using Windows.Storage.Pickers;
using Windows.Storage.Search;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Library_UWP.Model.CustomerViewModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_FileStorage
{
    public sealed partial class MainPage : Page
    {
       
        public PersonViewModel ViewModel { get; set; }
        private CustomerViewModel customerViewModel { get; set; }


        public MainPage() //kan vara GetFile(), ReadFile()
        {
            this.InitializeComponent();

            // ReadTextFromFileAsync().GetAwaiter();
        }



        //f . hämta from helper folder :
        private async Task GetFileContentAsync(string filename)// när startar textblock få info  .json i text
        {
            tblContent.Text = await FileHelper.GetFileContentAsync(filename);

        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //  WriteTextToFileAsync().GetAwaiter();
        }



        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".json");
            picker.FileTypeFilter.Add(".xml");
            picker.FileTypeFilter.Add(".csv");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                tblAllFile.Text = await FileHelper.GetFileContentAsync(file.Name);//Picked file: file.Name;
            }
            else
            {
                tblAllFile.Text = "Operation cancelled.";
            }
        }

        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    var context = ((FrameworkElement)sender).DataContext;
        //    (DataContext as TextBlock)?.RemoveHandler( TappedEvent,context); 
        //                                                 // (DataContext as PersonViewModel)?.RemoveItem((Person)context);// ++removeItem  f.i PersonVM
        //}       

        private void btnJson_Click(object sender, RoutedEventArgs e)
        {
            GetFileContentAsync("t.json").GetAwaiter();
        }

        private async void btnCSV_Click(object sender, RoutedEventArgs e)
        {
            //GetFileContentAsync("text upp1.csv").GetAwaiter();
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            picker.FileTypeFilter.Add(".csv");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                string[] lines = File.ReadAllLines(file.Path);
                for (int i = 1; i < lines.Count(); i++)
                {
                    string[] data2 = lines[i].Split(';');
                }
            }
            else
            {
                btnCSV.DataContext = "Operation cancelled.";
            }
        }

        private void btnAddPersons_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PersonView));
        }

    }

}









