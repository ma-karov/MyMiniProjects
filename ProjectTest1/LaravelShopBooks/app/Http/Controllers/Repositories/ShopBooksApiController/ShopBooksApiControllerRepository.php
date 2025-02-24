<?php

namespace App\Http\Controllers\Repositories\ShopBooksApiController;

class ShopBooksApiControllerRepository implements InterfaceShopBooksApiControllerRepository
{
    private function notEqualArrayLength(array $array1, array $array2): bool
    {
        return ( count($array1) - count($array2) );
    }

    function getPopulateAuthors(array $arrayValidatedParameters): array
    {
        return (
            isset($arrayValidatedParameters['genre_appellation']) ?
                \Illuminate\Support\Facades\DB::select("
                    Select
                        ( Select name From authors Where id = authorID ) As author_name,
                        ( Select birth_day From authors Where id = authorID ) As author_birth_day,
                        summa_purchases From ( Select authors.id As authorID, Sum(sells.count) As summa_purchases
                    From books
                    Inner Join sells On books.id = book_id
                    Inner Join books_and_authors On books.id = books_and_authors.book_id
                    Inner Join authors On authors.id = books_and_authors.author_id

                    Where sells.date Between :BOOKS_DATE_BEGIN And :BOOKS_DATE_END
                        And books.id In (
                                            Select book_id From books_and_genres
                                            Inner Join genres On genres.id = genre_id
                                            Where genres.appellation = :GENRE_APPELLATION
                                        )
                    Group By authors.id
                    Order By summa_purchases Desc
                    ) As table1
                    Limit :LIMIT",
                    array
                    (
                        ":BOOKS_DATE_BEGIN" => $arrayValidatedParameters['date_from'],
                        ":BOOKS_DATE_END" => $arrayValidatedParameters['date_to'],
                        ":GENRE_APPELLATION" => $arrayValidatedParameters['genre_appellation'],
                        ":LIMIT" => $arrayValidatedParameters['limit']
                    )
                ) :
                \Illuminate\Support\Facades\DB::select("
                    Select
                        ( Select name From authors Where id = authorID ) As author_name,
                        ( Select birth_day From authors Where id = authorID ) As author_birth_day,
                        summa_purchases
                    From (
                        Select authors.id As authorID, Sum(sells.count) As summa_purchases
                        From books
                        Inner Join sells On books.id = book_id
                        Inner Join books_and_authors On books.id = books_and_authors.book_id
                        Inner Join authors on books_and_authors.author_id = authors.id
                        Where sells.date Between :BOOKS_DATE_BEGIN And :BOOKS_DATE_END
                        Group By authorID
                        Order By summa_purchases Desc
                    ) As table1
                    Limit :LIMIT",
                    array
                    (
                        ":BOOKS_DATE_BEGIN" => $arrayValidatedParameters['date_from'],
                        ":BOOKS_DATE_END" => $arrayValidatedParameters['date_to'],
                        ":LIMIT" => $arrayValidatedParameters['limit']
                    )
                )
        );
    }

