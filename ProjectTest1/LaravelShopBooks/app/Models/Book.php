<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Book extends Model
{
    use HasFactory;

    protected $casts = array
        (
            #'authors' => 'json',
            #'genres' => 'json',
        ),
    $fillable = array
    (
        'appellation', 'year' #, 'authors', 'genres'
    );


}
