/*
 * Created by SharpDevelop.
 * User: lauer
 * Date: 2023. 01. 11.
 * Time: 2:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("45BC3786-2EF6-4A88-9FB5-AAB31AADE40D")]
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
		public void TestUtils()
		{
		}
		
		private Tuple<bool,string> IsWorksharedElementEditable(Document doc, Element el)
		{
			var workshareStatusExplanation = String.Format("{0} is not a workshared document, {1} is editable for {2}", doc.Title, el.Name, doc.Application.Username);
			
			if (doc.IsWorkshared)
			{
				// get the checkout and the model update status of the element
				WorksharingUtils.GetCheckoutStatus(doc, el.Id);
				
				CheckoutStatus CheckoutOfElement = WorksharingUtils.GetCheckoutStatus(doc, el.Id);
				ModelUpdatesStatus UpdateStatusOfElement = WorksharingUtils.GetModelUpdatesStatus(doc, el.Id);
				WorksharingTooltipInfo InfoOfElement = WorksharingUtils.GetWorksharingTooltipInfo(doc, el.Id);
				
				if (CheckoutOfElement == CheckoutStatus.OwnedByOtherUser)
				{
					workshareStatusExplanation = String.Format("{0}({1}) is currently owned by {2}. Can not be edited by {3}", el.Name, el.Id.IntegerValue, InfoOfElement.Owner, doc.Application.Username);
					return Tuple.Create(false, workshareStatusExplanation);
				}
				else if (CheckoutOfElement == CheckoutStatus.OwnedByCurrentUser)
				{
					workshareStatusExplanation = String.Format("{0}({1}) is currently owned by the user ({2})", el.Name, el.Id.IntegerValue, doc.Application.Username);
					return Tuple.Create(true, workshareStatusExplanation);
				}
				else if (CheckoutOfElement == CheckoutStatus.NotOwned)
				{
					if (UpdateStatusOfElement == ModelUpdatesStatus.CurrentWithCentral)
					{
						List<ElementId> ElSetToCheckout = new List<ElementId>();
						ElSetToCheckout.Add(el.Id);
						WorksharingUtils.CheckoutElements(doc, ElSetToCheckout);
						workshareStatusExplanation = String.Format("{0}({1}) was not owned, but now cheked out for the user ({2})", el.Name, el.Id.IntegerValue, doc.Application.Username);
						
						return Tuple.Create(true, workshareStatusExplanation);
					}
					else
					{
						workshareStatusExplanation = String.Format("{0}({1}) is not owned by anyone, but has an updated state in the central model. The user ({2}) must reload latest befor editing it.", el.Name, el.Id.IntegerValue, doc.Application.Username);
						return Tuple.Create(false, workshareStatusExplanation);
					}
				}
				else
				{
					throw new ArgumentException(String.Format("Unrecognized checkout status of {0}({1}): {3}. The function does not handle this status.", el.Name, el.Id.IntegerValue, CheckoutOfElement));
				}
			}
			
			return Tuple.Create(true, workshareStatusExplanation);
		}
		
		private Parameter GetAndValidateParameter(Element elOfParam, string paramName)
		{
			Parameter ReturnParameter;
			string ErrorMessage;
			IList<Parameter> ElemParamList = elOfParam.GetParameters(paramName);
			if (ElemParamList.Count == 0)
			{
				ErrorMessage = String.Format("The {0} element does not have a parameter named {1}. " +
				                                       "Please check your input configuration or add a parameter with the specified name ({1})", elOfParam.Name, paramName);
				TaskDialog.Show("Error", ErrorMessage);
				throw new ArgumentException(ErrorMessage);	
			}
			else if (ElemParamList.Count > 1)
			{
				ErrorMessage = String.Format("The {0} element has multiple parameters named {1}. " +
				                                       "Please rename or remove one of the parameters with the specified name ({1})", elOfParam.Name, paramName);
				TaskDialog.Show("Error", ErrorMessage);
				throw new ArgumentException(ErrorMessage);	
			}
			else
			{
				ReturnParameter = ElemParamList.ElementAt(0);
			}
			
			return ReturnParameter;
		}

	}
}