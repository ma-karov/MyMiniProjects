<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Auth;

class AuthController extends Controller
{
    public function login()
    {
        if (!empty(Auth::check())) {
            if (Auth::user()->usertype == 1) {
                return redirect('admin/dashboard');
            }
            elseif (Auth::user()->usertype == 2) {
                return redirect('teacher/dashboard');
            }
            elseif (Auth::user()->usertype == 3) {
                return redirect('student/dashboard');
            }
        }
        // dd(Hash::make(123456));
        return view('auth.login');
    }

    public function Authlogin(Request $request)
    {
        // dd($request->all());

        $remember = !empty($request->remember) ? true : false;

        if (Auth::attempt(['email' => $request->email, 'password' => $request->password], $remember)) {
            if (Auth::user()->usertype == 1) {
                return redirect('admin/dashboard');
            }
            elseif (Auth::user()->usertype == 2) {
                return redirect('teacher/dashboard');
            }
            elseif (Auth::user()->usertype == 3) {
                return redirect('student/dashboard');
            }
        } else {
            return redirect()->back()->with('error', 'Please enter correct email and password');
        }
    }

    public function logout()
    {
        Auth::logout();
        return redirect(url(''));
    }
}
