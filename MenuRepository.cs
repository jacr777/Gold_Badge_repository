using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class MenuRepository
    {
        private List<Menu> _menuList = new List<Menu>();

        //Add Item to Menu
        public void AddItem(Menu menu)
        {
            _menuList.Add(menu);
        }

        //Read Menu List
        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        //Delete a Menu Item
        public bool DeleteMenu(int mealNumber)
        {
            Menu content = GetMenuById(mealNumber);
            if (content == null)
            {
                return false;
            }
            int intialCount = _menuList.Count;
            _menuList.Remove(content);
            if (intialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Menu Helper
        public Menu GetMenuById(int mealNumber)
        {
            foreach (Menu content in _menuList)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }

    }
}
