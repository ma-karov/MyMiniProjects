<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\TimeTable;
use Illuminate\Support\Facades\Auth;

class StudentTimeTableController extends Controller
{
    public function list()
    {

        $data['getRecord'] = TimeTable::MySubjectStudentM(Auth::user()->group_name);
        $data['getRecordAll'] = TimeTable::MySubjectStudent(Auth::user()->group_name);
        $data['header_title'] = 'My Time Table List';

        return view('student.timeTable.monday', $data);
    }


    public function monday()
    {

        $data['getRecord'] = TimeTable::MySubjectStudentM(Auth::user()->group_name);
        $data['getRecordAll'] = TimeTable::MySubjectStudent(Auth::user()->group_name);
        $data['header_title'] = 'My Time Table List';

        return view('student.timeTable.monday', $data);
    }

    public function tuesday()
    {

        $data['getRecord'] = TimeTable::MySubjectStudentT(Auth::user()->group_name);
        $data['getRecordAll'] = TimeTable::MySubjectStudent(Auth::user()->group_name);
        $data['header_title'] = 'My Time Table List';

        return view('student.timeTable.tuesday', $data);
    }

    public function wednesday()
    {

        $data['getRecord'] = TimeTable::MySubjectStudentW(Auth::user()->group_name);
        $data['getRecordAll'] = TimeTable::MySubjectStudent(Auth::user()->group_name);
        $data['header_title'] = 'My Time Table List';

        return view('student.timeTable.wednesday', $data);
    }

    public function thursday()
    {

        $data['getRecord'] = TimeTable::MySubjectStudentTh(Auth::user()->group_name);
        $data['getRecordAll'] = TimeTable::MySubjectStudent(Auth::user()->group_name);
        $data['header_title'] = 'My Time Table List';

        return view('student.timeTable.thursday', $data);
    }

    public function friday()
    {

        $data['getRecord'] = TimeTable::MySubjectStudentF(Auth::user()->group_name);
        $data['getRecordAll'] = TimeTable::MySubjectStudent(Auth::user()->group_name);
        $data['header_title'] = 'My Time Table List';

        return view('student.timeTable.friday', $data);
    }

    public function saturday()
    {

        $data['getRecord'] = TimeTable::MySubjectStudentS(Auth::user()->group_name);
        $data['getRecordAll'] = TimeTable::MySubjectStudent(Auth::user()->group_name);
        $data['header_title'] = 'My Time Table List';

        return view('student.timeTable.saturday', $data);
    }
}
