using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyTextEditor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThirdPage : Page
    {
        public ThirdPage()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // BadgeUpdateManager.CreateBadgeUpdaterForApplication().Clear();
            TileUpdater tu = TileUpdateManager.CreateTileUpdaterForApplication();
            tu.EnableNotificationQueue(true);

            string[] mess = new string[] { " Tile", " demo", " for", "exam" };
            for (int tileNum = 1; tileNum <= mess.Length; ++tileNum)
            {
                XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);
                tileXml.GetElementsByTagName("text")[0].AppendChild(tileXml.CreateTextNode("#" + mess[tileNum - 1]));
                tu.Update(new TileNotification(tileXml));


            }
            XmlDocument xmlBadge = new XmlDocument();
            xmlBadge.LoadXml(@"<badge value=""attention""/>");
            var badgeNotification = new BadgeNotification(xmlBadge);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeNotification);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            XmlDocument tileData = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Block);
            XmlNodeList textData = tileData.GetElementsByTagName("text");
            textData[0].InnerText = "+5";
            textData[1].InnerText = "From PMA";
            var notification = new TileNotification(tileData);
            //notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(15);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            XmlDocument tileData = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Image);
            XmlNodeList imageData = tileData.GetElementsByTagName("image");
            ((XmlElement)imageData[0]).SetAttribute("src", "ms-appx:///assets/mainphoto.jpg");
            var notification = new TileNotification(tileData);
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(5);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            TileUpdater tu = TileUpdateManager.CreateTileUpdaterForApplication();
            tu.EnableNotificationQueue(true);

            string[] mess = new string[] { " Hello", " World", " from", " PMA", " forever!" };
            for (int tileNum = 1; tileNum <= 5; ++tileNum)
            {
                XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);
                tileXml.GetElementsByTagName("text")[0].AppendChild(tileXml.CreateTextNode("#" + tileNum + mess[tileNum - 1]));
                tu.Update(new TileNotification(tileXml));
            }
        }

        private void Back_ToMainPageClick(object sender, RoutedEventArgs e)
        {
            //перехід на першу сторінку
            List<PageStackEntry> pageEntries = Frame.BackStack.ToList();
            if (pageEntries.Count > 0)
                Frame.Navigate(pageEntries[0].SourcePageType);
        }
        private void r2(object sender, RoutedEventArgs e)
        {

            grid3.Background = new SolidColorBrush(Colors.Green);

        }

        private void r1(object sender, RoutedEventArgs e)
        {
            //object o = e.OriginalSource;
            //if (sender.Equals(o))
            //{
            //    txtbox.Background = new SolidColorBrush(Colors.Green);
            //}
            grid3.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
