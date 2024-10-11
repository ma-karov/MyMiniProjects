<?php

namespace App\Http\Requests\ApiSoliditySecret;

class RegistrationUsers_BaseParent_FormRequest extends \Illuminate\Foundation\Http\FormRequest
{
    private function SpecialCharsStringBool(string $SpecialCharsString): bool
    {
        $SpecialCharsString .= "\0";
        for ($i = 1, $Char = $SpecialCharsString[0]; $Char <> "\0"; $Char = $SpecialCharsString[$i++] )
            foreach ( [ ",", ":", "{", "}" ] as $SpecialChar)
                if ($Char == $SpecialChar)
                    return true;
        return false;
    }

    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array
     */
    public function rules()
    {
        return [
            //
        ];
    }

    // Присланную строку запроса преобразуем в массив
    protected function FormatingFieldsToArray(string $StringJSON): array
    {
        $StringJSON .= "\0";
        $ArrayFormatingFieldsForm = array(); $ArrayFormatingFieldsFormIndex = 1;
        $BracketsBetweenBool = false;
        for ($i = 1, $Char = $StringJSON[0], $NewString = ""; $Char <> "\0"; $Char = $StringJSON[$i++] )
        {
            if ($Char == "\"")
                $BracketsBetweenBool = !$BracketsBetweenBool;
            elseif ($BracketsBetweenBool)
                $NewString .= $Char;
            elseif ($NewString)
            {
                $ArrayFormatingFieldsForm[$ArrayFormatingFieldsFormIndex++] = $NewString;
                $NewString = "";
            }
        }

        $ArrayFormatingFieldsForm[0] = $ArrayFormatingFieldsFormIndex;
        return $ArrayFormatingFieldsForm;
    }

}
