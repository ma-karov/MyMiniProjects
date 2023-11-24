#include <iostream>

#define EPS 0.001

class Fraction 
{
    short Numerator, Denominator;
    
    static short ABS_Values(const short Value) { return ( Value < 0 ? -Value : Value ); }
    
    static void NOD_Values(short *Value1, short *Value2) 
    { 
        short Numer(ABS_Values(*Value1)), Denom(ABS_Values(*Value2)); 
        while (Numer && Denom) 
            if (Numer > Denom) Numer %= Denom; 
            else Denom %= Numer; 
        
        Numer += Denom; 
        *Value1 /= Numer; *Value2 /= Numer; 
    }

    static unsigned short NOK_Values(const short Value1, const short Value2) 
    { 
        short Value_1(Value1), Value_2(Value2); 
        NOD_Values(&Value_1, &Value_2); 
        return ABS_Values(Value_1*Value2); 
    } 

    void ReplacementSign() { if (Denominator < 0) { Numerator *= -1; Denominator *= -1; } }

public:
    Fraction() : Numerator(0), Denominator(1) { }
    Fraction(short Numerator, short Denominator = 1) 
    { 
        this->Numerator = Numerator; 
        this->Denominator = Denominator; 
        ReplacementSign(); 
        NOD_Values(&this->Numerator, &this->Denominator); 
    } 

    Fraction(const Fraction &NewFraction) 
    { 
        Numerator = NewFraction.Numerator; 
        Denominator = NewFraction.Denominator; 
        ReplacementSign(); 
    } 

    Fraction(const Fraction &NewFraction1, const Fraction &NewFraction2) 
    { 
        Fraction NewFraction(NewFraction1); 
        NewFraction.Division(NewFraction2); 
        Numerator = NewFraction.Numerator; 
        Denominator = NewFraction.Denominator; 
        ReplacementSign(); 
        NOD_Values(&this->Numerator, &this->Denominator); 
    }

    Fraction Addition(const Fraction NewFraction) 
    { 
        const unsigned short NOK_Denominators = NOK_Values(Denominator, NewFraction.Denominator); 
        Numerator = Numerator*(NOK_Denominators/Denominator) + NewFraction.Numerator*(NOK_Denominators/NewFraction.Denominator); 
        Denominator = NOK_Denominators; NOD_Values(&Numerator, &Denominator); 
        return *this; 
    }
    
    Fraction Subtraction(Fraction NewFraction) 
    { 
        NewFraction.Numerator *= -1; 
        return Addition(NewFraction); 
    }

    Fraction Multiplication(const short Value) 
    { 
        Numerator *= Value; 
        NOD_Values(&Numerator, &Denominator); 
        return *this; 
    }
    
    Fraction Multiplication(const Fraction NewFraction) 
    { 
        Numerator *= NewFraction.Numerator; 
        Denominator *= NewFraction.Denominator; 
        NOD_Values(&Numerator, &Denominator); 
        return *this; 
    } 

    Fraction Division(Fraction NewFraction) 
    { 
        NOD_Values(&Numerator, &NewFraction.Numerator); 
        NOD_Values(&Denominator, &NewFraction.Denominator); 
        Numerator *= NewFraction.Denominator; 
        Denominator *= NewFraction.Numerator; 
        NOD_Values(&Numerator, &Denominator); 
        return *this; 
    }

    float GetValue() { return 1.0*Numerator/Denominator; }

    void PrintFraction(const bool Boolean = true) 
    { 
        switch(Boolean) 
        {
            case true: 
            { 
                if (!Numerator) 
                    std::cout << 0; 
                else if (ABS_Values(Numerator) < ABS_Values(Denominator)) 
                    std::cout << Numerator << "/" << Denominator; 
                else 
                { 
                    const short RemainderFraction(Numerator%Denominator); 
                    std::cout << (Numerator - RemainderFraction)/Denominator; 
                    if (RemainderFraction) 
                        std::cout << " " << ABS_Values(RemainderFraction) << "/" << Denominator; 
                } 
                break; 
            }
            case false: 
            { 
                if (!Numerator) 
                    std::cout << 0; 
                else if (!(Numerator - Denominator)) 
                    std::cout << 1; 
                else if (!(Denominator - 1)) 
                    std::cout << Numerator; 
                else 
                    std::cout << Numerator << "/" << Denominator; 
            } 
        } 
    }

