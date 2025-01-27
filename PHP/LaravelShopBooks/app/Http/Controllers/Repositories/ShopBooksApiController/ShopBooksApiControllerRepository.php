<?php

namespace App\Http\Controllers\Repositories\ShopBooksApiController;

class ShopBooksApiControllerRepository implements InterfaceShopBooksApiControllerRepository
{
    private function findID_ByGenre($collection, string $genreAppellation)
    {
        define('GENRE_ID', \App\Models\Genre::where('appellation', '=', $genreAppellation)
            ->select("id")->get()->first()->getAttributeValue("id"));

        #dd($collection->where('genres', '=', '[' . GENRE_ID . ']')->orWhere('genres', 'Like', '%, ' . GENRE_ID . ']')->orWhere('genres', 'Like', '%' . GENRE_ID . ',%')->get());
        return $collection->where('genres', '=', '[' . GENRE_ID . ']')->orWhere('genres', 'Like', '%, ' . GENRE_ID . ']')->orWhere('genres', 'Like', '%' . GENRE_ID . ',%');
    }

    private function getAuthorsUniqueID_ByArrayBooks(\Illuminate\Database\Eloquent\Collection $collectionBooks): array
    {
        $arrayIDS = array(); $arrayIDS_Length = 0;
        foreach ($collectionBooks as $book)
            foreach (json_decode($book->getAttributeValue("authors")) as $authorID)
            {
                foreach ($arrayIDS as $ID)
                    if ($ID == $authorID)
                        goto LABEL_BREAK;

                $arrayIDS[$arrayIDS_Length++] = $authorID;

                LABEL_BREAK:
            }

        return $arrayIDS;
    }

    function getGroupByBookIDS_AllSells(\Illuminate\Database\Eloquent\Collection $collectionSells): array
    {
        $arraySells = array();
        $arrayBookIDS = array(); $arrayBookIDS_Length = 0;
        foreach ($collectionSells as $sell):
            $arrayBookIDS[$arrayBookIDS_Length] = $sell->getAttributeValue("book_id");
            $arraySells[$arrayBookIDS_Length] = array
            (
                'date' => \App\Models\Sell::where(array
                    (
                        array( 'book_id', '=', $arrayBookIDS[$arrayBookIDS_Length] ),
                        array( 'count', '=', $sell->getAttributeValue("MaxCount") )
                    ) )->select('date')->get()->first()['date'],
                'book_id' => $sell->getAttributeValue('book_id'),
                'MaxCount' => $sell->getAttributeValue('MaxCount')
            );
            $arrayBookIDS_Length++;

        endforeach;

        return array( $arraySells, $arrayBookIDS );
    }

    function getPopulateAuthors(array $arrayValidatedParameters): array
    {
        $collectionBooks = \App\Models\Book::whereBetween("year", array($arrayValidatedParameters['date_from'], $arrayValidatedParameters['date_to']) );
        if (isset($arrayValidatedParameters['genre_appellation']))
            $collectionBooks = $this->findID_ByGenre($collectionBooks, $arrayValidatedParameters['genre_appellation']);

        $collectionBooks = $collectionBooks->leftJoin('sells', 'books.id', '=', 'sells.book_id')
            ->select( array( "books.id", "books.authors", "sells.count" ) )
            ->take($arrayValidatedParameters['limit'])->get(); #->toArray();


        $arrayAuthors = \App\Models\Author::whereIn("id", $this->getAuthorsUniqueID_ByArrayBooks($collectionBooks))
            ->select( array( "name", "birth_day") )->get()->toArray();

        $arrayAuthors_Length = 0;
        foreach ($collectionBooks as $book)
            $arrayAuthors[$arrayAuthors_Length++]["count"] = $book->getAttributeValue("count");

        return $arrayAuthors;
    }

    function getPopulateBooks(array $arrayValidatedParameters): array
    {
        $collectionSells = \App\Models\Sell::whereBetween("date", array( new \DateTime($arrayValidatedParameters['date_from'] . '-1-1'), new \DateTime($arrayValidatedParameters['date_to'] . '-1-1') ) );

        if (isset($arrayValidatedParameters['genre_appellation']))
            $collectionSells = $collectionSells->whereIn('book_id', function ($builder) use ($arrayValidatedParameters)
            {
                $this->findID_ByGenre($builder->select('id')->from('books'), $arrayValidatedParameters['genre_appellation']);
            } );

        $arrayGroupByBookIDS_AllSells = $this->getGroupByBookIDS_AllSells(
            $collectionSells->select(\Illuminate\Support\Facades\DB::raw("Max(count) As MaxCount, book_id ") )
                ->groupBy('book_id')->take($arrayValidatedParameters['limit'])
                ->get());

        $arrayBookIDS_Length = 0;
        foreach (\App\Models\Book::whereIn('id', $arrayGroupByBookIDS_AllSells[1] )->get() as $book):
            $arrayGroupByBookIDS_AllSells[0][$arrayBookIDS_Length]['appellation'] = $book->getAttributeValue("appellation");
            $arrayGroupByBookIDS_AllSells[0][$arrayBookIDS_Length]['year'] = $book->getAttributeValue("year");
            $arrayGroupByBookIDS_AllSells[0][$arrayBookIDS_Length]['genres'] = $book->getAttributeValue("genres");
            $arrayGroupByBookIDS_AllSells[0][$arrayBookIDS_Length]['authors'] = $book->getAttributeValue("authors");
            $arrayBookIDS_Length++;
        endforeach;

        return $arrayGroupByBookIDS_AllSells[0];
    }
}

