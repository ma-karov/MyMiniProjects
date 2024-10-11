<?php

namespace App\Http\Middleware;

class CORS_MiddleWare
{
    function handle(\Illuminate\Http\Request $HttpRequest, \Closure $ClosureController)
    {
        return $ClosureController($HttpRequest)->header("Access-Control-Allow-Origin", "*")
                ->header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS ")
                ->header('Access-Control-Allow-Headers', 'Accept, Authorization, Content-Type');
    }
}
