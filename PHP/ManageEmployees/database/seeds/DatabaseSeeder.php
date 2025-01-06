<?php


use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

/**
 * Class DatabaseSeeder
 * @author IgorKorytin <ivkorytin@yandex.ru>
 */
class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     *
     * @return void
     */
    public function run()
    {
        $faker = new Faker\Generator();
        $faker->addProvider(new Faker\Provider\ru_RU\Person($faker));
        $faker->addProvider(new Faker\Provider\ru_RU\Address($faker));
        $faker->addProvider(new Faker\Provider\ru_RU\Company($faker));
        $this->call(CompanyTableSeeder::class);
        $this->call(DepartmentTableSeeder::class);
        $this->call(EmployeesTableSeeder::class);
        $this->command->info('Таблицы заполнены тестовыми данными!');
    }
}

/**
 * Class CompanyTableSeeder - создает три компании
 * @author IgorKorytin <ivkorytin@yandex.ru>
 */
class CompanyTableSeeder extends Seeder
{

    public function run()
    {
        $random_count = rand(10, 20);
        $faker = Faker\Factory::create('ru_RU');
        for ($i = 1; $i <= $random_count; $i++) {
            DB::table('companies')
                ->insert([
                    'name' => $faker->company,
                ]);
        }
    }

}

/**
 * Class DepartmentTableSeeder
 * @author IgorKorytin <ivkorytin@yandex.ru>
 */
class DepartmentTableSeeder extends Seeder
{

    /**
     *
     */
    public function run()
    {
        $count = DB::table('companies')->count();
        $faker = Faker\Factory::create('ru_RU');
        for ($i = 1; $i <= $count; $i++) {
            $random_count = rand(5, 15);
            $director = $faker->name;
            $address = $faker->address;
            for ($j = 1; $j < $random_count; $j++) {
                DB::table('departments')
                    ->insert([
                        'company_id' => $i,
                        'name' => $faker->company,
                        'director' => $director,
                        'address' => $address
                    ]);
            }
        }
    }

}

/**
 * Class EmployeesTableSeeder - создает для каждого подразделения от 5 до 20 сотрудников
 * @author IgorKorytin <ivkorytin@yandex.ru>
 */
class EmployeesTableSeeder extends Seeder
{

    public function run()
    {
        $departments_count = DB::table('departments')->count();
        $faker = Faker\Factory::create('ru_RU');
        for ($i = 1; $i <= $departments_count; $i++) {
            $random_count = rand(5, 20);
            for ($j = 1; $j < $random_count; $j++) {
                DB::table('employees')
                    ->insert([
                        'department_id' => $i,
                        'name' => $faker->name,
                        'role' => $j % 2 == 0 ? 'ИТР' : 'Сотрудник'
                    ]);
            }
        }
    }
}

