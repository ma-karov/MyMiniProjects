<?php 

namespace App\Http\Requests; 

use Illuminate\Foundation\Http\FormRequest; 

class HomeIndexRequest extends FormRequest 
{ 
    function authorize() 
    { 
        return true; 
    } 

    function rules() 
    { 
        return array(); //[ "EmailAddress" => "required", "Telephone" => "required", "Order" => "required" ];  
    }
    

}


?> 