    static bool Comparison(Fraction Fraction1, Fraction Fraction2, const unsigned short Switch) 
    { 
        switch(Switch) 
        {
            case 0: 
                return ( (!(Fraction1.Numerator - Fraction2.Numerator) && !(Fraction1.Denominator - Fraction2.Denominator)) ? true : false );
            case 1: 
                return ( (Fraction1.Numerator*Fraction2.Denominator > Fraction2.Numerator*Fraction1.Denominator) ? true : false );
            case 2: 
                return ( (Fraction1.Numerator*Fraction2.Denominator < Fraction2.Numerator*Fraction1.Denominator) ? true : false );
            case 3: 
                return ( (Fraction1.Numerator*Fraction2.Denominator >= Fraction2.Numerator*Fraction1.Denominator) ? true : false );
            case 4: 
                return ( (Fraction1.Numerator*Fraction2.Denominator <= Fraction2.Numerator*Fraction1.Denominator) ? true : false ); 
        } 
    }

};

class MatrixFraction 
{
    Fraction **ArrayFraction; unsigned short N1, N2;

    void Build_ArrayFraction() 
    { 
        if (!(N2 - 1)) 
        { 
            N2 = N1; N1 = 1; 
        } 
        
        ArrayFraction = new Fraction* [N1]; 
        for (unsigned short i(0); i < N2;) *(ArrayFraction + i++) = new Fraction[N2];

        for (unsigned short i1(0); i1 < N1; i1++)
            for (unsigned short i2(0); i2 < N2;) 
                *(*(this->ArrayFraction + i1) + i2++) = Fraction(); 
    }

    void Build_ArrayFraction(MatrixFraction NewMatrixFraction) 
    { 
        if (!(N2 - 1)) 
        { 
            N2 = N1; N1 = 1; 
            ArrayFraction = new Fraction* [N1]; 
            for (unsigned short i(0); i < N2;) 
                *(ArrayFraction + i++) = new Fraction[N2]; 
            for (unsigned short i(0); i < N2; i++) 
                *(*(ArrayFraction) + i) = NewMatrixFraction.GetElementAt(i); 
        } 
        else 
        { 
            ArrayFraction = new Fraction* [N1]; 
            for (unsigned short i(0); i < N2;) 
                *(ArrayFraction + i++) = new Fraction[N2];
            for (unsigned short i1(0); i1 < N1; i1++) 
                for (unsigned short i2(0); i2 < N2;) 
                    *(*(ArrayFraction + i1) + i2++) = NewMatrixFraction.GetElementAt(i1, i2); 
        } 
    }

public:
    MatrixFraction(const unsigned short N1, const unsigned short N2 = 1) : N1(N1), N2(N2) 
    { 
        Build_ArrayFraction(); 
    } 

    MatrixFraction(const MatrixFraction NewMatrixFraction, const unsigned short N1, const unsigned short N2 = 1) : N1(N1), N2(N2) 
    { 
        Build_ArrayFraction(NewMatrixFraction); 
    }

    void ResetZeroArray() { Build_ArrayFraction(); }

    void Cin_ArrayFraction() 
    { 
        const Fraction ArrayFraction[N1][N2] = { { 10, 0, 0, 10 }, { 0, 11, 2, 15 }, { 1, 0, 5, 11 } }; //{ { 2, -1, 0, 0, 0, -25 }, { -3, 8, -1, 0, 0, 72 }, { 0, -5, 12, 2, 0, -69 }, { 0, 0, -6, 18, -4, -156 }, { 0, 0, 0, -5, 10, 20 } }; //{ { 2, 3, -1, 7 }, { 1, -1, 6, 14 }, { 6, -2, 1, 11 } };
        for (unsigned short i1(0); i1 < N1; i1++) 
            for (unsigned short i2(0); i2 < N2; i2++) 
                *(*(this->ArrayFraction + i1) + i2) = *(*(ArrayFraction + i1) + i2); 
    }

    void Cin_ArrayFractionFromArray(const Fraction *ArrayFraction) 
    {
        for (unsigned short i(0); i < N2; i++) 
            *(*(this->ArrayFraction) + i) = *(ArrayFraction + i); 
    }

