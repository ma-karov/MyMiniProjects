<?php

//use Illuminate\Http\Request;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

//Route::middleware('auth:api')->get('/user', function (Request $request) {
//    return $request->user();
//});

Illuminate\Support\Facades\Route::get('company', 'CompanyController@index');
Illuminate\Support\Facades\Route::get('company/{id}', 'CompanyController@show');
Illuminate\Support\Facades\Route::post('company/delete/{id}', 'CompanyController@delete');
Illuminate\Support\Facades\Route::post('depart/search-by-name', 'DepartController@searchByName');
Illuminate\Support\Facades\Route::post('depart/create', 'DepartController@create');
Illuminate\Support\Facades\Route::post('employee/update', 'EmployeeController@update');
Illuminate\Support\Facades\Route::get('employee/get-depart', 'EmployeeController@getDepartEmployees');
