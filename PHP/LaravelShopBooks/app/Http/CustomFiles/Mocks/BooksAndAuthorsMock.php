<?php

namespace App\Http\CustomFiles\Mocks;

class BooksAndAuthorsMock
{
    function getBooksAndAuthors(): array
    {
        return array
        (
            array
            (
                "book_id" => 1,
                "author_id" => 1
            ),
            array
            (
                "book_id" => 1,
                "author_id" => 3
            ),
            array
            (
                "book_id" => 1,
                "author_id" => 2
            ),
            array
            (
                "book_id" => 2,
                "author_id" => 3
            ),
            array
            (
                "book_id" => 2,
                "author_id" => 2
            ),
            array
            (
                "book_id" => 3,
                "author_id" => 1
            )
        );
    }
}
