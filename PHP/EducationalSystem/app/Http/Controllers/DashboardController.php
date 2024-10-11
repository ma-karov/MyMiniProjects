<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use App\Models\Schedule;
use App\Models\Group;
use App\Models\Room;
use App\Models\Course;
use App\Models\User;
use App\Models\TimeTable;

class DashboardController extends Controller
{
    public function dashboard()
    {
        $data['header_title'] = 'Dashboard';
        if (!empty(Auth::check())) {
            if (Auth::user()->usertype == 1) {

                $data['getUser'] = User::getAdmin();
                $data['getGroup'] = Group::getGroup();
                $data['getRoom'] = Room::getRoom();
                $data['getCourse'] = Course::getCourse();
                $data['getTimeTable'] = TimeTable::getTimeTable();
                $data['getSchedule'] = Schedule::getSchedule();

                return view('admin/dashboard', $data);
            }
            elseif (Auth::user()->usertype == 2) {
                return view('teacher/dashboard', $data);
            }
            elseif (Auth::user()->usertype == 3) {
                return view('student/dashboard', $data);
            }
        }
    }
}
