<?php

namespace Tests;

//use Artisan;
use Illuminate\Foundation\Testing\DatabaseMigrations;
use Illuminate\Support\Facades\Artisan;
use Laravel\BrowserKitTesting\TestCase as BaseTestCase;

//use Illuminate\Foundation\Testing\DatabaseMigrations;
//use Illuminate\Foundation\Testing\TestCase as BaseTestCase;

abstract class TestCase extends BaseTestCase
{
    use CreatesApplication, DatabaseMigrations;

    public $baseUrl = 'http://localhost';

    public function setUp(): void
    {
        parent::setUp();
        Artisan::call('db:seed');
    }
}
