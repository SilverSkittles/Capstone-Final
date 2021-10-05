using Xamarin.Forms;
using MvvmHelpers;
using SeedShare.Services;
using SeedShare.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SeedShare.Models;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Plugin.Toast;

namespace SeedShare.ViewModels
{
    public class SeedsViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Seeds> Seeds { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Seeds> RemoveCommand { get; }
        public AsyncCommand EditCommand { get; set; }
        public AsyncCommand<int> SelectedSeedCommand { get; set; }

        public SeedsViewModel()
        {
            Title = "Seeds";
            Seeds = new ObservableRangeCollection<Seeds>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Seeds>(Remove);
            EditCommand = new AsyncCommand(Edit);
            SelectedSeedCommand = new AsyncCommand<int>(SelectedSeed);

        }



        public async Task SelectedSeed(int seedId)
        {
            try
            {

                var page = $"{nameof(SeedDetailsPage)}?SeedId={seedId}";
                await Shell.Current.GoToAsync($"//{nameof(SeedListPage)}/{page}");
            }
            catch (Exception oEx)
            {
                CrossToastPopUp.Current.ShowToastMessage($"Unable to retrieve that seed: {oEx.Message}");
            }

        }
        

        
        public async Task seedList()
        {
            var list = await DBService.GetSeedList();
            
        }

        public async Task Add()
        {            

            var route = $"{nameof(SeedAddPage)}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task Edit()
        {
            var route = $"{nameof(SeedDetailsPage)}";
            await Shell.Current.GoToAsync(route);
        }

        async Task Remove(Seeds seed)
        {
            await DBService.RemoveSeed(seed.seedId);
            await Refresh();
        }

        public async Task Refresh()
        {
            IsBusy = true;
            Seeds.Clear();

            var seeds = await DBService.GetSeedList();
            Seeds.AddRange(seeds);
            IsBusy = false;

        }

        public async Task FilterItems(string searchText)
        {
            try
            {
                var searchSeed = searchText;
                var seeds = await DBService.FilterSeeds(searchSeed);
                Seeds.Clear();
                Seeds.AddRange(seeds);               
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There were no matches for your search");
            }


        }
        
    }
}
