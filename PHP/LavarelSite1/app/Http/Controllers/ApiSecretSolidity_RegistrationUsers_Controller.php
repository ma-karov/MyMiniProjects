<?php

namespace App\Http\Controllers;


class ApiSecretSolidity_RegistrationUsers_Controller extends Controller
{
    private $NewApiSecretSolidity_RegistrationUsers_ControllerRepository;
    function __construct()
    {
        $this->NewApiSecretSolidity_RegistrationUsers_ControllerRepository = new \App\Http\Controllers\Repositories\ApiSecretSolidity_RegistrationUsers_ControllerRepository();
    }
    function GetAllRegistrationUsers(\Illuminate\Http\Request $Request): array
    {
        return $this->NewApiSecretSolidity_RegistrationUsers_ControllerRepository->GetAllRegistrationUsers();
    }
    function CreateUser(\App\Http\Requests\ApiSoliditySecret\RegistrationUsers_CreateUser_FormRequest $HttpFormRequest): array
    {
        //return [ "HttpRequest" => $HttpFormRequest];
        return $this->NewApiSecretSolidity_RegistrationUsers_ControllerRepository
            ->CreateUser($HttpFormRequest->post("CreateUser"));
    }
    function FindUser(\App\Http\Requests\ApiSoliditySecret\RegistrationUsers_FindUser_FormRequest $HttpFormRequest): array
    {
        return $this->NewApiSecretSolidity_RegistrationUsers_ControllerRepository
            ->FindUser($HttpFormRequest->post("FindUser"));
    }

}

