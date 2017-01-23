using Xamarin.Forms;

namespace MyShop
{
    public class GroupHeader : ViewCell
    {
        public GroupHeader()
        {
            View = new GroupHeaderView();
        }
    }

    public partial class GroupHeaderView : ContentView
    {
        public GroupHeaderView()
        {
            InitializeComponent();
        }
    }
}
