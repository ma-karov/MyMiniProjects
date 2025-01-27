<?php

namespace App\Http\CustomFiles\Mocks;

class GenresMock
{
    function getGenres(): array
    {
        return array
        (
            array
            (
                "appellation" => "Название"
            ),
            array
            (
                "appellation" => "Название2",
            ),
            array
            (
                "appellation" => "Название3"
            ),
        );
    }
}
