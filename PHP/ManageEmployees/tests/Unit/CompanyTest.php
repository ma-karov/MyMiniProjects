<?php

namespace Tests\Unit;

use PHPUnit\Framework\TestCase;

class CompanyTest extends TestCase
{

    /**
     * Проверяем, что верна структура ответа для индекса
     * @return void
     */
    public function testIndex()
    {
        $this->get('/company')
            ->seeJsonStructure([
                'company' => [
                    'id',
                    'name'
                ],
                'departs_count',
                'users_count'
            ])
            ->assertResponseOk()
            ->assertResponseStatus(200);
    }

    /**
     * Проверяем, что верна структура ответа для
     * @return void
     */
    public function testShow()
    {
        $this->get('/company/1')
            ->seeJsonStructure([
                'company' => [
                    'id',
                    'name'
                ],
                'departs_count',
                'users_count',
                'departments' => [
                    'depart' => ['id', 'company_id', 'name', 'director', 'address'],
                    'users' => ['id', 'department_id', 'name', 'role']
                ]
            ])
            ->assertResponseOk()
            ->assertResponseStatus(200);
    }
}
