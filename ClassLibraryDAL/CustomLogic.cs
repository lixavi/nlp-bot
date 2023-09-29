using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class CustomLogic
    {

        private static List<string> CheckBox { get; set; } = new List<string>();
        private static string? ChecKedItems { get; set; }
        public static void CheckboxClicked(string CheckID, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!CheckBox.Contains(CheckID))
                {

                    CheckBox.Add(CheckID);
                }
            }
            else
            {
                if (CheckBox.Contains(CheckID))
                {
                    CheckBox.Remove(CheckID);
                }
            }
        }

        public static string checklist()
        {
            ChecKedItems = null;
            foreach (var item in CheckBox)
            {

                ChecKedItems += item+",";
            }

            return ChecKedItems;
        }

        public static void DisposeList()
        {
            CheckBox.Clear();
        }


    }


}
