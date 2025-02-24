<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

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

#Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
Route::get('/user', function (Request $request) {
    return $request->user();
});

Route::group( array
(
    "middleware" => "App\\Http\\Middleware\\CORS_MiddleWare"
),
    function(Illuminate\Routing\Router $router)
{
    #Route::get('/GetPopulateAuthors', 'ShopBooksApiController@getPopulateAuthors');
    $router->get('/GetPopulateAuthors', array( "App\\Http\\Controllers\\ShopBooksApiController", 'getPopulateAuthors') );
    $router->get('/GetPopulateBooks', array( "App\\Http\\Controllers\\ShopBooksApiController", 'getPopulateBooks') );

    $router->post('/AddBook', array( "App\\Http\\Controllers\\ShopBooksApiController", 'addBook') );
} );

