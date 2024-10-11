<?php

namespace App\Console\Commands;

class MemoryCasheDataBase_QueryGetCommand extends MemoryCasheDataBase_QueriesBaseCommand
{
    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'MemoryCasheDataBase:GetValue {Key}';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = 'Получить запись из базы данных MemoryCasheDataBase';

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
    public function handle()
    {
        define("COMMAND_GET_VALUE_OUTPUT", exec(self::MEMORY_CASHE_DATABASE_CLIENT_EXE." \"Get\" \"".$this->argument("Key")."\"  ") );
        $this->line(COMMAND_GET_VALUE_OUTPUT);
    }
}
