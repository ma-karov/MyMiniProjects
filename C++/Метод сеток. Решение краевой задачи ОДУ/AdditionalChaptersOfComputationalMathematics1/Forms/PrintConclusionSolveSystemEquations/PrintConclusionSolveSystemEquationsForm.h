#pragma once 
#include "../../Main.h" 
#include "../Main/MainForm.h"

namespace AdditionalChaptersOfComputationalMathematics1 {

	/// <summary>
	/// —водка дл€ PrintConclusionSolveSystemEquationsForm
	/// </summary>
	public ref class PrintConclusionSolveSystemEquationsForm : public System::Windows::Forms::Form
	{
	public: 
		PrintConclusionSolveSystemEquationsForm(); 
		PrintConclusionSolveSystemEquationsForm(ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU); //: PrintConclusionSolveSystemEquationsForm() { this->NewArrayOfArrayFloatSLAU = NewArrayOfArrayFloatSLAU; }

	protected:
		/// <summary>
		/// ќсвободить все используемые ресурсы.
		/// </summary>
		~PrintConclusionSolveSystemEquationsForm();
	private: System::Windows::Forms::ListBox^ ListBoxPrintConclusionSolveSystemEquations;

	private: System::Windows::Forms::Panel^ panel1;
	private: System::Windows::Forms::DataVisualization::Charting::Chart^ SystemEquationsChart;


	private:
		/// <summary>
		/// ќб€зательна€ переменна€ конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// “ребуемый метод дл€ поддержки конструктора Ч не измен€йте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void); 
#pragma endregion 
		ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU;

		void FormLoadBefore(); 
	};
}
