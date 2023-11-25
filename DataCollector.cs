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
    internal class DataCollector : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //uiDocument
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;

            //Document
            Document doc = uIDoc.Document;

            //Pick on object ==>  select object
            TaskDialog.Show("Pick", "Please, pick an Element to display its data");

            Reference pickedObj = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

            if (pickedObj != null)
            {
                //Get the picked obj ID 
                ElementId pickedObjId = pickedObj.ElementId;

                //Get the instance
                Element ele = doc.GetElement(pickedObjId);

                //Get Type Id
                ElementId eleTypeId = ele.GetTypeId();

                //Get Type
                ElementType eleType = doc.GetElement(eleTypeId) as ElementType;

                //Print Data
                TaskDialog.Show("Picked object Data",

                    $"Element ID: {ele.Id}   \n " +
                    $"Element Name: {ele.Name} \n" +
                    $"Element Category: {ele.Category} \n" +
                    $"Element Type: {eleType.Name} \n" +
                    $"Element Family: {eleType.FamilyName}");

                return Result.Succeeded;
            }

            else
            {
                return Result.Failed;
            }
        }
    
}
}
