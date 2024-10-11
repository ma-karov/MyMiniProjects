<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Schedule;
use App\Models\Group;
use App\Models\Room;
use App\Models\Course;
use App\Models\User;
use App\Models\TimeTable;

class TimeTableController extends Controller
{
    public function list()
    {

        $data['getRecord'] = TimeTable::getTimeTable();
        $data['header_title'] = 'Time Table List';

        return view('admin.timeTable.list', $data);
    }

    public function add()
    {
        $data['header_title'] = 'Add new Time Table';
        $data['getGroup'] = Group::getGroupAll();
        $data['getRoom'] = Room::getRoomAll();
        $data['getCourse'] = Course::getCourseAll();
        $data['getTeacher'] = User::getTeacher();
        $data['getSchedule'] = Schedule::getScheduleAll();


        return view('admin.timeTable.add', $data);
    }

    public function insert(Request $request)
    {

        $timeTable = new TimeTable;
        $timeTable->schedule_id = trim($request->schedule_id);
        $timeTable->teacher_id = trim($request->teacher_id);
        $timeTable->course_title = trim($request->course_title);
        $timeTable->startTime = trim($request->startTime);
        $timeTable->endTime = trim($request->endTime);
        $timeTable->group = trim($request->group);
        $timeTable->room = trim($request->room);
        $timeTable->day = trim($request->day);

        $timeTable->save();

        return redirect('admin/timeTable/list')->with('success', 'Admin successfully created');
    }

    public function edit($id)
    {
        $data['getTimeTable'] = TimeTable::getSingle($id);
        if (!empty($data['getTimeTable'])) {
            $data['header_title'] = 'Edit Admin';
            $data['getGroup'] = Group::getGroupAll();
            $data['getRoom'] = Room::getRoomAll();
            $data['getCourse'] = Course::getCourseAll();
            $data['getTeacher'] = User::getTeacher();
            $data['getSchedule'] = Schedule::getScheduleAll();

            return view('admin.timeTable.edit', $data);
        } else {
            abort(404);
        }
    }

    public function update($id, Request $request)
    {

        $timeTable = TimeTable::getSingle($id);
        $timeTable->schedule_id = trim($request->schedule_title);
        $timeTable->teacher_id = trim($request->teacher_id);
        $timeTable->course_title = trim($request->course_title);
        $timeTable->startTime = trim($request->startTime);
        $timeTable->endTime = trim($request->endTime);
        $timeTable->group = trim($request->group);
        $timeTable->room = trim($request->room);
        $timeTable->day = trim($request->day);


        $timeTable->save();

        return redirect('admin/timeTable/list')->with('success', 'Admin successfully Updated');
    }

    public function delete($id)
    {
        $timeTable = TimeTable::getSingle($id);
        $timeTable->is_deleted = 1;

        $timeTable->save();

        return redirect('admin/timeTable/list')->with('success', 'Admin successfully deleted');
    }
}
