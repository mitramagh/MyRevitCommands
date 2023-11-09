using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace MyRevitCommands
{
    [TransactionAttribute(TransactionMode.ReadOnly)]
    public class GetElementId : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get UIDocument
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            try
            {

                //Pick object
                Reference pickedObj = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                //Display Element ID
                if (pickedObj != null)
                {
                    TaskDialog.Show("Element Id", pickedObj.ElementId.ToString());
                }

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}