    void Cin_ArrayFractionFromArray(const Fraction **ArrayFraction) 
    {
        for (unsigned short i1(0); i1 < N1; i1++)
            for (unsigned short i2(0); i2 < N2;) 
                *(*(this->ArrayFraction + i1) + i2) = *(*(ArrayFraction + i1) + i2++); 
    }

    Fraction GetElementAt(const unsigned short I1, const short I2 = -1) 
    { 
        return ( (!(I2 + 1)) ? *(*ArrayFraction + I1) : *(*(ArrayFraction + I1) + I2) ); 
    }
    
    void SetElementAt(const Fraction NewFraction, const unsigned short I1, const short I2 = -1) 
    { 
        (!(I2 + 1)) ? *(*ArrayFraction + I1) = NewFraction : *(*(ArrayFraction + I1) + I2) = NewFraction; 
    }

    unsigned short MinMaxValueArray(const unsigned short* ArrayIndexs, const unsigned short Index, const unsigned short Switch = 0) 
    { 
        unsigned short Index_MinMaxValue(0); 
        Fraction NewFraction = *(*(ArrayFraction + Index) + *ArrayIndexs);
        for (unsigned short i(1); i < N1 - Index; i++) 
        { 
            Fraction NewFraction2 = *(*(ArrayFraction + *(ArrayIndexs + i)) + Index); 
            if (Fraction::Comparison(NewFraction, NewFraction2, Switch)) 
            { 
                NewFraction = NewFraction2; Index_MinMaxValue = i; 
            } 
        } 
        return *(ArrayIndexs + Index_MinMaxValue); 
    }

    void PrintMatrix(const bool Boolean = true) 
    {
        for (unsigned short i1(0); i1 < N1; i1++) 
        {
            for (unsigned short i2(0); i2 < N2;) 
            { 
                Fraction NewFraction = *(*(ArrayFraction + i1) + i2++); 
                NewFraction.PrintFraction(Boolean); std::cout << "\t "; 
            } 
            std::cout << std::endl; 
        } 
        std::cout << std::endl; 
    }
};

class TypesMethods_Gauss {

    static float ABS(const float Value) { return ( Value < 0 ? -Value : Value ); }

    static MatrixFraction ReplacementRows(MatrixFraction Matrix_Fraction, const unsigned short CountElements, const unsigned short I1, const unsigned short I2) 
    { 
        if (I1 - I2) 
        { //std::cout << "I2 = " << I2 << std::endl;
            for (unsigned short i(0); i < CountElements; i++) 
            { 
                const Fraction NewFraction = Matrix_Fraction.GetElementAt(I1, i); 
                Matrix_Fraction.SetElementAt(Matrix_Fraction.GetElementAt(I2, i), I1, i); 
                Matrix_Fraction.SetElementAt(NewFraction, I2, i); 
            } 
        } 
        return Matrix_Fraction; 
    }

    static bool CheckAccuracy(MatrixFraction Array1, MatrixFraction Array2, const unsigned short Length) 
    {
        for (unsigned short i(0); i < Length; i++) 
            if (ABS(ABS(Array1.GetElementAt(i).GetValue()) - ABS(Array2.GetElementAt(i).GetValue())) >= EPS) 
                return true; 
        return false; 
    } 

    static void UsualMethod(MatrixFraction Matrix_Fraction, const unsigned short CountRow, const unsigned short CountColumn, const unsigned short Switch = 1) 
    {
        for (unsigned short i(0); i < CountRow - 1; i++) 
        { 
            unsigned short* ArrayIndexs = new unsigned short[CountRow - i];
            for (unsigned short i11(i), i12(0); i11 < CountRow; i11++, i12++) 
                   *(ArrayIndexs + i12) = i11; 
                   Matrix_Fraction = ReplacementRows(Matrix_Fraction, CountColumn, i, Matrix_Fraction.MinMaxValueArray(ArrayIndexs, i, Switch)); 
                   Fraction NewFractionI = Matrix_Fraction.GetElementAt(i, i);
            for (unsigned short i1(i+1); i1 < CountRow; i1++) 
            { 
                Fraction NewFractionI1 = Matrix_Fraction.GetElementAt(i1, i);
                for (unsigned short i2(0); i2 < CountColumn; i2++) 
                    Matrix_Fraction.SetElementAt(Matrix_Fraction.GetElementAt(i, i2).Multiplication(NewFractionI1).Subtraction(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(NewFractionI)), i1, i2); 
            } 
            std::cout << i + 1 << " Iteration. " << std::endl; 
            Matrix_Fraction.PrintMatrix(); 
        } 
        
        MatrixFraction NewMatrixFraction(CountRow);
        for (short i1(CountRow - 1); i1 >= 0; i1--) 
        { 
            const Fraction NewFraction(Matrix_Fraction.GetElementAt(i1, CountColumn - CountRow + i1 - 1)); 
            Fraction NewFraction2(Matrix_Fraction.GetElementAt(i1, CountColumn - 1).Division(NewFraction));
            for (unsigned short i2(CountColumn - 2); i2 > i1; i2--) 
                NewFraction2.Subtraction(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(NewMatrixFraction.GetElementAt(i2)).Division(NewFraction)); 
            NewMatrixFraction.SetElementAt(NewFraction2, i1); 
            std::cout << "x" << i1 + 1 << " = "; 
            NewFraction2.PrintFraction(false); 
            std::cout << std::endl; 
        } 
    }

