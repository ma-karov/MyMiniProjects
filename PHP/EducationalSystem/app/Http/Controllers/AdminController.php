<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\User;
use App\Models\Group;
use Illuminate\Support\Facades\Hash;

class AdminController extends Controller
{
    public function list()
    {

        $data['getRecord'] = User::getAdmin();
        $data['header_title'] = 'Admin List';
        return view('admin.admin.list', $data);
    }

    public function add()
    {
        $data['header_title'] = 'Add new Admin';
        $data['getGroupAll'] = Group::getGroupAll();
        return view('admin.admin.add', $data);
    }

    public function insert(Request $request)
    {

        $user = new User;
        $user->name = trim($request->name);
        $user->email = trim($request->email);
        $user->group_name = trim($request->group_name);
        $user->password = Hash::make($request->password);
        $user->usertype = trim($request->usertype);

        $user->save();

        return redirect('admin/admin/list')->with('success', 'Admin successfully created');
    }

    public function edit($id)
    {
        $data['getRecord'] = User::getSingle($id);
        if (!empty($data['getRecord'])) {
            $data['header_title'] = 'Edit Admin';
            $data['getGroupAll'] = Group::getGroupAll();
            return view('admin.admin.edit', $data);
        } else {
            abort(404);
        }
    }

    public function update($id, Request $request)
    {

        $user = User::getSingle($id);
        $user->name = trim($request->name);
        $user->email = trim($request->email);
        $user->group_name = trim($request->group_name);
        if (!empty($request->password)) {
            $user->password = Hash::make($request->password);
        }
        $user->usertype = trim($request->usertype);

        $user->save();

        return redirect('admin/admin/list')->with('success', 'Admin successfully Updated');
    }

    public function delete($id)
    {
        $user = User::getSingle($id);
        $user->is_deleted = 1;

        $user->save();

        return redirect('admin/admin/list')->with('success', 'Admin successfully deleted');
    }
}
