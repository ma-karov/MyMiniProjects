#pragma once 
#include "../../Main.h" 
#include "../Main/MainForm.h"

namespace AdditionalChaptersOfComputationalMathematics1 {

	/// <summary>
	/// ������ ��� PrintConclusionSolveSystemEquationsForm
	/// </summary>
	public ref class PrintConclusionSolveSystemEquationsForm : public System::Windows::Forms::Form
	{
	public: 
		PrintConclusionSolveSystemEquationsForm(); 
		PrintConclusionSolveSystemEquationsForm(ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU); //: PrintConclusionSolveSystemEquationsForm() { this->NewArrayOfArrayFloatSLAU = NewArrayOfArrayFloatSLAU; }

	protected:
		/// <summary>
		/// ���������� ��� ������������ �������.
		/// </summary>
		~PrintConclusionSolveSystemEquationsForm();
	private: System::Windows::Forms::ListBox^ ListBoxPrintConclusionSolveSystemEquations;

	private: System::Windows::Forms::Panel^ panel1;
	private: System::Windows::Forms::DataVisualization::Charting::Chart^ SystemEquationsChart;


	private:
		/// <summary>
		/// ������������ ���������� ������������.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// ��������� ����� ��� ��������� ������������ � �� ��������� 
		/// ���������� ����� ������ � ������� ��������� ����.
		/// </summary>
		void InitializeComponent(void); 
#pragma endregion 
		ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU;

		void FormLoadBefore(); 
	};
}
