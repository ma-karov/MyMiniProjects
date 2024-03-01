#include "Main.h" 
#include "Forms/Main/MainForm.h" 
#include "Forms/Main2/MainForm2.h" 

unsigned short ArrayOfArrayFloatSLAU::GetMaxValueIndexInColumnArray(const float **ArrayOfArrayFloat, const unsigned short INDEX) 
{
	float MaxValue(fabs(*(*ArrayOfArrayFloat + INDEX))); unsigned short MaxValueIndex(0);
	for (unsigned short i(1); i < *ArrayDimensions; i++) 
	{ 
		const float Value(fabs(*(*(ArrayOfArrayFloat + i) + INDEX))); 
		if (Value > MaxValue) 
		{ 
			MaxValue = Value; 
			MaxValueIndex = i; 
		} 
	} return MaxValueIndex;
}

void ArrayOfArrayFloatSLAU::AchievedAccuracyArrayOfArrayFloat(float **ArrayOfArrayFloat) 
{
	float *ArrayX = new float[*ArrayDimensions];
	for (unsigned short i(0); i < *ArrayDimensions; i++) 
		*(ArrayX + i) = (*(*(ArrayOfArrayFloat + i) + (*ArrayDimensions)))/(*(*(ArrayOfArrayFloat + i) + i));

	float **NewArrayOfArrayFloat = new float* [*ArrayDimensions];
	for (unsigned short i1 = 0; i1 < *ArrayDimensions; i1++) 
	{
		*(NewArrayOfArrayFloat + i1) = new float[*(ArrayDimensions + 1)]; float SummaBi(0);
		for (unsigned short i2 = 0; i2 < *ArrayDimensions; i2++) 
		{ 
			*(*(NewArrayOfArrayFloat + i1) + i2) = *(*(this->ArrayOfArrayFloat + i1) + i2); 
			SummaBi += (*(*(NewArrayOfArrayFloat + i1) + i2))*(*(ArrayX + i2)); 
		}
		*(*(NewArrayOfArrayFloat + i1) + *ArrayDimensions) = SummaBi - (*(*(this->ArrayOfArrayFloat + i1) + *ArrayDimensions));
	} 

	for (unsigned short i(0); i < *ArrayDimensions; i++) 
	{
		const unsigned short MAX_ELEMENT_IN_COLUMN_I(GetMaxValueIndexInColumnArray((const float **)NewArrayOfArrayFloat, i)); 
		if (MAX_ELEMENT_IN_COLUMN_I - i) 
			for (unsigned short i1(0); i1 < *(ArrayDimensions + 1); i1++) 
			{ 
				const float ELEMENT( *(*(NewArrayOfArrayFloat + i) + i1) ); 
				*(*(NewArrayOfArrayFloat + i) + i1) = *(*(NewArrayOfArrayFloat + MAX_ELEMENT_IN_COLUMN_I) + i1); 
				*(*(NewArrayOfArrayFloat + MAX_ELEMENT_IN_COLUMN_I) + i1) = ELEMENT; 
			} 
		
		const float ELEMENT_I_I(*(*(NewArrayOfArrayFloat + i) + i)); 
		for (unsigned short i1(0); i1 < i; i1++) 
		{
			const float ELEMENT_I1_I( *(*(NewArrayOfArrayFloat + i1) + i) );
			for (unsigned short i2(0); i2 < *(ArrayDimensions + 1); i2++) 
				*(*(NewArrayOfArrayFloat + i1) + i2) = ELEMENT_I_I*( *(*(NewArrayOfArrayFloat + i1) + i2) ) - ELEMENT_I1_I*( *(*(NewArrayOfArrayFloat + i) + i2) );
		}

		for (unsigned short i1(i + 1); i1 < *ArrayDimensions; i1++) 
		{
			const float ELEMENT_I1_I( *(*(NewArrayOfArrayFloat + i1) + i) );
			for (unsigned short i2(0); i2 < *(ArrayDimensions + 1); i2++) 
				*(*(NewArrayOfArrayFloat + i1) + i2) = ELEMENT_I_I*( *(*(NewArrayOfArrayFloat + i1) + i2) ) - ELEMENT_I1_I*( *(*(NewArrayOfArrayFloat + i) + i2) );
		}
	}

	//System::String ^SystemString = "";
	//for (unsigned short i(0); i < *ArrayDimensions; i++) SystemString += (*(*(NewArrayOfArrayFloat + i) + *ArrayDimensions)) + " "; return SystemString; 


	for (unsigned short i(0); i < *ArrayDimensions; i++) 
	{
		const unsigned short MAX_ELEMENT_IN_COLUMN_I(GetMaxValueIndexInColumnArray((const float **) NewArrayOfArrayFloat, i));
		if (MAX_ELEMENT_IN_COLUMN_I - i)
			for (unsigned short i1(0); i1 < *(ArrayDimensions + 1); i1++) 
			{ 
				const float ELEMENT( *(*(NewArrayOfArrayFloat + i) + i1) ); 
				*(*(NewArrayOfArrayFloat + i) + i1) = *(*(NewArrayOfArrayFloat + MAX_ELEMENT_IN_COLUMN_I) + i1); 
				*(*(NewArrayOfArrayFloat + MAX_ELEMENT_IN_COLUMN_I) + i1) = ELEMENT; 
			} 

		const float ELEMENT_I_I(*(*(NewArrayOfArrayFloat + i) + i));
		for (unsigned short i1(0); i1 < i; i1++) 
		{
			const float ELEMENT_I1_I(*(*(NewArrayOfArrayFloat + i1) + i));
			for (unsigned short i2(0); i2 < *(ArrayDimensions + 1); i2++) 
				*(*(NewArrayOfArrayFloat + i1) + i2) = ELEMENT_I_I*( *(*(NewArrayOfArrayFloat + i1) + i2) ) - ELEMENT_I1_I*( *(*(NewArrayOfArrayFloat + i) + i2) );
		}

		for (unsigned short i1(i + 1); i1 < *ArrayDimensions; i1++) 
		{
			const float ELEMENT_I1_I(*(*(NewArrayOfArrayFloat + i1) + i));
			for (unsigned short i2(0); i2 < *(ArrayDimensions + 1); i2++) 
				*(*(NewArrayOfArrayFloat + i1) + i2) = ELEMENT_I_I*( *(*(NewArrayOfArrayFloat + i1) + i2) ) - ELEMENT_I1_I*( *(*(NewArrayOfArrayFloat + i) + i2) ); 
		}
	}


	*ArrayX = (*(*NewArrayOfArrayFloat + (*ArrayDimensions)))/(**NewArrayOfArrayFloat); float MaxValue(fabs(*ArrayX));
	for (unsigned short i(1); i < *ArrayDimensions; i++) 
	{ 
		*(ArrayX + i) = (*(*(NewArrayOfArrayFloat + i) + (*ArrayDimensions)))/(*(*(NewArrayOfArrayFloat + i) + i)); 
		const float Value(fabs(*(ArrayX + i))); 
		if (Value > MaxValue) MaxValue = Value; 
	}

	if (MaxValue > ArrayOfArrayFloatSLAU_Prototype::GetAccuracyEPS())
		for (unsigned short i(0); i < *ArrayDimensions; i++) 
			*(*(ArrayOfArrayFloat + i) + i) += ArrayOfArrayFloatSLAU_Prototype::GetAccuracyEPS()*(*(ArrayX + i));
}

