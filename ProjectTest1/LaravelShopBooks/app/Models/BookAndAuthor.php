<?php

namespace App\Models;

class BookAndAuthor extends \Illuminate\Database\Eloquent\Model
{
    protected $table = 'books_and_authors',
    $fillable = array
    (
        'book_id',
        'author_id'
    );
}
