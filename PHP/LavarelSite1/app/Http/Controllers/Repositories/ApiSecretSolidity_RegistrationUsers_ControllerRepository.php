<?php

namespace App\Http\Controllers\Repositories;

class ApiSecretSolidity_RegistrationUsers_ControllerRepository
{
    private const ANSWER_FROM_DATABASE_NOT_FOUND_KEY = "Not Found Key In DataBase";
    private function DeleteUnnecessaryChars(string $StringAnswerCommand)
    {
        $StringAnswerCommand .= "\0";
        $NewStringAnswerCommand = "";
        for ($i = 1, $Char = $StringAnswerCommand[0]; $Char <> PHP_EOL[0] and $Char <> "\0"; $Char = $StringAnswerCommand[$i++] ) // foreach (str_split($StringAnswerCommand) as $Char)
            $NewStringAnswerCommand .= $Char;
        return $NewStringAnswerCommand;
    }

    function __construct() {}

    function GetAllRegistrationUsers(): array
    {
        \Artisan::call("MemoryCasheDataBase:PrintValues");
        define("COMMAND_PRINT_VALUES_OUTPUT2", \Artisan::output());
        $ArrayCommandPrintValuesOutput = array(); $ArrayCommandPrintValuesOutputIndex = 0;
        $String = COMMAND_PRINT_VALUES_OUTPUT2."\0";

        $NewString = "";
        for ($Char = $String[0], $i = 1; $Char <> "\0"; $Char = $String[$i])
            if ($Char <> "\n")
                $NewString .= $Char;
            elseif ($NewString)
            {
                $ArrayCommandPrintValuesOutput[$ArrayCommandPrintValuesOutputIndex++] = $NewString;
                $NewString = "";
            }
        return [ "Answer" => [ COMMAND_PRINT_VALUES_OUTPUT2, $this->DeleteUnnecessaryChars(COMMAND_PRINT_VALUES_OUTPUT2) ] ];
    }

    // MemoryCasheDataBase_Client.exe Add "ma-kar-ov@yandex.ru" "{ `UserName` : `Nikita`, `EmailAddress` : `ma-kar-ov@yandex.ru`, `Password` : `2001n`, }"
    // MemoryCasheDataBase_Client.exe Add "ma-kar-ov@yandex.ru" "{ \"UserName\": \"Nikita\", \"EmailAddress\": \"ma-kar-ov@yandex.ru\", \"Password\": \"2001n\", }"

    function CreateUser(\App\Http\Forms\ApiSoliditySecret\RegistrationUsers_JobWithFormatingUser_Form $Form): array
    { //$StreamOutput = fopen("php://output", "w");
        //return [ "Key" => $Form->GetField("EmailAddress"), "Value" => $Form->ConvertDictionaryToString() ];

        \Artisan::call("MemoryCasheDataBase:AddValue", [ "Key" => $Form->GetField("EmailAddress"), "Value" => $Form->ConvertDictionaryToString() ] );
        return [ "Answer" => $this->DeleteUnnecessaryChars( \Artisan::output()."" ) ];
    }

    function FindUser(\App\Http\Forms\ApiSoliditySecret\RegistrationUsers_JobWithFormatingUser_Form $Form): array
    {
        \Artisan::call("MemoryCasheDataBase:GetValue", [ "Key" => $Form->GetField("EmailAddress") ] );
        define("ANSWER_FROM_DATABASE", $this->DeleteUnnecessaryChars( \Artisan::output()."" ) );
        return ( ANSWER_FROM_DATABASE == self::ANSWER_FROM_DATABASE_NOT_FOUND_KEY ? [ "Error" => ANSWER_FROM_DATABASE ] : [ "Answer" => $Form->ConvertStringToDictionary(ANSWER_FROM_DATABASE) ] );
    }

}


