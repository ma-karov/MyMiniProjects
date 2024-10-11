<?php

Route::group( [ "middleware" => App\Http\Middleware\CORS_MiddleWare::class ], function(Illuminate\Routing\Router $Router)
{
    $Router->get("ApiSecretSolidity/RegistrationUsers/", "ApiSecretSolidity_RegistrationUsers_Controller@GetAllRegistrationUsers" )->name("ApiSecretSolidity-RegistrationUsers-GetAllRegistrationUsers");
    $Router->post("ApiSecretSolidity/RegistrationUsers/CreateUser", "ApiSecretSolidity_RegistrationUsers_Controller@CreateUser" );
    $Router->post("ApiSecretSolidity/RegistrationUsers/FindUser", "ApiSecretSolidity_RegistrationUsers_Controller@FindUser" );
    $Router->post("ApiSecretSolidity/RegistrationUsers/DeleteUser", "ApiSecretSolidity_RegistrationUsers_Controller@DeleteUser" );
} );

//Route::get("ApiSecretSolidity/RegistrationUsers/CreateUser", "ApiSecretSolidity_RegistrationUsers_Controller@CreateUser" )
//->middleware("CORS_MiddleWare")->name("ApiSecretSolidity-RegistrationUsers-CreateUser");


