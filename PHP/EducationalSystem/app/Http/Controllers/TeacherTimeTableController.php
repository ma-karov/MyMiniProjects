<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\TimeTable;
use Illuminate\Support\Facades\Auth;

class TeacherTimeTableController extends Controller
{
    public function list()
    {

        $data['getRecordAll'] = TimeTable::MySubject(Auth::user()->id);
        $data['getRecord'] = TimeTable::MySubjectM(Auth::user()->id);
        $data['header_title'] = 'My Time Table List';

        return view('teacher.timeTable.list', $data);
    }

    public function monday()
    {

        $data['getRecord'] = TimeTable::MySubjectM(Auth::user()->id);
        $data['getRecordAll'] = TimeTable::MySubject(Auth::user()->id);
        $data['header_title'] = 'My Time Table List';

        return view('teacher.timeTable.monday', $data);
    }

    public function tuesday()
    {

        $data['getRecord'] = TimeTable::MySubjectT(Auth::user()->id);
        $data['getRecordAll'] = TimeTable::MySubject(Auth::user()->id);
        $data['header_title'] = 'My Time Table List';

        return view('teacher.timeTable.tuesday', $data);
    }

    public function wednesday()
    {

        $data['getRecord'] = TimeTable::MySubjectW(Auth::user()->id);
        $data['getRecordAll'] = TimeTable::MySubject(Auth::user()->id);
        $data['header_title'] = 'My Time Table List';

        return view('teacher.timeTable.wednesday', $data);
    }

    public function thursday()
    {

        $data['getRecord'] = TimeTable::MySubjectTh(Auth::user()->id);
        $data['getRecordAll'] = TimeTable::MySubject(Auth::user()->id);
        $data['header_title'] = 'My Time Table List';

        return view('teacher.timeTable.thursday', $data);
    }

    public function friday()
    {

        $data['getRecord'] = TimeTable::MySubjectF(Auth::user()->id);
        $data['getRecordAll'] = TimeTable::MySubject(Auth::user()->id);
        $data['header_title'] = 'My Time Table List';

        return view('teacher.timeTable.friday', $data);
    }

    public function saturday()
    {

        $data['getRecord'] = TimeTable::MySubjectS(Auth::user()->id);
        $data['getRecordAll'] = TimeTable::MySubject(Auth::user()->id);
        $data['header_title'] = 'My Time Table List';

        return view('teacher.timeTable.saturday', $data);
    }
}
