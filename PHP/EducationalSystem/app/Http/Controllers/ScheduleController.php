<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Schedule;
use App\Models\Group;
use App\Models\Room;
use App\Models\Course;
use App\Models\User;

class ScheduleController extends Controller
{
    public function list(Request $request)
    {

        $data['getRecord'] = Schedule::getSchedule();
        $data['header_title'] = 'Schedule List';
        return view('admin.schedule.list', $data);
    }

    public function add()
    {
        $data['header_title'] = 'Add new Schedule';
        $data['getGroupAll'] = Group::getGroupAll();
        // $data['getRoom'] = Room::getRoom();
        // $data['getCourse'] = Course::getCourse();
        // $data['getTeacher'] = User::getTeacher();


        return view('admin.schedule.add', $data);
    }

    public function insert(Request $request)
    {

        $schedule = new Schedule;

        $schedule->title = trim($request->title);
        $schedule->startDate = trim($request->startDate);
        $schedule->endDate = trim($request->endDate);
        $schedule->group_id = trim($request->group_id);


        $schedule->save();

        return redirect('admin/schedule/list')->with('success', 'Admin successfully created');
    }

    public function edit($id)
    {
        $data['getSchedule'] = Schedule::getSingle($id);
        if (!empty($data['getSchedule'])) {
            $data['header_title'] = 'Edit Admin';
            $data['getGroupAll'] = Group::getGroupAll();
            // $data['getRoom'] = Room::getRoom();
            // $data['getCourse'] = Course::getCourse();
            // $data['getTeacher'] = User::getTeacher();

            return view('admin.schedule.edit', $data);
        } else {
            abort(404);
        }
    }

    public function update($id, Request $request)
    {

        $schedule = Schedule::getSingle($id);
        $schedule->title = trim($request->title);
        $schedule->startDate = trim($request->startDate);
        $schedule->endDate = trim($request->endDate);
        $schedule->group_id = trim($request->group_id);


        $schedule->save();

        return redirect('admin/schedule/list')->with('success', 'Admin successfully Updated');
    }

    public function delete($id)
    {
        $schedule = Schedule::getSingle($id);
        $schedule->is_deleted = 1;

        $schedule->save();

        return redirect('admin/schedule/list')->with('success', 'Admin successfully deleted');
    }
}
