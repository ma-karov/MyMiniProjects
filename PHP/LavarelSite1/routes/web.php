<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/ 

use App\Http\Controllers\HomeController;

/*Route::get('/', function () {
    return view('welcome');
}); */

/*Route::get('/', function () {
    return view('Home.Index');
}); */ 

Route::get("Home", "HomeController@Index" )->name("Home-Index");  

Route::post("Home/Response", "HomeController@Response" )->name("Home-Response"); 