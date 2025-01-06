<?php

namespace App\Models;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\Model;

/**
 * Class Employee
 *
 * @package App\Models
 * @property int $id
 * @property int $department_id
 * @property string $name
 * @property string $role
 * @method static Builder|Employee newModelQuery()
 * @method static Builder|Employee newQuery()
 * @method static Builder|Employee query()
 * @method static Builder|Employee whereDepartmentId($value)
 * @method static Builder|Employee whereId($value)
 * @method static Builder|Employee whereName($value)
 * @method static Builder|Employee whereRole($value)
 * @mixin Eloquent
 */
class Employee extends Model
{
//
    /**
     * @var bool
     */
    public $timestamps = false;

    /**
     * Экшен для обновления, проверяем, что компания существует, если возвращается true, обновляем сотрудника.
     * Возвращаем всю информацию по пользователям, чтобы обновить данные во фронте
     * @param array $data
     * @return int|Collection
     */
    public static function updateByFront(array $data)
    {
        $user = self::FindOrFail($data['id']);
        if ($user) {
            Employee::find($data['id'])->update($data);
            return self::getDepartUsers($data['department_id']);
        } else {
            return 404;
        }
    }

    /**
     * Находим всех пользователей, принадлежащие подразделению
     * @param $depart_id
     * @return Builder[]|Collection
     */
    public static function getDepartUsers($depart_id)
    {
        return self::where(array('department_id' => $depart_id))->orderBy('name', 'asc')->get();
    }

    /**
     * Находим количество пользователей конкретного подраздедления
     * @param $depart_id
     * @return int
     */
    public static function getDepartCount($depart_id)
    {
        return self::where(array('department_id' => $depart_id))->count();
    }
}
