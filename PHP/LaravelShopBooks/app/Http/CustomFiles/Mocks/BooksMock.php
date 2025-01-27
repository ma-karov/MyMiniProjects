<?php

namespace App\Http\CustomFiles\Mocks;

class BooksMock
{
    function getBooks(): array
    {
       return array
       (
           array
           (
               "appellation" => "Название",
               "year" => 1924,
               "authors" => "[1, 3, 2]",
               "genres" => "[3, 1]"
           ),
           array
           (
               "appellation" => "Название2",
               "year" => 1824,
               "authors" => "[3, 2]",
               "genres" => "[3, 1]"
           ),
           array
           (
               "appellation" => "Название3",
               "year" => 1924,
               "authors" => "[1]",
               "genres" => "[2]"
           ),
       );
    }
}