ArrayOfArrayFloatSLAU::ArrayOfArrayFloatSLAU(float *ArrayRange) 
{
	const unsigned short StepsN = *(ArrayRange + 2); const float H = ((*(ArrayRange + 1)) - (*ArrayRange))/(StepsN - 1); ArrayOfArrayFloat = new float *[StepsN]; 

	*this->ArrayRange = *ArrayRange; *(this->ArrayRange + 1) = *(ArrayRange + 1); *ArrayDimensions = StepsN; *(ArrayDimensions + 1) = StepsN + 1;
	for (unsigned short i1 = 0; i1 < StepsN; i1++) 
	{
		*(ArrayOfArrayFloat + i1) = new float[StepsN + 1];
		for (unsigned short i2 = 0; i2 <= StepsN; i2++) 
			*(*(ArrayOfArrayFloat + i1) + i2) = 0;
	}

	**ArrayOfArrayFloat = -3; *(*ArrayOfArrayFloat + 1) = 4; *(*ArrayOfArrayFloat + 2) = -1; *(*ArrayOfArrayFloat + StepsN) = 3*H;
	for (unsigned short i = 1; i < StepsN - 1; i++) 
	{ 
		*(*(ArrayOfArrayFloat + i) + i - 1) = F1((*ArrayRange) + i*H, H); 
		*(*(ArrayOfArrayFloat + i) + i) = F2(H); 
		*(*(ArrayOfArrayFloat + i) + i + 1) = F3((*ArrayRange) + i*H, H); 
		*(*(ArrayOfArrayFloat + i) + StepsN) = F4(H); 
	} 
	*(*(ArrayOfArrayFloat + StepsN - 1) + StepsN - 3) = 1; *(*(ArrayOfArrayFloat + StepsN - 1) + StepsN - 2) = -4; *(*(ArrayOfArrayFloat + StepsN - 1) + StepsN - 1) = 4*H + 3; *(*(ArrayOfArrayFloat + StepsN - 1) + StepsN) = 6*H;
}