    function getPopulateBooks(array $arrayValidatedParameters): array
    {
        $arrayPopulateBooks = ( isset($arrayValidatedParameters['genre_appellation']) ?
            \Illuminate\Support\Facades\DB::select("
                Select Distinct
                    ( Select appellation From books Where id = BookID ) As book_appellation,
                    ( Select year From books Where id = BookID ) As book_year,
                    authors_name,
                    genres_appellation,
                    date,
                    max_purchase

                From (
                    Select
                        BookID,
                        GROUP_CONCAT(Distinct authors.name) As authors_name,
                        GROUP_CONCAT(Distinct genres.appellation) As genres_appellation,
                        max_purchase From (
                            Select book_id As BookID,
                            Max(count) As max_purchase
                            From sells
                            Group By book_id
                        ) As table1
                    Inner Join books on books.id = BookID

                    Inner Join books_and_authors On BookID = books_and_authors.book_id
                    Inner Join authors On books_and_authors.author_id = authors.id

                    Inner Join books_and_genres On BookID = books_and_genres.book_id
                    Inner Join genres On books_and_genres.genre_id = genres.id

                    Where genres.appellation = :GENRE_APPELLATION

                    group by BookID, max_purchase
                ) As table2
                Inner Join sells On sells.book_id = BookID

                Where date Between :BOOKS_DATE_BEGIN And :BOOKS_DATE_END
                Limit :LIMIT",
                array
                (
                    ":GENRE_APPELLATION" => $arrayValidatedParameters['genre_appellation'],
                    ":BOOKS_DATE_BEGIN" => $arrayValidatedParameters['date_from'],
                    ":BOOKS_DATE_END" => $arrayValidatedParameters['date_to'],
                    ":LIMIT" => $arrayValidatedParameters['limit']
                )
            )

            : \Illuminate\Support\Facades\DB::select("
                Select Distinct
                    ( Select appellation From books Where id = BookID ) As book_appellation,
                    ( Select year From books Where id = BookID ) As book_year,
                    authors_name,
                    genres_appellation,
                    date,
                    max_purchase

                From (
                    Select
                        BookID,
                        GROUP_CONCAT(Distinct authors.name) As authors_name,
                        GROUP_CONCAT(Distinct genres.appellation) As genres_appellation,
                        max_purchase From (
                            Select book_id As BookID,
                            Max(count) As max_purchase
                            From sells
                            Group By book_id
                        ) As table1
                    Inner Join books on books.id = BookID

                    Inner Join books_and_authors On BookID = books_and_authors.book_id
                    Inner Join authors On books_and_authors.author_id = authors.id

                    Inner Join books_and_genres On BookID = books_and_genres.book_id
                    Inner Join genres On books_and_genres.genre_id = genres.id

                    group by BookID, max_purchase
                ) As table2
                Inner Join sells On sells.book_id = BookID

                Where date Between :BOOKS_DATE_BEGIN And :BOOKS_DATE_END
                Limit :LIMIT",
                array
                (
                    ":BOOKS_DATE_BEGIN" => $arrayValidatedParameters['date_from'],
                    ":BOOKS_DATE_END" => $arrayValidatedParameters['date_to'],
                    ":LIMIT" => $arrayValidatedParameters['limit']
                )
            )
        );

        $i = 0;
        foreach ($arrayPopulateBooks as $populateBook):
            $arrayPopulateBooks[$i]->authors_name = explode(',', $populateBook->authors_name);
            $arrayPopulateBooks[$i]->genres_appellation = explode(',', $populateBook->genres_appellation);
            $i++;
        endforeach;

        return $arrayPopulateBooks;
    }

    function addBook(array $arrayValidatedParameters): array
    {
        $arrayAuthorsName = \App\Models\Author::whereIn('id', $arrayValidatedParameters['authors'])->select("name")->get()->toArray();
        if ($this->notEqualArrayLength($arrayAuthorsName, $arrayValidatedParameters['authors']))
            return array( "error" => "" );

        $arrayGenresAppellation = \App\Models\Genre::whereIn('id', $arrayValidatedParameters['genres'])->select('appellation')->get()->toArray();
        if ($this->notEqualArrayLength($arrayGenresAppellation, $arrayValidatedParameters['genres']))
            return array( "error" => "" );

        $newBook = \App\Models\Book::create(
            array
            (
                "appellation" => $arrayValidatedParameters["appellation"],
                "year" => $arrayValidatedParameters['year']
            )
        );

        define('NEW_BOOK_ID', $newBook->getAttributeValue('id'));

        foreach ($arrayValidatedParameters['authors'] as $authorID)
            foreach ($arrayValidatedParameters['genres'] as $genreID):
                \App\Models\BookAndAuthor::insert(
                    array
                    (
                        "book_id" => NEW_BOOK_ID,
                        'author_id' => $authorID
                    )
                );

                \App\Models\BookAndGenre::insert(
                    array
                    (
                        "book_id" => NEW_BOOK_ID,
                        'genre_id' => $genreID
                    )
                );
            endforeach;

        return array
        (
            'book_id' => NEW_BOOK_ID,
            'book_appellation' => $arrayValidatedParameters["appellation"],
            'year' => $arrayValidatedParameters['year'],
            'authors_name' => $arrayAuthorsName,
            'genres_appellation' => $arrayGenresAppellation
        );
    }
}
