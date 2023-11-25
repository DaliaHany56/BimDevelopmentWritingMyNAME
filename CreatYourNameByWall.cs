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
    [Transaction(TransactionMode.Manual)]
    internal class CreatYourNameByWall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiDoc = commandData.Application.ActiveUIDocument;
            var doc = uiDoc.Document;

            var lvlOne = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels)
               .WhereElementIsNotElementType().FirstOrDefault(l => l.Name == "04- Basement Slab (299.45)");
            using (Transaction trans = new Transaction(doc, "TRANS ONE"))
            { 
                try
                {
                    trans.Start();

                    //Line based Elements 

                    //Create Walls
                    //D
                    XYZ xyz1 = new XYZ(0, 0, 0);
                    XYZ xyz2 = new XYZ(0, 3.28084, 0);
                    XYZ xyz3 = new XYZ(1.64042, 1.54528, 0);


                    //A
                    XYZ xyz4 = new XYZ(2.4518, 0, 0);
                    XYZ xyz5 = new XYZ(4.1258, 3.28084, 0);
                    XYZ xyz6 = new XYZ(5.77001312, 0, 0);
                    XYZ xyz7 = new XYZ(3.0377297, 1.14829, 0);
                    XYZ xyz8 = new XYZ(5.19455381, 1.14829, 0);
                    //L
                    XYZ xyz9 = new XYZ(7.4444, 3.28084, 0);
                    XYZ xyz10 = new XYZ(7.4444, 0, 0);
                    XYZ xyz11 = new XYZ(8.9388, 0, 0);
                    //I
                    XYZ xyz12 = new XYZ(10.43326, 3.28084, 0);
                    XYZ xyz13 = new XYZ(10.43326, 0, 0);
                    XYZ xyz19 = new XYZ(9.61318, 3.28084, 0);
                    XYZ xyz20 = new XYZ(11.2536089, 3.28084, 0);
                    XYZ xyz21 = new XYZ(9.61318, 0, 0);
                    XYZ xyz22 = new XYZ(11.2536089, 0, 0);
                    //A
                    XYZ xyz14 = new XYZ(12.359, 0, 0);
                    XYZ xyz15 = new XYZ(14.033, 3.28084, 0);
                    XYZ xyz16 = new XYZ(15.677, 0, 0);
                    XYZ xyz17 = new XYZ(12.94521, 1.14829, 0);
                    XYZ xyz18 = new XYZ(15.1020341, 1.14829, 0);
                   
                    //D
                    Line lineOne = Line.CreateBound(xyz1, xyz2);
                    Arc ArcThree = Arc.Create(xyz1, xyz2,xyz3);

                    //A
                    Line lineTwo = Line.CreateBound(xyz4, xyz5);
                    Line lineThree = Line.CreateBound(xyz5, xyz6);
                    Line lineFour = Line.CreateBound(xyz7, xyz8);
                    //L
                    Line lineFive = Line.CreateBound(xyz9, xyz10);
                    Line lineSix = Line.CreateBound(xyz10, xyz11);
                    //I
                    Line lineSeven = Line.CreateBound(xyz12, xyz13);
                    Line lineEleven = Line.CreateBound(xyz19, xyz20);
                    Line lineTwelve = Line.CreateBound(xyz21, xyz22);
                    //A
                    Line lineEight = Line.CreateBound(xyz14, xyz15);
                    Line lineNine = Line.CreateBound(xyz15, xyz16);
                    Line lineTen = Line.CreateBound(xyz17, xyz18);




                    Wall.Create(doc, lineOne, lvlOne.Id, true);
                    Wall.Create(doc, lineTwo, lvlOne.Id, true);
                    Wall.Create(doc, lineThree, lvlOne.Id, true);
                    Wall.Create(doc, lineFour, lvlOne.Id, true);
                    Wall.Create(doc, lineFive, lvlOne.Id, true);
                    Wall.Create(doc, lineSix, lvlOne.Id, true);
                    Wall.Create(doc, lineSeven, lvlOne.Id, true);
                    Wall.Create(doc, lineEleven, lvlOne.Id, true);
                    Wall.Create(doc, lineTwelve, lvlOne.Id, true);
                    Wall.Create(doc, lineEight, lvlOne.Id, true);
                    Wall.Create(doc, lineNine, lvlOne.Id, true);
                    Wall.Create(doc, lineTen, lvlOne.Id, true);
                   Wall.Create(doc, ArcThree, lvlOne.Id, true);

                    trans.Commit();
                    return Result.Succeeded;
                }
                catch (Exception ex)
                {
                    TaskDialog.Show("Warning", ex.Message);
                    trans.RollBack();
                    return Result.Failed;
                }

            }
        }
    }
}




