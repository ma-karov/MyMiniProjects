#include "MainForm2.h"

namespace AdditionalChaptersOfComputationalMathematics1 
{

	void MainForm2::FormLoadBefore() 
	{ 
		Panel_NumericUpDownBeginRange_OldValue = (float) Panel_NumericUpDownBeginRange->Value; 
		Panel_NumericUpDownEndRange_OldValue = (float) Panel_NumericUpDownEndRange->Value; 
		if (Panel_NumericUpDownBeginRange_OldValue > Panel_NumericUpDownEndRange_OldValue) 
			Panel_NumericUpDownEndRange->Value = System::Decimal(Panel_NumericUpDownEndRange_OldValue); 
	}

	System::Void MainForm2::Panel_NumericUpDownBeginRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		const float Panel_NumericUpDownBeginRange_Value((float) Panel_NumericUpDownBeginRange->Value); 
		if (Panel_NumericUpDownBeginRange_OldValue - Panel_NumericUpDownBeginRange_Value) 
		{ 
			if (Panel_NumericUpDownBeginRange_Value < Panel_NumericUpDownEndRange_OldValue) 
				Panel_NumericUpDownBeginRange_OldValue = Panel_NumericUpDownBeginRange_Value; 
			Panel_NumericUpDownBeginRange->Value = System::Decimal(Panel_NumericUpDownBeginRange_OldValue); 
		} 
	}

	System::Void MainForm2::Panel_NumericUpDownEndRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		const float Panel_NumericUpDownEndRange_Value((float) Panel_NumericUpDownEndRange->Value); 
		if (Panel_NumericUpDownEndRange_OldValue - Panel_NumericUpDownEndRange_Value) 
		{ 
			if (Panel_NumericUpDownEndRange_Value > Panel_NumericUpDownBeginRange_OldValue) 
				Panel_NumericUpDownEndRange_OldValue = Panel_NumericUpDownEndRange_Value; 
			Panel_NumericUpDownEndRange->Value = System::Decimal(Panel_NumericUpDownEndRange_OldValue); 
		} 
	} 

	System::Void MainForm2::ButtonSolveSystemEquations_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		delete NewArrayOfArrayFloatSLAU; 
		NewArrayOfArrayFloatSLAU = new ArrayOfArrayFloatSLAU( new float[3] { Panel_NumericUpDownBeginRange_OldValue, Panel_NumericUpDownEndRange_OldValue, System::Convert::ToSingle(TextBox_StepsN->Text) } ); 
		PrintConclusionSolveSystemEquationsForm(ArrayOfArrayFloatSLAU_Prototype::Clone(NewArrayOfArrayFloatSLAU, TextBox_AccuracyEPS->Text)).ShowDialog(); 
	}

}
