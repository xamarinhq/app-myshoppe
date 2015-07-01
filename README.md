# My Shoppe - Connect with your customers

Cross-platform Xamarin.Forms sample application template enabling you to easily connect with your customers and manage your stores. All powered by ([Xamarin](http://www.xamarin.com)) and ([Xamarin.Forms](http://www.xamarin.com/forms)) with a powerful Azure Mobile Apps backend with 100% shared code across iOS, Android, and Windows Phone.

Open Source Project by ([@JamesMontemagno](http://www.twitter.com/jamesmontemagno)) 

![](art/myshoppepromo.png)

## Consumer Application
The My Shoppe consumer application enables you as a shop owner to easily connect with your customer base. This highly themeable application enabled you to create a browesable list of shop locations so your consumers can find the closest location to them, call the shop, see shop hours, and even navigate to the shop with a single click.


### Features
* Browse Stores / Locations (with online/offline sync)
* Location Information: address, phone, store hours, and more
* Navigate to Location
* Call Location with 1 click
* Leave feedback for visit

![](art/MyShoppeHeroSmall.png)

### Download Sample Application
You can download the sample My Shoppe application for the following platforms:

* **Android** available on [Google Play](https://play.google.com/store/apps/details?id=com.refractored.myshoppe)
* **iPhone & iPad** available soon on App Store **Awaiting certification**
* **Windows Phone** available on [Windows Store](https://www.windowsphone.com/en-us/store/app/my-shoppe/8641ed20-1bf6-412d-ae28-a5f785cc6546)

## Admin Application
In addition to the consumer application that you can release into the store I create a very simple Administration application that allows you to manager all your shops and feedback from customers. It uses the same backend from the consumer application and even shares some of the same UI and code. 

### Features
* Create and Manage your Shops
* Browse & Manage Feedback from customers

![](art/MyShoppeAdminHero.png)

## My Shoppe Setup

### Azure Mobile Apps
My Shoppe leverages the brand new Azure App Service called [Azure Mobile Apps](http://azure.microsoft.com/en-us/services/app-service/mobile/) which is the next evolution of Azure Mobile Services. I have implemented the backend datastore with a simple interface, [IDataStore.cs](https://github.com/jamesmontemagno/MyShoppe/blob/master/MyShop/Interfaces/IDataStore.cs) that registers itself with the Xamarin.Forms Dependency Service. You could always create and implement your own XML or Json based service using this method.

I have provided my existing .NET Backend for reference on how to create your controllers and data entities to publish to Azure. Read through the [Azure Mobile Apps tutorial](https://azure.microsoft.com/en-us/documentation/articles/app-service-mobile-dotnet-backend-xamarin-android-get-started-preview/) to learn how to create and setup your own Mobile Apps backend for My Shoppe. 

Once you have your backend setup you will want to enter your very own Azure Mobile Apps credentials in the [AzureDataStore.cs file on the following lines](https://github.com/jamesmontemagno/MyShoppe/blob/master/MyShop/Services/AzureDataStore.cs#L29-L32):

```
MobileService = new MobileServiceClient(
				"Mobile App URL",
				"Gateway URI",
				"Application Key");

```

### (Xamarin Insights)[http://www.xamarin.com/insights] Integration
Xamarin Insights provides a simple and effective way real time monitoring of your mobile apps for crashes and events. My Shoppe integrated Insights for both crash reporting and event tracking. Simply follow the (Xamarin Insights Documentation)[https://insights.xamarin.com/docs] to create an API Key for your application. Once you have that simply replace all instances of the demo key: 
```
Insights.Initialize("c3d88c6f124fdabdf8880b65845094bb7bad90ac");
```
with
```
Insights.Initialize("Your Key");
```

### App Customization
Easily adjust the shop's name, sorting, and of course customize My Shoppe to Your Shoppe with your own branding and styles.

Simply replace the hero.png images with your companies logo or banner.

#### Brand Colors
Use your shop's brand colors and theming easily:

1. Modify [MyShoppe.Android/Resources/values/colors.xml](https://github.com/jamesmontemagno/MyShoppe/blob/master/MyShop.Android/Resources/values/colors.xml) with your Primary, Primary Dark, and Accent Color. I recommend using [materialpalette.com](http://www.materialpalette.com) for help.
2. String Replace 3498DB with your Primary color in all xaml pages


### Built with Xamarin & Amazing Plugins
Built in C# and powered by ([Xamarin](http://www.xamarin.com)) from inside of Visual Studio and Xamarin Studio. In addition there was a plethora of amazing NuGet packages and [Plugins for Xamarin](http://www.github.com/xamarin/plugins) that helped in the creation of this application. You can see a full list of open source licenses [here](https://github.com/jamesmontemagno/MyShoppe/blob/master/OpenSource.md).

* 
* 
* 



## License
The MIT License (MIT)
Copyright (c) 2015 Refractored LLC / James Montemagno

See latest License file [here](https://github.com/jamesmontemagno/MyShoppe/blob/master/LICENSE).

## Privacy Policy
Please see the latest at: http://refractored.ghost.io/about/
