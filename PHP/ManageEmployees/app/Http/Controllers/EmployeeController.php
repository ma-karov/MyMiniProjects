<?php


namespace App\Http\Controllers;

use App\Models\Employee;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Collection;
use Request;

/**
 * Class EmployeeController
 * @package App\Http\Controllers
 */
class EmployeeController
{

    /**
     * Обновление сотрудника компании
     * @param Request $request
     */
    public function update(Request $request)
    {
        Employee::updateByFront((array)$request::instance());
    }

    /**
     * Найдем всех пользователей конкретного подразделения на случай,
     * если потребуется обновлять список пользователей
     * @param int $depart_id
     * @return Builder[]|Collection
     */
    public function getDepartEmployees($depart_id)
    {
        return Employee::getDepartUsers($depart_id);
    }

}