ArrayOfArrayFloatSLAU::ArrayOfArrayFloatSLAU(const unsigned short Dimension) : ArrayOfArrayFloatSLAU(Dimension, Dimension + 1) {}

ArrayOfArrayFloatSLAU::ArrayOfArrayFloatSLAU(const unsigned short Dimension1, const unsigned short Dimension2) 
{
	*ArrayDimensions = Dimension1; *(ArrayDimensions + 1) = Dimension2; ArrayOfArrayFloat = new float *[Dimension1];
	for (unsigned short i1 = 0; i1 < Dimension1; i1++) 
	{ 
		*(ArrayOfArrayFloat + i1) = new float[Dimension2];
		for (unsigned short i2 = 0; i2 < Dimension2; i2++) *(*(ArrayOfArrayFloat + i1) + i2) = i1 * 10 + i2;
	}

	if (!(Dimension1 - 3)) 
	{ //float ArrayOfArrayFloat[3][4] = { { 2.74, -1.18, 3.17, 2.18 }, { 1.12, 0.83, -2.16, -1.15 }, { 0.18, 1.27, 0.76, 3.23 } }; 
		float ArrayOfArrayFloat[3][4] = { { 2, 3, -1, 7 }, { 1, -1, 6, 14 }, { 6, -2, 1, 11 } };
		for (unsigned short i1 = 0; i1 < Dimension1; i1++)
			for (unsigned short i2 = 0; i2 < Dimension2; i2++) 
				*(*(this->ArrayOfArrayFloat + i1) + i2) = *(*(ArrayOfArrayFloat + i1) + i2);
	}
}

ArrayOfArrayFloatSLAU::ArrayOfArrayFloatSLAU(System::String ^SystemStringDimension1, System::String ^SystemStringDimension2) : ArrayOfArrayFloatSLAU(StringToNumber(SystemStringDimension1), StringToNumber(SystemStringDimension2)) {}

