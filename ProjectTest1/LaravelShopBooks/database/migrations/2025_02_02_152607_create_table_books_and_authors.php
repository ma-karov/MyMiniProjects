<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateTableBooksAndAuthors extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('books_and_authors', function (Blueprint $table) {
            $table->unsignedBigInteger('book_id');
            $table->foreign('book_id')->references('id')->on('books')->onDelete('cascade');

            $table->unsignedBigInteger('author_id');
            $table->foreign('author_id')->references('id')->on('authors')->onDelete('cascade');
        });

        Schema::table('books', function (Blueprint $table) {
            $table->dropColumn('author_id');
        });

    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('books_and_authors');

        Schema::table('books', function (Blueprint $table) {
            $table->unsignedBigInteger('author_id');
            $table->foreign('author_id')->references('id')->on('authors')->onDelete('set null');
        });
    }
}
