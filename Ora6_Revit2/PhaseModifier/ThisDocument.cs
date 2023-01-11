/*
 * Created by SharpDevelop.
 * User: lauer
 * Date: 2022. 12. 19.
 * Time: 20:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace PhaseModifier
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("F59A44C7-3C14-4062-A251-C363593BC6AA")]
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
		public void RoomCopier()
		{
			var phase1 = GetPhaseIdByName("Phase 1");
			var phase2 = GetPhaseIdByName("Phase 2");
			
			var rooms = new FilteredElementCollector(Document)
				.OfClass(typeof(SpatialElement))
				.WhereElementIsNotElementType()
				.Where(element => IsTypeRoom(element) && IsRoomOnPhase(element as Room, phase1))
				.Cast<Room>()
				.ToList();
				

			foreach(var room in rooms)
			{
				CreateRoomOnPhase(room, phase2);
			}
				
			Console.Write("asd");
		}
		
		
		public Phase GetPhaseIdByName(string phaseName)
		{ 
			return new FilteredElementCollector(Document)
		    	.OfClass(typeof(Phase))
				.Cast<Phase>()
 				.Where( phase => phase.Name == phaseName)
 				.First();
  		}
		
		private Room CreateRoomOnPhase(Room room, Phase destinationPhase)
		{
			Level roomLevel = room.Level;
			PlanCircuitSet circuits = Document.get_PlanTopology(roomLevel).Circuits;
		    Room createdRoom = null;

		    foreach (PlanCircuit circuit in circuits)
		    {
		    	UV pointInCircuit = circuit.GetPointInside();
		    	if(pointInCircuit != null && room.IsPointInRoom(new XYZ(pointInCircuit.U, pointInCircuit.V, roomLevel.Elevation)))
		    	{
    				using(Transaction tx = new Transaction(Document, "Copy rooms to phase"))
					{					
						tx.Start();
    					var roomOnPhase = Document.Create.NewRoom(destinationPhase);
						roomOnPhase.Name = room.get_Parameter(BuiltInParameter.ROOM_NAME).AsValueString();
						roomOnPhase.Number = room.Number;
		    			createdRoom = Document.Create.NewRoom(roomOnPhase, circuit);	
		            	
						tx.Commit();
    				}
		            break;
		        }
		    }
			
			return createdRoom;
		}
		
		private bool IsTypeRoom(Element element) 
		{
			return element.GetType() == typeof(Room);
		}
		
		private bool IsRoomOnPhase(Room room, Phase phase)
		{
			return room.get_Parameter(BuiltInParameter.ROOM_PHASE).AsValueString() == phase.Name;
		}
	}
}