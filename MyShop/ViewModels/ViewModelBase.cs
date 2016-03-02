using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MvvmHelpers;

namespace MyShop
{
	public class ViewModelBase : BaseViewModel
	{
		protected Page page;
		public ViewModelBase(Page page)
		{
			this.page = page;
		}
	}
}
