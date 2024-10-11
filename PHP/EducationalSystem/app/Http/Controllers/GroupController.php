<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Group;

class GroupController extends Controller
{
    public function list()
    {

        $data['getGroup'] = Group::getGroup();
        $data['header_title'] = 'Group List';
        return view('admin.group.list', $data);
    }

    public function add()
    {
        $data['header_title'] = 'Add new Group';
        return view('admin.group.add', $data);
    }

    public function insert(Request $request)
    {

        $group = new Group;
        $group->title = trim($request->group);


        $group->save();

        return redirect('admin/group/list')->with('success', 'Admin successfully created');
    }

    public function edit($id)
    {
        $data['getGroup'] = Group::getSingle($id);
        if (!empty($data['getGroup'])) {
            $data['header_title'] = 'Edit Group';
            return view('admin.group.edit', $data);
        } else {
            abort(404);
        }
    }

    public function update($id, Request $request)
    {

        $group = Group::getSingle($id);
        $group->title = trim($request->group);

        $group->save();

        return redirect('admin/group/list')->with('success', 'Admin successfully Updated');
    }

    public function delete($id)
    {
        $group = Group::getSingle($id);
        $group->is_deleted = 1;

        $group->save();

        return redirect('admin/group/list')->with('success', 'Admin successfully deleted');
    }
}
