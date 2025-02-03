<?php

namespace App\Http\CustomFiles\Mocks;

class BooksAndGenresMock
{
    function getBooksAndGenres(): array
    {
        return array
        (
            array
            (
                "book_id" => 1,
                "genre_id" => 3 # "[3, 1]"
            ),
            array
            (
                "book_id" => 1,
                "genre_id" => 1 # "[3, 1]"
            ),
            array
            (
                "book_id" => 2,
                "genre_id" => 3 # "[3, 1]"
            ),
            array
            (
                "book_id" => 2,
                "genre_id" => 1 # "[3, 1]"
            ),
            array
            (
                "book_id" => 3,
                "genre_id" => 2
            )
        );
    }
}
