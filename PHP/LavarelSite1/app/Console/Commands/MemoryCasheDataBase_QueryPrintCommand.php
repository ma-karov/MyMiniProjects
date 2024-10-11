<?php

namespace App\Console\Commands;

class MemoryCasheDataBase_QueryPrintCommand extends MemoryCasheDataBase_QueriesBaseCommand
{
    protected $signature = 'MemoryCasheDataBase:PrintValues',
              $description = 'Получить все записи из базы данных MemoryCasheDataBase';

    public function __construct()
    {
        parent::__construct();
    }

    public function handle(): void
    {
        define("COMMAND_PRINT_VALUES_OUTPUT", shell_exec(self::MEMORY_CASHE_DATABASE_CLIENT_EXE." \"Print\" "));
        $this->line(COMMAND_PRINT_VALUES_OUTPUT);
    }
}
