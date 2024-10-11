<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use App\Models\Schedule;

class TimeTable extends Model
{
    protected $fillable = ['teacher_name', 'title', 'startTime', 'endTime', 'group', 'room'];

    static function getTimeTable()
    {

        $request = request(); // get the current request instance

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('time_tables.is_deleted', '=', 0);

        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedules.title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('users.name', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('time_tables.created_at', '=', $createdAt);
        }

        $query = $query->orderBy('time_tables.id', 'desc')
            ->paginate(20);

        return $query;
    }

    static function getSingle($id)
    {
        // return self::find($id);

        return self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('time_tables.id', $id)
            ->first();
    }

    static function MySubject($name)
    {
        $request = request();

        $query = self::select('time_tables.*')
            ->where('teacher_id', '=', $name)
            ->where('is_deleted', '=', 0);
        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedule_title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('teacher_id', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('created_at', '=', $createdAt);
        }
        $query = $query->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    // get Teacher Time Table
    static function MySubjectM($name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->where('teacher_id', '=', $name)
            ->where('day', '=', 'Monday')
            ->where('time_tables.is_deleted', '=', 0);
        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedule_title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('teacher_id', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('time_tables.created_at', '=', $createdAt);
        }
        $query = $query->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectT($name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->where('teacher_id', '=', $name)
            ->where('day', '=', 'Tuesday')
            ->where('time_tables.is_deleted', '=', 0);
        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedule_title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('teacher_id', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('time_tables.created_at', '=', $createdAt);
        }
        $query = $query->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectW($name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->where('teacher_id', '=', $name)
            ->where('day', '=', 'Wednesday')
            ->where('time_tables.is_deleted', '=', 0);
        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedule_title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('teacher_id', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('time_tables.created_at', '=', $createdAt);
        }
        $query = $query->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectTh($name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->where('teacher_id', '=', $name)
            ->where('day', '=', 'Thursday')
            ->where('time_tables.is_deleted', '=', 0);
        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedule_title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('teacher_id', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('time_tables.created_at', '=', $createdAt);
        }
        $query = $query->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectF($name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->where('teacher_id', '=', $name)
            ->where('day', '=', 'Friday')
            ->where('time_tables.is_deleted', '=', 0);
        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedule_title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('teacher_id', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('time_tables.created_at', '=', $createdAt);
        }
        $query = $query->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectS($name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->where('teacher_id', '=', $name)
            ->where('day', '=', 'Saturday')
            ->where('time_tables.is_deleted', '=', 0);
        // Name filter
        if (!empty($request->get('schedule_title'))) {
            $schedule_title = $request->get('schedule_title');
            $query = $query->where('schedule_title', 'like', '%' . $schedule_title . '%');
        }

        // teacher filter
        if (!empty($request->get('teacher_name'))) {
            $teacher_name = $request->get('teacher_name');
            $query = $query->where('teacher_id', 'like', '%' . $teacher_name . '%');
        }

        // course_title filter
        if (!empty($request->get('course_title'))) {
            $course_title = $request->get('course_title');
            $query = $query->where('course_title', 'like', '%' . $course_title . '%');
        }

        // start time at filter
        if (!empty($request->get('startTime'))) {
            $startTime = $request->get('startTime');
            $query = $query->where('startTime', 'like', '%' . $startTime . '%');
        }

        // end date at filter
        if (!empty($request->get('endTime'))) {
            $endTime = $request->get('endTime');
            $query = $query->where('endTime', 'like', '%' . $endTime . '%');
        }

        // group filter
        if (!empty($request->get('group'))) {
            $group = $request->get('group');
            $query = $query->where('group', 'like', '%' . $group . '%');
        }

        // room filter
        if (!empty($request->get('room'))) {
            $room = $request->get('room');
            $query = $query->where('room', 'like', '%' . $room . '%');
        }

        // day filter
        if (!empty($request->get('day'))) {
            $day = $request->get('day');
            $query = $query->where('day', 'like', '%' . $day . '%');
        }

        // Created at filter
        if (!empty($request->get('date'))) {
            $createdAt = $request->get('date');
            $query = $query->whereDate('time_tables.created_at', '=', $createdAt);
        }
        $query = $query->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    // get student Time Table

    static function MySubjectStudent($group_name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('group', '=', $group_name)
            ->where('time_tables.is_deleted', '=', 0)
            ->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectStudentM($group_name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('group', '=', $group_name)
            ->where('day', '=', 'Monday')
            ->where('time_tables.is_deleted', '=', 0)
            ->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectStudentT($group_name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('group', '=', $group_name)
            ->where('day', '=', 'Tuesday')
            ->where('time_tables.is_deleted', '=', 0)
            ->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectStudentW($group_name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('group', '=', $group_name)
            ->where('day', '=', 'Wednesday')
            ->where('time_tables.is_deleted', '=', 0)
            ->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectStudentTh($group_name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('group', '=', $group_name)
            ->where('day', '=', 'Thursday')
            ->where('time_tables.is_deleted', '=', 0)
            ->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectStudentF($group_name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('group', '=', $group_name)
            ->where('day', '=', 'Friday')
            ->where('time_tables.is_deleted', '=', 0)
            ->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }

    static function MySubjectStudentS($group_name)
    {
        $request = request();

        $query = self::select('time_tables.*', 'schedules.title as schedule_title', 'users.name as teacher_name')
            ->join('schedules', 'schedules.id', '=', 'time_tables.schedule_id')
            ->join('users', 'users.id', '=', 'time_tables.teacher_id')
            ->where('group', '=', $group_name)
            ->where('day', '=', 'Saturday')
            ->where('time_tables.is_deleted', '=', 0)
            ->orderBy('startTime', 'asc')
            ->get();
        return $query;
    }
}
