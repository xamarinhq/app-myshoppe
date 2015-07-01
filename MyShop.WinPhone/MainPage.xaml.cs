using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyShop.WinPhone.Resources;
using ImageCircle.Forms.Plugin.WindowsPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace MyShop.WinPhone
{
	public partial class MainPage : FormsApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			Forms.Init();
			Xamarin.FormsMaps.Init();
			Xamarin.Insights.Initialize("c3d88c6f124fdabdf8880b65845094bb7bad90ac");
			Xamarin.Insights.ForceDataTransmission = true;
			ImageCircleRenderer.Init();
			LoadApplication(new MyShop.App());
		}
	}
}