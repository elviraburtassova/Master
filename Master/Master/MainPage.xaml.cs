using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
			profileImage.Source = ImageSource.FromFile("prof.jpg");
			aboutList.ItemsSource = GetMenuList();
			var homePage = typeof(Views.AboutPage);
			Detail = new NavigationPage((Page)Activator.CreateInstance(homePage));
			IsPresented = false;
		}

	 public List<MasterMenuItems> GetMenuList()
		{
			var list = new List<MasterMenuItems>();
			list.Add(new MasterMenuItems() //-----------------
			{
				Text = "Обо мне",
				Detail = "Доп.Информация",
				ImagePath = "info.png",
				TargetPage=typeof(Views.AboutPage)
			});
			list.Add(new MasterMenuItems()//-----------------------
			{
				Text = "Мой опыт",
				Detail = "Немного о моём опыте",
				ImagePath = "exp.png",
				TargetPage = typeof(Views.ExperiencePage)
			});
			list.Add(new MasterMenuItems()//-------------------------------
			{
				Text = "Мли навыки",
				Detail = "Немного о моих навыках",
				ImagePath = "skills.png",
				TargetPage = typeof(Views.SkillsPage)
			});
			list.Add(new MasterMenuItems()//----------------------------
			{
				Text = "Мои достижения",
				Detail = "О моих достижениях",
				ImagePath = "achiev.png",
				TargetPage = typeof(Views.AchievemnetsPage)
			});
			return list;
		}

		private void aboutList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var SelectedMenuItem = (MasterMenuItems)e.SelectedItem;
			Type selectedPage = SelectedMenuItem.TargetPage;
			Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
			IsPresented = false;
		}
	}
}
