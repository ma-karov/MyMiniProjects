#include "MainForm.h"

namespace AdditionalChaptersOfComputationalMathematics1 {

	MainForm::MainForm() 
	{ 
		InitializeComponent(); 
		FormLoadBefore(); 
	} 

	MainForm::~MainForm() 
	{ 
		delete NewArrayOfArrayFloatSLAU; 
		if (components) 
			delete components; 
	}
	
	void MainForm::InitializeComponent(void) 
	{
		this->TextBoxInputDimensionSLAU = (gcnew System::Windows::Forms::TextBox());
		this->label1 = (gcnew System::Windows::Forms::Label());
		this->ButtonCreateSystemEquations = (gcnew System::Windows::Forms::Button());
		this->PanelTop = (gcnew System::Windows::Forms::Panel());
		this->TableLayoutPanelMainRow3 = (gcnew System::Windows::Forms::TableLayoutPanel());
		this->PanelMiddle = (gcnew System::Windows::Forms::Panel());
		this->PanelMiddlePrintSLAU = (gcnew System::Windows::Forms::Panel());
		this->PanelMiddle_ScrollBarWidth = (gcnew System::Windows::Forms::HScrollBar());
		this->PanelMiddle_ScrollBarHeight = (gcnew System::Windows::Forms::VScrollBar());
		this->PanelBottom = (gcnew System::Windows::Forms::Panel());
		this->textBox1 = (gcnew System::Windows::Forms::TextBox());
		this->label3 = (gcnew System::Windows::Forms::Label());
		this->PanelBottom_NumericUpDownEndRange = (gcnew System::Windows::Forms::NumericUpDown());
		this->PanelBottom_NumericUpDownBeginRange = (gcnew System::Windows::Forms::NumericUpDown());
		this->ButtonSolveSystemEquations = (gcnew System::Windows::Forms::Button());
		this->TextBoxInputAccuracySolveSLAU = (gcnew System::Windows::Forms::TextBox());
		this->label2 = (gcnew System::Windows::Forms::Label());
		this->PanelTop->SuspendLayout();
		this->TableLayoutPanelMainRow3->SuspendLayout();
		this->PanelMiddle->SuspendLayout();
		this->PanelBottom->SuspendLayout();
		(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->PanelBottom_NumericUpDownEndRange))->BeginInit();
		(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->PanelBottom_NumericUpDownBeginRange))->BeginInit();
		this->SuspendLayout();
		// 
		// TextBoxInputDimensionSLAU
		// 
		this->TextBoxInputDimensionSLAU->Location = System::Drawing::Point(103, 6);
		this->TextBoxInputDimensionSLAU->Name = L"TextBoxInputDimensionSLAU";
		this->TextBoxInputDimensionSLAU->Size = System::Drawing::Size(100, 20);
		this->TextBoxInputDimensionSLAU->TabIndex = 0;
		this->TextBoxInputDimensionSLAU->Text = L"3";
		// 
		// label1
		// 
		this->label1->AutoSize = true;
		this->label1->Location = System::Drawing::Point(3, 9);
		this->label1->Name = L"label1";
		this->label1->Size = System::Drawing::Size(99, 13);
		this->label1->TabIndex = 0;
		this->label1->Text = L"Dimension SLAU = ";
		// 
		// ButtonCreateSystemEquations
		// 
		this->ButtonCreateSystemEquations->AutoSize = true;
		this->ButtonCreateSystemEquations->Location = System::Drawing::Point(214, 6);
		this->ButtonCreateSystemEquations->Name = L"ButtonCreateSystemEquations";
		this->ButtonCreateSystemEquations->Size = System::Drawing::Size(92, 23);
		this->ButtonCreateSystemEquations->TabIndex = 1;
		this->ButtonCreateSystemEquations->Text = L"Create a system";
		this->ButtonCreateSystemEquations->UseVisualStyleBackColor = true;
		this->ButtonCreateSystemEquations->Click += gcnew System::EventHandler(this, &MainForm::ButtonCreateSystemEquations_EventClick);
		// 
		// PanelTop
		// 
		this->PanelTop->Controls->Add(this->label1);
		this->PanelTop->Controls->Add(this->TextBoxInputDimensionSLAU);
		this->PanelTop->Controls->Add(this->ButtonCreateSystemEquations);
		this->PanelTop->Dock = System::Windows::Forms::DockStyle::Top;
		this->PanelTop->Location = System::Drawing::Point(3, 3);
		this->PanelTop->Name = L"PanelTop";
		this->PanelTop->Size = System::Drawing::Size(308, 30);
		this->PanelTop->TabIndex = 0;
		// 
		// TableLayoutPanelMainRow3
		// 
		this->TableLayoutPanelMainRow3->ColumnCount = 1;
		this->TableLayoutPanelMainRow3->ColumnStyles->Add((gcnew System::Windows::Forms::ColumnStyle(System::Windows::Forms::SizeType::Percent,
			100)));
		this->TableLayoutPanelMainRow3->Controls->Add(this->PanelTop, 0, 0);
		this->TableLayoutPanelMainRow3->Controls->Add(this->PanelMiddle, 0, 1);
		this->TableLayoutPanelMainRow3->Controls->Add(this->PanelBottom, 0, 2);
		this->TableLayoutPanelMainRow3->Dock = System::Windows::Forms::DockStyle::Fill;
		this->TableLayoutPanelMainRow3->Location = System::Drawing::Point(0, 0);
		this->TableLayoutPanelMainRow3->Name = L"TableLayoutPanelMainRow3";
		this->TableLayoutPanelMainRow3->RowCount = 3;
		this->TableLayoutPanelMainRow3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent,
			10)));
		this->TableLayoutPanelMainRow3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent,
			70)));
		this->TableLayoutPanelMainRow3->RowStyles->Add((gcnew System::Windows::Forms::RowStyle(System::Windows::Forms::SizeType::Percent,
			20)));
		this->TableLayoutPanelMainRow3->Size = System::Drawing::Size(314, 365);
		this->TableLayoutPanelMainRow3->TabIndex = 0;
		// 
		// PanelMiddle
		// 
		this->PanelMiddle->Controls->Add(this->PanelMiddlePrintSLAU);
		this->PanelMiddle->Controls->Add(this->PanelMiddle_ScrollBarWidth);
		this->PanelMiddle->Controls->Add(this->PanelMiddle_ScrollBarHeight);
		this->PanelMiddle->Dock = System::Windows::Forms::DockStyle::Fill;
		this->PanelMiddle->Location = System::Drawing::Point(3, 39);
		this->PanelMiddle->Name = L"PanelMiddle";
		this->PanelMiddle->Size = System::Drawing::Size(308, 249);
		this->PanelMiddle->TabIndex = 1;
		// 
		// PanelMiddlePrintSLAU
		// 
		this->PanelMiddlePrintSLAU->Dock = System::Windows::Forms::DockStyle::Fill;
		this->PanelMiddlePrintSLAU->Location = System::Drawing::Point(0, 0);
		this->PanelMiddlePrintSLAU->Name = L"PanelMiddlePrintSLAU";
		this->PanelMiddlePrintSLAU->Size = System::Drawing::Size(291, 232);
		this->PanelMiddlePrintSLAU->TabIndex = 0;
		// 
		// PanelMiddle_ScrollBarWidth
		// 
		this->PanelMiddle_ScrollBarWidth->Dock = System::Windows::Forms::DockStyle::Bottom;
		this->PanelMiddle_ScrollBarWidth->LargeChange = 1;
		this->PanelMiddle_ScrollBarWidth->Location = System::Drawing::Point(0, 232);
		this->PanelMiddle_ScrollBarWidth->Maximum = 0;
		this->PanelMiddle_ScrollBarWidth->Name = L"PanelMiddle_ScrollBarWidth";
		this->PanelMiddle_ScrollBarWidth->Size = System::Drawing::Size(291, 17);
		this->PanelMiddle_ScrollBarWidth->TabIndex = 1;
		this->PanelMiddle_ScrollBarWidth->ValueChanged += gcnew System::EventHandler(this, &MainForm::PanelMiddle_ScrollBarWidth_EventValueChange);
		// 
		// PanelMiddle_ScrollBarHeight
		// 
		this->PanelMiddle_ScrollBarHeight->Dock = System::Windows::Forms::DockStyle::Right;
		this->PanelMiddle_ScrollBarHeight->LargeChange = 1;
		this->PanelMiddle_ScrollBarHeight->Location = System::Drawing::Point(291, 0);
		this->PanelMiddle_ScrollBarHeight->Maximum = 0;
		this->PanelMiddle_ScrollBarHeight->Name = L"PanelMiddle_ScrollBarHeight";
		this->PanelMiddle_ScrollBarHeight->Size = System::Drawing::Size(17, 249);
		this->PanelMiddle_ScrollBarHeight->TabIndex = 2;
		this->PanelMiddle_ScrollBarHeight->ValueChanged += gcnew System::EventHandler(this, &MainForm::PanelMiddle_ScrollBarHeight_EventValueChange);
		// 
		// PanelBottom
		// 
		this->PanelBottom->Controls->Add(this->textBox1);
		this->PanelBottom->Controls->Add(this->label3);
		this->PanelBottom->Controls->Add(this->PanelBottom_NumericUpDownEndRange);
		this->PanelBottom->Controls->Add(this->PanelBottom_NumericUpDownBeginRange);
		this->PanelBottom->Controls->Add(this->ButtonSolveSystemEquations);
		this->PanelBottom->Controls->Add(this->TextBoxInputAccuracySolveSLAU);
		this->PanelBottom->Controls->Add(this->label2);
		this->PanelBottom->Dock = System::Windows::Forms::DockStyle::Fill;
		this->PanelBottom->Location = System::Drawing::Point(3, 294);
		this->PanelBottom->Name = L"PanelBottom";
		this->PanelBottom->Size = System::Drawing::Size(308, 68);
		this->PanelBottom->TabIndex = 2;
		// 
		// textBox1
		// 
		this->textBox1->Location = System::Drawing::Point(46, 32);
		this->textBox1->Name = L"textBox1";
		this->textBox1->Size = System::Drawing::Size(29, 20);
		this->textBox1->TabIndex = 6;
		this->textBox1->Text = L"0,1";
		// 
		// label3
		// 
		this->label3->AutoSize = true;
		this->label3->Location = System::Drawing::Point(3, 35);
		this->label3->Name = L"label3";
		this->label3->Size = System::Drawing::Size(25, 13);
		this->label3->TabIndex = 5;
		this->label3->Text = L"h = ";
		// 
		// PanelBottom_NumericUpDownEndRange
		// 
		this->PanelBottom_NumericUpDownEndRange->DecimalPlaces = 1;
		this->PanelBottom_NumericUpDownEndRange->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 65536 });
		this->PanelBottom_NumericUpDownEndRange->Location = System::Drawing::Point(164, 7);
		this->PanelBottom_NumericUpDownEndRange->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 10000, 0, 0, 0 });
		this->PanelBottom_NumericUpDownEndRange->Name = L"PanelBottom_NumericUpDownEndRange";
		this->PanelBottom_NumericUpDownEndRange->Size = System::Drawing::Size(39, 20);
		this->PanelBottom_NumericUpDownEndRange->TabIndex = 4;
		this->PanelBottom_NumericUpDownEndRange->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 23, 0, 0, 65536 });
		this->PanelBottom_NumericUpDownEndRange->Click += gcnew System::EventHandler(this, &MainForm::PanelBottom_NumericUpDownEndRange_EventClick);
		// 
		// PanelBottom_NumericUpDownBeginRange
		// 
		this->PanelBottom_NumericUpDownBeginRange->DecimalPlaces = 1;
		this->PanelBottom_NumericUpDownBeginRange->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 65536 });
		this->PanelBottom_NumericUpDownBeginRange->Location = System::Drawing::Point(119, 7);
		this->PanelBottom_NumericUpDownBeginRange->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 10000, 0, 0, 0 });
		this->PanelBottom_NumericUpDownBeginRange->Name = L"PanelBottom_NumericUpDownBeginRange";
		this->PanelBottom_NumericUpDownBeginRange->Size = System::Drawing::Size(39, 20);
		this->PanelBottom_NumericUpDownBeginRange->TabIndex = 3;
		this->PanelBottom_NumericUpDownBeginRange->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 2, 0, 0, 0 });
		this->PanelBottom_NumericUpDownBeginRange->Click += gcnew System::EventHandler(this, &MainForm::PanelBottom_NumericUpDownBeginRange_EventClick);
		// 
		// ButtonSolveSystemEquations
		// 
		this->ButtonSolveSystemEquations->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F));
		this->ButtonSolveSystemEquations->Location = System::Drawing::Point(214, 5);
		this->ButtonSolveSystemEquations->Name = L"ButtonSolveSystemEquations";
		this->ButtonSolveSystemEquations->Size = System::Drawing::Size(88, 23);
		this->ButtonSolveSystemEquations->TabIndex = 2;
		this->ButtonSolveSystemEquations->Text = L"Solve a system ";
		this->ButtonSolveSystemEquations->UseVisualStyleBackColor = true;
		this->ButtonSolveSystemEquations->Click += gcnew System::EventHandler(this, &MainForm::ButtonSolveSystemEquations_EventClick);
		// 
		// TextBoxInputAccuracySolveSLAU
		// 
		this->TextBoxInputAccuracySolveSLAU->Location = System::Drawing::Point(46, 7);
		this->TextBoxInputAccuracySolveSLAU->Name = L"TextBoxInputAccuracySolveSLAU";
		this->TextBoxInputAccuracySolveSLAU->Size = System::Drawing::Size(29, 20);
		this->TextBoxInputAccuracySolveSLAU->TabIndex = 1;
		this->TextBoxInputAccuracySolveSLAU->Text = L"0,1";
		this->TextBoxInputAccuracySolveSLAU->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &MainForm::TextBoxInputAccuracySolveSLAU_EventKeyPress);
		// 
		// label2
		// 
		this->label2->AutoSize = true;
		this->label2->Location = System::Drawing::Point(3, 10);
		this->label2->Name = L"label2";
		this->label2->Size = System::Drawing::Size(37, 13);
		this->label2->TabIndex = 0;
		this->label2->Text = L"Eps = ";
		// 
		// MainForm
		// 
		this->ClientSize = System::Drawing::Size(314, 365);
		this->Controls->Add(this->TableLayoutPanelMainRow3);
		this->MinimumSize = System::Drawing::Size(330, 285);
		this->Name = L"MainForm";
		this->Text = L"Solving a system of equations";
		this->Resize += gcnew System::EventHandler(this, &MainForm::ThisForm_EventResize);
		this->PanelTop->ResumeLayout(false);
		this->PanelTop->PerformLayout();
		this->TableLayoutPanelMainRow3->ResumeLayout(false);
		this->PanelMiddle->ResumeLayout(false);
		this->PanelBottom->ResumeLayout(false);
		this->PanelBottom->PerformLayout();
		(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->PanelBottom_NumericUpDownEndRange))->EndInit();
		(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->PanelBottom_NumericUpDownBeginRange))->EndInit();
		this->ResumeLayout(false);

	}
