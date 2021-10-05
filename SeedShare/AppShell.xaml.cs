using SeedShare.Views;
using Xamarin.Forms;

namespace SeedShare
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LibraryAddPage), typeof(LibraryAddPage));
            Routing.RegisterRoute(nameof(LibraryEditPage), typeof(LibraryEditPage));
            Routing.RegisterRoute(nameof(LibraryDetailsPage), typeof(LibraryDetailsPage));
            Routing.RegisterRoute(nameof(LibrariesPage), typeof(LibrariesPage));
            Routing.RegisterRoute(nameof(SeedAddPage), typeof(SeedAddPage));
            Routing.RegisterRoute(nameof(SeedEditPage), typeof(SeedEditPage));
            Routing.RegisterRoute(nameof(SeedDetailsPage), typeof(SeedDetailsPage));
            Routing.RegisterRoute(nameof(SeedListPage), typeof(SeedListPage));
            Routing.RegisterRoute(nameof(UserAddPage), typeof(UserAddPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

        }
       
    }
}
