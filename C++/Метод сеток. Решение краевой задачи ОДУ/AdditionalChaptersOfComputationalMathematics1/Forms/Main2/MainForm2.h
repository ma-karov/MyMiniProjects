#pragma once 

#include "../PrintConclusionSolveSystemEquations/PrintConclusionSolveSystemEquationsForm.h" 
#include "../../Main.h" 

namespace AdditionalChaptersOfComputationalMathematics1 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// —водка дл€ MainForm2
	/// </summary>
	public ref class MainForm2 : public System::Windows::Forms::Form
	{
	public:
		MainForm2(void)
		{
			InitializeComponent(); 
			FormLoadBefore(); 
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// ќсвободить все используемые ресурсы.
		/// </summary>
		~MainForm2()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TextBox^ TextBox_AccuracyEPS;
	protected:

	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Panel^ panel1;
	private: System::Windows::Forms::NumericUpDown^ Panel_NumericUpDownBeginRange;
	private: System::Windows::Forms::TextBox^ TextBox_StepsN;


	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::NumericUpDown^ Panel_NumericUpDownEndRange;
	private: System::Windows::Forms::Button^ ButtonSolveSystemEquations;


	protected:

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
		void InitializeComponent(void)
		{
			this->TextBox_AccuracyEPS = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->ButtonSolveSystemEquations = (gcnew System::Windows::Forms::Button());
			this->Panel_NumericUpDownEndRange = (gcnew System::Windows::Forms::NumericUpDown());
			this->Panel_NumericUpDownBeginRange = (gcnew System::Windows::Forms::NumericUpDown());
			this->TextBox_StepsN = (gcnew System::Windows::Forms::TextBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->panel1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Panel_NumericUpDownEndRange))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Panel_NumericUpDownBeginRange))->BeginInit();
			this->SuspendLayout();
			// 
			// TextBox_AccuracyEPS
			// 
			this->TextBox_AccuracyEPS->Location = System::Drawing::Point(69, 6);
			this->TextBox_AccuracyEPS->Name = L"TextBox_AccuracyEPS";
			this->TextBox_AccuracyEPS->Size = System::Drawing::Size(100, 20);
			this->TextBox_AccuracyEPS->TabIndex = 0;
			this->TextBox_AccuracyEPS->Text = L"0,01";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(3, 9);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(40, 13);
			this->label1->TabIndex = 1;
			this->label1->Text = L"EPS = ";
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->ButtonSolveSystemEquations);
			this->panel1->Controls->Add(this->Panel_NumericUpDownEndRange);
			this->panel1->Controls->Add(this->Panel_NumericUpDownBeginRange);
			this->panel1->Controls->Add(this->TextBox_StepsN);
			this->panel1->Controls->Add(this->label2);
			this->panel1->Controls->Add(this->TextBox_AccuracyEPS);
			this->panel1->Controls->Add(this->label1);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(284, 261);
			this->panel1->TabIndex = 2;
			// 
			// ButtonSolveSystemEquations
			// 
			this->ButtonSolveSystemEquations->Location = System::Drawing::Point(37, 108);
			this->ButtonSolveSystemEquations->Name = L"ButtonSolveSystemEquations";
			this->ButtonSolveSystemEquations->Size = System::Drawing::Size(142, 33);
			this->ButtonSolveSystemEquations->TabIndex = 6;
			this->ButtonSolveSystemEquations->Text = L"Solve System Equations";
			this->ButtonSolveSystemEquations->UseVisualStyleBackColor = true;
			this->ButtonSolveSystemEquations->Click += gcnew System::EventHandler(this, &MainForm2::ButtonSolveSystemEquations_EventClick);
			// 
			// Panel_NumericUpDownEndRange
			// 
			this->Panel_NumericUpDownEndRange->DecimalPlaces = 1;
			this->Panel_NumericUpDownEndRange->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 65536 });
			this->Panel_NumericUpDownEndRange->Location = System::Drawing::Point(69, 82);
			this->Panel_NumericUpDownEndRange->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 100000, 0, 0, 0 });
			this->Panel_NumericUpDownEndRange->Name = L"Panel_NumericUpDownEndRange";
			this->Panel_NumericUpDownEndRange->Size = System::Drawing::Size(50, 20);
			this->Panel_NumericUpDownEndRange->TabIndex = 5;
			this->Panel_NumericUpDownEndRange->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 11, 0, 0, 65536 });
			this->Panel_NumericUpDownEndRange->Click += gcnew System::EventHandler(this, &MainForm2::Panel_NumericUpDownEndRange_EventClick);
			// 
			// Panel_NumericUpDownBeginRange
			// 
			this->Panel_NumericUpDownBeginRange->DecimalPlaces = 1;
			this->Panel_NumericUpDownBeginRange->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 65536 });
			this->Panel_NumericUpDownBeginRange->Location = System::Drawing::Point(13, 82);
			this->Panel_NumericUpDownBeginRange->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 100000, 0, 0, 0 });
			this->Panel_NumericUpDownBeginRange->Name = L"Panel_NumericUpDownBeginRange";
			this->Panel_NumericUpDownBeginRange->Size = System::Drawing::Size(50, 20);
			this->Panel_NumericUpDownBeginRange->TabIndex = 4;
			this->Panel_NumericUpDownBeginRange->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 8, 0, 0, 65536 });
			this->Panel_NumericUpDownBeginRange->Click += gcnew System::EventHandler(this, &MainForm2::Panel_NumericUpDownBeginRange_EventClick);
			// 
			// TextBox_StepsN
			// 
			this->TextBox_StepsN->Location = System::Drawing::Point(69, 45);
			this->TextBox_StepsN->Name = L"TextBox_StepsN";
			this->TextBox_StepsN->Size = System::Drawing::Size(100, 20);
			this->TextBox_StepsN->TabIndex = 2;
			this->TextBox_StepsN->Text = L"4";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(3, 48);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(60, 13);
			this->label2->TabIndex = 3;
			this->label2->Text = L"Steps(N) = ";
			// 
			// MainForm2
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(284, 261);
			this->Controls->Add(this->panel1);
			this->Name = L"MainForm2";
			this->Text = L"MainForm2";
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Panel_NumericUpDownEndRange))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->Panel_NumericUpDownBeginRange))->EndInit();
			this->ResumeLayout(false);

		}

#pragma endregion 

		ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU = new ArrayOfArrayFloatSLAU(); 
		float Panel_NumericUpDownBeginRange_OldValue, Panel_NumericUpDownEndRange_OldValue; 

		void FormLoadBefore(); 

		System::Void Panel_NumericUpDownBeginRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void Panel_NumericUpDownEndRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
		System::Void ButtonSolveSystemEquations_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs); 
	};
}
