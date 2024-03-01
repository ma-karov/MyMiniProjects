<?php 

namespace App\Http\Controllers; 

use Illuminate\Http\Request; 
use App\Http\Requests\HomeIndexRequest; 
use App\Http\Requests\HomeResponseRequest; 

class HomeController extends Controller 
{ 
    //function __construct() {}

    function Index(HomeIndexRequest $Request) 
    { 
        //if ($Request->isMethod("post")) 
        /*$response = ( new \GuzzleHttp\Client() )->get('https://fakerapi.it/api/v1/books', [ 
            'headers' => [
                'Content-Type' => 'application/json' 
            ] 
        ] ); */

        //dd($response->getBody()->getContents()); 
        
        return view("Home.Index");
    } 

    /* 
    [ 
                'stream_code'   => 'iu244',
            'client'        => [ 
                'name'      => 'Nikita',
                'phone'     => '+7(777)777-77-77' 
            ],
            'sub1'      => 'test' ] 
            */

    function Response(HomeResponseRequest $Request) 
    { 
        //$Request->session()->put("Telephone", '$TELEPHONE'); 
        //dd($Request->session()); 
        try 
        { 
            define('REQUEST_INPUT_TELEPHONE', $Request->input("Telephone")); 
            $TELEPHONE = $Request->session()->get("Telephone".REQUEST_INPUT_TELEPHONE); 
            if (!$TELEPHONE) 
            { 
                $Request->session()->put("Telephone".REQUEST_INPUT_TELEPHONE, REQUEST_INPUT_TELEPHONE); 
                ( new \GuzzleHttp\Client() )->post('https://order.drcash.sh/v1/order', [ 
                    'headers' => [
                        'Content-Type' => 'application/json',
                        'Authorization' => 'Bearer NWJLZGEWOWETNTGZMS00MZK4LWFIZJUTNJVMOTG0NJQXOTI3' 
                    ], 
                    'body' => '{ "stream_code": "iu244", "client": { "name": "'.$Request->input("Name").'", "phone": "'.REQUEST_INPUT_TELEPHONE.'" }, "sub1": "'.$Request->input("InputHidden").'" }'  
                ] ); 
                return "Thank you for order"; 
            } 
            return "Error. You have already placed an order"; 
        } 
        catch (\GuzzleHttp\Exception\RequestException $e) 
        { 
            return "Error"; 
        }
    }
}

/* 

https://order.drcash.sh/v1/order

Заголовок запроса:
[
    'Content-Type: application/json',
    'Authorization: Bearer     NWJLZGEWOWETNTGZMS00MZK4LWFIZJUTNJVMOTG0NJQXOTI3',
]

Тело:
[
    'stream_code'   => 'iu244',
    'client'        => [
        'name'      => Имя с формы,
        'phone'     => Номер телефона с формы,
    ],
    'sub1'      => Значение с формы, из скрытого поля,     со значением test,
]

*/

?> 
