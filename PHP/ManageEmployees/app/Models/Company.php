<?php

namespace App\Models;

use App;
use Eloquent;
use Exception;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;

/**
 * Class Company
 *
 * @package App\Models
 * @property int $id
 * @property string $name
 * @method static Builder|Company newModelQuery()
 * @method static Builder|Company newQuery()
 * @method static Builder|Company query()
 * @method static Builder|Company whereId($value)
 * @method static Builder|Company whereName($value)
 * @mixin Eloquent
 */
class Company extends Model
{
    /**
     * @var bool
     */
    public $timestamps = false;

    /**
     * Собираем информацию для просмотра компании.
     * Возвращаем инфу по компании, каждое подразделение (вместе с пользователями), общее количество пользователей и количество подразделеений
     * @param $id
     * @return array|integer
     */
    public static function GetFullData($id)
    {
        $company = self::FindOrFail($id);
        if ($company) {
            $data [] = [
                'company' => $company,
                'departs_count' => Department::getCompaniesDepartCount($id),
                'users_count' => Company::getAllUsersCount($id),
                'departments' => Department::getAllByCompany($id)
            ];
            return $data;
        } else {
            return 404;
        }
    }

    /**
     * Считаем общее количество сотрудников компании по всем подразделениям
     * @param $company_id
     * @return Builder|int
     */
    public static function getAllUsersCount($company_id)
    {
        $departs = Department::getAllByCompany($company_id);
        $count = 0;
        if ($departs) {
            foreach ($departs as $key => $depart) {
                $department = (array)$depart['depart'];
                $count += Employee::getDepartCount($department['id']);
            }
        }
        return $count;
    }

    /**
     * Находим информацию о всех компаний для отображения общего списка.
     * Дополнительно показываем количество сотрудников (общее) и количество подразделений
     * @return array
     */
    public static function allWithCounts()
    {
        $companies = self::all();
        if ($companies) {
            foreach ($companies as $company) {
                $data [] = [
                    'company' => $company,
                    'departs_count' => Department::getCompaniesDepartCount($company->id),
                    'users_count' => Company::getAllUsersCount($company->id)
                ];
            }
        }
        return $data;

    }

    /**
     * Удаляем компанию
     * @param $id
     * @return bool
     * @throws Exception
     */
    public static function deleteCompany($id)
    {
        $company = App\Models\Company::find($id);
        if ($company->delete()) {
            return true;
        } else {
            return false;
        }
    }

}
