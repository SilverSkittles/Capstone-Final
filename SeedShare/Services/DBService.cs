using MvvmHelpers;
using MvvmHelpers.Commands;
using SeedShare.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Xamarin.Essentials;
using Plugin.Toast;

namespace SeedShare.Services
{
    public static class DBService
    {
        public static SQLiteAsyncConnection db;

        public static ObservableRangeCollection<Libraries> Libraries { get; private set; }
        public static ObservableRangeCollection<Seeds> Seeds { get; private set; }
        public static ObservableRangeCollection<UserData> Users { get; private set; }
        public static ICommand CallServerCommand { get; }
         

        //public static ObservableRangeCollection<Seeds> SeedCount { get; private set; }


        public static async Task Init()
        {
            
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Libraries>();
            await db.CreateTableAsync<Seeds>();
            await db.CreateTableAsync<UserData>();

            DummyData();
            
        }

        public static async void DummyData()
        {
            bool check = Preferences.Get("dummyCheck", false);
            if (check == true)
            {
                await GetLibraryList();
                await GetSeedList();
                await GetUserList();
            }
            else
            {
                Libraries libraries = new Libraries { libraryName = "POLLINATOR HAVEN HOTEL", libraryStreet = "3026 Lincoln Boulevard", libraryCity = "Omaha", libraryState = "Nebraska", libraryZip = "68131", libraryPhone = "000-000-0000", libraryHours = "24 hours", publicLibraryUrl = "NA" };
                Libraries libraries2 = new Libraries { libraryName = "BENSON BRANCH", libraryStreet = "6015 BINEY STREET", libraryCity = "Omaha", libraryState = "Nebraska", libraryZip = "68104", libraryPhone = "402-444-4846", libraryHours = "9a-7p M-Th, 9a-5p F-Sat", publicLibraryUrl = "https://omaha.bibliocommons.com/v2/search?query=Common+Soil+Seed+Library&searchType=subject&sort=TITLE&_ga=2.178402284.951276481.1633190641-2052652095.1629127981" };
                Libraries libraries3 = new Libraries { libraryName = "BESS JOHNSON ELKHORN", libraryStreet = "2100 READING PLAZA", libraryCity = "Omaha", libraryState = "Nebraska", libraryZip = "68022", libraryPhone = "402-289-4367", libraryHours = "9a-7p M-Th, 9a-5p F-Sat", publicLibraryUrl = "https://omaha.bibliocommons.com/v2/search?query=Common+Soil+Seed+Library&searchType=subject&sort=TITLE&_ga=2.178402284.951276481.1633190641-2052652095.1629127981" };
                Libraries libraries4 = new Libraries { libraryName = "MILLARD BRANCH", libraryStreet = "13214 WESTWOOD LANE", libraryCity = "Omaha", libraryState = "Nebraska", libraryZip = "68144", libraryPhone = "402-444-4848", libraryHours = "9a-7p M-Th, 9a-5p F-Sat, 1p-5p Sun", publicLibraryUrl = "https://omaha.bibliocommons.com/v2/search?query=Common+Soil+Seed+Library&searchType=subject&sort=TITLE&_ga=2.178402284.951276481.1633190641-2052652095.1629127981" };
                Libraries libraries5 = new Libraries { libraryName = "SOUTH OMAHA LIBRARY", libraryStreet = "2808 Q STREET", libraryCity = "Omaha", libraryState = "Nebraska", libraryZip = "68107", libraryPhone = "402-444-4850", libraryHours = "9a-7p M-Th, 9a-5p F-Sat", publicLibraryUrl = "https://omaha.bibliocommons.com/v2/search?query=Common+Soil+Seed+Library&searchType=subject&sort=TITLE&_ga=2.178402284.951276481.1633190641-2052652095.1629127981" };

                Seeds seeds = new Seeds { seedName = "WILD BERGAMOT", packetQuantity = "1", location = "POLLINATOR HAVEN HOTEL" };
                Seeds seeds2 = new Seeds { seedName = "GREEN ZEBRA TOMATO", packetQuantity = "3", location = "POLLINATOR HAVEN HOTEL" };
                Seeds seeds3 = new Seeds { seedName = "BRANDYWINE HEIRLOOM TOMATO", packetQuantity = "2", location = "POLLINATOR HAVEN HOTEL" };
                Seeds seeds4 = new Seeds { seedName = "ROYAL CATCHFLY", packetQuantity = "1", location = "POLLINATOR HAVEN HOTEL" };

                UserData users = new UserData { userName = "angela", password = "password" };

                await db.InsertAsync(libraries);
                await db.InsertAsync(libraries2);
                await db.InsertAsync(libraries3);
                await db.InsertAsync(libraries4);
                await db.InsertAsync(libraries5);

                await db.InsertAsync(seeds);
                await db.InsertAsync(seeds2);
                await db.InsertAsync(seeds3);
                await db.InsertAsync(seeds4);

                await db.InsertAsync(users);

                Preferences.Set("dummyCheck", true);

                
            }

        }

        public static async Task AddLibrary(string name, string street, string city, string state, string zip, string phone, string hours, string website)
        {
            await Init();
            var library = new Libraries
            {
                libraryName = name.ToUpperInvariant(),
                libraryStreet = street.ToString(),
                libraryCity = city,
                libraryState = state,
                libraryZip = zip.ToString(),
                libraryPhone = phone,
                libraryHours = hours,
                publicLibraryUrl = website
            };

            await db.InsertAsync(library);
        }

