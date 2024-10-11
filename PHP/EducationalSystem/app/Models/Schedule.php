<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Symfony\Component\HttpFoundation\Request;

class Schedule extends Model
{
    protected $fillable = ['title', 'startDate', 'endDate', 'group_id', 'room'];

    static function getSchedule()
    {
        $request = request(); // get the current request instance

        $query = self::select('schedules.*', 'groups.title as group_title')
            ->join('groups', 'groups.id', '=', 'schedules.group_id')
            ->where('schedules.is_deleted', '=', 0);

        // Name filter
        if (!empty($request->get('name'))) {
            $name = $request->get('name');
            $query = $query->where('schedules.title', 'like', '%' . $name . '%');
        }

        // start date at filter
        if (!empty($request->get('startDate'))) {
            $startDate = $request->get('startDate');
            $query = $query->whereDate('startDate', '=', $startDate);
        }

        // end date at filter
        if (!empty($request->get('endDate'))) {
            $endDate = $request->get('endDate');
            $query = $query->whereDate('endDate', '=', $endDate);
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('groups.title', 'like', '%' . $group . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('schedules.created_at', '=', $createdAt);
        }

        $query = $query->orderBy('schedules.id', 'desc')
            ->paginate(20);

        return $query;
    }

    // static public function getScheduleNew()
    // {
    //     $query = self::select('schedules.*', 'groups.title as group_title')
    //         ->join('groups', 'groups.id', '=', 'schedules.group_id')
    //         ->where('schedules.is_deleted', '=', 0)
    //         ->orderBy('schedules.id', 'desc')
    //         ->paginate(20);

    //     return $query;
    // }

    static public function  getScheduleAll()
    {
        $query = self::select('schedules.*')
            ->where('is_deleted', '=', 0)
            ->orderBy('title', 'asc')
            ->get();

        return $query;
    }

    public static function getSingle($id)
    {
        return self::select('schedules.*', 'groups.title as group_title')
            ->join('groups', 'groups.id', '=', 'schedules.group_id')
            ->where('schedules.id', $id)
            ->first();
    }
}
