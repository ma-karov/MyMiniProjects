#pragma once 
#include <time.h> 

class IArrayOfArraySLAU {

protected:


public:
	bool ArrayPanelMiddle_ScrollBars_EventValueChange_Bool[2] = { false, false }; unsigned short ArrayDimensionsPanelMiddle[2];

	//	virtual unsigned short GetDimensionRow() = 0;
	//	virtual unsigned short GetDimensionColumn() = 0; 

	virtual unsigned short GetDimensionRow() = 0;
	virtual unsigned short GetDimensionColumn() = 0;
};

class ArrayOfArrayFloatSLAU /* : public IArrayOfArraySLAU*/ {
	float **ArrayOfArrayFloat; unsigned short ArrayDimensions[2] = { 0, 0 }; 

	unsigned short GetMaxValueIndexInColumnArray(const float **ArrayOfArrayFloat, const unsigned short INDEX); 
	void AchievedAccuracyArrayOfArrayFloat(float **ArrayOfArrayFloat);

public: 
	bool MainForm_NotEventResizeChange_Bool = true; unsigned short ArrayDimensionsPanelMiddle[2]; float ArrayRange[2] = { 0, 0 }; 
	
	ArrayOfArrayFloatSLAU() : ArrayOfArrayFloatSLAU(1, 1) {} 
	ArrayOfArrayFloatSLAU(float *ArrayRange); 
	ArrayOfArrayFloatSLAU(const unsigned short Dimension);
	ArrayOfArrayFloatSLAU(const unsigned short Dimension1, const unsigned short Dimension2); 
	ArrayOfArrayFloatSLAU(System::String ^SystemStringDimension1, System::String ^SystemStringDimension2); 
	ArrayOfArrayFloatSLAU(System::String ^SystemStringDimensions); 
	~ArrayOfArrayFloatSLAU(); 

	//unsigned short GetDimensionRow() override; 
	//unsigned short GetDimensionColumn() override; 
	unsigned short GetDimensionRow();
	unsigned short GetDimensionColumn(); 
	float GetElementArray(const unsigned short Index1, const unsigned short Index2); 
	void SetElementArray(const unsigned short Index1, const unsigned short Index2, const float NewElement); 

	System::String ^SolveSystemEquationsToString(); 
	
	static float F1(const float X, const float H); 
	static float F2(const float H); 
	static float F3(const float X, const float H); 
	static float F4(const float H); 
	static unsigned short StringToNumber(System::String ^SystemString); 
	static unsigned short *StringToArrayNumbersTwo(System::String ^SystemString); 
	static float *StringToArrayFloat(System::String ^SystemString);
}; 

class ArrayOfArrayFloatSLAU_Prototype {
	static float AccuracyEPS;
public: 
	static float GetAccuracyEPS();
	static ArrayOfArrayFloatSLAU *Clone(ArrayOfArrayFloatSLAU *ObjectArrayOfArrayFloatSLAU, const float AccuracyEPS); 
	static ArrayOfArrayFloatSLAU *Clone(ArrayOfArrayFloatSLAU *ObjectArrayOfArrayFloatSLAU, System::String ^SystemStringAccuracyEPS);
}; 