        public static async Task RemoveLibrary(int libraryId)
        {
            await Init();
            await App.Current.MainPage.DisplayPromptAsync("Delete Library", "Are you sure you want to delete this library?", accept: "Yes", cancel: "Cancel");
            await db.DeleteAsync<Libraries>(libraryId);
        }



        public static async Task<IEnumerable<Seeds>> FilterSeeds(string searchText)
        {
            await Init();
            return await db.Table<Seeds>().Where(s => s.seedName.Contains(searchText)).ToArrayAsync();
        }



        public static async Task<IEnumerable<Libraries>> FilterLibraries(string searchText)
        {
            await Init();
            return await db.Table<Libraries>().Where(s => s.libraryName.Contains(searchText)).ToArrayAsync();
        }



        public static async Task EditLibrary(Libraries libraryId, string name, string street, string city, string state, string zip, string phone, string hours, string website)
        {
            await Init();
            var existingLibrary = await db.FindAsync<Libraries>(libraryId);
            existingLibrary.libraryName = name.ToUpperInvariant();
            existingLibrary.libraryStreet = street;
            existingLibrary.libraryCity = city;
            existingLibrary.libraryState = state;
            existingLibrary.libraryZip = zip;
            existingLibrary.libraryPhone = phone;
            existingLibrary.libraryHours = hours;
            existingLibrary.publicLibraryUrl = website;
            await db.UpdateAsync(existingLibrary);
        }


        public static async Task<Libraries> GetLibrary(int id)
        {
            await Init();
            var library = await db.Table<Libraries>().FirstOrDefaultAsync(c => c.libraryId == id);
                                   
            return library;
        }



        public static async Task<IEnumerable<Libraries>> GetLibraryList()
        {
            await Init();
            var libraries = await db.Table<Libraries>().ToListAsync();
            return libraries;
            
        }

        public static async Task<IEnumerable<Seeds>> GetSeedList()
        {
            await Init();
            var seeds = await db.Table<Seeds>().ToListAsync();
            return seeds;

        }

        public static async Task<IEnumerable<UserData>> GetUserList()
        {
            await Init();
            var users = await db.Table<UserData>().ToListAsync();
            return users;
        }


        public static async Task AddSeed(string seedName, string packetQuantity, string location)
        {
            await Init();
          

            var dupeCheck = await db.Table<Seeds>().FirstOrDefaultAsync(c => c.seedName == seedName);
            if (dupeCheck == null)
            {
                var seed = new Seeds
                {
                    seedName = seedName.ToUpperInvariant(),
                    packetQuantity = packetQuantity,
                    location = location
                };
                await db.InsertAsync(seed);
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("This seed already exists");
            }            
        }


        public static async Task EditSeed(Seeds seedId, string name, string quantity, string location)
        {
            await Init();
            var existingSeed = await db.FindAsync<Seeds>(seedId);
            existingSeed.seedName = name.ToUpperInvariant();
            existingSeed.packetQuantity = quantity.ToString();
            existingSeed.location = location.ToString();
            await db.UpdateAsync(existingSeed);
        }



        public static async Task RemoveSeed(int seedId)
        {
            await Init();
            await App.Current.MainPage.DisplayPromptAsync("Delete this item?", "Are you sure you want to delete this seed?", accept: "Yes", cancel: "Cancel");
            await db.DeleteAsync<Seeds>(seedId);
        }
                

        public static async Task<Seeds> GetSeed(int id)
        {
            await Init();

            var seed = await db.Table<Seeds>().FirstOrDefaultAsync(c => c.seedId == id);

            return seed;
        }
        


        public static async Task AddUser(string userName, string password)
        {            
            await Init();            

            var dupeCheck = await db.Table<UserData>().FirstOrDefaultAsync(c => c.userName == userName);
            if(dupeCheck == null)
            {
                var user = new UserData
                {
                    userName = userName,
                    password = password,
                    active = true
                };
                await db.InsertAsync(user);
            }
            else
            {                
                CrossToastPopUp.Current.ShowToastMessage("Username already exists");
            }            
        }

        public static async Task RemoveUser(int userId, bool active) 
        {
            await Init();
            active = false;
            await db.DeleteAsync<UserData>(userId);
        }

        public static async Task<IEnumerable<UserData>> GetUser(int userId)
        {
            await Init();
            var user = await db.QueryAsync<UserData>(userId.ToString());
            return user;
        }

        public static async Task<bool> CheckUser(string username, string password)
        {
            bool isValid = false;
            
            var user = await db.Table<UserData>().FirstOrDefaultAsync(c => c.userName == username);
            //var pass = await db.Table<UserData>().FirstOrDefaultAsync(c => c.password == password);
            //string query = $"SELECT * FROM UserData WHERE userName = '{username}' AND password = '{password}'";
            
            

            if (user == null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Valid username and password are required");
                return isValid;                
            }
            else
            {
                if (user.password == password)
                {
                    isValid = true;
                    return isValid;
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage("Valid username and password are required");
                    return isValid;
                }
            }
            
        }
                
    }
}
