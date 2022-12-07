using System;
using System.Collections.Generic;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using HouseMacro.Model;

namespace HouseMacro
{
	public class HouseFactory
	{
		private Document document;
		
		public HouseFactory(Document document)
		{
			this.document = document;
		}
		
		public void create(House house) {
			var level = groundLevel();
			
			var height = new XYZ(0, house.Base.TopRight.Y - house.Base.BottomLeft.Y, 0);
			var width = new XYZ(house.Base.TopRight.X - house.Base.BottomLeft.X, 0, 0);
			
			var leftWall = createWall(document, level, house.Base.BottomLeft, house.Base.BottomLeft + height);
			var bottomWall = createWall(document, level, house.Base.BottomLeft, house.Base.BottomLeft + width);
			var topWall = createWall(document, level, house.Base.TopRight, house.Base.TopRight - width);
			var rightWall = createWall(document, level, house.Base.TopRight, house.Base.TopRight - height);
			var walls = new List<Wall>{leftWall, bottomWall, topWall, rightWall};
			
			addDoor(level, leftWall, house.Base.BottomLeft + height / 2);
			
			addWindow(level, rightWall, house.Base.TopRight - height / 3);
			addWindow(level, rightWall, house.Base.TopRight - height * 2 / 3);
			
			var roof = addRoof(walls);
			Console.Write("asd");
		}
		
		private Level groundLevel() {
			return new FilteredElementCollector(document).OfClass(typeof(Level)).FirstElement() as Level;
		}

		private Level topLevel() {
			return new FilteredElementCollector(document).OfClass(typeof(Level)).ToElements()[1] as Level;
		}
		
		
		private Wall createWall(Document document, Level level, XYZ from, XYZ to)
		{
			var line = Line.CreateBound(from, to);
			return Wall.Create(document, line, level.Id , true);
		}
		
		private FamilyInstance addDoor(Level level, Wall wall, XYZ pos)
		{
			var door = new FilteredElementCollector(document)
				.OfClass(typeof(FamilySymbol))
				.OfCategory(BuiltInCategory.OST_Doors)
				.FirstElement() as FamilySymbol;
			return document.Create.NewFamilyInstance(pos, door, wall, StructuralType.NonStructural);
		}
		
		private FamilyInstance addWindow(Level level, Wall wall, XYZ pos)
		{
			var door = new FilteredElementCollector(document)
				.OfClass(typeof(FamilySymbol))
				.OfCategory(BuiltInCategory.OST_Windows)
				.FirstElement() as FamilySymbol;
			return document.Create.NewFamilyInstance(pos, door, wall, level, StructuralType.NonStructural);
		}
		
		private FootPrintRoof addRoof(List<Wall> walls) 
		{
			var footPrint = document.Application.Create.NewCurveArray();
			walls.ForEach(wall=>footPrint.Append((wall.Location as LocationCurve).Curve));
			
			var roofType = new FilteredElementCollector(document)
				.OfClass(typeof(RoofType))
				.FirstElement() as RoofType;
			
			var modelCurveArray = new ModelCurveArray();

			var roof = document.Create.NewFootPrintRoof(footPrint,topLevel(), roofType, out modelCurveArray);
			
			//var iterator = modelCurveArray.ForwardIterator();
			//iterator.Reset();
			//while(iterator.MoveNext())
			//{
			//	var modelCurve = iterator.Current as ModelCurve;
			//	roof.set_DefinesSlope(modelCurve, true);
			//	roof.set_SlopeAngle(modelCurve, 0.5);
			//}
			
			return roof;
		}
	}
}