<?php

namespace App\Http\CustomFiles\Mocks;

class AuthorsMock
{
    function getAuthors(): array
    {
        return array
        (
            array
            (
                "name" => "Автор1",
                "birth_day" => "1794-09-12"
            ),
            array
            (
                "name" => "Автор2",
                "birth_day" => "1905-02-09"
            ),
            array
            (
                "name" => "Автор3",
                "birth_day" => "1905-02-09"
            ),
        );
    }
}
