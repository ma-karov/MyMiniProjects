<?php

namespace App\Models;

class BookAndGenre extends \Illuminate\Database\Eloquent\Model
{
    protected $table = 'books_and_genres',
    $fillable = array
    (
        'book_id',
        'genre_id'
    );
}
