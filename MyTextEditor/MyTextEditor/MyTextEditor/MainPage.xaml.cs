using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.Text;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyTextEditor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<string> fonts = new List<string>();
        private List<int> fontsizes = new List<int>();

        SpeechSynthesizer speechSynthesizer;
        ApplicationView appView = ApplicationView.GetForCurrentView();

        public MainPage()
        {
            this.InitializeComponent();
            // this.RequestedTheme = ElementTheme.Dark;
            FillListFonts();
            fontfamilyCmbBox.ItemsSource = fonts;
            fontsizeCmbBox.ItemsSource = fontsizes;
            fontsizeCmbBox.SelectedIndex = 15; // because there is 16th size as default
            speechSynthesizer = new SpeechSynthesizer();
        }
        
        private void FillListFonts()
        {
            List<InstalledFont> mylist = InstalledFont.GetFonts();
            foreach(InstalledFont font in mylist)
            {
                fonts.Add(font.Name);
            }
            fontsizes.AddRange(Enumerable.Range(1, 72));
        }

        private void boldButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ITextCharacterFormat format = editText.Document.Selection.CharacterFormat;
             format.Bold = FormatEffect.Toggle;
            editText.Focus(FocusState.Programmatic);
        }

        private void fontIncButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            int i = fontsizeCmbBox.SelectedIndex;
            if (i != fontsizeCmbBox.Items.Count - 1)
            {
                fontsizeCmbBox.SelectedValue = fontsizeCmbBox.Items[++i];
            }
            editText.Focus(FocusState.Programmatic);
        }

        private void fontDecButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int i = fontsizeCmbBox.SelectedIndex;
            if (i != 0)
            {
                fontsizeCmbBox.SelectedValue = fontsizeCmbBox.Items[--i];
            }
            editText.Focus(FocusState.Programmatic);
        }

        private void italicButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ITextCharacterFormat format = editText.Document.Selection.CharacterFormat;
            format.Italic =  FormatEffect.Toggle;
            editText.Focus(FocusState.Programmatic);
        }

        private void underlineButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ITextCharacterFormat format = editText.Document.Selection.CharacterFormat;
            if (underlineButton.IsChecked == true)
            {
                format.Underline = UnderlineType.Single;
            }
            else format.Underline = UnderlineType.None;
            editText.Focus(FocusState.Programmatic);
        }

        //private void leftAlign_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    ITextParagraphFormat format = editText.Document.Selection.ParagraphFormat;
        //    if (leftAlign.IsChecked == true)
        //    {
        //        format.Alignment = ParagraphAlignment.Left;
        //    }
        //    else format.Alignment = ParagraphAlignment.Undefined;
        //    editText.Focus(FocusState.Programmatic);
        //}

        //private void AlignText_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    ITextParagraphFormat format = editText.Document.Selection.ParagraphFormat;
        //    if (leftAlign.IsChecked == true)
        //    {
        //        format.Alignment = ParagraphAlignment.Left;
        //        rightAlign.IsChecked = centerAlign.IsChecked = justifyAlign.IsChecked = false;
        //    }
        //    else if (rightAlign.IsChecked == true)
        //    {
        //        format.Alignment = ParagraphAlignment.Right;
        //        leftAlign.IsChecked = centerAlign.IsChecked = justifyAlign.IsChecked = false;
        //    }
        //    else if (centerAlign.IsChecked == true)
        //    {
        //        format.Alignment = ParagraphAlignment.Center;
        //        rightAlign.IsChecked = leftAlign.IsChecked = justifyAlign.IsChecked = false;
        //    }
        //    else if (justifyAlign.IsChecked == true)
        //    {
        //        format.Alignment = ParagraphAlignment.Justify;
        //        rightAlign.IsChecked = leftAlign.IsChecked = centerAlign.IsChecked = false;
        //    }
        //    else
        //    {
        //        format.Alignment = ParagraphAlignment.Undefined;
        //        rightAlign.IsChecked = leftAlign.IsChecked = centerAlign.IsChecked  = justifyAlign.IsChecked = false;
        //    }
        //    editText.Focus(FocusState.Programmatic);
        //}


        //private async void Talk(string message)
        //{
        //    var stream = await speechSynthesizer.SynthesizeTextToStreamAsync(message);
            
        //    media.SetSource(stream, stream.ContentType);
        //    media.Play();
        //}

        //private void speechButton_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    string textToSpeak = editText.Document.Selection.Text;
        //    Talk(textToSpeak);
        //}

        private void fontcolButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ITextCharacterFormat format = editText.Document.Selection.CharacterFormat;

            if (fontcolButton.IsChecked == true)
            //{
                format.ForegroundColor = Windows.UI.Colors.MediumVioletRed;
            //}
            else format.ForegroundColor = Windows.UI.Colors.Black;
        }

        private void newdocButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            editText.Document.SetText(TextSetOptions.None, string.Empty);
            appView.Title = "Новий документ";
        }

        private async void saveButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.DefaultFileExtension = ".txt";
            picker.FileTypeChoices.Add("Text", new List<string> { ".txt" });
            StorageFile storageFile = await picker.PickSaveFileAsync();
            
            if (storageFile == null)
                return;

            using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                editText.Document.SaveToStream(TextGetOptions.FormatRtf, stream);
            }
            appView.Title = storageFile.DisplayName;
        }

        private void cutButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            editText.Document.Selection.Cut();
        }

        private void copyButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            editText.Document.Selection.Copy();
        }

        private void pasteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            editText.Document.Selection.Paste(0);
        }

        private async void closeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog msg = new Windows.UI.Popups.MessageDialog("Ви дійсно хочете вийти? Збережіть файл, якщо потрібно.", "Попередження");
            msg.Commands.Add(new Windows.UI.Popups.UICommand("Так") { Id = 0 , Label = "Yes"});
            msg.Commands.Add(new Windows.UI.Popups.UICommand("Зберегти файл") { Id = 1, Label = "Save" });
            var result =  await  msg.ShowAsync();
            if (result.Label == "Yes")
            {
                
                App.Current.Exit();
            }
        }

        private async void opendocButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".txt");
            StorageFile storageFile = await picker.PickSingleFileAsync();
            
            if (storageFile == null)
                return;

            using (IRandomAccessStream stream = await storageFile.OpenReadAsync())
            {

                editText.Document.LoadFromStream(TextSetOptions.FormatRtf, stream);
            }
            appView.Title = storageFile.DisplayName;
        }

        private void backcolButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ITextCharacterFormat format = editText.Document.Selection.CharacterFormat;
           if (backcolButton.IsChecked == true)
            //{
                format.BackgroundColor = Windows.UI.Colors.PaleGreen;
            //}
            else format.BackgroundColor = Windows.UI.Colors.White;

        }

        private void editText_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoForward)
                Frame.GoForward();
            else
                Frame.Navigate(typeof(SecondPage));
        }
    }
}
