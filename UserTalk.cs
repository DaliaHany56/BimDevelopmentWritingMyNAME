using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPISession09
{
    [TransactionAttribute(TransactionMode.ReadOnly)]
    internal class UserTalk : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var result = TaskDialog.Show("Breakfast", "Did you eat your breakfast ? " ,TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No );

            bool flag = false;
            while (flag == false)
            {

                if (result == TaskDialogResult.Yes)
                {
                    TaskDialog.Show("Result", "Bon Apetit!!");
                    flag = true;
                }
                else if (result == TaskDialogResult.No)
                {
                    TaskDialog.Show("Result", "Go Eat!!!!!!!");
                    result = TaskDialog.Show("Breakfast", "Did you eat your Breakfast ?", TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No);
                }
            
        }
            return Result.Succeeded;
        }
    }
}
