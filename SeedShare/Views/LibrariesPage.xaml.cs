using SeedShare.ViewModels;
using System;
using SeedShare.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SeedShare.Models;
using Plugin.Toast;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.IO;
using Syncfusion.Drawing;
using System.Data;

namespace SeedShare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibrariesPage : ContentPage
    {
        public LibrariesPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = (LibrariesViewModel)BindingContext;
            await vm.Refresh();

        }



        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}"); //absolute route erases back stack instead of adding to the stack
        }



        private async Task SelectedLibrary(Libraries libraries)
        {
            try
            {
                if (libraries == null)
                    return;

                var route = $"{nameof(LibraryDetailsPage)}?LibraryId={libraries.libraryId}";
                await Shell.Current.GoToAsync($"//{nameof(LibrariesPage)}/{(route)}");
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("Unable to reach that page");
            }

        }



        private async void LibrarySearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = (LibrariesViewModel)BindingContext;
            await vm.FilterItems(e.NewTextValue);

        }

        private async void libraryPdf_Clicked(object sender, EventArgs e)
        {

            try
            {
                var vm = (LibrariesViewModel)BindingContext;
                // Column fields on report
                var list = vm.Libraries.Select(l => new { l.libraryName, l.libraryLocation, l.libraryHours, l.libraryPhone, l.publicLibraryUrl }).ToList();  


                //Creates a new PDF document
                PdfDocument document = new PdfDocument();
                //Adds page settings
                document.PageSettings.Orientation = PdfPageOrientation.Portrait;
                document.PageSettings.Margins.All = 50;
                //Adds a page to the document
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;

                PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
                RectangleF bounds = new RectangleF(176, 0, 390, 130);
                bounds = new RectangleF(0, bounds.Bottom + 90, graphics.ClientSize.Width, 30);
                // Draws a rectangle to place the heading in that region.
                graphics.DrawRectangle(solidBrush, bounds);
                //Creates a font for adding the heading in the page
                PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);

                //Creates a text element to add the invoice number
                PdfTextElement element = new PdfTextElement("Library List " + DateTime.Now.ToLongDateString(), subHeadingFont);
                element.Brush = PdfBrushes.White;

                //Draws the heading on the page
                PdfLayoutResult result = element.Draw(page, new PointF(10, 8)); 
                string currentDate = "DATE " + DateTime.Now.ToString("MM/dd/yyyy");
                //Measures the width of the text to place it in the correct location
                SizeF textSize = subHeadingFont.MeasureString(currentDate);
                PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
                //Draws the date by using DrawString method
                graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
                PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);

                //Creates text elements to add the address and draw it to the page.
                element = new PdfTextElement("Library List " + DateTime.Now.ToLongDateString(), timesRoman);
                element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 25));
                PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
                PointF startPoint = new PointF(0, result.Bounds.Bottom + 3);
                PointF endPoint = new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 3);
                //Draws a line at the bottom of the address
                graphics.DrawLine(linePen, startPoint, endPoint);

                
                PdfGrid grid = new PdfGrid();
                grid.DataSource = list;

                PdfGridCellStyle cellStyle = new PdfGridCellStyle();
                cellStyle.Borders.All = PdfPens.White;
                PdfGridRow header = grid.Headers[0];

                PdfGridCellStyle headerStyle = new PdfGridCellStyle();
                headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
                headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
                headerStyle.TextBrush = PdfBrushes.White;
                headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

                for (int i = 0; i < header.Cells.Count; i++)
                {
                    if (i == 0 || i == 1)
                        header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                    else
                        header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
                }

                header.ApplyStyle(headerStyle);
                cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
                cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
                cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));

                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                layoutFormat.Layout = PdfLayoutType.Paginate;
                PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);

                //saves file to memory stream then disk
                MemoryStream stream = new MemoryStream();
                document.Save(stream);
                document.Close(true);
                await DependencyService.Get<ISave>().SaveAndView(Path.GetRandomFileName() + ".pdf", "application/pdf", stream);

            }
            catch (Exception oEx)
            {
                
                CrossToastPopUp.Current.ShowToastMessage("Unable to create a PDF at this time");
            }                       

        }
      
    }
}