using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Library_UWP.Helper
{ //samma info kan ligga i main.xaml.cs i UWP
    public static class FileHelper
    {

        public static async Task<string> GetFileContentAsync(string fileName)//hämta innerhål
        {//använda standart windows catalog

            //StorageFolder storageFolder = ApplicationData.Current.LocalFolder;//standart windows catalog
            StorageFolder storageFolder = KnownFolders.DocumentsLibrary;//catalog
            StorageFile file = await storageFolder.GetFileAsync(fileName);//hämta fil

            //läsa fil innerhål:
            return await FileIO.ReadTextAsync(file);//return direct , ! spara/hämta text from file

        }





    }
}