ArrayOfArrayFloatSLAU::ArrayOfArrayFloatSLAU(System::String ^SystemStringDimensions) 
{
	SystemStringDimensions += "  "; unsigned short ArrayDimensionsIndex(0), i(1); System::String ^NewSystemStringDimensions("");
	for (System::Char SystemChar(SystemStringDimensions[0]); ArrayDimensionsIndex - 2; SystemChar = SystemStringDimensions[i++]) 
		if (SystemChar == ' ' && NewSystemStringDimensions != "") 
		{ 
			*(ArrayDimensions + ArrayDimensionsIndex) = StringToNumber(NewSystemStringDimensions); 
			NewSystemStringDimensions = ""; 
		} 
		else 
			NewSystemStringDimensions += SystemChar;

	ArrayOfArrayFloat = new float *[*ArrayDimensions];
	for (unsigned short i1 = 0; i1 < *ArrayDimensions; i1++) 
	{
		*(ArrayOfArrayFloat + i1) = new float[*(ArrayDimensions + 1)];
		for (unsigned short i2 = 0; i2 < *(ArrayDimensions + 1); i2++) 
			*(*(ArrayOfArrayFloat + i1) + i2) = i1*10 + i2;
	} 
}

ArrayOfArrayFloatSLAU::~ArrayOfArrayFloatSLAU() 
{ 
	for (unsigned short i = 0; i < *ArrayDimensions; i++) 
		delete *(ArrayOfArrayFloat + i); 
	delete ArrayOfArrayFloat; 
}

unsigned short ArrayOfArrayFloatSLAU::GetDimensionRow() 
{ 
	return *ArrayDimensions; 
} 

unsigned short ArrayOfArrayFloatSLAU::GetDimensionColumn() 
{ 
	return *(ArrayDimensions + 1); 
}

float ArrayOfArrayFloatSLAU::GetElementArray(const unsigned short Index1, const unsigned short Index2) 
{ 
	return *(*(ArrayOfArrayFloat + Index1) + Index2); 
} 

void ArrayOfArrayFloatSLAU::SetElementArray(const unsigned short Index1, const unsigned short Index2, const float NewElement) 
{ 
	*(*(ArrayOfArrayFloat + Index1) + Index2) = NewElement; 
}

