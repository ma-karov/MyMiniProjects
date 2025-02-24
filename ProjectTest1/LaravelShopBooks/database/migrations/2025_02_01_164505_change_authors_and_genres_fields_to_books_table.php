<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class ChangeAuthorsAndGenresFieldsToBooksTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::table('books', function (Blueprint $table) {
            $table->dropColumn(
                array( 'authors', 'genres' )
            );

            $table->unsignedBigInteger('author_id');
            $table->foreign('author_id')->references('id')->on('authors')->onDelete('set null');

            $table->unsignedBigInteger('genre_id');
            $table->foreign('genre_id')->references('id')->on('genres')->onDelete('set null');
        });

        Schema::table('sells', function (Blueprint $table) {
            $table->dateTime('date')->change();

        });

    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::table('books', function (Blueprint $table) {
            $table->dropColumn(
                array( 'author_id', 'genre_id' )
            );

            $table->text('authors');
            $table->text('genres');
        });

        Schema::table('sells', function (Blueprint $table) {
            $table->date('date')->change();

        });
    }
}
