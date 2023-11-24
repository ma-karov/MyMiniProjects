#include "PrintConclusionSolveSystemEquationsForm.h"

namespace AdditionalChaptersOfComputationalMathematics1 {

	PrintConclusionSolveSystemEquationsForm::PrintConclusionSolveSystemEquationsForm() { InitializeComponent(); }
	PrintConclusionSolveSystemEquationsForm::PrintConclusionSolveSystemEquationsForm(ArrayOfArrayFloatSLAU *NewArrayOfArrayFloatSLAU) : NewArrayOfArrayFloatSLAU(NewArrayOfArrayFloatSLAU) { InitializeComponent(); FormLoadBefore(); }

	PrintConclusionSolveSystemEquationsForm::~PrintConclusionSolveSystemEquationsForm() { delete NewArrayOfArrayFloatSLAU; if (components) delete components; }


	void PrintConclusionSolveSystemEquationsForm::InitializeComponent(void)
	{
		System::Windows::Forms::DataVisualization::Charting::ChartArea^ chartArea1 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
		System::Windows::Forms::DataVisualization::Charting::Series^ series1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
		System::Windows::Forms::DataVisualization::Charting::Title^ title1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Title());
		this->ListBoxPrintConclusionSolveSystemEquations = (gcnew System::Windows::Forms::ListBox());
		this->panel1 = (gcnew System::Windows::Forms::Panel());
		this->SystemEquationsChart = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
		this->panel1->SuspendLayout();
		(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->SystemEquationsChart))->BeginInit();
		this->SuspendLayout();
		// 
		// ListBoxPrintConclusionSolveSystemEquations
		// 
		this->ListBoxPrintConclusionSolveSystemEquations->Dock = System::Windows::Forms::DockStyle::Top;
		this->ListBoxPrintConclusionSolveSystemEquations->FormattingEnabled = true;
		this->ListBoxPrintConclusionSolveSystemEquations->Location = System::Drawing::Point(0, 0);
		this->ListBoxPrintConclusionSolveSystemEquations->Name = L"ListBoxPrintConclusionSolveSystemEquations";
		this->ListBoxPrintConclusionSolveSystemEquations->Size = System::Drawing::Size(365, 56);
		this->ListBoxPrintConclusionSolveSystemEquations->TabIndex = 0;
		// 
		// panel1
		// 
		this->panel1->Controls->Add(this->SystemEquationsChart);
		this->panel1->Controls->Add(this->ListBoxPrintConclusionSolveSystemEquations);
		this->panel1->Dock = System::Windows::Forms::DockStyle::Fill;
		this->panel1->Location = System::Drawing::Point(0, 0);
		this->panel1->Name = L"panel1";
		this->panel1->Size = System::Drawing::Size(365, 261);
		this->panel1->TabIndex = 1;
		// 
		// SystemEquationsChart
		// 
		chartArea1->AxisX->Title = L"X";
		chartArea1->AxisX->TitleAlignment = System::Drawing::StringAlignment::Far;
		chartArea1->AxisX->TitleFont = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8, System::Drawing::FontStyle::Bold));
		chartArea1->AxisX2->TextOrientation = System::Windows::Forms::DataVisualization::Charting::TextOrientation::Rotated270;
		chartArea1->AxisY->TextOrientation = System::Windows::Forms::DataVisualization::Charting::TextOrientation::Horizontal;
		chartArea1->AxisY->Title = L"Y";
		chartArea1->AxisY->TitleAlignment = System::Drawing::StringAlignment::Far;
		chartArea1->AxisY->TitleFont = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8, System::Drawing::FontStyle::Bold));
		chartArea1->Name = L"ChartArea1";
		this->SystemEquationsChart->ChartAreas->Add(chartArea1);
		this->SystemEquationsChart->Dock = System::Windows::Forms::DockStyle::Fill;
		this->SystemEquationsChart->Location = System::Drawing::Point(0, 56);
		this->SystemEquationsChart->Name = L"SystemEquationsChart";
		series1->BorderWidth = 2;
		series1->ChartArea = L"ChartArea1";
		series1->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
		series1->Name = L"Series1";
		this->SystemEquationsChart->Series->Add(series1);
		this->SystemEquationsChart->Size = System::Drawing::Size(365, 205);
		this->SystemEquationsChart->TabIndex = 1;
		title1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10));
		title1->Name = L"Title1";
		title1->Text = L"График решения СЛАУ";
		this->SystemEquationsChart->Titles->Add(title1);
		// 
		// PrintConclusionSolveSystemEquationsForm
		// 
		this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
		this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
		this->ClientSize = System::Drawing::Size(365, 261);
		this->Controls->Add(this->panel1);
		this->Name = L"PrintConclusionSolveSystemEquationsForm";
		this->Text = L"Print conclusion of solving a system of equations";
		this->panel1->ResumeLayout(false);
		(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->SystemEquationsChart))->EndInit();
		this->ResumeLayout(false);

	}

	void PrintConclusionSolveSystemEquationsForm::FormLoadBefore() 
	{ 
		float *ArrayXY = ArrayOfArrayFloatSLAU::StringToArrayFloat(NewArrayOfArrayFloatSLAU->SolveSystemEquationsToString()); const unsigned short ArrayXY_Length(*ArrayXY);
		for (unsigned short i(2); i < ArrayXY_Length; i += 2) 
		{ 
			const float X(*(ArrayXY + i - 1)), Y(*(ArrayXY + i)); 
			ListBoxPrintConclusionSolveSystemEquations->Items->Add("X" + (i/2) + " = " + X + ", Y" + (i/2) + " = " + Y); 
			SystemEquationsChart->Series[0]->Points->AddXY(X, Y);
		} 
		SystemEquationsChart->ChartAreas[0]->AxisX->LabelStyle->Format = "0.00"; 
	}

}