System::String ^ArrayOfArrayFloatSLAU::SolveSystemEquationsToString() 
{
	float **NewArrayOfArrayFloat = new float *[*ArrayDimensions];
	for (unsigned short i1 = 0; i1 < *ArrayDimensions; i1++) 
	{
		*(NewArrayOfArrayFloat + i1) = new float[*(ArrayDimensions + 1)];
		for (unsigned short i2 = 0; i2 < *(ArrayDimensions + 1); i2++) 
			*(*(NewArrayOfArrayFloat + i1) + i2) = *(*(ArrayOfArrayFloat + i1) + i2);
	}

	/*System::String^ SystemString("");
	for (unsigned short i1 = 0; i1 < *ArrayDimensions; i1++, SystemString += "; ")
	for (unsigned short i2 = 0; i2 < *(ArrayDimensions + 1); i2++) SystemString += (*(*(NewArrayOfArrayFloat + i1) + i2)).ToString("0.0000") + " "; return SystemString;*/

	for (unsigned short i(0); i < *ArrayDimensions; i++) 
	{
		const unsigned short MAX_ELEMENT_IN_COLUMN_I(GetMaxValueIndexInColumnArray((const float**)NewArrayOfArrayFloat, i)); //const float ELEMENT_I_I( *( *(NewArrayOfArrayFloat + i) + i ) ); 
		//if (MAX_ELEMENT_IN_COLUMN_I - i)
		//for (unsigned short i1(0); i1 < *(ArrayDimensions + 1); i1++) { const float ELEMENT(*(*(NewArrayOfArrayFloat + i) + i1)); *(*(NewArrayOfArrayFloat + i) + i1) = *(*(NewArrayOfArrayFloat + MAX_ELEMENT_IN_COLUMN_I) + i1); *(*(NewArrayOfArrayFloat + MAX_ELEMENT_IN_COLUMN_I) + i1) = ELEMENT; } 
		const float ELEMENT_I_I(*(*(NewArrayOfArrayFloat + i) + i));

		for (unsigned short i1(0); i1 < i; i1++) 
		{
			const float ELEMENT_I1_I(*(*(NewArrayOfArrayFloat + i1) + i));
			for (unsigned short i2(0); i2 < *(ArrayDimensions + 1); i2++) 
				*(*(NewArrayOfArrayFloat + i1) + i2) = ELEMENT_I_I*( *(*(NewArrayOfArrayFloat + i1) + i2) ) - ELEMENT_I1_I*( *(*(NewArrayOfArrayFloat + i) + i2) );
		} 

		for (unsigned short i1(i + 1); i1 < *ArrayDimensions; i1++) 
		{
			const float ELEMENT_I1_I(*(*(NewArrayOfArrayFloat + i1) + i));
			for (unsigned short i2(0); i2 < *(ArrayDimensions + 1); i2++) 
				*(*(NewArrayOfArrayFloat + i1) + i2) = ELEMENT_I_I*( *(*(NewArrayOfArrayFloat + i1) + i2) ) - ELEMENT_I1_I*( *(*(NewArrayOfArrayFloat + i) + i2) );
		}
	}

	/*System::String^ SystemString("");
	for (unsigned short i1 = 0; i1 < *ArrayDimensions; i1++, SystemString += "; ")
	for (unsigned short i2 = 0; i2 < *(ArrayDimensions + 1); i2++) SystemString += (*(*(NewArrayOfArrayFloat + i1) + i2)).ToString("0.0000") + " "; return SystemString;*/

	unsigned short LengthAccuracyEPS(0); float AccuracyEPS(ArrayOfArrayFloatSLAU_Prototype::GetAccuracyEPS());
	if (AccuracyEPS) 
		for (; AccuracyEPS < 1; AccuracyEPS *= 11, LengthAccuracyEPS++); 

	System::String ^SystemString(""); const float H = ((*(ArrayRange + 1)) - (*ArrayRange))/((*ArrayDimensions) - 1); AccuracyEPS = *ArrayRange;
	for (unsigned short i(0); i < *ArrayDimensions; i++, AccuracyEPS += H) 
		SystemString += System::String::Format("{0:F" + LengthAccuracyEPS + "} {1:F" + LengthAccuracyEPS + "} ", AccuracyEPS, ( ( *( *(NewArrayOfArrayFloat + i) + (*ArrayDimensions) ) )/( *(*(NewArrayOfArrayFloat + i) + i) )));
	return SystemString;
}

float ArrayOfArrayFloatSLAU::F1(const float X, const float H) { return 1 - H/X; }
float ArrayOfArrayFloatSLAU::F2(const float H) { return -(2 + 3*H*H); }
float ArrayOfArrayFloatSLAU::F3(const float X, const float H) { return 1 + H/X; }
float ArrayOfArrayFloatSLAU::F4(const float H) { return 2 * H*H; }

unsigned short ArrayOfArrayFloatSLAU::StringToNumber(System::String ^SystemString) 
{
	unsigned short Number(0), i(1); System::Char SystemCharEndOfSystemString = System::Char('\0'); SystemString += SystemCharEndOfSystemString;
	for (System::Char SystemChar(SystemString[0]); SystemChar != SystemCharEndOfSystemString; SystemChar = SystemString[i++]) 
		Number = Number*10 + ( (unsigned short) (SystemChar - '0') ); 
	return Number;
}

unsigned short *ArrayOfArrayFloatSLAU::StringToArrayNumbersTwo(System::String ^SystemString) 
{
	unsigned short *ArrayNumbersTwo = new unsigned short[2]; 
	unsigned short i(1), ArrayNumbersTwoIndex; 
	System::Char SystemCharEndOfSystemString = System::Char('\0'); 
	SystemString += " "; SystemString += SystemCharEndOfSystemString; 
	System::String ^NewSystemString("");
	for (System::Char SystemChar(SystemString[0]); SystemChar != SystemCharEndOfSystemString; SystemChar = SystemString[i++]) 
		if (SystemChar == ' ' && NewSystemString != "") 
		{ 
			*(ArrayNumbersTwo + ArrayNumbersTwoIndex) = StringToNumber(NewSystemString); 
			ArrayNumbersTwoIndex++; 
			NewSystemString = ""; 
		}
		else 
			NewSystemString += SystemChar; 
	return ArrayNumbersTwo;
}

