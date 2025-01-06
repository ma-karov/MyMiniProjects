<?php

namespace Tests\Feature;

use Tests\TestCase;

class CompanyControllerTest extends TestCase
{
    /**
     * A basic feature test example.
     *
     * @return void
     */
    public function testIndex()
    {
        $response = $this->call('GET', '/api/company');

        $this->assertEquals(200, $response->status());
        $response->content();
    }
}
