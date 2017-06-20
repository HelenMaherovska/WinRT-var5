using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Professorweb_6_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : SaveStatePage
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            // Визначення стану блокування кнопок
            forwardBtn.IsEnabled = this.Frame.CanGoForward;
            backBtn.IsEnabled = this.Frame.CanGoBack;

            if (args.NavigationMode != NavigationMode.New)
            {
                // Створити ключ словника
                int pageKey = this.Frame.BackStackDepth;

                // отримати словник стану для поточної сторінки
                pageState = pages[pageKey];

                // Отримати стан сторінки зі словника
                firstTxt.Text = pageState["FirstTextBoxText"] as string;
                //firstTxt.SelectionStart = (int)pageState["FirstTextBoxText"];

                secondTxt.Text = pageState["SecondTextBoxText"] as string;
            }
            // !!!
            base.OnNavigatedTo(args);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs args)
        {
            pageState.Clear();

            // Зберегти стан сторінки в словнику
            pageState.Add("FirstTextBoxText", firstTxt.Text);
            pageState.Add("SecondTextBoxText", secondTxt.Text);

            base.OnNavigatedFrom(args);
        }
        private void ThirdPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ThirdPage));
        }
        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoForward();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            (this.Resources["myStoryboard"] as Storyboard).Begin();
            XmlDocument tileData = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Image);
            XmlNodeList imageData = tileData.GetElementsByTagName("image");
            ((XmlElement)imageData[0]).SetAttribute("src", "ms-appx:///assets/roses.png");
            var notification = new TileNotification(tileData);
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(5);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }
    }
}
