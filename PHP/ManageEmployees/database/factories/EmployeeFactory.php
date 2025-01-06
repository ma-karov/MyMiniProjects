<?php
/** @var Factory $factory */

use App\Models\Employee;
use Faker\Generator as Faker;
use Illuminate\Database\Eloquent\Factory;

$factory->define(Employee::class, function (Faker $faker) {
    $roles = ['ИТР', 'Сотрудник'];
    return [
        'department_id' => 1,
        'name' => $faker->name,
        'role' => array_rand($roles, 1)
    ];
});
