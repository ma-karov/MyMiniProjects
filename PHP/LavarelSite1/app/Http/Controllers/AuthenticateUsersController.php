<?php

namespace App\Http\Controllers;

class AuthenticateUsersController extends Controller
{

    function SignUp(\Illuminate\Http\Request $HttpRequest): \Illuminate\View\View
    {
        return view("AuthenticateUsers.SignUp");
    }

    function PrivateAccount(\App\Http\Requests\AuthenticateUsers\PrivateAccountFormRequest $HttpFormRequest): \Illuminate\View\View
    {
        return view("AuthenticateUsers.PrivateAccount");
    }
}
