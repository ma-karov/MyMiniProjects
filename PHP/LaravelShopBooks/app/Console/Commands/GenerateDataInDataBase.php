<?php

namespace App\Console\Commands;

use Illuminate\Console\Command;

class GenerateDataInDataBase extends Command
{
    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'GenerateData:InDataBase';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = 'Command generate array data in database';

    /**
     * Create a new command instance.
     *
     * @return void
     */
    public function __construct()
    {
        parent::__construct();
    }

    /**
     * Execute the console command.
     *
     * @return void
     */
    public function handle(): void
    {
        \App\Models\Book::insert( (new \App\Http\CustomFiles\Mocks\BooksMock())->getBooks() );
        \App\Models\Author::insert( (new \App\Http\CustomFiles\Mocks\AuthorsMock())->getAuthors() );
        \App\Models\Genre::insert( (new \App\Http\CustomFiles\Mocks\GenresMock())->getGenres() );
        \App\Models\Sell::insert( (new \App\Http\CustomFiles\Mocks\SellsMock())->getSells() );

        \App\Models\BookAndAuthor::insert( (new \App\Http\CustomFiles\Mocks\BooksAndAuthorsMock())->getBooksAndAuthors() );
        \App\Models\BookAndGenre::insert( (new \App\Http\CustomFiles\Mocks\BooksAndGenresMock())->getBooksAndGenres() );

        $this->info("Command complete");
    }
}