float *ArrayOfArrayFloatSLAU::StringToArrayFloat(System::String ^SystemString) 
{
	System::Char SystemCharEndOfSystemString = System::Char('\0'); 
	SystemString += SystemCharEndOfSystemString; 
	unsigned short i(1), ArrayFloatX_Length(1), ArrayFloatX_Index(1);
	for (System::Char SystemChar(SystemString[0]); SystemChar != SystemCharEndOfSystemString; SystemChar = SystemString[i++]) 
		if (SystemChar == ' ') 
			ArrayFloatX_Length++; 

	float *ArrayFloatX = new float[ArrayFloatX_Length]; *ArrayFloatX = ArrayFloatX_Length; i = 1; System::String ^NewSystemString("");
	for (System::Char SystemChar(SystemString[0]); SystemChar != SystemCharEndOfSystemString; SystemChar = SystemString[i++]) 
		if (SystemChar == ' ' && NewSystemString != "") 
		{ 
			*(ArrayFloatX + ArrayFloatX_Index) = System::Convert::ToSingle(NewSystemString); 
			ArrayFloatX_Index++; NewSystemString = ""; 
		}
		else 
			NewSystemString += SystemChar;
	return ArrayFloatX;
}

float ArrayOfArrayFloatSLAU_Prototype::AccuracyEPS(0);
float ArrayOfArrayFloatSLAU_Prototype::GetAccuracyEPS() { return AccuracyEPS; }

ArrayOfArrayFloatSLAU *ArrayOfArrayFloatSLAU_Prototype::Clone(ArrayOfArrayFloatSLAU *ObjectArrayOfArrayFloatSLAU, const float AccuracyEPS) 
{
	ArrayOfArrayFloatSLAU_Prototype::AccuracyEPS = AccuracyEPS; 
	unsigned short ArrayDimensions[2] = { ObjectArrayOfArrayFloatSLAU->GetDimensionRow(), ObjectArrayOfArrayFloatSLAU->GetDimensionColumn() }; 
	ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU = new ArrayOfArrayFloatSLAU(*ArrayDimensions, *(ArrayDimensions + 1));
	NewArrayOfArrayFloatSLAU->ArrayRange[0] = ObjectArrayOfArrayFloatSLAU->ArrayRange[0]; 
	NewArrayOfArrayFloatSLAU->ArrayRange[1] = ObjectArrayOfArrayFloatSLAU->ArrayRange[1];
	for (unsigned short i1 = 0; i1 < *ArrayDimensions; i1++)
		for (unsigned short i2 = 0; i2 < *(ArrayDimensions + 1); i2++) 
			NewArrayOfArrayFloatSLAU->SetElementArray(i1, i2, ObjectArrayOfArrayFloatSLAU->GetElementArray(i1, i2)); 
	return NewArrayOfArrayFloatSLAU; 
} 

ArrayOfArrayFloatSLAU *ArrayOfArrayFloatSLAU_Prototype::Clone(ArrayOfArrayFloatSLAU *ObjectArrayOfArrayFloatSLAU, System::String ^SystemStringAccuracyEPS) 
{ 
	return Clone(ObjectArrayOfArrayFloatSLAU, System::Convert::ToSingle(SystemStringAccuracyEPS)); 
}


//[STAThread] 
int main(array<System::String ^> ^args) 
{
	System::Windows::Forms::Application::EnableVisualStyles(); System::Windows::Forms::Application::SetCompatibleTextRenderingDefault(false);
	System::Windows::Forms::Application::Run(gcnew AdditionalChaptersOfComputationalMathematics1::MainForm2()); srand(time(NULL));
}

