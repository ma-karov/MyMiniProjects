<?php


namespace App\Http\Controllers;

use App\Models\Company;
use Exception;
use Illuminate\Contracts\Routing\ResponseFactory;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Response;

/**
 * Class CompanyController - отвечает за все запросы касающиеся сущности компания
 */
class CompanyController
{


    /**
     * Список компаний для отрисовки главной страницы, помимо данных из таблиц, отобраэаем количество подразделений и сотрудников (общее)
     * @return JsonResponse
     */
    public function index()
    {
        $data = Company::allWithCounts();
        return response()->json($data);
    }

    /**
     * Просмотр компании, возвращаем сразу вместе с компанией всех ее пользователей
     * @param $company_id integer
     * @return JsonResponse
     */
    public function show($company_id)
    {
        return response()->json(Company::GetFullData($company_id));
    }

    /**
     * Удаляем компанию вместе со всеми подразделениями и пользователями.
     * Если удалось удалить компанию, то вернем полный список, чтобы обновить данные
     * @param $id
     * @return ResponseFactory|Response
     * @throws Exception
     */
    public function delete($id)
    {
        $deleted = Company::deleteCompany($id);
        if ($deleted) {
            $data = Company::allWithCounts();
            return response($data, 204);
        } else {
            return response('Что-то пошло не так', 500);
        }
    }
}
