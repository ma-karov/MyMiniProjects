<?php

namespace App\Models;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\Model;

/**
 * Class Department
 *
 * @package App\Models
 * @property int $id
 * @property int $company_id
 * @property string $name
 * @property string $director
 * @property string $address
 * @method static Builder|Department newModelQuery()
 * @method static Builder|Department newQuery()
 * @method static Builder|Department query()
 * @method static Builder|Department whereAddress($value)
 * @method static Builder|Department whereCompanyId($value)
 * @method static Builder|Department whereDirector($value)
 * @method static Builder|Department whereName($value)
 * @method static Builder|Department whereId($value)
 * @mixin Eloquent
 */
class Department extends Model
{

    /**
     * @var bool
     */
    public $timestamps = false;

    /**
     * Атрибуты, для которых разрешено массовое назначение.
     *
     * @var array $fillable
     */
    protected $fillable = ['company_id', 'name', 'director', 'address'];

    /**
     * Возращаем массив подразделений, к каждому подразделению добавляем информацию о его пользователе
     * @param integer $company_id
     * @return array
     */
    public static function getAllByCompany($company_id)
    {
        $data = [];
        $departs = Department::where(array('company_id' => $company_id))->get()->toArray();
        if ($departs) {
            foreach ($departs as $value => $depart) {
                $data [] = [
                    'depart' => $depart,
                    'users' => Employee::getDepartUsers($depart['id']),
                    'users_count' => Employee::getDepartCount($depart['id'])
                ];
            }
        }
        return $data;
    }

    /**
     * Возвращаем количество подразделений для компании
     * @param $company_id
     * @return int
     */
    public static function getCompaniesDepartCount($company_id)
    {
        return self::where(array('company_id' => $company_id))->count();
    }

    /**
     * Поиск подразделения по названию (частичное сопоставление) и id компании
     * @param array $array
     * @return Collection
     */
    public static function searchByName($array)
    {
        return self::where('name', 'like', $array['name'])->
        where(array('company_id' => $array['company_id']))->get();
    }
}
