/*
 * Created by SharpDevelop.
 * User: lauer
 * Date: 2022. 12. 06.
 * Time: 21:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using HouseMacro.Model;

namespace HouseMacro
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("CBC8CBB5-F8AF-47E0-A994-620B021D5C6B")]
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
		
		public void CreateHouse()
		{
			using(Transaction transaction = new Transaction(Document, "CreateHouse"))
     	    {
			      	transaction.Start("Create House");
		      		var houseFactory = new HouseFactory(this.Document);
		      		var house= new House { Base = new Model.Rectangle{BottomLeft = new XYZ(-35,0,0), TopRight = new XYZ(-10,25,0) }};
		      		
		      		houseFactory.create(house);
		      		transaction.Commit();
	        }
		}
	}
}