<?php

namespace App\Console\Commands;

class MemoryCasheDataBase_QueriesBaseCommand extends \Illuminate\Console\Command
{
    protected const MEMORY_CASHE_DATABASE_CLIENT_EXE = "..\\storage\\app\\Files\\Exe\\MemoryCasheDataBase\\MemoryCasheDataBase_Client.exe";
    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'MemoryCasheDataBase_QueriesBaseCommand ';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = '';

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
     * @return mixed
     */
    public function handle() {}
}