    static void UsualMethod_With_SelectMainElement(const MatrixFraction Matrix_Fraction, const unsigned short CountRow, const unsigned short CountColumn) 
    { 
        UsualMethod(Matrix_Fraction, CountRow, CountColumn, 2); 
    }

    static void JordanMethod(MatrixFraction Matrix_Fraction, const unsigned short CountRow, const unsigned short CountColumn) 
    {
        for (unsigned short i(0); i < CountRow; i++) 
        { 
            const Fraction NewFractionI = Matrix_Fraction.GetElementAt(i, i);
            for (unsigned short i1(0); i1 < i; i1++) 
            { 
                const Fraction NewFractionI1 = Matrix_Fraction.GetElementAt(i1, i);
                for (unsigned short i2(0); i2 < CountColumn; i2++) 
                    Matrix_Fraction.SetElementAt(Matrix_Fraction.GetElementAt(i, i2).Multiplication(NewFractionI1).Subtraction(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(NewFractionI)), i1, i2); 
            } 

            for (unsigned short i1(i+1); i1 < CountRow; i1++) 
            { 
                const Fraction NewFractionI1 = Matrix_Fraction.GetElementAt(i1, i);
                for (unsigned short i2(0); i2 < CountColumn; i2++) 
                    Matrix_Fraction.SetElementAt(Matrix_Fraction.GetElementAt(i, i2).Multiplication(NewFractionI1).Subtraction(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(NewFractionI)), i1, i2); 
            } 
            std::cout << i + 1 << " Iteration. " << std::endl; 
            Matrix_Fraction.PrintMatrix(false); 
        }
        
        for (unsigned short i(0); i < CountRow; i++) 
        { 
            Fraction NewFraction(Matrix_Fraction.GetElementAt(i, CountColumn - 1), Matrix_Fraction.GetElementAt(i, i)); 
            std::cout << "x" << i + 1 << " = "; NewFraction.PrintFraction(false); 
            std::cout << std::endl; 
        } 
    }

