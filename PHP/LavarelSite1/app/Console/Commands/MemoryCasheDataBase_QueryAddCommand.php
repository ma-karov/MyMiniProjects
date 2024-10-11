<?php

namespace App\Console\Commands;


class MemoryCasheDataBase_QueryAddCommand extends MemoryCasheDataBase_QueriesBaseCommand
{

    /**
     * The name and signature of the console command.
     *
     * @var string
     */
    protected $signature = 'MemoryCasheDataBase:AddValue {Key} {Value}';

    /**
     * The console command description.
     *
     * @var string
     */
    protected $description = 'Добавить запись в базу данных MemoryCasheDataBase';

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
    public function handle(): void
    {
        //\Artisan::call shell_exec

        // С консоли запускать
        //$this->line("LavarelSite1\\storage\\app\\Files\\Exe\\MemoryCasheDataBase\\MemoryCasheDataBase_Client.exe \"Add\" \"".addslashes($this->argument("Key"))."\" \"".addslashes($this->argument("Value"))."\" " );

        //define("COMMAND_ADD_VALUE_OUTPUT", exec(self::MEMORY_CASHE_DATABASE_CLIENT_EXE." \"Add\" \"".addslashes($this->argument("Key"))."\" \"".addslashes($this->argument("Value"))."\" ") );
        define("COMMAND_ADD_VALUE_OUTPUT", self::MEMORY_CASHE_DATABASE_CLIENT_EXE." \"Add\" \"".addslashes($this->argument("Key"))."\" \"".addslashes($this->argument("Value"))."\" ");

        $this->line(COMMAND_ADD_VALUE_OUTPUT);

    }
}
