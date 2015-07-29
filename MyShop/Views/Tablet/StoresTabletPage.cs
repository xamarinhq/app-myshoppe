using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MyShop.Views.Tablet
{
    public class StoresTabletPage : MasterDetailPage
    {
        public StoresTabletPage()
        {
            Title = "Stores";
            
            Master = new StoresPage();

            Detail = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "Select a Shop", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) }
                    }
                }
            };

            ((StoresPage)Master).ItemSelected = (store) =>
            {
                Detail = new StorePage(store);
                if(Device.OS != TargetPlatform.Windows)
                    IsPresented = false;
            };

            IsPresented = true;
        }

        protected override bool OnBackButtonPressed()
        {
            if (IsPresented)
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                IsPresented = true;
                return true;
            }
        }
    }
}