    static void ThomasMethod(MatrixFraction Matrix_Fraction, const unsigned short CountRow, const unsigned short CountColumn) 
    { 
        MatrixFraction ArrayP(CountRow), ArrayQ(CountRow); MatrixFraction ArrayKoef(4);
        ArrayKoef.Cin_ArrayFractionFromArray(new Fraction[4] { 0, Matrix_Fraction.GetElementAt(0, 0).Multiplication(-1), Matrix_Fraction.GetElementAt(0, 1), Matrix_Fraction.GetElementAt(0, CountColumn - 1) } );
        for (unsigned short i(1); i < CountRow - 1; i++) 
        { 
            const Fraction NewDelimiter(ArrayKoef.GetElementAt(1).Subtraction(ArrayKoef.GetElementAt(0).Multiplication(ArrayP.GetElementAt(i - 1)))); 
            ArrayP.SetElementAt(ArrayKoef.GetElementAt(2).Division(NewDelimiter), i); 
            ArrayQ.SetElementAt(ArrayKoef.GetElementAt(0).Multiplication(ArrayQ.GetElementAt(i - 1)).Subtraction(ArrayKoef.GetElementAt(3)).Division(NewDelimiter), i); 
            ArrayKoef.Cin_ArrayFractionFromArray(new Fraction[4] { Matrix_Fraction.GetElementAt(i, i - 1), Matrix_Fraction.GetElementAt(i, i).Multiplication(-1), Matrix_Fraction.GetElementAt(i, i + 1), Matrix_Fraction.GetElementAt(i, CountColumn - 1) } ); 
        }

        Fraction NewDelimiter(ArrayKoef.GetElementAt(1).Subtraction(ArrayKoef.GetElementAt(0).Multiplication(ArrayP.GetElementAt(CountRow - 2)))); 
        ArrayP.SetElementAt(ArrayKoef.GetElementAt(2).Division(NewDelimiter), CountRow - 1); 
        ArrayQ.SetElementAt((ArrayKoef.GetElementAt(0).Multiplication(ArrayQ.GetElementAt(CountRow - 2)).Subtraction(ArrayKoef.GetElementAt(3))).Division(NewDelimiter), CountRow - 1); 
        std::cout << "Array P: " << std::endl; ArrayP.PrintMatrix(false); 
        std::cout << std::endl << "Array Q: " << std::endl; ArrayQ.PrintMatrix(false); std::cout << std::endl;

        ArrayKoef.Cin_ArrayFractionFromArray(new Fraction[4] { Matrix_Fraction.GetElementAt(CountRow - 1, CountColumn - 3), Matrix_Fraction.GetElementAt(CountRow - 1, CountColumn - 2).Multiplication(-1), 0, Matrix_Fraction.GetElementAt(CountRow - 1, CountColumn - 1) } ); 
        MatrixFraction ArrayU(CountRow);
        ArrayU.SetElementAt(ArrayKoef.GetElementAt(3).Subtraction(ArrayKoef.GetElementAt(0).Multiplication(ArrayQ.GetElementAt(CountRow - 1))).Division(ArrayKoef.GetElementAt(0).Multiplication(ArrayP.GetElementAt(CountRow - 1)).Subtraction(ArrayKoef.GetElementAt(1))), CountRow - 1);
        for (short i(CountRow - 2); i > -1; i--) 
        { 
            Fraction NewFraction(ArrayU.GetElementAt(i + 1)); 
            std::cout << "x" << i + 1 << " = "; NewFraction.PrintFraction(false); std::cout << std::endl; 
            ArrayU.SetElementAt(ArrayP.GetElementAt(i + 1).Multiplication(NewFraction).Addition(ArrayQ.GetElementAt(i + 1)), i); 
        } 
        std::cout << "x0 = "; ArrayU.GetElementAt(0).PrintFraction(false); 
    }

    static void JacobiMethod(MatrixFraction Matrix_Fraction, const unsigned short CountRow, const unsigned short CountColumn) 
    { 
        MatrixFraction ArrayU(CountRow), ArrayUU(CountRow), ArrayUUU(CountRow); 
        ArrayUU.SetElementAt(Fraction(100), 0); 
        unsigned short i(0);
        while (i < 2) 
        {
            for (unsigned short i1(0); i1 < CountRow; i1++) 
            { 
                Fraction NewFraction;
                for (unsigned short i2(0); i2 < i1; i2++) 
                    NewFraction.Addition(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(ArrayU.GetElementAt(i2)));
                for (unsigned short i2(i1 + 1); i2 < CountRow; i2++) 
                    NewFraction.Addition(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(ArrayU.GetElementAt(i2))); 
                ArrayUU.SetElementAt(NewFraction.Subtraction(Matrix_Fraction.GetElementAt(i1, CountColumn - 1)).Division(Matrix_Fraction.GetElementAt(i1, i1)).Multiplication(-1), i1); 
            } 
            if (CheckAccuracy(ArrayU, ArrayUUU, CountRow)) 
            { 
                i = 0; 
                ArrayUUU = ArrayU; 
                ArrayU.PrintMatrix(false); 
            } 
            else 
                i++; 
            
            ArrayU = ArrayUU; 
            ArrayUU.ResetZeroArray(); 
        }

        for (unsigned short i(0); i < CountRow; i++) 
        { 
            std::cout << "x" << i + 1 << " = "; ArrayU.GetElementAt(i).PrintFraction(false); 
            std::cout << std::endl; 
        } 
    }

