<?php 

namespace App\Http\Requests; 

use Illuminate\Foundation\Http\FormRequest; 

class HomeResponseRequest extends FormRequest 
{ 
    function authorize() 
    { 
        return true; 
    } 

    function rules() 
    { 
        return [ 
            "Name" => "required", 
            "Telephone" => "required|regex:/\+7[\(]\d{3}[\)]\d{3}\-\d{2}\-\d{2}/", 
            "Order" => "required" 
     ]; //[ "EmailAddress" => "required", "Telephone" => "required", "Order" => "required" ];  
    }
    

}


?> 
