<?php

namespace App\Http\CustomFiles\Mocks;

class SellsMock
{
    function getSells(): array
    {
        return array
        (
            array
            (
                "date" => new \DateTime() ,
                "count" => "10",
                "book_id" => "1"
            ),
            array
            (
                "date" => new \DateTime() ,
                "count" => "4",
                "book_id" => "2"
            )
        );
    }
}

