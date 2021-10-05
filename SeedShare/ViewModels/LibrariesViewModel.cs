using Xamarin.Forms;
using MvvmHelpers;
using SeedShare.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SeedShare.Models;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using SeedShare.Services;
using Plugin.Toast;

namespace SeedShare.ViewModels
{
    public class LibrariesViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Libraries> Libraries { get; set; }       
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Libraries> RemoveCommand { get; }
        public AsyncCommand <int>EditLibraryCommand { get; set; }
        public AsyncCommand<int> SelectedLibraryCommand { get; set; }
        //public AsyncCommand<int> SelectedEditLibraryCommand { get; set; }

        public LibrariesViewModel()
        {
            Title = "Libraries";
            Libraries = new ObservableRangeCollection<Libraries>();            
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Libraries>(Remove);
            EditLibraryCommand = new AsyncCommand<int>(Edit);                        
            RefreshCommand = new AsyncCommand(Refresh);
            SelectedLibraryCommand = new AsyncCommand<int>(SelectedLibrary);
           // SelectedEditLibraryCommand = new AsyncCommand<int>(SelectedEditLibrary);

        }

        
        public async Task SelectedLibrary(int libraryId)
        {
            try
            {               

                var route = $"{nameof(LibraryDetailsPage)}?LibraryId={libraryId}";
                await Shell.Current.GoToAsync($"//{nameof(LibrariesPage)}/{route}");
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("Unable to retrieve that Library");
            }
            

        }

       

        public async Task Add()
        {                       
            var route = $"{nameof(LibraryAddPage)}";
            await Shell.Current.GoToAsync(route);

        }

        public async Task Edit(int libraryId)
        {
            
            var route = $"{nameof(LibraryDetailsPage)}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task Remove(Libraries library)
        {            
            await DBService.RemoveLibrary(library.libraryId);
            await Refresh();
        }

        public async Task Refresh()
        {
            IsBusy = true;
            Libraries.Clear();

            var libraries = await DBService.GetLibraryList();
            Libraries.AddRange(libraries);
            IsBusy = false;
            
        }


        public async Task FilterItems(string searchText)
        {
            try
            {
                var searchSeed = searchText;
                var libraries = await DBService.FilterLibraries(searchSeed);
                Libraries.Clear();
                Libraries.AddRange(libraries);                
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There were no matches for your search");
            }


        }
    }
}