    static void SeidelMethod(MatrixFraction Matrix_Fraction, const unsigned short CountRow, const unsigned short CountColumn) 
    { 
        MatrixFraction ArrayU(CountRow), ArrayUU(CountRow); 
        ArrayUU.SetElementAt(Fraction(100), 0); 
        unsigned short i(0);
        while (i < 2) 
        {
            for (unsigned short i1(0); i1 < CountRow; i1++) 
            { 
                Fraction NewFraction;
                for (unsigned short i2(0); i2 < i1; i2++) 
                    NewFraction.Addition(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(ArrayU.GetElementAt(i2)));
                for (unsigned short i2(i1 + 1); i2 < CountRow; i2++) 
                    NewFraction.Addition(Matrix_Fraction.GetElementAt(i1, i2).Multiplication(ArrayU.GetElementAt(i2))); 
                ArrayU.SetElementAt(NewFraction.Subtraction(Matrix_Fraction.GetElementAt(i1, CountColumn - 1)).Division(Matrix_Fraction.GetElementAt(i1, i1)).Multiplication(-1), i1); 
            } 
                
            if (CheckAccuracy(ArrayU, ArrayUU, CountRow)) 
            { 
                i = 0; 
                ArrayUU = ArrayU; 
                ArrayU.PrintMatrix(false); 
            } 
            else 
                i++; 
            ArrayUU = ArrayU; 
        } 
        ArrayU.PrintMatrix(false);
        for (unsigned short i(0); i < CountRow; i++) 
        { 
            std::cout << "x" << i + 1 << " = "; ArrayU.GetElementAt(i).PrintFraction(false); 
            std::cout << std::endl; 
        } 
    }

public:
    static void SetDataUser() 
    { 
        const unsigned short N1(3), N2(4); MatrixFraction Matrix_Fraction(N1, N2); std::cout << "Your matrix: " << std::endl; Matrix_Fraction.Cin_ArrayFraction(); Matrix_Fraction.PrintMatrix(); unsigned short Switch; std::cout << "Menu. \n1 - the Gauss method; \n2 - Gauss method with selection of the main element; \n3 - the Jordan-Gauss method; \n4 - Thomas method (runs); \n5 - Jacobi method; \n6 - Seidel method. \n\nenter the command: "; std::cin >> Switch;
        switch(Switch) 
        {
            case 1: 
            { 
                UsualMethod(Matrix_Fraction, N1, N2); 
                break; 
            }
            case 2:             
            { 
                UsualMethod_With_SelectMainElement(Matrix_Fraction, N1, N2); 
                break; 
            }
            case 3: 
            { 
                JordanMethod(Matrix_Fraction, N1, N2); 
                break; 
            }
            case 4: 
            { 
                ThomasMethod(Matrix_Fraction, N1, N2); 
                break; 
            }
            case 5: 
            { 
                JacobiMethod(Matrix_Fraction, N1, N2); 
                break; 
            }
            case 6: 
                SeidelMethod(Matrix_Fraction, N1, N2); 
        } 
        std::cout << std::endl << std::endl; 
    }
};
/* x3 = Matrix_Fraction[CountRow - 1][CountColumn - 1]/Matrix_Fraction[CountRow - 1][CountColumn - 2]

x2 = (Matrix_Fraction[CountRow - 2][CountColumn - 1] - Matrix_Fraction[CountRow - 2][CountColumn - 2]*x3)/Matrix_Fraction[CountRow - 2][CountColumn - 3] =
= Matrix_Fraction[CountRow - 2][CountColumn - 1]/Matrix_Fraction[CountRow - 2][CountColumn - 3] -
- Matrix_Fraction[CountRow - 2][CountColumn - 2]*x3/Matrix_Fraction[CountRow - 2][CountColumn - 3]

x1 = (Matrix_Fraction[CountRow - 3][CountColumn - 1] - Matrix_Fraction[CountRow - 3][CountColumn - 2]*x3 - Matrix_Fraction[CountRow - 3][CountColumn - 3]*x2 )/Matrix_Fraction[CountRow - 3][CountColumn - 4] =
= Matrix_Fraction[CountRow - 3][CountColumn - 1]/Matrix_Fraction[CountRow - 3][CountColumn - 4] -
- Matrix_Fraction[CountRow - 3][CountColumn - 2]*x3/Matrix_Fraction[CountRow - 3][CountColumn - 4] -
- Matrix_Fraction[CountRow - 3][CountColumn - 3]*x2/Matrix_Fraction[CountRow - 3][CountColumn - 4]
*/

int main() 
{ 
    TypesMethods_Gauss::SetDataUser(); 
}
