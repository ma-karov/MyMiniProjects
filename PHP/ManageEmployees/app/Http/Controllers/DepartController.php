<?php


namespace App\Http\Controllers;

use App\Models\Company;
use App\Models\Department;
use Illuminate\Http\JsonResponse;
use Request;

/**
 * Class DepartController
 * @package App\Http\Controllers
 */
class DepartController
{

    /**
     * Экшен специально для поиска по наименованию в лайтбоксе создания нового подразделения.
     * Передаем id компании и введенное название, получаем результат
     * @param Request $request
     * @return JsonResponse
     */
    public function searchByName(Request $request)
    {
        $data = Department::searchByName((array)$request::instance());
        return response()->json(Department::create($data));
    }

    /**
     * Создаем подразделение, после создания вернем обновленную инфу по компании,
     * чтобы можно было реактивно обновить данные на вкладке
     * @param Request $request
     * @return JsonResponse
     */
    public function create(Request $request)
    {
        Department::create((array)$request::instance());
        return response()->json(Company::GetFullData($request::input('company_id')));
    }
}
