using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Professorweb_6_2
{
    public class SaveStatePage : Page
    {
        // єдине місце для зберігання словників стану всіх сторінок
        static protected Dictionary<int, Dictionary<string, object>> pages =
                                new Dictionary<int, Dictionary<string, object>>();

        // словник стану екземпляра сторінки
        protected Dictionary<string, object> pageState;

        // при першому відвіданні сторінки потрібно створити словник стану
        // наповнення словника відрізняється для різних екземплярів, тому
        // наповнення програмують у підкласах у перевизначеному методі
        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            if (args.NavigationMode == NavigationMode.New)
            {
                // Ключем статичного словника буде індекс сторінки у стеку повернення
                int pageKey = this.Frame.BackStackDepth;

                // Вилучити зі словника словників усі неактуальні ключі
                for (int key = pageKey; pages.Remove(key); key++) ;

                // Створити словник стану сторінки і занести його до єдиного словника словників
                pageState = new Dictionary<string, object>();
                pages.Add(pageKey, pageState);
            }
            // обов'язковий виклик !!!
            base.OnNavigatedTo(args);
        }
    }
}
