<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Course;

class CourseController extends Controller
{
    public function list()
    {

        $data['getCourse'] = Course::getCourse();
        $data['header_title'] = 'Course List';
        return view('admin.course.list', $data);
    }

    public function add()
    {
        $data['header_title'] = 'Add new Course';
        return view('admin.course.add', $data);
    }

    public function insert(Request $request)
    {

        $course = new Course;
        $course->title = trim($request->course);


        $course->save();

        return redirect('admin/course/list')->with('success', 'Admin successfully created');
    }

    public function edit($id)
    {
        $data['getCourse'] = Course::getSingle($id);
        if (!empty($data['getCourse'])) {
            $data['header_title'] = 'Edit Course';
            return view('admin.course.edit', $data);
        } else {
            abort(404);
        }
    }

    public function update($id, Request $request)
    {

        $course = Course::getSingle($id);
        $course->title = trim($request->course);

        $course->save();

        return redirect('admin/course/list')->with('success', 'Admin successfully Updated');
    }

    public function delete($id)
    {
        $course = Course::getSingle($id);
        $course->is_deleted = 1;

        $course->save();

        return redirect('admin/course/list')->with('success', 'Admin successfully deleted');
    }
}
