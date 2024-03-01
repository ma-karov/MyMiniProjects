#pragma once
#include <string> 
#include "../PrintConclusionSolveSystemEquations/PrintConclusionSolveSystemEquationsForm.h" 
#include "../../Main.h"


namespace AdditionalChaptersOfComputationalMathematics1 {
#define ARRAY_TEXTBOX_SLAU_LENGTH 8 
	/// <summary>
	/// —водка дл€ MainForm1
	/// </summary>
	public ref class MainForm : public System::Windows::Forms::Form {
	public:
		MainForm(void);

	protected:
		/// <summary>
		/// ќсвободить все используемые ресурсы.
		/// </summary>
		~MainForm();

	private:
		/// <summary>
		/// ќб€зательна€ переменна€ конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;
		System::Drawing::Size Size;

	private: System::Windows::Forms::TextBox^ TextBoxInputDimensionSLAU;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Panel^ PanelTop;
	private: System::Windows::Forms::TableLayoutPanel^ TableLayoutPanelMainRow3;
	private: System::Windows::Forms::Button^ ButtonCreateSystemEquations, ^ButtonSolveSystemEquations;

	private: System::Windows::Forms::Button^ ButtonCreateMatrix;
	private: System::Windows::Forms::TextBox^ TextBoxInputAccuracySolveSLAU;



	private: System::Windows::Forms::Panel^ PanelBottom;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Panel^ PanelMiddle;
	private: System::Windows::Forms::HScrollBar^ PanelMiddle_ScrollBarWidth;

	private: System::Windows::Forms::VScrollBar^ PanelMiddle_ScrollBarHeight;
	private: System::Windows::Forms::Panel^ PanelMiddlePrintSLAU;
	private: System::Windows::Forms::VScrollBar^ ScrollBarHeight;
	private: System::Windows::Forms::NumericUpDown^ PanelBottom_NumericUpDownBeginRange;
	private: System::Windows::Forms::NumericUpDown^ PanelBottom_NumericUpDownEndRange;
	private: System::Windows::Forms::TextBox^ textBox1;
	private: System::Windows::Forms::Label^ label3;




		//System::Drawing::Font AutoScaleMode;
		
#pragma region Windows Form Designer generated code
		/// <summary>
		/// “ребуемый метод дл€ поддержки конструктора Ч не измен€йте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void); 
#pragma endregion 

		ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU = new ArrayOfArrayFloatSLAU(); float PanelBottom_NumericUpDownBeginRange_OldValue, PanelBottom_NumericUpDownEndRange_OldValue; 
		array<System::Windows::Forms::Control ^> ^ArrayTextBoxInputSLAU; //= gcnew array<System::Windows::Forms::Control ^>(ARRAY_TEXTBOX_SLAU_LENGTH);

		void FormLoadBefore(); 
		void ForEnterUserPanelMiddlePrintSLAU();
		void SetConfigureControl_PanelMiddlePrintSLAU(System::Windows::Forms::Control ^SystemObjectControl, System::Windows::Forms::Control ^GcControl, const unsigned short INDEX1, const unsigned short INDEX2); 
		unsigned short *GetLengthForPlacePanelMiddlePrintSLAU();
		unsigned short GetLengthForPlacePanelMiddlePrintSLAU(std::string StdStringSwitch); 
		unsigned short *PanelMiddle_ScrollBars_EventValueChange(const unsigned short COUNT_EQUATIONS); 
		void PanelMiddlePrintSLAU_EventResizeChange();

		System::Void ThisForm_EventResize(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void PanelMiddle_ScrollBarWidth_EventValueChange(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs);
		System::Void PanelMiddle_ScrollBarHeight_EventValueChange(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void PanelBottom_NumericUpDownBeginRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void PanelBottom_NumericUpDownEndRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void PanelMiddlePrintSLAU_LabelToTextBox_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs);
		System::Void PanelMiddlePrintSLAU_TextBoxToLabel_EventLeave(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void TextBoxInputAccuracySolveSLAU_EventKeyPress(System::Object ^SystemObject, System::Windows::Forms::KeyPressEventArgs ^SystemKeyPressEventArgs); 
		System::Void ButtonCreateSystemEquations_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void ButtonSolveSystemEquations_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 

	public: 

	};
}
