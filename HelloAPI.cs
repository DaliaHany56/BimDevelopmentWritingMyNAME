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
    public class HelloAPI : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("My First Plugin", "Hello API ");

            return Result.Succeeded;
        }
    }
}
