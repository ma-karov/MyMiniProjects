<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateTableBooksAndGenres extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('books_and_genres', function (Blueprint $table) {
            $table->unsignedBigInteger('book_id');
            $table->foreign('book_id')->references('id')->on('books')->onDelete('cascade');

            $table->unsignedBigInteger('genre_id');
            $table->foreign('genre_id')->references('id')->on('genres')->onDelete('cascade');
        });

        Schema::table('books', function (Blueprint $table) {
            $table->dropColumn('genre_id');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('books_and_genres');

        Schema::table('books', function (Blueprint $table) {
            $table->unsignedBigInteger('genre_id');
            $table->foreign('genre_id')->references('id')->on('genres')->onDelete('set null');
        });
    }
}