#pragma endregion
	
	void MainForm::FormLoadBefore() 
	{ //System::Threading::Thread ^SystemThread = gcnew System::Threading::Thread(gcnew System::Threading::ThreadStart(this, &ButtonCreateMatrix_EventClick)); SystemThread->Start();
		PanelMiddle_ScrollBarHeight->Visible = false; 
		PanelMiddle_ScrollBarWidth->Visible = false; 
		PanelBottom_NumericUpDownBeginRange_OldValue = (float) PanelBottom_NumericUpDownBeginRange->Value; 
		PanelBottom_NumericUpDownEndRange_OldValue = (float) PanelBottom_NumericUpDownEndRange->Value; 
		if (PanelBottom_NumericUpDownBeginRange_OldValue > PanelBottom_NumericUpDownEndRange_OldValue) 
			PanelBottom_NumericUpDownEndRange->Value = System::Decimal(PanelBottom_NumericUpDownEndRange_OldValue); 
	}

	void MainForm::ForEnterUserPanelMiddlePrintSLAU() 
	{ 
		unsigned short *ArraySizePanelMiddlePrintSLAU = PanelMiddle_ScrollBars_EventValueChange(NewArrayOfArrayFloatSLAU->GetDimensionRow());
		for (unsigned short i1(*(ArraySizePanelMiddlePrintSLAU + 2)), Index1(0); i1 < *(ArraySizePanelMiddlePrintSLAU + 3); i1++, Index1++) 
		for (unsigned short i2(*ArraySizePanelMiddlePrintSLAU), Index2(0); i2 < *(ArraySizePanelMiddlePrintSLAU + 1); i2++, Index2++) 
		{ 
			System::Windows::Forms::Control ^GcNewControlLabel = gcnew System::Windows::Forms::Label(); 
			GcNewControlLabel->Text = NewArrayOfArrayFloatSLAU->GetElementArray(i1, i2) + ""; 
			GcNewControlLabel->Name = (i1 + " ") + i2;
			GcNewControlLabel->Location = System::Drawing::Point(4 + 40*Index2, 4 + 25*Index1); 
			GcNewControlLabel->Size = System::Drawing::Size(35, 20); 
			GcNewControlLabel->Click += gcnew System::EventHandler(this, &MainForm::PanelMiddlePrintSLAU_LabelToTextBox_EventClick); 
			ArrayTextBoxInputSLAU[Index1*NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] + Index2] = GcNewControlLabel; 
		} 
		PanelMiddlePrintSLAU->Controls->AddRange(ArrayTextBoxInputSLAU); 
	} 

	void MainForm::SetConfigureControl_PanelMiddlePrintSLAU(System::Windows::Forms::Control ^SystemObjectControl, System::Windows::Forms::Control ^GcControl, const unsigned short INDEX1, const unsigned short INDEX2) 
	{ 
		GcControl->Text = SystemObjectControl->Text; 
		GcControl->Name = (INDEX1 + " ") + INDEX2; 
		GcControl->Location = System::Drawing::Point(4 + 40*INDEX2, 4 + 25*INDEX1); 
		GcControl->Size = System::Drawing::Size(30, 20); 
		PanelMiddlePrintSLAU->Controls->Remove(ArrayTextBoxInputSLAU[INDEX1*NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] + INDEX2]); 
	}
	
	unsigned short *MainForm::GetLengthForPlacePanelMiddlePrintSLAU() { return new unsigned short[2] { GetLengthForPlacePanelMiddlePrintSLAU("Width"), GetLengthForPlacePanelMiddlePrintSLAU("Height") }; } 

	unsigned short MainForm::GetLengthForPlacePanelMiddlePrintSLAU(std::string StdStringSwitch) 
	{ 
		System::Drawing::Size PanelMiddlePrintSLAU_Size = PanelMiddlePrintSLAU->Size; 
		if (StdStringSwitch == "Width") 
			return (0 + PanelMiddlePrintSLAU_Size.Width/40); //return ( ( WIDTH < 310 ) ? 8 : 9 ); 
		if (StdStringSwitch == "Height") 
			return (2 + PanelMiddlePrintSLAU_Size.Height/30); return 0; } //return ( ( HEIGHT < 180 ) ? 7 : ( ( HEIGHT < 210 ) ? 8 : 9 ) ); 

	unsigned short *MainForm::PanelMiddle_ScrollBars_EventValueChange(const unsigned short COUNT_EQUATIONS) 
	{ 
		unsigned short *ArraySizePanelMiddlePrintSLAU = new unsigned short[4] { 0, GetLengthForPlacePanelMiddlePrintSLAU("Width"), 0, GetLengthForPlacePanelMiddlePrintSLAU("Height") };
		#define COUNT_EQUATIONS_LT_SIZE_WIDTH_FORM (COUNT_EQUATIONS - (*(ArraySizePanelMiddlePrintSLAU + 1))) 
		#define COUNT_EQUATIONS_LT_SIZE_HEIGHT_FORM (COUNT_EQUATIONS - (*(ArraySizePanelMiddlePrintSLAU + 3))) 	
		PanelMiddle_ScrollBarWidth->Visible = COUNT_EQUATIONS_LT_SIZE_WIDTH_FORM > 0; 
		PanelMiddle_ScrollBarWidth->Maximum = (COUNT_EQUATIONS_LT_SIZE_WIDTH_FORM > 0) ? COUNT_EQUATIONS_LT_SIZE_WIDTH_FORM : 0; 
		PanelMiddle_ScrollBarHeight->Visible = COUNT_EQUATIONS_LT_SIZE_HEIGHT_FORM > 0; 
		PanelMiddle_ScrollBarHeight->Maximum = (COUNT_EQUATIONS_LT_SIZE_HEIGHT_FORM > 0) ? COUNT_EQUATIONS_LT_SIZE_HEIGHT_FORM : 0; 

		#define LENGTH NewArrayOfArrayFloatSLAU->GetDimensionColumn() 
		*ArraySizePanelMiddlePrintSLAU = PanelMiddle_ScrollBarWidth->Value; 
		*(ArraySizePanelMiddlePrintSLAU + 1) = ((*(ArraySizePanelMiddlePrintSLAU + 1)) > LENGTH) ? LENGTH : (*(ArraySizePanelMiddlePrintSLAU + 1)) + (*ArraySizePanelMiddlePrintSLAU);

		#define LENGTH COUNT_EQUATIONS 
		*(ArraySizePanelMiddlePrintSLAU + 2) = PanelMiddle_ScrollBarHeight->Value; 
		*(ArraySizePanelMiddlePrintSLAU + 3) = ((*(ArraySizePanelMiddlePrintSLAU + 3)) > LENGTH) ? LENGTH : (*(ArraySizePanelMiddlePrintSLAU + 3)) + (*(ArraySizePanelMiddlePrintSLAU + 2)); 

		return ArraySizePanelMiddlePrintSLAU; 
	} 

	void MainForm::PanelMiddlePrintSLAU_EventResizeChange() 
	{ 
		NewArrayOfArrayFloatSLAU->MainForm_NotEventResizeChange_Bool = false; 
		unsigned short *ArrayCoefficientForPlacePanelMiddlePrintSLAU = GetLengthForPlacePanelMiddlePrintSLAU(); 
		bool ChangeArrayBool(false); 
		if ((*ArrayCoefficientForPlacePanelMiddlePrintSLAU) <= NewArrayOfArrayFloatSLAU->GetDimensionColumn()) 
		{ 
			ChangeArrayBool = NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[0] != *ArrayCoefficientForPlacePanelMiddlePrintSLAU; 
			NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[0] = *ArrayCoefficientForPlacePanelMiddlePrintSLAU; 
		} 

		if ((*(ArrayCoefficientForPlacePanelMiddlePrintSLAU + 1)) < NewArrayOfArrayFloatSLAU->GetDimensionRow()) 
		{ 
			ChangeArrayBool = ChangeArrayBool || NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] != *(ArrayCoefficientForPlacePanelMiddlePrintSLAU + 1);
			NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] = *(ArrayCoefficientForPlacePanelMiddlePrintSLAU + 1); 
		}

		if (ChangeArrayBool) 
		{ 
			ArrayTextBoxInputSLAU = gcnew array<System::Windows::Forms::Control ^>(NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[0]*NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1]); 
			TextBoxInputDimensionSLAU->Text = PanelMiddlePrintSLAU->Size.Width + " " + PanelMiddlePrintSLAU->Size.Height; 
			ForEnterUserPanelMiddlePrintSLAU(); 
		} 

		NewArrayOfArrayFloatSLAU->MainForm_NotEventResizeChange_Bool = true; 
	}
	

	System::Void MainForm::ThisForm_EventResize(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) { if (NewArrayOfArrayFloatSLAU->MainForm_NotEventResizeChange_Bool) PanelMiddlePrintSLAU_EventResizeChange(); }

	System::Void MainForm::PanelMiddle_ScrollBarWidth_EventValueChange(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) { ForEnterUserPanelMiddlePrintSLAU(); }
	System::Void MainForm::PanelMiddle_ScrollBarHeight_EventValueChange(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) { ForEnterUserPanelMiddlePrintSLAU(); } 

	System::Void MainForm::PanelBottom_NumericUpDownBeginRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		const float PanelBottom_NumericUpDownBeginRange_Value((float) PanelBottom_NumericUpDownBeginRange->Value); 
		if (PanelBottom_NumericUpDownBeginRange_OldValue - PanelBottom_NumericUpDownBeginRange_Value) 
		{ 
			if (PanelBottom_NumericUpDownBeginRange_Value < PanelBottom_NumericUpDownEndRange_OldValue) 
				PanelBottom_NumericUpDownBeginRange_OldValue = PanelBottom_NumericUpDownBeginRange_Value; 
			PanelBottom_NumericUpDownBeginRange->Value = System::Decimal(PanelBottom_NumericUpDownBeginRange_OldValue); 
		} 
	}

	System::Void MainForm::PanelBottom_NumericUpDownEndRange_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		const float PanelBottom_NumericUpDownEndRange_Value((float) PanelBottom_NumericUpDownEndRange->Value); 
		if (PanelBottom_NumericUpDownEndRange_OldValue - PanelBottom_NumericUpDownEndRange_Value) 
		{ 
			if (PanelBottom_NumericUpDownEndRange_Value > PanelBottom_NumericUpDownBeginRange_OldValue) 
				PanelBottom_NumericUpDownEndRange_OldValue = PanelBottom_NumericUpDownEndRange_Value; 
			PanelBottom_NumericUpDownEndRange->Value = System::Decimal(PanelBottom_NumericUpDownEndRange_OldValue); 
		} 
	}

	System::Void MainForm::PanelMiddlePrintSLAU_LabelToTextBox_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		System::Windows::Forms::Label ^SystemObjectLabel = (System::Windows::Forms::Label ^) SystemObject; 
		unsigned short *ARRAY_INDEX = ArrayOfArrayFloatSLAU::StringToArrayNumbersTwo(SystemObjectLabel->Name);
		System::Windows::Forms::Control ^GcNewControlTextBox = gcnew System::Windows::Forms::TextBox(); 
		SetConfigureControl_PanelMiddlePrintSLAU(SystemObjectLabel, GcNewControlTextBox, *ARRAY_INDEX, *(ARRAY_INDEX + 1)); 
		GcNewControlTextBox->Leave += gcnew System::EventHandler(this, &MainForm::PanelMiddlePrintSLAU_TextBoxToLabel_EventLeave); 
	//	System::Windows::Forms::MessageBox::Show((*ARRAY_INDEX) + " " + NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] + " " + (*(ARRAY_INDEX + 1)) + " = " + ((*ARRAY_INDEX)*NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] + (*(ARRAY_INDEX + 1))) ); 
		ArrayTextBoxInputSLAU[(*ARRAY_INDEX)*NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] + (*(ARRAY_INDEX + 1))] = GcNewControlTextBox; 
		PanelMiddlePrintSLAU->Controls->Add(GcNewControlTextBox); /*ActiveControl = GcNewControlTextBox;*/ 
		GcNewControlTextBox->Focus(); 
	}

	System::Void MainForm::PanelMiddlePrintSLAU_TextBoxToLabel_EventLeave(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		System::Windows::Forms::TextBox ^SystemObjectTextBox = (System::Windows::Forms::TextBox ^) SystemObject; 
		const unsigned short *ARRAY_INDEX = ArrayOfArrayFloatSLAU::StringToArrayNumbersTwo(SystemObjectTextBox->Name); 
		System::Windows::Forms::Control ^GcNewControlLabel = gcnew System::Windows::Forms::Label(); 
		SetConfigureControl_PanelMiddlePrintSLAU(SystemObjectTextBox, GcNewControlLabel, *ARRAY_INDEX, *(ARRAY_INDEX + 1)); 
		GcNewControlLabel->Click += gcnew System::EventHandler(this, &MainForm::PanelMiddlePrintSLAU_LabelToTextBox_EventClick); 
		NewArrayOfArrayFloatSLAU->SetElementArray(*ARRAY_INDEX, *(ARRAY_INDEX + 1), ArrayOfArrayFloatSLAU::StringToNumber(GcNewControlLabel->Text));
		ArrayTextBoxInputSLAU[(*ARRAY_INDEX)*NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] + (*(ARRAY_INDEX + 1))] = GcNewControlLabel; 
		PanelMiddlePrintSLAU->Controls->Add(GcNewControlLabel); 
	}

	System::Void MainForm::TextBoxInputAccuracySolveSLAU_EventKeyPress(System::Object ^SystemObject, System::Windows::Forms::KeyPressEventArgs ^SystemKeyPressEventArgs) 
	{ 
		if ( ( (unsigned short) SystemKeyPressEventArgs->KeyChar) == ( (unsigned short) System::Windows::Forms::Keys::Enter) ) 
			ButtonSolveSystemEquations_EventClick(ButtonSolveSystemEquations, gcnew System::EventArgs()); 
	} 
	
	System::Void MainForm::ButtonCreateSystemEquations_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		delete NewArrayOfArrayFloatSLAU; 
		const unsigned short INPUT_DIMENSION_SLAU(ArrayOfArrayFloatSLAU::StringToNumber(TextBoxInputDimensionSLAU->Text));
		NewArrayOfArrayFloatSLAU = new ArrayOfArrayFloatSLAU(INPUT_DIMENSION_SLAU); 
		NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[0] = INPUT_DIMENSION_SLAU; 
		NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1] = INPUT_DIMENSION_SLAU + 1; 
		ArrayTextBoxInputSLAU = gcnew array<System::Windows::Forms::Control ^>(NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[0]*NewArrayOfArrayFloatSLAU->ArrayDimensionsPanelMiddle[1]); 
		ForEnterUserPanelMiddlePrintSLAU(); 
	} 
	
	System::Void MainForm::ButtonSolveSystemEquations_EventClick(System::Object ^SystemObject, System::EventArgs ^SystemEventArgs) 
	{ 
		PrintConclusionSolveSystemEquationsForm(ArrayOfArrayFloatSLAU_Prototype::Clone(NewArrayOfArrayFloatSLAU, TextBoxInputAccuracySolveSLAU->Text)).ShowDialog(); 
	}
	
}

