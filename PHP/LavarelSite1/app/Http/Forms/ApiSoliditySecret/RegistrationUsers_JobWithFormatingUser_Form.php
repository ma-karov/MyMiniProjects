<?php

namespace App\Http\Forms\ApiSoliditySecret;

class RegistrationUsers_JobWithFormatingUser_Form
{
    public $ArrayDictionaryFields = array();

    private function SpecialCharsStringBool(string $SpecialCharsString): bool
    {
        $SpecialCharsString .= "\0";
        for ($i = 1, $Char = $SpecialCharsString[0]; $Char <> "\0"; $Char = $SpecialCharsString[$i++] )
            foreach ( [ ",", ":", "{", "}" ] as $SpecialChar)
                if ($Char == $SpecialChar)
                    return true;
        return false;
    }

    private static function ConvertArrayToDictionary(array $ArrayFieldsForm): array
    {
        $ArrayFormatingFieldsForm = array();
        for ($i = 2; $i < $ArrayFieldsForm[0]; $i += 2)
            $ArrayFormatingFieldsForm[$ArrayFieldsForm[$i - 1]] = $ArrayFieldsForm[$i];
        return $ArrayFormatingFieldsForm;
    }

    function __construct(array $ArrayFormatingFieldsForm)
    {
        $this->ArrayDictionaryFields = self::ConvertArrayToDictionary($ArrayFormatingFieldsForm);
    }

    function GetField(string $StringField): string
    {
        return $this->ArrayDictionaryFields[$StringField];
    }

    function ConvertDictionaryToString(): string
    {
        $StringObject = "";
        foreach($this->ArrayDictionaryFields as $Key => $Value)
            $StringObject .= "\"$Key\": \"$Value\", ";
        return "{ $StringObject}";
    }

    function ConvertStringToDictionary(string $StringJSON): array
    {
        $StringJSON .= "\0";
        $ArrayDictionaryFields = array();
        $ArrayDictionaryFieldsLength = 0;
        $BracketsBetweenBool = false;
        for ($i = 1, $Char = $StringJSON[0], $NewString = ""; $Char <> "\0"; $Char = $StringJSON[$i++])
        {
            if ($Char == "\"")
                $BracketsBetweenBool = !$BracketsBetweenBool;
            elseif ($BracketsBetweenBool)
                $NewString .= $Char;
            elseif ($NewString)
            {
                $ArrayDictionaryFields[$ArrayDictionaryFieldsLength++] = $NewString;
                $NewString = "";
            }
        }

        $ArrayDictionaryFields[0] = $ArrayDictionaryFieldsLength;

        /*$this->ArrayDictionaryFields = array();
        for ($i = 1; $i < $ArrayDictionaryFieldsLength; $i += 2)
            $this->ArrayDictionaryFields[$ArrayDictionaryFields[$i - 1]] = $ArrayDictionaryFields[$i];*/

        $this->ArrayDictionaryFields = self::ConvertArrayToDictionary($ArrayDictionaryFields);
        return $this->ArrayDictionaryFields;
    }

}
