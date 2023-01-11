/*
 * Created by SharpDevelop.
 * User: lauer
 * Date: 2023. 01. 04.
 * Time: 7:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace WorkSet
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("6A10EA0D-4FF2-4443-89BA-B429CFDD5014")]
	public partial class ThisDocument
	{
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		#region Revit Macros generated code
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
		public void B1010OnWrongWorkset()
		{
			const string B1010 = "B1010";
			const string ARC_WORKSET_NAME = "ARC";
			const string STR_WORKSET_NAME = "STR";
			
			var wrongWorksetElements = new FilteredElementCollector(Document, Document.ActivewView.Id)
				.WhereElementIsElementType() //.OfCategory(BuiltInCategory.OST_StructuralColumns) //.OfClass(typeof(FamilyInstance))
				.Where(element =>
				{
					Parameter assemblyCode = element.get_Parameter(BuiltInParameter.UNIFORMAT_CODE);
					Workset workset = Document.GetWorksetTable().GetWorkset(element.WorksetId);
					
					return assemblyCode.HasValue && assemblyCode.AsValueString().Contains(B1010) && workset.Name.Contains(ARC_WORKSET_NAME);
				})
				.Select(element =>
				{
					Parameter assemblyCode = element.get_Parameter(BuiltInParameter.UNIFORMAT_CODE);
					Workset workset = Document.GetWorksetTable().GetWorkset(element.WorksetId);
					
					var dialog = new TaskDialog("Found element on wrong workset");
					dialog.MainContent = "We found an element with a wrong workset. Should we move it to the correct one?";
					dialog.FooterText = "assemblyCode: " + assemblyCode.AsValueString() + " workset: " + workset.Name;
					
					dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "Yes");
					dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "No");
					
					var dialogResult = dialog.Show();
					
					if (TaskDialogResult.CommandLink1 == dialogResult)
					{
						var correctWorkset = new FilteredWorksetCollector(Document)
							.OfKind(WorksetKind.UserWorkset)
							.Where(ws => ws.Name.Contains(STR_WORKSET_NAME))
							.FirstOrDefault();
						
						var t = new Transaction(Document, "Move to correct workset");
						
						t.Start();
						var param = element.GetParameters("Workset").First();
						param.Set(correctWorkset.Id.IntegerValue);
						t.Commit();
					}
					return element.Id;
				}).ToList();
		}
	}
}
