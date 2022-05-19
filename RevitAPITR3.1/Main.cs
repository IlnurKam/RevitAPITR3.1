using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITR3._1
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedRef = uidoc.Selection.PickObject(ObjectType.Element, "Выберите элемент");
            var selectedElement = doc.GetElement(selectedRef);

            if (selectedElement is Wall)
            {
                Parameter volumeParameter1 = selectedElement.LookupParameter("Volume");
                if (volumeParameter1.StorageType==StorageType.Double)
                {
                    TaskDialog.Show("Volume1", volumeParameter1.AsDouble().ToString());
                }

                Parameter volumeParameter2 = selectedElement.get.Parameter(BuiltInParameter.CURVE_ELEM_VOLUME);
                if (volumeParameter2.StorageType==StorageType.Double)
                {
                    TaskDialog.Show("Volume2", volumeParameter2.AsDouble().ToString());
                }

                return Result.Succeeded;
            }
        }
    }
}
